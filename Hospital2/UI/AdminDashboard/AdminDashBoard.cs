using HospitalPRAC.UI.AdminPatient;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hospital2.UI
{
    public partial class AdminDashBoard : Form
    {
        string connectionString = @"Data Source=MIKEE-ESMERO\SQLEXPRESS;Initial Catalog=UserModel;Integrated Security=True;TrustServerCertificate=True;";
        public AdminDashBoard()
        {
            InitializeComponent();
            RefreshDashboard();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible) RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            LoadDashboardCounts();
            LoadRecentAdmissions();
        }

        private void LoadDashboardCounts()
        {
            string query = @"
                SELECT
                    (SELECT COUNT(*) FROM dbo.rooms r
                     WHERE NOT EXISTS (SELECT 1 FROM dbo.admissions a WHERE a.room_id = r.room_id)) AS AvailableRooms,
                    (SELECT COUNT(*) FROM dbo.Patient) AS Patients,
                    (SELECT COUNT(*) FROM dbo.Users)   AS Users";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        label1.Text = reader["AvailableRooms"].ToString();
                        lblPatientCount.Text = reader["Patients"].ToString();
                        lblUserCount.Text = reader["Users"].ToString();
                    }
                }
            }
        }



        private void LoadRecentAdmissions()
        {
            string query = @"
                SELECT TOP 10
                       a.admission_id          AS [Admission ID],
                       p.FullName              AS [Patient],
                       d.doctor_name           AS [Doctor],
                       r.room_number           AS [Room],
                       t.admission_type_name   AS [Type],
                       a.reason_for_admission  AS [Reason],
                       a.admission_datetime    AS [Admitted On]
                FROM dbo.admissions a
                INNER JOIN dbo.Patient p          ON p.PatientID = a.PatientID
                LEFT JOIN  dbo.doctors d          ON d.doctor_id = a.doctor_id
                LEFT JOIN  dbo.rooms r            ON r.room_id = a.room_id
                LEFT JOIN  dbo.admission_types t  ON t.admission_type_id = a.admission_type_id
                ORDER BY a.admission_datetime DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);


                dgvRecentAdmissions.DataSource = table;
            }

            dgvRecentAdmissions.ReadOnly = true;
            dgvRecentAdmissions.AllowUserToAddRows = false;
            dgvRecentAdmissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentAdmissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecentAdmissions.Columns["Admitted On"].DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt";
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            Patient patientForm = new Patient();
            patientForm.FormClosed += (s, args) => this.Close();
            patientForm.Show();
            this.Hide();

        }
    }
}

