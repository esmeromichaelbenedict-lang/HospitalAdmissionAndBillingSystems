using Hospital2.UI;
using HospitalPRAC.BusinessLogic.Controller;
using HospitalPRAC.Model;
using HospitalPRAC.UI.AdminAdmitPatient;
using HospitalPRAC.UI.RoomUI;

namespace HospitalPRAC.UI.AdminPatient
{
    public partial class Patient : Form
    {
        private int selectedPatientID = 0;
        private readonly PatientController _controller = new PatientController();

        // Orihinal na kulay ng mga button, para maibalik kapag na-enable ulit
        private readonly Dictionary<Button, Color> _buttonColors = new Dictionary<Button, Color>();

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
            SetEditMode(false);
        }

        // Normal:  Add Patient at Edit lang ang pwede
        // Editing: Update, Delete at Cancel lang ang pwede
        private void SetEditMode(bool editing)
        {
            SetButton(btnAdd, !editing);
            SetButton(btnEdit, !editing);
            SetButton(btnUpdate, editing);
            SetButton(btnDelete, editing);
            SetButton(btnCancel, editing);
        }

        private void SetButton(Button button, bool enabled)
        {
            if (!_buttonColors.ContainsKey(button))
                _buttonColors[button] = button.BackColor;

            button.Enabled = enabled;
            button.BackColor = enabled ? _buttonColors[button] : Color.Gainsboro;
        }

        private void LoadPatients(string search = "")
        {
            try
            {
                dgvPatients.DataSource = _controller.GetPatients(search);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load patients: " + ex.Message);
            }
        }

        // Collects what the user typed into one object; the controller does the checking.
        private PatientInput ReadForm()
        {
            return new PatientInput
            {
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                MiddleName = txtMI.Text,
                Suffix = txtSuffix.Text,
                DateOfBirth = dtpDOB.Value,
                Sex = cmbSex.Text,
                CivilStatus = cmbCivilStatus.Text,
                Age = txtAge.Text,
                Address = txtAddress.Text,
                ContactNumber = txtContactNumber.Text,
                Weight = txtWeight.Text,
                Height = txtHeight.Text,
                CompanionName = txtCompanionName.Text,
                CompanionRelationship = txtCompanionRelationship.Text,
                CompanionContact = txtCompanionContact.Text
            };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPatients(txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OperationResult result = _controller.AddPatient(ReadForm());
            MessageBox.Show(result.Message);

            if (result.Success)
            {
                LoadPatients();
                ClearForm();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow?.DataBoundItem is not PatientRecord p)
            {
                return;
            }

            selectedPatientID = p.PatientID;

            txtLastName.Text = p.LastName;
            txtFirstName.Text = p.FirstName;
            txtMI.Text = p.MiddleName;
            txtSuffix.Text = p.Suffix;
            dtpDOB.Value = p.DateOfBirth;
            txtAge.Text = p.Age.ToString();
            cmbSex.Text = p.Sex;
            cmbCivilStatus.Text = p.CivilStatus;
            txtAddress.Text = p.Address;
            txtContactNumber.Text = p.ContactNumber;
            txtWeight.Text = p.Weight?.ToString();
            txtHeight.Text = p.Height?.ToString();

            txtCompanionName.Text = p.CompanionName;
            txtCompanionRelationship.Text = p.CompanionRelationship;
            txtCompanionContact.Text = p.CompanionContact;

            SetEditMode(true);
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

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to update this patient?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
            {
                return;
            }

            OperationResult result = _controller.UpdatePatient(selectedPatientID, ReadForm());
            MessageBox.Show(result.Message);

            if (result.Success)
            {
                LoadPatients();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPatientID == 0)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this patient?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.No)
            {
                return;
            }

            OperationResult result = _controller.DeletePatient(selectedPatientID);
            MessageBox.Show(result.Message);

            if (result.Success)
            {
                LoadPatients();
                ClearForm();
            }
        }

        private void ClearForm()
        {
            selectedPatientID = 0;
            SetEditMode(false);

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

        private void button8_Click(object sender, EventArgs e)
        {
            AdmitPatient admitPatient = new AdmitPatient();
            admitPatient.FormClosed += (s, args) => this.Close();
            admitPatient.Show();
            this.Hide();
        }
    }
}