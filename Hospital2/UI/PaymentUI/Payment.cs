using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using HospitalPRAC.BusinessLogic.Controller;
using HospitalPRAC.Model;

// PAALALA: dapat TUMUGMA ang namespace at class name sa Payment.Designer.cs
namespace HospitalPRAC
{
    public partial class Payment : Form
    {
        private readonly BillingController _controller = new BillingController();

        private readonly int patientId;
        private BillSummary _bill = new BillSummary();   // ang kasalukuyang bill (kasama ang mga dating room)
        private bool busy = false;                       // iwas double-click sa Pay button

        private readonly Dictionary<string, string> info = new Dictionary<string, string>();

        private DataGridView grid = null!;
        private Button? btnPayControl;
        private Font balanceFont = null!;

        // Mga detalye ng pinakahuling bayad (para sa receipt)
        private decimal lastPaidNow = 0m;
        private DateTime lastPaidTime = DateTime.MinValue;

        // Para sa pag-print ng receipt
        private List<ReceiptLine> receiptLines = new List<ReceiptLine>();
        private int printIndex = 0;

        private sealed class ReceiptLine
        {
            public string Left = "";
            public string Right = "";
            public bool Bold;
            public bool Center;
            public bool Rule;       // linya lang
        }

        // Kinukuha sa bill ang mga ito
        private int admissionId => _bill.AdmissionId;
        private decimal totalBill => _bill.TotalBill;
        private decimal paid => _bill.Paid;

        // Para hindi mag-error ang Designer
        public Payment() : this(-1)
        {
        }

        public Payment(int patientId)
        {
            InitializeComponent();
            this.patientId = patientId;
        }

        // ---------------------------------------------------------
        // 1. PAG-OPEN NG FORM
        // ---------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;

            grid = FindOrCreateGrid();
            SetupGrid();
            WireButtons();

            if (patientId < 0)
            {
                MessageBox.Show("Walang napiling patient. Buksan ito mula sa Billing form (Payment button).",
                    "Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (btnPayControl != null) btnPayControl.Enabled = false;
                return;
            }

            Reload();
        }

        private void Reload()
        {
            if (!LoadAll()) return;
            ShowInfo();
            BindGrid();
            if (btnPayControl != null)
                btnPayControl.Enabled = admissionId >= 0;
        }

        // ---------------------------------------------------------
        // 2. PAGHANAP NG CONTROLS (para gumana kahit anong pangalan sa Designer)
        // ---------------------------------------------------------
        private static IEnumerable<Control> AllControls(Control root)
        {
            foreach (Control c in root.Controls)
            {
                yield return c;
                foreach (Control child in AllControls(c))
                    yield return child;
            }
        }

        private T? FindByName<T>(params string[] names) where T : Control
        {
            foreach (string n in names)
            {
                Control[] found = Controls.Find(n, true);
                foreach (Control c in found)
                {
                    if (c is T typed) return typed;
                }
            }
            return null;
        }

        private DataGridView FindOrCreateGrid()
        {
            DataGridView? g = FindByName<DataGridView>("dgvBreakdown", "dgvPayment", "dgvBills", "dgvPaymentBreakdown");
            if (g != null) return g;

            foreach (Control c in AllControls(this))
            {
                if (c is DataGridView found) return found;
            }

            // Walang grid sa Designer: gumawa sa lugar ng kulay-abong kahon
            g = new DataGridView();
            g.Name = "dgvBreakdown";
            g.Location = new Point(28, 163);
            g.Size = new Size(1301, 196);
            g.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Controls.Add(g);
            g.BringToFront();
            return g;
        }

        private void SetupGrid()
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.BackgroundColor = Color.White;

            balanceFont = new Font(grid.Font, FontStyle.Bold);

            grid.CellFormatting -= Grid_CellFormatting;
            grid.CellFormatting += Grid_CellFormatting;
        }

        private void WireButtons()
        {
            // Back button
            Button? back = FindByName<Button>("btnBack", "btnBackPayment");
            if (back == null)
                foreach (Control c in AllControls(this))
                {
                    if (c is Button b && b.Text.Trim().Equals("Back", StringComparison.OrdinalIgnoreCase))
                    { back = b; break; }
                }
            if (back != null)
            {
                back.Click -= BtnBack_Click;
                back.Click += BtnBack_Click;
            }

            // Pay/Print Receipt button
            btnPayControl = FindByName<Button>("btnPay", "btnPayPrint", "btnPrint", "btnPayReceipt", "btnPayPrintReceipt");
            if (btnPayControl == null)
                foreach (Control c in AllControls(this))
                {
                    if (c is Button b && b != back && b.Text.IndexOf("Pay", StringComparison.OrdinalIgnoreCase) >= 0)
                    { btnPayControl = b; break; }
                }
            if (btnPayControl != null)
            {
                btnPayControl.Click -= BtnPay_Click;
                btnPayControl.Click += BtnPay_Click;
            }
        }

