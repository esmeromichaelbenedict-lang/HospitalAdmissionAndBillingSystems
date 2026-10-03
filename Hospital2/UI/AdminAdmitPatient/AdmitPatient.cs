using Hospital2.UI;
using HospitalPRAC.UI.AdminPatient;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HospitalPRAC.UI.AdminAdmitPatient
{
    public partial class AdmitPatient : Form
    {
        // SQL Server connection
        private string connectionString =
            @"Data Source=MIKEE-ESMERO\SQLEXPRESS;
              Initial Catalog=UserModel;
              Integrated Security=True;
              TrustServerCertificate=True";

        // Temporary table for selected services
        private DataTable serviceTable = new DataTable();

        public AdmitPatient()
        {
            InitializeComponent();

            // Setup DataGridView
            SetupServiceTable();

            // Load data from SQL Server
            LoadDoctors();
            LoadRooms();
            LoadAdmissionTypes();
            LoadServices();

            // Events
            cmbService.SelectedIndexChanged += cmbService_SelectedIndexChanged;
            btnAddService.Click += btnAddService_Click;
        }


        // =====================================================
        // SETUP DATAGRIDVIEW
        // =====================================================

        private void SetupServiceTable()
        {
            serviceTable.Columns.Add("ServiceID", typeof(int));
            serviceTable.Columns.Add("ServiceName", typeof(string));
            serviceTable.Columns.Add("Price", typeof(decimal));

            dgvServices.DataSource = serviceTable;

            // Hide ServiceID
            dgvServices.Columns["ServiceID"].Visible = false;

            // Column headers
            dgvServices.Columns["ServiceName"].HeaderText = "Service";
            dgvServices.Columns["Price"].HeaderText = "Fee";

            // Currency format
            dgvServices.Columns["Price"]
                .DefaultCellStyle.Format = "₱#,##0.00";

            // DataGridView settings
            dgvServices.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvServices.AllowUserToAddRows = false;
            dgvServices.ReadOnly = true;
        }


        // =====================================================
        // LOAD DOCTORS
        // =====================================================

        private void LoadDoctors()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query =
                        "SELECT doctor_id, doctor_name, consultation_fee " +
                        "FROM doctors " +
                        "ORDER BY doctor_name";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            cmbDoctor.Items.Clear();

                            while (reader.Read())
                            {
                                DoctorItem doctor = new DoctorItem();

                                doctor.DoctorID =
                                    Convert.ToInt32(
                                        reader["doctor_id"]);

                                doctor.DoctorName =
                                    reader["doctor_name"].ToString();

                                doctor.ConsultationFee =
                                    Convert.ToDecimal(
                                        reader["consultation_fee"]);

                                cmbDoctor.Items.Add(doctor);
                            }
                        }
                    }
                }

                cmbDoctor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading doctors:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query =
                        "SELECT room_id, room_number, room_type, daily_rate " +
                        "FROM rooms " +
                        "ORDER BY room_number";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            cmbRoom.Items.Clear();

                            while (reader.Read())
                            {
                                RoomItem room = new RoomItem();

                                room.RoomID =
                                    Convert.ToInt32(
                                        reader["room_id"]);

                                room.RoomNumber =
                                    reader["room_number"].ToString();

                                room.RoomType =
                                    reader["room_type"].ToString();

                                room.DailyRate =
                                    Convert.ToDecimal(
                                        reader["daily_rate"]);

                                cmbRoom.Items.Add(room);
                            }
                        }
                    }
                }

                cmbRoom.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading rooms:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadAdmissionTypes()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query =
                        "SELECT admission_type_id, admission_type_name " +
                        "FROM admission_types " +
                        "ORDER BY admission_type_id";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            cmbAdmissionType.Items.Clear();

                            while (reader.Read())
                            {
                                AdmissionTypeItem type =
                                    new AdmissionTypeItem();

                                type.AdmissionTypeID =
                                    Convert.ToInt32(
                                        reader["admission_type_id"]);

                                type.AdmissionTypeName =
                                    reader["admission_type_name"]
                                    .ToString();

                                cmbAdmissionType.Items.Add(type);
                            }
                        }
                    }
                }

                cmbAdmissionType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading admission types:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadServices()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query =
                        "SELECT ServiceID, ServiceName, Price " +
                        "FROM Services " +
                        "ORDER BY ServiceName";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            cmbService.Items.Clear();

                            while (reader.Read())
                            {
                                ServiceItem service =
                                    new ServiceItem();

                                service.ServiceID =
                                    Convert.ToInt32(
                                        reader["ServiceID"]);

                                service.ServiceName =
                                    reader["ServiceName"].ToString();

                                service.Price =
                                    Convert.ToDecimal(
                                        reader["Price"]);

                                cmbService.Items.Add(service);
                            }
                        }
                    }
                }

                cmbService.SelectedIndex = -1;

                lblServiceFee.Text = "₱0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading services:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmbService_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cmbService.SelectedItem is ServiceItem service)
            {
                lblServiceFee.Text =
                    "₱" + service.Price.ToString("N2");
            }
            else
            {
                lblServiceFee.Text = "₱0.00";
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (cmbService.SelectedItem == null)
                return;

            ServiceItem service = (ServiceItem)cmbService.SelectedItem;

            foreach (DataRow row in serviceTable.Rows)
            {
                if (Convert.ToInt32(row["ServiceID"]) == service.ServiceID)
                {
                    MessageBox.Show(
                        "This service is already added.",
                        "Duplicate Service",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            serviceTable.Rows.Add(
                service.ServiceID,
                service.ServiceName,
                service.Price
            );

            cmbService.SelectedIndex = -1;
            lblServiceFee.Text = "₱0.00";
        }

        private class DoctorItem
        {
            public int DoctorID { get; set; }

            public string DoctorName { get; set; }

            public decimal ConsultationFee { get; set; }

            public override string ToString()
            {
                return DoctorName;
            }
        }

        private class RoomItem
        {
            public int RoomID { get; set; }

            public string RoomNumber { get; set; }

            public string RoomType { get; set; }

            public decimal DailyRate { get; set; }

            public override string ToString()
            {
                return RoomNumber + " - " + RoomType;
            }
        }

        private class AdmissionTypeItem
        {
            public int AdmissionTypeID { get; set; }

            public string AdmissionTypeName { get; set; }

            public override string ToString()
            {
                return AdmissionTypeName;
            }
        }



        private class ServiceItem
        {
            public int ServiceID { get; set; }

            public string ServiceName { get; set; }

            public decimal Price { get; set; }

            public override string ToString()
            {
                return ServiceName;
            }
        }

        private void btnAdmitPatient_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction tr = con.BeginTransaction();

                try
                {
                    string q1 = @"INSERT INTO Patient
                (FullName, DateOfBirth, Sex, CivilStatus, Address, ContactNumber, Age)
                VALUES (@name,@dob,@sex,@status,@address,@contact,@age);
                SELECT SCOPE_IDENTITY();";

                    int patientID;

                    using (SqlCommand cmd = new SqlCommand(q1, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value.Date);
                        cmd.Parameters.AddWithValue("@sex", cmbSex.Text);
                        cmd.Parameters.AddWithValue("@status", cmbCivilStatus.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@contact", txtContactNumber.Text);
                        cmd.Parameters.AddWithValue("@age", txtAge.Text);

                        patientID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    DoctorItem doctor = (DoctorItem)cmbDoctor.SelectedItem;
                    RoomItem room = (RoomItem)cmbRoom.SelectedItem;
                    AdmissionTypeItem type =
                        (AdmissionTypeItem)cmbAdmissionType.SelectedItem;

                    string q2 = @"INSERT INTO admissions
                (PatientID, admission_datetime, reason_for_admission,
                 doctor_id, room_id, admission_type_id)
                VALUES (@pid,@date,@reason,@doctor,@room,@type);
                SELECT SCOPE_IDENTITY();";

                    int admissionID;

                    using (SqlCommand cmd = new SqlCommand(q2, con, tr))
                    {
                        cmd.Parameters.AddWithValue("@pid", patientID);
                        cmd.Parameters.AddWithValue("@date", dtpAdmissionDateTime.Value);
                        cmd.Parameters.AddWithValue("@reason", txtReasonForAdmission.Text);
                        cmd.Parameters.AddWithValue("@doctor", doctor.DoctorID);
                        cmd.Parameters.AddWithValue("@room", room.RoomID);
                        cmd.Parameters.AddWithValue("@type", type.AdmissionTypeID);

                        admissionID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    foreach (DataRow row in serviceTable.Rows)
                    {
                        string q3 = @"INSERT INTO admission_services
                    (admission_id, ServiceID, Price)
                    VALUES (@aid,@sid,@price)";

                        using (SqlCommand cmd = new SqlCommand(q3, con, tr))
                        {
                            cmd.Parameters.AddWithValue("@aid", admissionID);
                            cmd.Parameters.AddWithValue("@sid", row["ServiceID"]);
                            cmd.Parameters.AddWithValue("@price", row["Price"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tr.Commit();

                    txtFullName.Clear();
                    txtAge.Clear();
                    txtAddress.Clear();
                    txtContactNumber.Clear();
                    txtReasonForAdmission.Clear();

                    cmbSex.SelectedIndex = -1;
                    cmbCivilStatus.SelectedIndex = -1;
                    cmbDoctor.SelectedIndex = -1;
                    cmbRoom.SelectedIndex = -1;
                    cmbAdmissionType.SelectedIndex = -1;
                    cmbService.SelectedIndex = -1;

                    dtpDateOfBirth.Value = DateTime.Today;
                    dtpAdmissionDateTime.Value = DateTime.Now;

                    lblServiceFee.Text = "₱0.00";

                    serviceTable.Rows.Clear();

                    MessageBox.Show("Patient admitted successfully!");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            Patient patientForm = new Patient();
            patientForm.FormClosed += (s, args) => this.Close();
            patientForm.Show();
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