using Hospital2.UI;
using HospitalPRAC.BusinessLogic.Controller;
using HospitalPRAC.Model;
using HospitalPRAC.UI.AdminAdmitPatient;
using HospitalPRAC.UI.AdminPatient;

namespace HospitalPRAC.UI.RoomUI
{
    public partial class AdminRoomUI : Form
    {
        private readonly RoomController _controller = new RoomController();
        private AdmittedPatientRow? _selected;
        private bool loading;

        public AdminRoomUI()
        {
            InitializeComponent();

            dgvPatients.ReadOnly = true;
            dgvPatients.MultiSelect = false;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRoomHistory.ReadOnly = true;
            dgvRoomHistory.MultiSelect = false;
            dgvRoomHistory.AllowUserToAddRows = false;
            dgvRoomHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoomHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBed.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpTransfer.Format = DateTimePickerFormat.Custom;
            dtpTransfer.CustomFormat = "MMM dd, yyyy  h:mm tt";
            txtReason.MaxLength = 255;

            Load += Room_Load;
            btnSearch.Click += btnSearch_Click;
            btnEdit.Click += btnEdit_Click;
            btnCancel.Click += btnCancel_Click;
            btnTransfer.Click += btnTransfer_Click;
            dgvPatients.SelectionChanged += dgvPatients_SelectionChanged;
            cboRoomType.SelectedIndexChanged += cboRoomType_SelectedIndexChanged;
            cboRoom.SelectedIndexChanged += cboRoom_SelectedIndexChanged;
            cboBed.SelectedIndexChanged += cboBed_SelectedIndexChanged;
        }

        void Room_Load(object? sender, EventArgs e)
        {
            LoadPatients("");
        }

        // =====================================================
        // PATIENT LIST
        // =====================================================

        void LoadPatients(string keyword)
        {
            try
            {
                dgvPatients.DataSource = _controller.GetAdmittedPatients(keyword);

                dgvPatients.Columns[nameof(AdmittedPatientRow.AdmissionId)].Visible = false;
                dgvPatients.Columns[nameof(AdmittedPatientRow.PatientID)].Visible = false;
                dgvPatients.Columns[nameof(AdmittedPatientRow.RoomId)].Visible = false;
                dgvPatients.Columns[nameof(AdmittedPatientRow.BedId)].Visible = false;
                dgvPatients.Columns[nameof(AdmittedPatientRow.Rate)].DefaultCellStyle.Format = "N2";
                dgvPatients.Columns[nameof(AdmittedPatientRow.Admitted)].DefaultCellStyle.Format = "MMM dd, yyyy h:mm tt";

                dgvPatients.CurrentCell = null;
                dgvPatients.ClearSelection();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load patients:\n\n" + ex.Message);
            }
        }

        void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadPatients(txtSearch.Text.Trim());
        }

        // Clicking a patient clears the form and shows that patient's room history.
        void dgvPatients_SelectionChanged(object? sender, EventArgs e)
        {
            ClearAll();

            if (dgvPatients.SelectedRows.Count > 0 &&
                dgvPatients.SelectedRows[0].DataBoundItem is AdmittedPatientRow row)
            {
                LoadHistory(row);
            }
        }

        // After a transfer, select the same patient again so their history is visible.
        void SelectAdmission(int admissionId)
        {
            foreach (DataGridViewRow gridRow in dgvPatients.Rows)
            {
                if (gridRow.DataBoundItem is AdmittedPatientRow r && r.AdmissionId == admissionId)
                {
                    dgvPatients.CurrentCell = gridRow.Cells[nameof(AdmittedPatientRow.Patient)];
                    gridRow.Selected = true;
                    break;
                }
            }
        }

        // =====================================================
        // ROOM HISTORY
        // =====================================================

