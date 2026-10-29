using HospitalPRAC;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hospital2.UI.CashierDashboard
{
    public partial class CashierDashboard : Form
    {
        private const string ConnStr =
            @"Data Source=MIKEE-ESMERO\SQLEXPRESS;Initial Catalog=UserModel;Integrated Security=True;TrustServerCertificate=True;";

        // ID ng napiling patient (-1 = wala pang napipili)
        private int selectedPatientId = -1;

        public CashierDashboard()
        {
            InitializeComponent();

            // Pang-check lang: kapag nakita mo ito sa title bar, bago na ang tumatakbong code
            this.Text = "CashierDashboard v4";

            // I-connect ang lahat ng events dito sa code
            // (-= muna para hindi madoble kahit na-connect na sa Designer)
            Load -= CashierDashboard_Load;
            Load += CashierDashboard_Load;

            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            txtSearch.KeyDown -= txtSearch_KeyDown;
            txtSearch.KeyDown += txtSearch_KeyDown;

            btnView.Click -= btnView_Click;
            btnView.Click += btnView_Click;

            dgvPatients.CellClick -= dgvPatients_CellClick;
            dgvPatients.CellClick += dgvPatients_CellClick;

            dgvPatients.Visible = true;
            dgvPatients.BringToFront();

            SetupGrid();
        }

        // ---------------------------------------------------------
        // 1. PAG-OPEN NG FORM: ilabas agad lahat ng patients
        // ---------------------------------------------------------
        private void CashierDashboard_Load(object sender, EventArgs e)
        {
            LoadPatients("");
            ClearDetails();
        }

        private void SetupGrid()
        {
            dgvPatients.ReadOnly = true;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.MultiSelect = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.BackgroundColor = System.Drawing.Color.White;
        }

        // ---------------------------------------------------------
        // 2. SEARCH
        // ---------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            LoadPatients(kw);
            ClearDetails();

            if (kw != "" && dgvPatients.Rows.Count == 0)
                MessageBox.Show("Walang nahanap na patient.", "Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Enter key sa textbox
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch.PerformClick();
            }
        }

        // Walang laman ang keyword = lahat ng patients
        private void LoadPatients(string keyword)
        {
            const string sql = @"
                SELECT PatientID, LastName, FirstName, MiddleName, Suffix,
                       DateOfBirth, Age, Sex, Address, ContactNumber
                FROM Patient
                WHERE @kw = ''
                   OR CAST(PatientID AS NVARCHAR(20)) LIKE @like
                   OR LastName      LIKE @like
                   OR FirstName     LIKE @like
                   OR FullName      LIKE @like
                   OR (LastName + ', ' + FirstName) LIKE @like
                   OR ContactNumber LIKE @like
                ORDER BY PatientID";

            try
            {
                var dt = new DataTable();
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", keyword);
                    cmd.Parameters.AddWithValue("@like", "%" + keyword + "%");
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                dgvPatients.DataSource = dt;
                FormatGridColumns();
                dgvPatients.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng patients:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridColumns()
        {
            if (dgvPatients.Columns.Count == 0) return;

            dgvPatients.CurrentCell = null; // para hindi mag-error sa pag-hide ng column

            // Itago ang mga hindi kailangan sa list (lalabas sila sa details sa baba)
            foreach (string hidden in new[] { "Suffix", "Age", "Sex", "Address" })
                if (dgvPatients.Columns.Contains(hidden))
                    dgvPatients.Columns[hidden].Visible = false;

            dgvPatients.Columns["PatientID"].HeaderText = "Patient ID";
            dgvPatients.Columns["LastName"].HeaderText = "Last Name";
            dgvPatients.Columns["FirstName"].HeaderText = "First Name";
            dgvPatients.Columns["MiddleName"].HeaderText = "Middle Name";
            dgvPatients.Columns["DateOfBirth"].HeaderText = "Birthdate";
            dgvPatients.Columns["DateOfBirth"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dgvPatients.Columns["ContactNumber"].HeaderText = "Contact No.";

            // Ayusin ang pagkakasunod-sunod ng columns
            string[] order = { "PatientID", "LastName", "FirstName", "MiddleName",
                               "DateOfBirth", "ContactNumber" };
            for (int i = 0; i < order.Length; i++)
                dgvPatients.Columns[order[i]].DisplayIndex = i;
        }

        // ---------------------------------------------------------
        // 3. PAG PINILI ANG ROW -> PUNUIN ANG DETAILS
        // ---------------------------------------------------------
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // header click

            var drv = dgvPatients.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;

            ShowDetails(drv.Row);
        }

        private void ShowDetails(DataRow row)
        {
            selectedPatientId = Convert.ToInt32(row["PatientID"]);

            // --- Patient Information ---
            string suffix = Val(row, "Suffix");
            lblLastName.Text = Val(row, "LastName") + (suffix != "" ? " " + suffix : "");
            lblFirstName.Text = Val(row, "FirstName");

            string mid = Val(row, "MiddleName");
            lblMI.Text = mid.Length > 0 ? mid.Substring(0, 1) + "." : "";

            if (row["DateOfBirth"] != DBNull.Value)
            {
                DateTime dob = Convert.ToDateTime(row["DateOfBirth"]);
                lblBirthdate.Text = dob.ToString("MMM dd, yyyy");
                lblAge.Text = ComputeAge(dob).ToString();
            }
            else
            {
                lblBirthdate.Text = "";
                lblAge.Text = Val(row, "Age"); // gamitin ang naka-save na Age
            }

            lblSex.Text = Val(row, "Sex");
            lblAddress.Text = Val(row, "Address");
            lblContactNo.Text = Val(row, "ContactNumber");

            // --- Accompanying person at Bed Information ---
            LoadCompanion(selectedPatientId);
            LoadAdmission(selectedPatientId);
        }

        // Companion table -> Accompanying person
        private void LoadCompanion(int patientId)
        {
            lblAccName.Text = "";
            lblAccRelationship.Text = "";
            lblAccContact.Text = "";

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
                            lblAccName.Text = r["FullName"].ToString();
                            lblAccRelationship.Text = r["Relationship"].ToString();
                            lblAccContact.Text = r["ContactNumber"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng accompanying person:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // admissions + rooms + Beds -> Bed Information (pinakabagong admission)
        private void LoadAdmission(int patientId)
        {
            lblRoomNo.Text = "N/A";
            lblBedNo.Text = "N/A";
            lblAdmissionDate.Text = "N/A";

            const string sql = @"
                SELECT TOP 1
                       r.room_number,
                       b.bed_number,
                       ISNULL(a.admission_date, a.admission_datetime) AS AdmitDate
                FROM admissions a
                LEFT JOIN rooms r ON r.room_id = a.room_id
                LEFT JOIN Beds  b ON b.bed_id  = a.bed_id
                WHERE a.PatientID = @id
                ORDER BY a.admission_datetime DESC, a.admission_id DESC";

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
                            lblRoomNo.Text = r["room_number"] == DBNull.Value
                                ? "N/A" : r["room_number"].ToString();

                            lblBedNo.Text = r["bed_number"] == DBNull.Value
                                ? "N/A" : r["bed_number"].ToString();

                            lblAdmissionDate.Text = r["AdmitDate"] == DBNull.Value
                                ? "N/A"
                                : Convert.ToDateTime(r["AdmitDate"]).ToString("MMM dd, yyyy");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng bed information:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------
        // 4. VIEW BUTTON
        // ---------------------------------------------------------
        private void btnView_Click(object sender, EventArgs e)
        {
            if (selectedPatientId < 0)
            {
                MessageBox.Show(
                    "Pumili muna ng patient sa list.",
                    "View",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var billing = new Patient_Bill_List_Downpayment(selectedPatientId);
            billing.ShowDialog(this);
            this.Hide();
        }

        // ---------------------------------------------------------
        // 5. Helpers
        // ---------------------------------------------------------
        private void ClearDetails()
        {
            selectedPatientId = -1;

            lblLastName.Text = "";
            lblFirstName.Text = "";
            lblMI.Text = "";
            lblBirthdate.Text = "";
            lblAge.Text = "";
            lblSex.Text = "";
            lblAddress.Text = "";
            lblContactNo.Text = "";

            lblAccName.Text = "";
            lblAccRelationship.Text = "";
            lblAccContact.Text = "";

            lblRoomNo.Text = "";
            lblBedNo.Text = "";
            lblAdmissionDate.Text = "";
        }

        // Ligtas na pagkuha ng text (walang error kapag NULL)
        private static string Val(DataRow row, string col)
        {
            return row[col] == DBNull.Value ? "" : row[col].ToString().Trim();
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