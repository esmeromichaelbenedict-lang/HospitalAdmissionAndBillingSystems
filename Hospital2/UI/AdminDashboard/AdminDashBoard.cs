using HospitalPRAC.BusinessLogic.Controller;
using HospitalPRAC.Model;
using HospitalPRAC.UI.AdminPatient;
using HospitalPRAC.UI.RoomUI;

namespace Hospital2.UI
{
    public partial class AdminDashBoard : Form
    {
        private readonly DashboardController _controller = new DashboardController();

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
            try
            {
                LoadDashboardCounts();
                LoadRecentAdmissions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the dashboard.\n\n" + ex.Message,
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDashboardCounts()
        {
            var counts = _controller.GetCounts();
            label1.Text = counts.AvailableRooms.ToString();
            lblPatientCount.Text = counts.Patients.ToString();
            lblUserCount.Text = counts.Users.ToString();
        }

        private void LoadRecentAdmissions()
        {
            dgvRecentAdmissions.DataSource = _controller.GetRecentAdmissions(10);

            dgvRecentAdmissions.ReadOnly = true;
            dgvRecentAdmissions.AllowUserToAddRows = false;
            dgvRecentAdmissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentAdmissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Friendly headers (model property names -> what the user sees)
            dgvRecentAdmissions.Columns[nameof(AdmissionRecord.AdmissionId)].HeaderText = "Admission ID";
            dgvRecentAdmissions.Columns[nameof(AdmissionRecord.AdmittedOn)].HeaderText = "Admitted On";
            dgvRecentAdmissions.Columns[nameof(AdmissionRecord.AdmittedOn)].DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt";
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            Patient patientForm = new Patient();
            patientForm.FormClosed += (s, args) => this.Close();
            patientForm.Show();
            this.Hide();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            AdminRoomUI roomForm = new AdminRoomUI();
            roomForm.FormClosed += (s, args) => this.Close();
            roomForm.Show();
            this.Hide();
        }
    }
}