        // Ilalagay ang value sa label sa tabi ng caption (hal. "Last Name:")
        private void SetField(string value, string caption, params string[] names)
        {
            Label? target = FindByName<Label>(names);

            if (target == null)
            {
                Label? cap = null;
                foreach (Control c in AllControls(this))
                {
                    if (c is Label l && l.Text.Trim().Equals(caption, StringComparison.OrdinalIgnoreCase))
                    { cap = l; break; }
                }

                if (cap != null && cap.Parent != null)
                {
                    int bestLeft = int.MaxValue;
                    foreach (Control c in cap.Parent.Controls)
                    {
                        if (c is not Label l || l == cap) continue;
                        if (l.Text.Trim().EndsWith(":")) continue;           // caption ito, hindi value
                        if (Math.Abs(l.Top - cap.Top) > 12) continue;       // dapat nasa parehong row
                        if (l.Left <= cap.Left) continue;                   // dapat nasa kanan
                        if (l.Left < bestLeft) { bestLeft = l.Left; target = l; }
                    }
                }
            }

            if (target != null) target.Text = value;
        }

        private void ShowInfo()
        {
            SetField(Get("LastName"), "Last Name:", "lblLastName");
            SetField(Get("FirstName"), "First Name:", "lblFirstName");
            SetField(Get("MI"), "M.I.:", "lblMI");
            SetField(Get("Birthdate"), "Birthdate:", "lblBirthdate");
            SetField(Get("Age"), "Age:", "lblAge");
            SetField(Get("Sex"), "Sex:", "lblSex");
            SetField(Get("Address"), "Address:", "lblAddress");
            SetField(Get("Contact"), "Contact number:", "lblContact", "lblContactNumber");

            SetField(Get("Room"), "Room No.:", "lblRoomNo");
            SetField(Get("Bed"), "Bed No.:", "lblBedNo");

            SetField(Get("AdmissionId"), "Admission ID:", "lblAdmissionId");
            SetField(Get("AdmissionDate"), "Admission date:", "lblAdmissionDate");
            SetField(Get("Doctor"), "Attending Doctor:", "lblDoctor");
            SetField(Get("AdmissionType"), "Admission Type:", "lblAdmissionType");
        }

        private string Get(string key)
        {
            return info.TryGetValue(key, out string? v) ? v : "";
        }

