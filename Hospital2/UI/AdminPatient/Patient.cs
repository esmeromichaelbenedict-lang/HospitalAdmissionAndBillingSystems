
using Hospital2.UI;
using HospitalPRAC.UI.AdminAdmitPatient;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalPRAC.UI.AdminPatient
{
    public partial class Patient : Form
    {
        private int selectedPatientID = 0;
        private int selectedAdmissionID = 0;

        string connectionString = @"Data Source=MIKEE-ESMERO\SQLEXPRESS;Initial Catalog=UserModel;Integrated Security=True;TrustServerCertificate=True;";

        // Pinakabagong admission ng bawat patient ang lalabas
        private const string BaseSelect = @"
            SELECT p.PatientID, p.FullName, p.DateOfBirth, p.Sex,
                   p.CivilStatus, p.Address, p.ContactNumber, p.Age,
                   a.admission_id, a.admission_datetime, a.reason_for_admission,
                   a.doctor_id, a.room_id, a.admission_type_id
            FROM dbo.Patient p
            OUTER APPLY (SELECT TOP 1 *
                         FROM dbo.admissions
                         WHERE PatientID = p.PatientID
                         ORDER BY admission_datetime DESC) a";

        public Patient()
        {
            InitializeComponent();
            LoadCombos();
            LoadPatients();
        }

        // ---------- LOAD ----------

        private void LoadCombos()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var doctors = new DataTable();
                new SqlDataAdapter("SELECT doctor_id, doctor_name FROM dbo.doctors", conn).Fill(doctors);
                cmbDoctor.DataSource = doctors;
                cmbDoctor.DisplayMember = "doctor_name";
                cmbDoctor.ValueMember = "doctor_id";
                cmbDoctor.SelectedIndex = -1;

                var rooms = new DataTable();
                new SqlDataAdapter("SELECT room_id, room_number FROM dbo.rooms", conn).Fill(rooms);
                cmbRoom.DataSource = rooms;
                cmbRoom.DisplayMember = "room_number";
                cmbRoom.ValueMember = "room_id";
                cmbRoom.SelectedIndex = -1;

                var types = new DataTable();
                new SqlDataAdapter("SELECT admission_type_id, admission_type_name FROM dbo.admission_types", conn).Fill(types);
                cmbAdmissionType.DataSource = types;
                cmbAdmissionType.DisplayMember = "admission_type_name";
                cmbAdmissionType.ValueMember = "admission_type_id";
                cmbAdmissionType.SelectedIndex = -1;
            }
        }

        private void LoadPatients()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(BaseSelect, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    ShowInGrid(table);
                }
            }
        }

        private void ShowInGrid(DataTable table)
        {
            dgvPatients.DataSource = table;


            foreach (string col in new[] { "admission_id", "doctor_id", "room_id", "admission_type_id" })
            {
                if (dgvPatients.Columns.Contains(col))
                    dgvPatients.Columns[col].Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = BaseSelect + @"
                    WHERE CONVERT(VARCHAR(20), p.PatientID) LIKE @search
                       OR p.FullName LIKE @search";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue(
                        "@search", "%" + txtSearch.Text.Trim() + "%");

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    ShowInGrid(table);
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null) return;

            var row = dgvPatients.CurrentRow;

            selectedPatientID = Convert.ToInt32(row.Cells["PatientID"].Value);

            txtFirstName.Text = row.Cells["FullName"].Value?.ToString();
            dtpDOB.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
            txtAge.Text = row.Cells["Age"].Value?.ToString();
            cmbSex.Text = row.Cells["Sex"].Value?.ToString();
            cmbCivilStatus.Text = row.Cells["CivilStatus"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();
            txtContactNumber.Text = row.Cells["ContactNumber"].Value?.ToString();

            object admId = row.Cells["admission_id"].Value;

            if (admId != null && admId != DBNull.Value)
            {
                selectedAdmissionID = Convert.ToInt32(admId);

                dtpAdmission.Value = Convert.ToDateTime(row.Cells["admission_datetime"].Value);
                txtReason.Text = row.Cells["reason_for_admission"].Value?.ToString();
                cmbDoctor.SelectedValue = row.Cells["doctor_id"].Value;
                cmbRoom.SelectedValue = row.Cells["room_id"].Value;
                cmbAdmissionType.SelectedValue = row.Cells["admission_type_id"].Value;
            }
            else
            {
                selectedAdmissionID = 0;
                dtpAdmission.Value = DateTime.Now;
                txtReason.Clear();
                cmbDoctor.SelectedIndex = -1;
                cmbRoom.SelectedIndex = -1;
                cmbAdmissionType.SelectedIndex = -1;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPatientID == 0)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to update this patient?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Age must be a number.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"UPDATE Patient
                                 SET FullName = @FullName,
                                     DateOfBirth = @DateOfBirth,
                                     Sex = @Sex,
                                     Age = @Age,
                                     CivilStatus = @CivilStatus,
                                     Address = @Address,
                                     ContactNumber = @ContactNumber
                                 WHERE PatientID = @PatientID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", selectedPatientID);
                    cmd.Parameters.AddWithValue("@FullName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@Sex", cmbSex.Text);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@CivilStatus", cmbCivilStatus.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text);
                    cmd.ExecuteNonQuery();
                }

                if (selectedAdmissionID != 0)
                {
                    string admQuery = @"UPDATE dbo.admissions
                                        SET admission_datetime = @AdmDate,
                                            reason_for_admission = @Reason,
                                            doctor_id = @DoctorID,
                                            room_id = @RoomID,
                                            admission_type_id = @TypeID
                                        WHERE admission_id = @AdmissionID";

                    using (SqlCommand cmd2 = new SqlCommand(admQuery, conn))
                    {
                        cmd2.Parameters.AddWithValue("@AdmDate", dtpAdmission.Value);
                        cmd2.Parameters.AddWithValue("@Reason", txtReason.Text);
                        cmd2.Parameters.AddWithValue("@DoctorID", cmbDoctor.SelectedValue ?? DBNull.Value);
                        cmd2.Parameters.AddWithValue("@RoomID", cmbRoom.SelectedValue ?? DBNull.Value);
                        cmd2.Parameters.AddWithValue("@TypeID", cmbAdmissionType.SelectedValue ?? DBNull.Value);
                        cmd2.Parameters.AddWithValue("@AdmissionID", selectedAdmissionID);
                        cmd2.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Patient updated successfully!");

            LoadPatients();
            ClearForm();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPatientID == 0)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this patient?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmdService = new SqlCommand(@"
                         DELETE FROM dbo.admission_services
                        WHERE admission_id IN
                        (
                            SELECT admission_id
                            FROM dbo.admissions
                            WHERE PatientID = @PatientID
                        )", conn))
                    {
                        cmdService.Parameters.AddWithValue("@PatientID", selectedPatientID);
                        cmdService.ExecuteNonQuery();
                    }

                    // Delete admissions
                    using (SqlCommand cmdAdm = new SqlCommand(@"
                DELETE FROM dbo.admissions
                WHERE PatientID = @PatientID", conn))
                    {
                        cmdAdm.Parameters.AddWithValue("@PatientID", selectedPatientID);
                        cmdAdm.ExecuteNonQuery();
                    }

                    // Delete patient
                    using (SqlCommand cmdPatient = new SqlCommand(@"
                DELETE FROM dbo.Patient
                WHERE PatientID = @PatientID", conn))
                    {
                        cmdPatient.Parameters.AddWithValue("@PatientID", selectedPatientID);
                        cmdPatient.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Patient deleted successfully!");

                LoadPatients();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting patient:\n\n" + ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ---------- HELPER ----------

        private void ClearForm()
        {
            selectedPatientID = 0;
            selectedAdmissionID = 0;

            txtFirstName.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            txtReason.Clear();

            cmbSex.SelectedIndex = -1;
            cmbCivilStatus.SelectedIndex = -1;
            cmbDoctor.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbAdmissionType.SelectedIndex = -1;

            dtpDOB.Value = DateTime.Today;
            dtpAdmission.Value = DateTime.Now;

            dgvPatients.ClearSelection();
        }

        private void btnAdmitPatient_Click(object sender, EventArgs e)
        {
            AdmitPatient admitPatient = new AdmitPatient();
            admitPatient.FormClosed += (s, args) => this.Close();
            admitPatient.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdminDashBoard dashboardForm = new AdminDashBoard();
            dashboardForm.FormClosed += (s, args) => this.Close();
            dashboardForm.Show();
            this.Hide();
        }

    }
}