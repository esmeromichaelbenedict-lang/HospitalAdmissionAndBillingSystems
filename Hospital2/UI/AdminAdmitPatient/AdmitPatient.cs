using Hospital2.UI;
using HospitalPRAC.BusinessLogic.Controller;
using HospitalPRAC.Model;
using HospitalPRAC.UI.AdminPatient;
using System.ComponentModel;

namespace HospitalPRAC.UI.AdminAdmitPatient
{
    public partial class AdmitPatient : Form
    {
        private readonly AdmissionController _controller = new AdmissionController();

        // The patient picked from the search results (null until the user double-clicks one).
        private PatientRecord? _selectedPatient;

        // Services chosen for this admission; the grid shows this list.
        private readonly BindingList<ServiceItem> _selectedServices = new BindingList<ServiceItem>();

        // True while dropdowns are being filled, so their change events are ignored.
        private bool loading;

        public AdmitPatient()
        {
            InitializeComponent();

            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBed.DropDownStyle = ComboBoxStyle.DropDownList;

            SetupServiceGrid();
            LoadLookups();
            LoadRoomTypes();
            LoadPatients();
            ClearPatientLabels();

            // Events (wired here, so do not also create them by double-clicking in the Designer)
            btnSearch.Click += btnSearch_Click;
            dgvPatientList.CellDoubleClick += dgvPatientList_CellDoubleClick;
            cmbService.SelectedIndexChanged += cmbService_SelectedIndexChanged;
            btnAddService.Click += btnAddService_Click;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
        }

        // =====================================================
        // SETUP
        // =====================================================

        private void SetupServiceGrid()
        {
            dgvServices.DataSource = _selectedServices;

            dgvServices.Columns[nameof(ServiceItem.ServiceID)].Visible = false;
            dgvServices.Columns[nameof(ServiceItem.ServiceName)].HeaderText = "Service";
            dgvServices.Columns[nameof(ServiceItem.Price)].HeaderText = "Fee";
            dgvServices.Columns[nameof(ServiceItem.Price)].DefaultCellStyle.Format = "₱#,##0.00";

            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.AllowUserToAddRows = false;
            dgvServices.ReadOnly = true;
        }

        private void LoadLookups()
        {
            try
            {
                cmbDoctor.Items.Clear();
                cmbDoctor.Items.AddRange(_controller.GetDoctors().ToArray());

                cmbAdmissionType.Items.Clear();
                cmbAdmissionType.Items.AddRange(_controller.GetAdmissionTypes().ToArray());

                cmbService.Items.Clear();
                cmbService.Items.AddRange(_controller.GetServices().ToArray());

                cmbDoctor.SelectedIndex = -1;
                cmbAdmissionType.SelectedIndex = -1;
                cmbService.SelectedIndex = -1;
                lblServiceFee.Text = "₱0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // ROOM TYPE -> ROOM -> BED
        // =====================================================

        private void LoadRoomTypes()
        {
            try
            {
                loading = true;
                cmbRoom.DataSource = null;
                cmbBed.DataSource = null;
                cmbRoomType.DataSource = _controller.GetRoomTypes();
                cmbRoomType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load room types:\n\n" + ex.Message);
            }
            finally
            {
                loading = false;
            }
        }

        private void cmbRoomType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (loading || cmbRoomType.SelectedItem is not string roomType) return;

            try
            {
                loading = true;
                cmbBed.DataSource = null;
                cmbRoom.DataSource = _controller.GetRooms(roomType);
                cmbRoom.DisplayMember = nameof(RoomOption.RoomNumber);
                cmbRoom.ValueMember = nameof(RoomOption.RoomID);
                cmbRoom.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load rooms:\n\n" + ex.Message);
            }
            finally
            {
                loading = false;
            }
        }

        private void cmbRoom_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (loading || cmbRoom.SelectedItem is not RoomOption room) return;

            try
            {
                loading = true;
                cmbBed.DataSource = _controller.GetBeds(room.RoomID);
                cmbBed.DisplayMember = nameof(BedOption.BedNumber);
                cmbBed.ValueMember = nameof(BedOption.BedID);
                cmbBed.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load beds:\n\n" + ex.Message);
            }
            finally
            {
                loading = false;
            }
        }

        // =====================================================
        // SEARCH PATIENT
        // =====================================================

