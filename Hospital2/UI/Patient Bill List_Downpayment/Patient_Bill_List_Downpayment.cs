using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

// PAALALA: dapat TUMUGMA ang namespace at class name sa
// Patient_Bill_List_Downpayment.Designer.cs
namespace HospitalPRAC
{
    public partial class Patient_Bill_List_Downpayment : Form
    {
        private const string ConnStr =
            @"Data Source=MIKEE-ESMERO\SQLEXPRESS;Initial Catalog=UserModel;Integrated Security=True;TrustServerCertificate=True;";

        // Mga pangalan ng "type" na sine-save sa payments table
        private const string TypeDownpayment = "Downpayment";
        private const string TypePayment = "Payment";

        private readonly int patientId;     // galing sa CashierDashboard (View button)
        private int admissionId = -1;       // pinakabagong admission ng patient
        private decimal totalBill = 0m;     // kabuuang singil
        private decimal paid = 0m;          // kabuuang nabayad na (downpayment + payment)
        private bool openingPayment = false; // para hindi dalawang beses mabuksan ang Payment form

        private DataTable charges;          // mga singil: room, consultation, services
        private DataTable paymentRows;      // mga bayad na ibabawas sa bill
        private Font balanceFont;           // bold font para sa Balance row

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
        private void Patient_Bill_List_Downpayment_Load(object sender, EventArgs e)
        {
            ClearAll();

            if (patientId < 0)
            {
                MessageBox.Show("Walang napiling patient. Buksan ito mula sa Cashier Dashboard (View button).",
                    "Billing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetPaymentControls(false);
                return;
            }

            LoadPatient();
            LoadCompanion();
            LoadAdmissionAndBill();
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
        // 2. PATIENT INFORMATION
        // ---------------------------------------------------------
        private void LoadPatient()
        {
            const string sql = @"
                SELECT LastName, FirstName, MiddleName, Suffix, DateOfBirth, Age,
                       Sex, Address, ContactNumber
                FROM Patient
                WHERE PatientID = @id";

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", patientId);
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return;

                        string suffix = Str(r, "Suffix");
                        lblLastName.Text = Str(r, "LastName") + (suffix != "" ? " " + suffix : "");
                        lblFirstName.Text = Str(r, "FirstName");

                        string mid = Str(r, "MiddleName");
                        lblMI.Text = mid.Length > 0 ? mid.Substring(0, 1) + "." : "";

                        if (r["DateOfBirth"] != DBNull.Value)
                        {
                            DateTime dob = Convert.ToDateTime(r["DateOfBirth"]);
                            lblBirthdate.Text = dob.ToString("MMM dd, yyyy");
                            lblAge.Text = ComputeAge(dob).ToString();
                        }
                        else
                        {
                            lblBirthdate.Text = "";
                            lblAge.Text = Str(r, "Age");
                        }

                        lblSex.Text = Str(r, "Sex");
                        lblAddress.Text = Str(r, "Address");
                        lblContact.Text = Str(r, "ContactNumber");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng patient:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------
        // 3. ACCOMPANYING PERSON
        // ---------------------------------------------------------
        private void LoadCompanion()
        {
            const string sql = @"
                SELECT TOP 1 FullName, Relationship, ContactNumber
                FROM Companion
                WHERE PatientID = @id
                ORDER BY CompanionID";

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", patientId);
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            lblAccName.Text = Str(r, "FullName");
                            lblAccRelationship.Text = Str(r, "Relationship");
                            lblAccContact.Text = Str(r, "ContactNumber");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng accompanying person:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------
        // 4. ADMISSION + BED + MGA SINGIL (CHARGES)
        // ---------------------------------------------------------
        private void LoadAdmissionAndBill()
        {
            // Pinakabagong admission ng patient + doctor, type, room, bed
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

            // Mga serbisyong nakalagay sa admission
            const string sqlServices = @"
                SELECT s.ServiceName, x.price
                FROM admission_services x
                LEFT JOIN Services s ON s.ServiceID = x.ServiceID
                WHERE x.admission_id = @aid
                ORDER BY x.admission_service_id";

            charges = NewBillTable();
            totalBill = 0m;
            admissionId = -1;

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

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

                                lblAdmissionId.Text = admissionId.ToString();
                                lblAdmissionDate.Text = admitDate.ToString("MMM dd, yyyy");
                                lblDoctor.Text = doctor != "" ? doctor : "N/A";

                                string type = Str(r, "admission_type_name");
                                lblAdmissionType.Text = type != "" ? type : "N/A";

                                lblRoomNo.Text = room != "" ? room : "N/A";
                                lblBedNo.Text = bed != "" ? bed : "N/A";
                            }
                        }
                    }

                    if (admissionId < 0)
                    {
                        // Walang admission
                        lblAdmissionId.Text = "N/A";
                        lblAdmissionDate.Text = "N/A";
                        lblDoctor.Text = "N/A";
                        lblAdmissionType.Text = "N/A";
                        lblRoomNo.Text = "N/A";
                        lblBedNo.Text = "N/A";
                    }
                    else
                    {
                        // 1) Room / Bed = daily rate x bilang ng araw (kahit 1 araw man lang)
                        int days = Math.Max(1, (DateTime.Today - admitDate.Date).Days);
                        if (rate > 0)
                        {
                            decimal roomCharge = days * rate;
                            charges.Rows.Add("Room & Bed",
                                "Room " + room + ", Bed " + bed + " - " + days + " day(s) x " + Money(rate),
                                roomCharge);
                            totalBill += roomCharge;
                        }

                        // 2) Consultation fee ng doctor
                        if (fee > 0)
                        {
                            charges.Rows.Add("Consultation",
                                doctor != "" ? doctor : "Attending doctor", fee);
                            totalBill += fee;
                        }

                        // 3) Mga services
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
                                    charges.Rows.Add("Service",
                                        name != "" ? name : "(unknown service)", price);
                                    totalBill += price;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng admission at bill:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadPayments();
            RefreshBillView();
        }

        // ---------------------------------------------------------
        // 5. MGA BAYAD (DOWNPAYMENT / PAYMENT) MULA SA DATABASE
        // ---------------------------------------------------------
        private void LoadPayments()
        {
            paid = 0m;
            paymentRows = NewBillTable();
            if (admissionId < 0) return;

            const string sql = @"
                SELECT payment_type, amount, payment_datetime
                FROM payments
                WHERE admission_id = @aid
                ORDER BY payment_datetime, payment_id";

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@aid", admissionId);
                    conn.Open();
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
                            // Negatibo, kasi ibinabawas ito sa bill
                            paymentRows.Rows.Add(label, when, -amt);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Hindi mabasa ang payments table.\n" +
                    "I-run muna ang create_payments_table.sql sa SSMS.\n\n" + ex.Message,
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Ina-update ang grid at ang mga total sa screen
        private void RefreshBillView()
        {
            BindBillGrid();
            UpdateTotals();
        }

        // Grid = mga singil + mga bayad (negatibo) + Balance sa dulo
        private void BindBillGrid()
        {
            DataTable view = charges != null ? charges.Copy() : NewBillTable();

            if (paymentRows != null)
                foreach (DataRow row in paymentRows.Rows)
                    view.ImportRow(row);

            decimal remaining = Math.Max(0m, totalBill - paid);
            if (admissionId >= 0)
                view.Rows.Add("Balance", "Remaining balance", remaining);

            dgvBills.DataSource = view;

            if (dgvBills.Columns.Contains("Amount"))
            {
                dgvBills.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dgvBills.Columns["Amount"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                dgvBills.Columns["Amount"].FillWeight = 25;
            }
            if (dgvBills.Columns.Contains("Item"))
                dgvBills.Columns["Item"].FillWeight = 25;
            if (dgvBills.Columns.Contains("Details"))
                dgvBills.Columns["Details"].FillWeight = 50;

            // Walang sorting, para laging nasa tamang pagkakasunod ang mga row
            foreach (DataGridViewColumn col in dgvBills.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvBills.ClearSelection();
        }

        // Berde ang mga bayad, bold ang Balance
        private void dgvBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var drv = dgvBills.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;

            string item = drv["Item"] as string ?? "";

            if (item == TypeDownpayment || item == TypePayment)
                e.CellStyle.ForeColor = Color.Green;
            else if (item == "Balance")
                e.CellStyle.Font = balanceFont;
        }

        private void UpdateTotals()
        {
            decimal remaining = Math.Max(0m, totalBill - paid);

            lblTotalBill.Text = Money(totalBill);
            lblPreviousPayments.Text = Money(paid);
            lblRemainingBalance.Text = Money(remaining);

            // Naka-disable ang mga button kung walang admission o bayad na lahat
            SetPaymentControls(admissionId >= 0 && remaining > 0m);
        }

        private void SetPaymentControls(bool enabled)
        {
            txtAmount.Enabled = enabled;
            btnDownPayment.Enabled = enabled;
            btnPayment.Enabled = enabled;
        }

        // ---------------------------------------------------------
        // 6. DOWNPAYMENT AT PAYMENT
        // ---------------------------------------------------------
        private void btnDownPayment_Click(object sender, EventArgs e)
        {
            SavePayment(TypeDownpayment);
        }

        // Pag pinindot ang Payment button -> pupunta sa Payment module (kasama ang data ng patient)
        private void btnPayment_Click(object sender, EventArgs e)
        {
            OpenPaymentModule();
        }

        // Lumang handler (baka naka-connect pa sa Designer). Pareho lang ang ginagawa.
        private void btnPayment_Click_1(object sender, EventArgs e)
        {
            OpenPaymentModule();
        }

        private void OpenPaymentModule()
        {
            if (openingPayment) return;   // iwas double-click

            if (patientId < 0 || admissionId < 0)
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
                LoadAdmissionAndBill();          
            }
        }

        private void SavePayment(string type)
        {
            if (admissionId < 0)
            {
                MessageBox.Show("Walang admission ang patient na ito, kaya walang mababayaran.",
                    type, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            string text = txtAmount.Text.Replace("₱", "").Trim();

            decimal amount;
            if (!decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out amount))
            {
                MessageBox.Show("Maglagay ng tamang amount (numero lang).", type,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            amount = Math.Round(amount, 2);
            if (amount <= 0m)
            {
                MessageBox.Show("Ang amount ay dapat higit sa 0.", type,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

          
            LoadPayments();
            decimal remaining = totalBill - paid;

            if (remaining <= 0m)
            {
                RefreshBillView();
                MessageBox.Show("Bayad na ang bill na ito.", type,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (amount > remaining)
            {
                MessageBox.Show("Hindi pwedeng lumampas sa remaining balance (" + Money(remaining) + ").",
                    type, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            var confirm = MessageBox.Show(
                "I-save ang " + type + " na " + Money(amount) + "?\n\n" +
                "Remaining balance pagkatapos: " + Money(remaining - amount),
                type, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            const string sql = @"
                INSERT INTO payments (admission_id, payment_type, amount)
                VALUES (@aid, @type, @amt)";

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@aid", admissionId);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@amt", amount);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hindi na-save ang " + type + ":\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadPayments();
            RefreshBillView();
            txtAmount.Clear();

            MessageBox.Show(type + " na " + Money(amount) + " ay na-save.", type,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ClearAll()
        {
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

            lblTotalBill.Text = Money(0m);
            lblPreviousPayments.Text = Money(0m);
            lblRemainingBalance.Text = Money(0m);

            txtAmount.Clear();
        }

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