        // ---------------------------------------------------------
        // 3. PAG-LOAD NG DATA (galing sa BillingController)
        // ---------------------------------------------------------
        private bool LoadAll()
        {
            info.Clear();

            try
            {
                PatientDetails? d = _controller.GetPatientDetails(patientId);
                _bill = _controller.GetBill(patientId);

                if (d != null)
                {
                    info["LastName"] = d.LastName;
                    info["FirstName"] = d.FirstName;
                    info["MI"] = d.MiddleInitial;
                    info["Birthdate"] = d.Birthdate;
                    info["Age"] = d.Age;
                    info["Sex"] = d.Sex;
                    info["Address"] = d.Address;
                    info["Contact"] = d.ContactNo;
                }

                info["AdmissionId"] = _bill.HasAdmission ? _bill.AdmissionId.ToString() : "N/A";
                info["AdmissionDate"] = _bill.AdmissionDate;
                info["Doctor"] = _bill.Doctor;
                info["AdmissionType"] = _bill.AdmissionType;
                info["Room"] = _bill.RoomNo;
                info["Bed"] = _bill.BedNo;

                if (!string.IsNullOrEmpty(_bill.PaymentsWarning))
                {
                    MessageBox.Show(_bill.PaymentsWarning, "Payments",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng payment data:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------------------------------------------------------
        // 4. GRID (PAYMENT BREAKDOWN)
        // ---------------------------------------------------------
        // Mga singil (dating room muna) + Total Bill + mga bayad (negatibo) + Balance
        private void BindGrid()
        {
            var view = new List<BillLine>(_bill.Charges);

            if (_bill.HasAdmission)
            {
                view.Add(new BillLine("Total Bill", "", totalBill));
                view.AddRange(_bill.PaymentLines);
                view.Add(new BillLine(BillingController.ItemBalance, "Remaining balance", Math.Max(0m, totalBill - paid)));
            }

            grid.DataSource = null;
            grid.Columns.Clear();
            grid.AutoGenerateColumns = true;
            grid.DataSource = view;

            if (grid.Columns.Contains(nameof(BillLine.Amount)))
            {
                grid.Columns[nameof(BillLine.Amount)].DefaultCellStyle.Format = "N2";
                grid.Columns[nameof(BillLine.Amount)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns[nameof(BillLine.Amount)].FillWeight = 25;
            }
            if (grid.Columns.Contains(nameof(BillLine.Item))) grid.Columns[nameof(BillLine.Item)].FillWeight = 25;
            if (grid.Columns.Contains(nameof(BillLine.Details))) grid.Columns[nameof(BillLine.Details)].FillWeight = 50;

            foreach (DataGridViewColumn col in grid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.ClearSelection();
        }

        private void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= grid.Rows.Count) return;

            if (grid.Rows[e.RowIndex].DataBoundItem is not BillLine line) return;

            if (line.Item == BillingController.TypeDownpayment || line.Item == BillingController.TypePayment)
                e.CellStyle.ForeColor = Color.Green;
            else if (line.Item == BillingController.ItemBalance || line.Item == "Total Bill")
                e.CellStyle.Font = balanceFont;
        }

        // ---------------------------------------------------------
        // 5. BUTTONS
        // ---------------------------------------------------------
        private void BtnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // Pay (kung may balance pa) at i-print ang receipt
        private void BtnPay_Click(object? sender, EventArgs e)
        {
            if (busy) return;
            busy = true;
            if (btnPayControl != null) btnPayControl.Enabled = false;

            try
            {
                PayAndPrint();
            }
            catch (Exception ex)
            {
                MessageBox.Show("May error:\n" + ex.Message, "Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                busy = false;
                if (btnPayControl != null) btnPayControl.Enabled = admissionId >= 0;
            }
        }

        private void PayAndPrint()
        {
            if (admissionId < 0)
            {
                MessageBox.Show("Walang admission ang patient na ito, kaya walang mababayaran.",
                    "Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kunin ang pinakabagong data bago magbayad
            if (!LoadAll()) return;
            ShowInfo();
            BindGrid();

            decimal remaining = Math.Round(totalBill - paid, 2);

            // Bayad na lahat: receipt na lang ang i-print
            if (remaining <= 0m)
            {
                var again = MessageBox.Show("Bayad na ang bill na ito.\nI-print ang receipt?",
                    "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (again == DialogResult.Yes)
                {
                    lastPaidNow = 0m;
                    PrintReceipt();
                }
                return;
            }

            var confirm = MessageBox.Show(
                "Bayaran ang buong remaining balance na " + Money(remaining) + "?",
                "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Ang controller ang nag-save (may ulit na tsek ng balance sa loob ng transaction)
            PayResult result = _controller.PayRemaining(_bill, DateTime.Now);

            if (result.BalanceChanged)
            {
                MessageBox.Show(result.Message + "\n" +
                    "Na-refresh na ang screen, subukan ulit.", "Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Reload();
                return;
            }

            if (!result.Success)
            {
                MessageBox.Show("Hindi na-save ang payment:\n" + result.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lastPaidNow = result.Amount;
            lastPaidTime = result.PaidAt;

            Reload();   // lalabas na ang bagong bayad at Balance 0.00

            MessageBox.Show("Payment na " + Money(result.Amount) + " ay na-save.", "Payment",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrintReceipt();
        }

        // ---------------------------------------------------------
        // 6. RECEIPT (PRINT PREVIEW)
        // ---------------------------------------------------------
        private void BuildReceipt()
        {
            receiptLines = new List<ReceiptLine>();

            Action<string, string, bool> add = (l, r, bold) =>
                receiptLines.Add(new ReceiptLine { Left = l, Right = r, Bold = bold });

            receiptLines.Add(new ReceiptLine { Left = "HOSPITAL OFFICIAL RECEIPT", Bold = true, Center = true });
            receiptLines.Add(new ReceiptLine { Left = "Printed: " + DateTime.Now.ToString("MMM dd, yyyy h:mm tt"), Center = true });
            receiptLines.Add(new ReceiptLine { Rule = true });

            string fullName = (Get("FirstName") + " " + Get("MI") + " " + Get("LastName")).Replace("  ", " ").Trim();
            add("Patient: " + fullName, "", false);
            add("Admission ID: " + Get("AdmissionId"), "", false);
            add("Admission date: " + Get("AdmissionDate"), "", false);
            add("Doctor: " + Get("Doctor"), "", false);
            add("Room " + Get("Room") + " / Bed " + Get("Bed"), "", false);
            receiptLines.Add(new ReceiptLine { Rule = true });

            // Kasama dito ang mga "Previous Room" na singil
            add("CHARGES", "AMOUNT", true);
            foreach (BillLine row in _bill.Charges)
                add(row.Item + " - " + row.Details, Money(row.Amount), false);

            receiptLines.Add(new ReceiptLine { Rule = true });
            add("TOTAL BILL", Money(totalBill), true);

            if (_bill.PaymentLines.Count > 0)
            {
                add("PAYMENTS", "", true);
                foreach (BillLine row in _bill.PaymentLines)
                    add(row.Item + " (" + row.Details + ")", Money(-row.Amount), false);
            }

            receiptLines.Add(new ReceiptLine { Rule = true });
            add("TOTAL PAID", Money(paid), true);
            add("BALANCE", Money(Math.Max(0m, totalBill - paid)), true);

            if (lastPaidNow > 0m)
            {
                receiptLines.Add(new ReceiptLine { Rule = true });
                add("Amount paid now (" + lastPaidTime.ToString("MMM dd, yyyy h:mm tt") + ")",
                    Money(lastPaidNow), true);
            }

            receiptLines.Add(new ReceiptLine { Rule = true });
            receiptLines.Add(new ReceiptLine { Left = "Thank you!", Center = true });
        }

        private void PrintReceipt()
        {
            BuildReceipt();

            using (var doc = new PrintDocument())
            using (var preview = new PrintPreviewDialog())
            {
                doc.DocumentName = "Receipt";
                doc.BeginPrint += Doc_BeginPrint;
                doc.PrintPage += Doc_PrintPage;

                preview.Document = doc;
                preview.StartPosition = FormStartPosition.CenterScreen;
                preview.WindowState = FormWindowState.Maximized;
                preview.ShowIcon = false;

                preview.KeyPreview = true;
                preview.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Escape) preview.Close();
                };

                preview.ShowDialog(this);

                doc.BeginPrint -= Doc_BeginPrint;
                doc.PrintPage -= Doc_PrintPage;
            }
        }

        private void Doc_BeginPrint(object? sender, PrintEventArgs e)
        {
            printIndex = 0;
        }

        private void Doc_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null) return;

            float x = e.MarginBounds.Left;
            float width = e.MarginBounds.Width;
            float y = e.MarginBounds.Top;
            const float amountWidth = 140f;

            using (var regular = new Font("Segoe UI", 10f))
            using (var bold = new Font("Segoe UI", 10f, FontStyle.Bold))
            using (var leftFmt = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
            using (var rightFmt = new StringFormat { Alignment = StringAlignment.Far, FormatFlags = StringFormatFlags.NoWrap })
            using (var centerFmt = new StringFormat { Alignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoWrap })
            {
                while (printIndex < receiptLines.Count)
                {
                    ReceiptLine ln = receiptLines[printIndex];
                    Font f = ln.Bold ? bold : regular;
                    float h = f.GetHeight(e.Graphics) + 4f;

                    if (y + h > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;   // may susunod na pahina
                        return;
                    }

                    if (ln.Rule)
                    {
                        e.Graphics.DrawLine(Pens.Black, x, y + h / 2f, x + width, y + h / 2f);
                    }
                    else if (ln.Center)
                    {
                        e.Graphics.DrawString(ln.Left, f, Brushes.Black,
                            new RectangleF(x, y, width, h), centerFmt);
                    }
                    else
                    {
                        float leftW = ln.Right != "" ? width - amountWidth : width;
                        e.Graphics.DrawString(ln.Left, f, Brushes.Black,
                            new RectangleF(x, y, leftW, h), leftFmt);
                        if (ln.Right != "")
                            e.Graphics.DrawString(ln.Right, f, Brushes.Black,
                                new RectangleF(x + width - amountWidth, y, amountWidth, h), rightFmt);
                    }

                    y += h;
                    printIndex++;
                }
            }

            e.HasMorePages = false;
        }

        // ---------------------------------------------------------
        // 7. Helpers
        // ---------------------------------------------------------
        private static string Money(decimal value)
        {
            return BillingController.Money(value);
        }
    }
}