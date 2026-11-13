using System;
using System.Drawing;
using System.Windows.Forms;
using HospitalPRAC.BusinessLogic.Controller;
using HospitalPRAC.Model;

// PAALALA: dapat TUMUGMA ang namespace at class name sa
// Patient_Bill_List_Downpayment.Designer.cs
namespace HospitalPRAC
{
    public partial class Patient_Bill_List_Downpayment : Form
    {
        private readonly BillingController _controller = new BillingController();

        private readonly int patientId;      // galing sa CashierDashboard (View button)
        private BillSummary _bill = new BillSummary();  // ang kasalukuyang bill ng patient
        private bool openingPayment = false; // para hindi dalawang beses mabuksan ang Payment form

        private Font balanceFont = null!;    // bold font para sa Balance row

        // Para hindi mag-error ang Designer
        public Patient_Bill_List_Downpayment() : this(-1)
        {
        }

        public Patient_Bill_List_Downpayment(int patientId)
        {
            InitializeComponent();
            this.patientId = patientId;

            // I-connect ang events dito sa code (-= muna para hindi madoble)
            Load -= Patient_Bill_List_Downpayment_Load;
            Load += Patient_Bill_List_Downpayment_Load;

            btnDownPayment.Click -= btnDownPayment_Click;
            btnDownPayment.Click += btnDownPayment_Click;

            // Isang handler lang ang btnPayment: ang pagbukas ng Payment module.
            // Inalis muna ang dalawang lumang handler para hindi ito mag-double (kahit
            // naka-connect sila sa Designer).
            btnPayment.Click -= btnPayment_Click;
            btnPayment.Click -= btnPayment_Click_1;
            btnPayment.Click += btnPayment_Click;

            dgvBills.CellFormatting -= dgvBills_CellFormatting;
            dgvBills.CellFormatting += dgvBills_CellFormatting;

            SetupGrid();
        }