        void LoadHistory(AdmittedPatientRow patient)
        {
            try
            {
                dgvRoomHistory.DataSource = _controller.GetTransferHistory(patient);

                dgvRoomHistory.Columns[nameof(RoomTransferRecord.FromRoom)].HeaderText = "From Room";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.FromBed)].HeaderText = "From Bed";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.FromRate)].HeaderText = "Previous Rate";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.ToRoom)].HeaderText = "To Room";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.ToBed)].HeaderText = "To Bed";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.ToRate)].HeaderText = "New Rate";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.StayedFrom)].HeaderText = "Stayed From";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.TransferredOn)].HeaderText = "Transferred On";

                dgvRoomHistory.Columns[nameof(RoomTransferRecord.FromRate)].DefaultCellStyle.Format = "N2";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.ToRate)].DefaultCellStyle.Format = "N2";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.StayedFrom)].DefaultCellStyle.Format = "MMM dd, yyyy h:mm tt";
                dgvRoomHistory.Columns[nameof(RoomTransferRecord.TransferredOn)].DefaultCellStyle.Format = "MMM dd, yyyy h:mm tt";

                dgvRoomHistory.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load room history:\n\n" + ex.Message);
            }
        }

        // =====================================================
        // PERSONAL INFORMATION / EDIT
        // =====================================================

        void ClearAll()
        {
            _selected = null;
            lblPatientName.Text = "";
            lblRoomNo.Text = "";
            lblRoomType.Text = "";
            lblBedNo.Text = "";
            lblRate.Text = "";
            lblAdmitted.Text = "";
            dgvRoomHistory.DataSource = null;
            ResetTransfer();
        }

        void ResetTransfer()
        {
            loading = true;
            cboRoomType.DataSource = null;
            cboRoom.DataSource = null;
            cboBed.DataSource = null;
            txtReason.Clear();
            loading = false;

            lblNewRate.Text = "";
        }

        void btnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0 ||
                dgvPatients.SelectedRows[0].DataBoundItem is not AdmittedPatientRow row)
            {
                MessageBox.Show("Click a patient in the list first.");
                return;
            }

            _selected = row;

            lblPatientName.Text = row.Patient;
            lblRoomNo.Text = row.Room;
            lblRoomType.Text = row.Type;
            lblBedNo.Text = row.BedId == null ? "Not assigned" : row.Bed;
            lblRate.Text = "₱" + row.Rate.ToString("N2");
            lblAdmitted.Text = row.Admitted.ToString("MMM dd, yyyy h:mm tt");

            ResetTransfer();
            dtpTransfer.Value = DateTime.Now;

            try
            {
                loading = true;
                cboRoomType.DataSource = _controller.GetRoomTypes();
                cboRoomType.SelectedIndex = -1;
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

        void btnCancel_Click(object? sender, EventArgs e)
        {
            dgvPatients.CurrentCell = null;
            dgvPatients.ClearSelection();
            ClearAll();
        }

        // =====================================================
        // TRANSFER DROPDOWNS
        // =====================================================

        void cboRoomType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (loading || cboRoomType.SelectedItem is not string roomType) return;

            try
            {
                loading = true;
                cboBed.DataSource = null;
                lblNewRate.Text = "";
                cboRoom.DataSource = _controller.GetRooms(roomType);
                cboRoom.DisplayMember = nameof(RoomOption.RoomNumber);
                cboRoom.ValueMember = nameof(RoomOption.RoomID);
                cboRoom.SelectedIndex = -1;
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

        void cboRoom_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (loading || cboRoom.SelectedItem is not RoomOption room) return;

            try
            {
                loading = true;
                lblNewRate.Text = "";
                cboBed.DataSource = _controller.GetBeds(room.RoomID);
                cboBed.DisplayMember = nameof(BedOption.BedNumber);
                cboBed.ValueMember = nameof(BedOption.BedID);
                cboBed.SelectedIndex = -1;
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

        void cboBed_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (loading || cboBed.SelectedItem is not BedOption bed) return;

            lblNewRate.Text = "₱" + bed.DailyRate.ToString("N2");
        }

        // =====================================================
        // TRANSFER
        // =====================================================

        void btnTransfer_Click(object? sender, EventArgs e)
        {
            var request = new TransferRequest
            {
                AdmissionId = _selected?.AdmissionId ?? 0,
                PatientId = _selected?.PatientID ?? 0,
                CurrentRoomId = _selected?.RoomId ?? 0,
                CurrentBedId = _selected?.BedId,
                AdmissionDate = _selected?.Admitted ?? DateTime.MinValue,
                NewRoomId = (cboRoom.SelectedItem as RoomOption)?.RoomID ?? 0,
                NewBed = cboBed.SelectedItem as BedOption,
                TransferDateTime = dtpTransfer.Value,
                Reason = txtReason.Text
            };

            int admissionId = request.AdmissionId;

            OperationResult result = _controller.Transfer(request);
            MessageBox.Show(result.Message);

            if (result.Success)
            {
                LoadPatients(txtSearch.Text.Trim());
                SelectAdmission(admissionId);   // shows the updated Room History
            }
        }

        // =====================================================
        // NAVIGATION
        // =====================================================

        private void btnAdmitting_Click(object sender, EventArgs e)
        {
            AdmitPatient admitPatientForm = new AdmitPatient();
            admitPatientForm.FormClosed += (s, args) => this.Close();
            admitPatientForm.Show();
            this.Hide();
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
            AdminDashBoard adminDashBoard = new AdminDashBoard();
            adminDashBoard.FormClosed += (s, args) => this.Close();
            adminDashBoard.Show();
            this.Hide();
        }
    }
}