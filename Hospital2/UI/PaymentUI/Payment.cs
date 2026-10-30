using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

// PAALALA: dapat TUMUGMA ang namespace at class name sa Payment.Designer.cs
namespace HospitalPRAC
{
    public partial class Payment : Form
    {
        private const string ConnStr =
            @"Data Source=MIKEE-ESMERO\SQLEXPRESS;Initial Catalog=UserModel;Integrated Security=True;TrustServerCertificate=True;";

        private const string TypeDownpayment = "Downpayment";
        private const string TypePayment = "Payment";

        private readonly int patientId;
        private int admissionId = -1;
        private decimal totalBill = 0m;
        private decimal paid = 0m;
        private bool busy = false;                  // iwas double-click sa Pay button

        private DataTable charges;
        private DataTable paymentRows;
        private readonly Dictionary<string, string> info = new Dictionary<string, string>();

        private DataGridView grid;
        private Button btnPayControl;
        private Font balanceFont;

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

        private T FindByName<T>(params string[] names) where T : Control
        {
            foreach (string n in names)
            {
                Control[] found = Controls.Find(n, true);
                foreach (Control c in found)
                {
                    T typed = c as T;
                    if (typed != null) return typed;
                }
            }
            return null;
        }

        private DataGridView FindOrCreateGrid()
        {
            DataGridView g = FindByName<DataGridView>("dgvBreakdown", "dgvPayment", "dgvBills", "dgvPaymentBreakdown");
            if (g != null) return g;

            foreach (Control c in AllControls(this))
            {
                g = c as DataGridView;
                if (g != null) return g;
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
            Button back = FindByName<Button>("btnBack", "btnBackPayment");
            if (back == null)
                foreach (Control c in AllControls(this))
                {
                    Button b = c as Button;
                    if (b != null && b.Text.Trim().Equals("Back", StringComparison.OrdinalIgnoreCase))
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
                    Button b = c as Button;
                    if (b != null && b != back && b.Text.IndexOf("Pay", StringComparison.OrdinalIgnoreCase) >= 0)
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
            Label target = FindByName<Label>(names);

            if (target == null)
            {
                Label cap = null;
                foreach (Control c in AllControls(this))
                {
                    Label l = c as Label;
                    if (l != null && l.Text.Trim().Equals(caption, StringComparison.OrdinalIgnoreCase))
                    { cap = l; break; }
                }

                if (cap != null)
                {
                    int bestLeft = int.MaxValue;
                    foreach (Control c in cap.Parent.Controls)
                    {
                        Label l = c as Label;
                        if (l == null || l == cap) continue;
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
            string v;
            return info.TryGetValue(key, out v) ? v : "";
        }

        // ---------------------------------------------------------
        // 3. PAG-LOAD NG DATA MULA SA DATABASE
        // ---------------------------------------------------------
        private bool LoadAll()
        {
            info.Clear();
            charges = NewBillTable();
            paymentRows = NewBillTable();
            totalBill = 0m;
            paid = 0m;
            admissionId = -1;

            const string sqlPatient = @"
                SELECT LastName, FirstName, MiddleName, Suffix, DateOfBirth, Age,
                       Sex, Address, ContactNumber
                FROM Patient
                WHERE PatientID = @id";

            const string sqlAdmission = @"
                SELECT TOP 1
                       a.admission_id,
                       ISNULL(a.admission_date, a.admission_datetime) AS AdmitDate,
                       d.doctor_name,
                       d.consultation_fee,
                       t.admission_type_name,
                       r.room_number,
                       b.bed_number,
                       ISNULL(b.daily_rate, r.daily_rate) AS DailyRate
                FROM admissions a
                LEFT JOIN doctors d          ON d.doctor_id = a.doctor_id
                LEFT JOIN admission_types t  ON t.admission_type_id = a.admission_type_id
                LEFT JOIN rooms r            ON r.room_id = a.room_id
                LEFT JOIN Beds  b            ON b.bed_id  = a.bed_id
                WHERE a.PatientID = @id
                ORDER BY a.admission_datetime DESC, a.admission_id DESC";

            const string sqlServices = @"
                SELECT s.ServiceName, x.price
                FROM admission_services x
                LEFT JOIN Services s ON s.ServiceID = x.ServiceID
                WHERE x.admission_id = @aid
                ORDER BY x.admission_service_id";

            const string sqlPayments = @"
                SELECT payment_type, amount, payment_datetime
                FROM payments
                WHERE admission_id = @aid
                ORDER BY payment_datetime, payment_id";

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // --- Patient ---
                    using (var cmd = new SqlCommand(sqlPatient, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", patientId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                string suffix = Str(r, "Suffix");
                                info["LastName"] = Str(r, "LastName") + (suffix != "" ? " " + suffix : "");
                                info["FirstName"] = Str(r, "FirstName");

                                string mid = Str(r, "MiddleName");
                                info["MI"] = mid.Length > 0 ? mid.Substring(0, 1) + "." : "";

                                if (r["DateOfBirth"] != DBNull.Value)
                                {
                                    DateTime dob = Convert.ToDateTime(r["DateOfBirth"]);
                                    info["Birthdate"] = dob.ToString("MMM dd, yyyy");
                                    info["Age"] = ComputeAge(dob).ToString();
                                }
                                else
                                {
                                    info["Birthdate"] = "";
                                    info["Age"] = Str(r, "Age");
                                }

                                info["Sex"] = Str(r, "Sex");
                                info["Address"] = Str(r, "Address");
                                info["Contact"] = Str(r, "ContactNumber");
                            }
                        }
                    }

                    // --- Admission ---
                    DateTime admitDate = DateTime.Today;
                    string doctor = "";
                    decimal fee = 0m;
                    decimal rate = 0m;
                    string room = "";
                    string bed = "";

                    using (var cmd = new SqlCommand(sqlAdmission, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", patientId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                admissionId = Convert.ToInt32(r["admission_id"]);

                                if (r["AdmitDate"] != DBNull.Value)
                                    admitDate = Convert.ToDateTime(r["AdmitDate"]);

                                doctor = Str(r, "doctor_name");
                                fee = r["consultation_fee"] == DBNull.Value
                                    ? 0m : Convert.ToDecimal(r["consultation_fee"]);
                                room = Str(r, "room_number");
                                bed = Str(r, "bed_number");
                                rate = r["DailyRate"] == DBNull.Value
                                    ? 0m : Convert.ToDecimal(r["DailyRate"]);

                                string type = Str(r, "admission_type_name");

                                info["AdmissionId"] = admissionId.ToString();
                                info["AdmissionDate"] = admitDate.ToString("MMM dd, yyyy");
                                info["Doctor"] = doctor != "" ? doctor : "N/A";
                                info["AdmissionType"] = type != "" ? type : "N/A";
                                info["Room"] = room != "" ? room : "N/A";
                                info["Bed"] = bed != "" ? bed : "N/A";
                            }
                        }
                    }

                    if (admissionId < 0)
                    {
                        info["AdmissionId"] = "N/A";
                        info["AdmissionDate"] = "N/A";
                        info["Doctor"] = "N/A";
                        info["AdmissionType"] = "N/A";
                        info["Room"] = "N/A";
                        info["Bed"] = "N/A";
                        return true;
                    }

                    // --- Mga singil (pareho ng Billing form) ---
                    int days = Math.Max(1, (DateTime.Today - admitDate.Date).Days);
                    if (rate > 0)
                    {
                        decimal roomCharge = days * rate;
                        charges.Rows.Add("Room & Bed",
                            "Room " + room + ", Bed " + bed + " - " + days + " day(s) x " + Money(rate),
                            roomCharge);
                        totalBill += roomCharge;
                    }

                    if (fee > 0)
                    {
                        charges.Rows.Add("Consultation", doctor != "" ? doctor : "Attending doctor", fee);
                        totalBill += fee;
                    }

                    using (var cmd = new SqlCommand(sqlServices, conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", admissionId);
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                decimal price = r["price"] == DBNull.Value
                                    ? 0m : Convert.ToDecimal(r["price"]);
                                string name = Str(r, "ServiceName");
                                charges.Rows.Add("Service", name != "" ? name : "(unknown service)", price);
                                totalBill += price;
                            }
                        }
                    }

                    // --- Mga bayad na ---
                    using (var cmd = new SqlCommand(sqlPayments, conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", admissionId);
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                decimal amt = r["amount"] == DBNull.Value
                                    ? 0m : Convert.ToDecimal(r["amount"]);

                                string label = IsDownpayment(Str(r, "payment_type"))
                                    ? TypeDownpayment : TypePayment;

                                string when = r["payment_datetime"] == DBNull.Value
                                    ? "" : Convert.ToDateTime(r["payment_datetime"])
                                             .ToString("MMM dd, yyyy h:mm tt");

                                paid += amt;
                                paymentRows.Rows.Add(label, when, -amt);
                            }
                        }
                    }
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
        private void BindGrid()
        {
            DataTable view = charges.Copy();

            if (admissionId >= 0)
            {
                view.Rows.Add("Total Bill", "", totalBill);

                foreach (DataRow row in paymentRows.Rows)
                    view.ImportRow(row);

                view.Rows.Add("Balance", "Remaining balance", Math.Max(0m, totalBill - paid));
            }

            grid.DataSource = null;
            grid.Columns.Clear();
            grid.AutoGenerateColumns = true;
            grid.DataSource = view;

            if (grid.Columns.Contains("Amount"))
            {
                grid.Columns["Amount"].DefaultCellStyle.Format = "N2";
                grid.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns["Amount"].FillWeight = 25;
            }
            if (grid.Columns.Contains("Item")) grid.Columns["Item"].FillWeight = 25;
            if (grid.Columns.Contains("Details")) grid.Columns["Details"].FillWeight = 50;

            foreach (DataGridViewColumn col in grid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.ClearSelection();
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= grid.Rows.Count) return;

            var drv = grid.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;

            string item = drv["Item"] as string ?? "";

            if (item == TypeDownpayment || item == TypePayment)
                e.CellStyle.ForeColor = Color.Green;
            else if (item == "Balance" || item == "Total Bill")
                e.CellStyle.Font = balanceFont;
        }

        // ---------------------------------------------------------
        // 5. BUTTONS
        // ---------------------------------------------------------
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Pay (kung may balance pa) at i-print ang receipt
        private void BtnPay_Click(object sender, EventArgs e)
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

            // Transaction: ulit na tsek ng balance bago mag-save (iwas sobra ang bayad)
            bool saved = false;
            bool tooMuch = false;
            DateTime now = DateTime.Now;

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction(IsolationLevel.Serializable))
                    {
                        decimal alreadyPaid;
                        using (var cmd = new SqlCommand(
                            "SELECT ISNULL(SUM(amount), 0) FROM payments WITH (UPDLOCK, HOLDLOCK) WHERE admission_id = @aid",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@aid", admissionId);
                            alreadyPaid = Convert.ToDecimal(cmd.ExecuteScalar());
                        }

                        if (Math.Round(totalBill - alreadyPaid, 2) < remaining)
                        {
                            tooMuch = true;   // may ibang nag-save na; wala pang na-insert
                        }
                        else
                        {
                            using (var cmd = new SqlCommand(
                                "INSERT INTO payments (admission_id, payment_type, amount, payment_datetime) " +
                                "VALUES (@aid, @type, @amt, @dt)", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@aid", admissionId);
                                cmd.Parameters.AddWithValue("@type", TypePayment);
                                cmd.Parameters.AddWithValue("@amt", remaining);
                                cmd.Parameters.AddWithValue("@dt", now);
                                cmd.ExecuteNonQuery();
                            }
                            tx.Commit();
                            saved = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hindi na-save ang payment:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tooMuch)
            {
                MessageBox.Show("Nagbago ang balance ng bill (may ibang nag-save ng bayad).\n" +
                    "Na-refresh na ang screen, subukan ulit.", "Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Reload();
                return;
            }

            if (!saved) return;

            lastPaidNow = remaining;
            lastPaidTime = now;

            Reload();   // lalabas na ang bagong bayad at Balance 0.00

            MessageBox.Show("Payment na " + Money(remaining) + " ay na-save.", "Payment",
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

            add("CHARGES", "AMOUNT", true);
            foreach (DataRow row in charges.Rows)
                add(row["Item"] + " - " + row["Details"], Money(Convert.ToDecimal(row["Amount"])), false);

            receiptLines.Add(new ReceiptLine { Rule = true });
            add("TOTAL BILL", Money(totalBill), true);

            if (paymentRows.Rows.Count > 0)
            {
                add("PAYMENTS", "", true);
                foreach (DataRow row in paymentRows.Rows)
                    add(row["Item"] + " (" + row["Details"] + ")",
                        Money(-Convert.ToDecimal(row["Amount"])), false);
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

        private void Doc_BeginPrint(object sender, PrintEventArgs e)
        {
            printIndex = 0;
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
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
        private static DataTable NewBillTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("Details", typeof(string));
            dt.Columns.Add("Amount", typeof(decimal));
            return dt;
        }

        private static bool IsDownpayment(string type)
        {
            return string.Equals(type, "Deposit", StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, TypeDownpayment, StringComparison.OrdinalIgnoreCase);
        }

        private static string Str(SqlDataReader r, string col)
        {
            return r[col] == DBNull.Value ? "" : r[col].ToString().Trim();
        }

        private static string Money(decimal value)
        {
            return "₱" + value.ToString("N2");
        }

        private static int ComputeAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}