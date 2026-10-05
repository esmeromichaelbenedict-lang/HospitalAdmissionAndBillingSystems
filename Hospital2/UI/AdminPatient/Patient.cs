using Hospital2.UI;
using HospitalPRAC.UI.AdminAdmitPatient;
using HospitalPRAC.UI.RoomUI;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalPRAC.UI.AdminPatient
{
    public partial class Patient : Form
    {
        private int selectedPatientID = 0;
        string connectionString = @"Data Source=MIKEE-ESMERO\SQLEXPRESS;Initial Catalog=UserModel;Integrated Security=True;TrustServerCertificate=True;";

        private const string BaseSelect = @"
            SELECT p.PatientID, p.FullName, p.LastName, p.FirstName, p.MiddleName, p.Suffix,
                   p.DateOfBirth, p.Sex, p.CivilStatus, p.Address, p.ContactNumber, p.Age,
                   p.Weight, p.Height,
                   c.FullName AS CompanionName, c.Relationship AS CompanionRelationship,
                   c.ContactNumber AS CompanionContact,
                   a.admission_id, a.admission_datetime, a.reason_for_admission,
                   a.doctor_id, a.room_id, a.admission_type_id
            FROM dbo.Patient p
            OUTER APPLY (SELECT TOP 1 *
                         FROM dbo.admissions
                         WHERE PatientID = p.PatientID
                         ORDER BY admission_datetime DESC) a
            OUTER APPLY (SELECT TOP 1 *
                         FROM dbo.Companion
                         WHERE PatientID = p.PatientID
                         ORDER BY CompanionID DESC) c";
        public Patient()
        {
            InitializeComponent();

            txtLastName.MaxLength = 50;
            txtFirstName.MaxLength = 50;
            txtMI.MaxLength = 50;
            txtSuffix.MaxLength = 10;
            txtCompanionName.MaxLength = 100;
            txtCompanionRelationship.MaxLength = 50;
            txtCompanionContact.MaxLength = 20;

            LoadPatients();
        }
        private void LoadPatients(string search = "")
        {
            try
            {
                string query = BaseSelect;

                if (search != "")
                {
                    query += @" WHERE CONVERT(VARCHAR(20), p.PatientID) LIKE @search
                                   OR p.FullName LIKE @search
                                   OR p.LastName LIKE @search
                                   OR p.FirstName LIKE @search";
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    if (search != "")
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                    }

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvPatients.DataSource = table;
                }

                foreach (string col in new[] { "admission_id", "doctor_id", "room_id", "admission_type_id" })
                {
                    if (dgvPatients.Columns.Contains(col))
                        dgvPatients.Columns[col].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load patients: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPatients(txtSearch.Text.Trim());
        }

        private string MakeFullName()
        {
            string name = txtFirstName.Text.Trim();

            if (txtMI.Text.Trim() != "")
                name = name + " " + txtMI.Text.Trim();

            name = name + " " + txtLastName.Text.Trim();

            if (txtSuffix.Text.Trim() != "")
                name = name + " " + txtSuffix.Text.Trim();

            return name;
        }

        private object GetText(TextBox box)
        {
            if (box.Text.Trim() == "")
                return DBNull.Value;

            return box.Text.Trim();
        }

        private object GetNumber(TextBox box)
        {
            if (box.Text.Trim() == "")
                return DBNull.Value;

            return decimal.Parse(box.Text);
        }

        private bool CheckForm()
        {
            if (txtLastName.Text.Trim() == "" || txtFirstName.Text.Trim() == "")
            {
                MessageBox.Show("Last Name and First Name are required.");
                return false;
            }

            if (cmbSex.Text == "" || cmbCivilStatus.Text == "")
            {
                MessageBox.Show("Please select Sex and Civil Status.");
                return false;
            }

            if (dtpDOB.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Date of birth cannot be in the future.");
                return false;
            }

            int age;
            if (!int.TryParse(txtAge.Text, out age) || age < 0 || age > 130)
            {
                MessageBox.Show("Age must be a number from 0 to 130.");
                return false;
            }

            decimal number;

            if (txtWeight.Text.Trim() != "" &&
                (!decimal.TryParse(txtWeight.Text, out number) || number <= 0 || number > 500))
            {
                MessageBox.Show("Weight must be a number in kg. Example: 65.5");
                return false;
            }

            if (txtHeight.Text.Trim() != "" &&
                (!decimal.TryParse(txtHeight.Text, out number) || number <= 0 || number >= 10))
            {
                MessageBox.Show("Height must be a number in feet. Example: 5.6");
                return false;
            }

            if (txtCompanionName.Text.Trim() == "" &&
                (txtCompanionRelationship.Text.Trim() != "" || txtCompanionContact.Text.Trim() != ""))
            {
                MessageBox.Show("Please enter the Accompanying Person's full name.");
                return false;
            }

            return true;
        }

        private void AddPatientValues(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@FullName", MakeFullName());
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
            cmd.Parameters.AddWithValue("@MiddleName", GetText(txtMI));
            cmd.Parameters.AddWithValue("@Suffix", GetText(txtSuffix));
            cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value.Date);
            cmd.Parameters.AddWithValue("@Sex", cmbSex.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
            cmd.Parameters.AddWithValue("@CivilStatus", cmbCivilStatus.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text);
            cmd.Parameters.AddWithValue("@Weight", GetNumber(txtWeight));
            cmd.Parameters.AddWithValue("@Height", GetNumber(txtHeight));
        }

        private void DeleteRows(SqlConnection conn, string tableName, int patientId)
        {
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM dbo." + tableName + " WHERE PatientID = @PatientID", conn))
            {
                cmd.Parameters.AddWithValue("@PatientID", patientId);
                cmd.ExecuteNonQuery();
            }
        }

        private void SaveCompanion(SqlConnection conn, int patientId)
        {
            DeleteRows(conn, "Companion", patientId);

            if (txtCompanionName.Text.Trim() == "")
            {
                return;
            }

            string query = @"INSERT INTO dbo.Companion (PatientID, FullName, Relationship, ContactNumber)
                             VALUES (@PatientID, @FullName, @Relationship, @ContactNumber)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PatientID", patientId);
                cmd.Parameters.AddWithValue("@FullName", txtCompanionName.Text.Trim());
                cmd.Parameters.AddWithValue("@Relationship", GetText(txtCompanionRelationship));
                cmd.Parameters.AddWithValue("@ContactNumber", GetText(txtCompanionContact));
                cmd.ExecuteNonQuery();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckForm())
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO dbo.Patient
                                        (FullName, LastName, FirstName, MiddleName, Suffix, DateOfBirth,
                                         Sex, Age, CivilStatus, Address, ContactNumber, Weight, Height)
                                     VALUES
                                        (@FullName, @LastName, @FirstName, @MiddleName, @Suffix, @DateOfBirth,
                                         @Sex, @Age, @CivilStatus, @Address, @ContactNumber, @Weight, @Height);
                                     SELECT CAST(SCOPE_IDENTITY() AS int);";

                    int newPatientId;

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        AddPatientValues(cmd);
                        newPatientId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    SaveCompanion(conn, newPatientId);
                }

                MessageBox.Show("Patient added successfully!");
                LoadPatients();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add the patient: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var row = dgvPatients.CurrentRow;

            if (row == null || row.Cells["PatientID"].Value == null || row.Cells["PatientID"].Value == DBNull.Value)
            {
                return;
            }

            selectedPatientID = Convert.ToInt32(row.Cells["PatientID"].Value);

            txtLastName.Text = row.Cells["LastName"].Value?.ToString();
            txtFirstName.Text = row.Cells["FirstName"].Value?.ToString();
            txtMI.Text = row.Cells["MiddleName"].Value?.ToString();
            txtSuffix.Text = row.Cells["Suffix"].Value?.ToString();

            if (row.Cells["DateOfBirth"].Value != null && row.Cells["DateOfBirth"].Value != DBNull.Value)
            {
                dtpDOB.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
            }

            txtAge.Text = row.Cells["Age"].Value?.ToString();
            cmbSex.Text = row.Cells["Sex"].Value?.ToString();
            cmbCivilStatus.Text = row.Cells["CivilStatus"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();
            txtContactNumber.Text = row.Cells["ContactNumber"].Value?.ToString();
            txtWeight.Text = row.Cells["Weight"].Value?.ToString();
            txtHeight.Text = row.Cells["Height"].Value?.ToString();

            txtCompanionName.Text = row.Cells["CompanionName"].Value?.ToString();
            txtCompanionRelationship.Text = row.Cells["CompanionRelationship"].Value?.ToString();
            txtCompanionContact.Text = row.Cells["CompanionContact"].Value?.ToString();
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

            if (!CheckForm())
            {
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

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE dbo.Patient
                                     SET FullName = @FullName,
                                         LastName = @LastName,
                                         FirstName = @FirstName,
                                         MiddleName = @MiddleName,
                                         Suffix = @Suffix,
                                         DateOfBirth = @DateOfBirth,
                                         Sex = @Sex,
                                         Age = @Age,
                                         CivilStatus = @CivilStatus,
                                         Address = @Address,
                                         ContactNumber = @ContactNumber,
                                         Weight = @Weight,
                                         Height = @Height
                                     WHERE PatientID = @PatientID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", selectedPatientID);
                        AddPatientValues(cmd);
                        cmd.ExecuteNonQuery();
                    }

                    SaveCompanion(conn, selectedPatientID);
                }

                MessageBox.Show("Patient updated successfully!");
                LoadPatients();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update the patient: " + ex.Message);
            }
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

                    DeleteRows(conn, "Companion", selectedPatientID);
                    DeleteRows(conn, "admissions", selectedPatientID);
                    DeleteRows(conn, "Patient", selectedPatientID);
                }

                MessageBox.Show("Patient deleted successfully!");
                LoadPatients();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete the patient: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            selectedPatientID = 0;

            txtLastName.Clear();
            txtFirstName.Clear();
            txtMI.Clear();
            txtSuffix.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            txtWeight.Clear();
            txtHeight.Clear();

            txtCompanionName.Clear();
            txtCompanionRelationship.Clear();
            txtCompanionContact.Clear();

            cmbSex.SelectedIndex = -1;
            cmbCivilStatus.SelectedIndex = -1;

            dtpDOB.Value = DateTime.Today;

            dgvPatients.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdmitPatient admitPatient = new AdmitPatient();
            admitPatient.FormClosed += (s, args) => this.Close();
            admitPatient.Show();
            this.Hide();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            AdminRoomUI adminRoomUI = new AdminRoomUI();
            adminRoomUI.FormClosed += (s, args) => this.Close();
            adminRoomUI.Show();
            this.Hide();
        }

        private void btnRoom_Click_1(object sender, EventArgs e)
        {
            AdminRoomUI adminRoomUI = new AdminRoomUI();
            adminRoomUI.FormClosed += (s, args) => this.Close();
            adminRoomUI.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdminDashBoard adminDashBoard = new AdminDashBoard();
            adminDashBoard.FormClosed += (s, args) => this.Close();
            adminDashBoard.Show();
            this.Hide();
        }
    }
}