        private void LoadPatients(string search = "")
        {
            try
            {
                dgvPatientList.DataSource = _controller.SearchPatients(search);

                dgvPatientList.ReadOnly = true;
                dgvPatientList.AllowUserToAddRows = false;
                dgvPatientList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPatientList.MultiSelect = false;

                // Show only the columns needed to pick the right patient.
                string[] hidden =
                {
                    nameof(PatientRecord.LastName), nameof(PatientRecord.FirstName),
                    nameof(PatientRecord.MiddleName), nameof(PatientRecord.Suffix),
                    nameof(PatientRecord.CivilStatus), nameof(PatientRecord.Address),
                    nameof(PatientRecord.Weight), nameof(PatientRecord.Height),
                    nameof(PatientRecord.CompanionName), nameof(PatientRecord.CompanionRelationship),
                    nameof(PatientRecord.CompanionContact)
                };

                foreach (string name in hidden)
                {
                    if (dgvPatientList.Columns.Contains(name))
                        dgvPatientList.Columns[name].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load patients:\n\n" + ex.Message);
            }
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadPatients(txtSearch.Text.Trim());
        }

        // Double-click a row: copy that patient into the Personal Information labels.
        private void dgvPatientList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvPatientList.Rows[e.RowIndex].DataBoundItem is not PatientRecord patient)
                return;

            _selectedPatient = patient;

            lblFullName.Text = patient.FullName;
            lblDateOfBirth.Text = patient.DateOfBirth.ToString("MMM dd, yyyy");
            lblAge.Text = patient.Age.ToString();
            lbl1.Text = patient.Sex;
            lblCivilStatus.Text = patient.CivilStatus;
            lblAddress.Text = patient.Address;
            lblContactNumber.Text = patient.ContactNumber;
        }

        private void ClearPatientLabels()
        {
            _selectedPatient = null;

            lblFullName.Text = string.Empty;
            lblDateOfBirth.Text = string.Empty;
            lblAge.Text = string.Empty;
            lbl1.Text = string.Empty;
            lblCivilStatus.Text = string.Empty;
            lblAddress.Text = string.Empty;
            lblContactNumber.Text = string.Empty;
        }

        // =====================================================
        // SERVICES
        // =====================================================

        private void cmbService_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbService.SelectedItem is ServiceItem service)
                lblServiceFee.Text = "₱" + service.Price.ToString("N2");
            else
                lblServiceFee.Text = "₱0.00";
        }

        private void btnAddService_Click(object? sender, EventArgs e)
        {
            OperationResult result =
                _controller.AddService(_selectedServices, cmbService.SelectedItem as ServiceItem);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Service",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cmbService.SelectedIndex = -1;
            lblServiceFee.Text = "₱0.00";
        }

        // =====================================================
        // ADMIT
        // =====================================================

        private void btnAdmitPatient_Click(object sender, EventArgs e)
        {
            var request = new AdmissionRequest
            {
                PatientID = _selectedPatient?.PatientID ?? 0,
                AdmissionDateTime = dtpAdmissionDateTime.Value,
                Reason = txtReasonForAdmission.Text,
                Doctor = cmbDoctor.SelectedItem as DoctorItem,
                Room = cmbRoom.SelectedItem as RoomOption,
                Bed = cmbBed.SelectedItem as BedOption,
                AdmissionType = cmbAdmissionType.SelectedItem as AdmissionTypeItem,
                Services = _selectedServices.ToList()
            };

            OperationResult result = _controller.AdmitPatient(request);
            MessageBox.Show(result.Message);

            if (result.Success)
            {
                ClearAdmissionForm();
            }
        }

        private void ClearAdmissionForm()
        {
            ClearPatientLabels();

            txtReasonForAdmission.Clear();
            cmbDoctor.SelectedIndex = -1;
            cmbAdmissionType.SelectedIndex = -1;
            cmbService.SelectedIndex = -1;

            // Reload the room chain so the bed that was just taken no longer shows up.
            LoadRoomTypes();

            dtpAdmissionDateTime.Value = DateTime.Now;
            lblServiceFee.Text = "₱0.00";

            _selectedServices.Clear();

            dgvPatientList.ClearSelection();
        }

        // =====================================================
        // NAVIGATION
        // =====================================================

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