        // ---------------------------------------------------------
        // 1. PAG-OPEN NG FORM
        // ---------------------------------------------------------
        private void Patient_Bill_List_Downpayment_Load(object? sender, EventArgs e)
        {
            ClearAll();

            if (patientId < 0)
            {
                MessageBox.Show("Walang napiling patient. Buksan ito mula sa Cashier Dashboard (View button).",
                    "Billing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetPaymentControls(false);
                return;
            }

            ShowPatient();
            ShowBill();
        }

        private void SetupGrid()
        {
            dgvBills.ReadOnly = true;
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.MultiSelect = false;
            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBills.RowHeadersVisible = false;
            dgvBills.BackgroundColor = Color.White;

            balanceFont = new Font(dgvBills.Font, FontStyle.Bold);
        }

        // ---------------------------------------------------------
        // 2. PATIENT INFORMATION + ACCOMPANYING PERSON
        // ---------------------------------------------------------
        private void ShowPatient()
        {
            try
            {
                PatientDetails? d = _controller.GetPatientDetails(patientId);
                if (d == null) return;

                lblLastName.Text = d.LastName;
                lblFirstName.Text = d.FirstName;
                lblMI.Text = d.MiddleInitial;
                lblBirthdate.Text = d.Birthdate;
                lblAge.Text = d.Age;
                lblSex.Text = d.Sex;
                lblAddress.Text = d.Address;
                lblContact.Text = d.ContactNo;

                lblAccName.Text = d.AccName;
                lblAccRelationship.Text = d.AccRelationship;
                lblAccContact.Text = d.AccContact;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng patient:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------
        // 3. ADMISSION + BED + BILL (kasama na ang mga dating room)
        // ---------------------------------------------------------
        private void ShowBill()
        {
            try
            {
                _bill = _controller.GetBill(patientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng admission at bill:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAdmissionId.Text = _bill.HasAdmission ? _bill.AdmissionId.ToString() : "N/A";
            lblAdmissionDate.Text = _bill.AdmissionDate;
            lblDoctor.Text = _bill.Doctor;
            lblAdmissionType.Text = _bill.AdmissionType;
            lblRoomNo.Text = _bill.RoomNo;
            lblBedNo.Text = _bill.BedNo;

            BindBillGrid();
            UpdateTotals();

            if (!string.IsNullOrEmpty(_bill.PaymentsWarning))
            {
                MessageBox.Show(_bill.PaymentsWarning, "Payments",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Grid = mga singil (dating room muna) + mga bayad (negatibo) + Balance sa dulo
        private void BindBillGrid()
        {
            dgvBills.DataSource = _bill.Lines;

            dgvBills.Columns[nameof(BillLine.Amount)].DefaultCellStyle.Format = "N2";
            dgvBills.Columns[nameof(BillLine.Amount)].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvBills.Columns[nameof(BillLine.Amount)].FillWeight = 25;
            dgvBills.Columns[nameof(BillLine.Item)].FillWeight = 25;
            dgvBills.Columns[nameof(BillLine.Details)].FillWeight = 50;

            // Walang sorting, para laging nasa tamang pagkakasunod ang mga row
            foreach (DataGridViewColumn col in dgvBills.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvBills.ClearSelection();
        }

        // Berde ang mga bayad, bold ang Balance
        private void dgvBills_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvBills.Rows[e.RowIndex].DataBoundItem is not BillLine line) return;

            if (line.Item == BillingController.TypeDownpayment || line.Item == BillingController.TypePayment)
                e.CellStyle.ForeColor = Color.Green;
            else if (line.Item == BillingController.ItemBalance)
                e.CellStyle.Font = balanceFont;
        }

        private void UpdateTotals()
        {
            lblTotalBill.Text = BillingController.Money(_bill.TotalBill);
            lblPreviousPayments.Text = BillingController.Money(_bill.Paid);
            lblRemainingBalance.Text = BillingController.Money(_bill.Remaining);

            // Naka-disable ang mga button kung walang admission o bayad na lahat
            SetPaymentControls(_bill.HasAdmission && _bill.Remaining > 0m);
        }

        private void SetPaymentControls(bool enabled)
        {
            txtAmount.Enabled = enabled;
            btnDownPayment.Enabled = enabled;
            btnPayment.Enabled = enabled;
        }

        // ---------------------------------------------------------
        // 4. DOWNPAYMENT AT PAYMENT
        // ---------------------------------------------------------
        private void btnDownPayment_Click(object? sender, EventArgs e)
        {
            SavePayment(BillingController.TypeDownpayment);
        }

        // Pag pinindot ang Payment button -> pupunta sa Payment module (kasama ang data ng patient)
        private void btnPayment_Click(object? sender, EventArgs e)
        {
            OpenPaymentModule();
        }

        // Lumang handler (baka naka-connect pa sa Designer). Pareho lang ang ginagawa.
        private void btnPayment_Click_1(object? sender, EventArgs e)
        {
            OpenPaymentModule();
        }

        private void OpenPaymentModule()
        {
            if (openingPayment) return;   // iwas double-click

            if (patientId < 0 || !_bill.HasAdmission)
            {
                MessageBox.Show("Walang admission ang patient na ito, kaya walang mababayaran.",
                    "Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            openingPayment = true;
            try
            {
                using (var paymentForm = new Payment(patientId))
                {
                    Hide();
                    paymentForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hindi mabuksan ang Payment form:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                openingPayment = false;
                Show();
                Activate();
                ShowBill();
            }
        }

        private void SavePayment(string type)
        {
            // 1. Tingnan muna ang amount laban sa kasalukuyang bill
            PaymentCheck check = _controller.PreparePayment(patientId, txtAmount.Text);

            if (!check.Success)
            {
                if (check.AlreadyPaid)
                {
                    ShowBill();
                    MessageBox.Show(check.Message, type,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(check.Message, type,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (_bill.HasAdmission) txtAmount.Focus();
                }
                return;
            }

            // 2. Tanungin muna bago i-save
            var confirm = MessageBox.Show(
                "I-save ang " + type + " na " + BillingController.Money(check.Amount) + "?\n\n" +
                "Remaining balance pagkatapos: " + BillingController.Money(check.Remaining - check.Amount),
                type, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // 3. I-save
            OperationResult result = _controller.SavePayment(check.AdmissionId, type, check.Amount);

            if (!result.Success)
            {
                MessageBox.Show("Hindi na-save ang " + type + ":\n" + result.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShowBill();
            txtAmount.Clear();

            MessageBox.Show(result.Message, type,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------------------------------------------------------
        // 5. Helpers
        // ---------------------------------------------------------
        private void ClearAll()
        {
            _bill = new BillSummary();

            lblLastName.Text = "";
            lblFirstName.Text = "";
            lblMI.Text = "";
            lblBirthdate.Text = "";
            lblAge.Text = "";
            lblSex.Text = "";
            lblAddress.Text = "";
            lblContact.Text = "";

            lblRoomNo.Text = "";
            lblBedNo.Text = "";

            lblAccName.Text = "";
            lblAccRelationship.Text = "";
            lblAccContact.Text = "";

            lblAdmissionId.Text = "";
            lblAdmissionDate.Text = "";
            lblDoctor.Text = "";
            lblAdmissionType.Text = "";

            lblTotalBill.Text = BillingController.Money(0m);
            lblPreviousPayments.Text = BillingController.Money(0m);
            lblRemainingBalance.Text = BillingController.Money(0m);

            txtAmount.Clear();
        }
    }
}