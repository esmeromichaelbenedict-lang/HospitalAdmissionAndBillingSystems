using HospitalPRAC.BusinessLogic.Controller;
using HospitalPRAC.Model;

namespace Hospital2.UI.NurseDashboard
{
    public partial class NurseDashboard : Form
    {
        private readonly NurseController _controller = new NurseController();
        private NursePatientInfo? _current;

        // All Medicine ComboBoxes
        private ComboBox[] AllCombos =>
            new[]
            {
                cmbAnalgesics,
                cmbBetaBlockers,
                cmbIVFluids,
                cmbSyringeIVCannula
            };

        public NurseDashboard()
        {
            InitializeComponent();

            Load -= NurseDashboard_Load;
            Load += NurseDashboard_Load;

            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            dgvPatients.CellDoubleClick -= dgvPatients_CellDoubleClick;
            dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;

            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnAdd_Click;

            // DataGridView Settings
            dgvPatients.ReadOnly = true;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.MultiSelect = false;
            dgvPatients.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.RowHeadersVisible = false;
        }

        // FORM LOAD
        private void NurseDashboard_Load(object? sender, EventArgs e)
        {
            ClearLabels();

            try
            {
                BindCombo(cmbAnalgesics, "Analgesics");
                BindCombo(cmbBetaBlockers, "BetaBlockers");
                BindCombo(cmbIVFluids, "IVFluids");
                BindCombo(cmbSyringeIVCannula, "SyringeIVCannula");

                LoadPatients("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading the dashboard:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // COMBO BOXES
        private void BindCombo(ComboBox cmb, string category)
        {
            cmb.DataSource = null;
            cmb.DataSource = _controller.GetMedicines(category);

            cmb.DisplayMember = nameof(MedicineItem.Display);
            cmb.ValueMember = nameof(MedicineItem.MedicineID);

            cmb.SelectedIndex = -1;
        }

        // SEARCH PATIENT
        private void btnSearch_Click(object? sender, EventArgs e)
        {
            try
            {
                LoadPatients(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error searching patients:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // LOAD PATIENTS TO DATAGRIDVIEW
        private void LoadPatients(string keyword)
        {
            _current = null;
            ClearLabels();

            dgvPatients.DataSource = null;

            var patients = _controller.SearchPatients(keyword).ToList();

            dgvPatients.DataSource = patients;

            dgvPatients.ClearSelection();
        }

        // DOUBLE CLICK PATIENT
        private void dgvPatients_CellDoubleClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvPatients.Rows[e.RowIndex].DataBoundItem
                is not PatientListItem item)
                return;

            try
            {
                _current = _controller.GetPatientInfo(item.PatientID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading the patient:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (_current == null)
                return;

            // DISPLAY PATIENT INFORMATION
            lblFullName.Text = _current.FullName;
            lblDOB.Text = _current.DateOfBirth?.ToString("MMM dd, yyyy") ?? "-";
            lblSex.Text = _current.Sex;
            lblHeight.Text = _current.Height + " ft";
            lblWeight.Text = _current.Weight + " kg";
            lblAge.Text = _current.Age.ToString();
            lblRoomType.Text = _current.RoomType;
            lblRoom.Text = _current.RoomNumber;
            lblBed.Text = _current.BedNumber;
        }

        // ADD MEDICINES
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (_current == null)
            {
                MessageBox.Show(
                    "Please double-click a patient first.",
                    "Add",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var ids = AllCombos
                .Where(c => c.SelectedIndex >= 0 &&
                            c.SelectedValue != null)
                .Select(c => Convert.ToInt32(c.SelectedValue))
                .ToList();

            try
            {
                int added = _controller.AddMedicines(
                    _current.AdmissionId,
                    ids);

                MessageBox.Show(
                    added + " item(s) added to the account.",
                    "Add",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // CLEAR COMBOBOXES AFTER ADDING
                foreach (ComboBox c in AllCombos)
                {
                    c.SelectedIndex = -1;
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Add",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not save:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // CLEAR LABELS
        private void ClearLabels()
        {
            lblFullName.Text = "";
            lblDOB.Text = "";
            lblSex.Text = "";
            lblHeight.Text = "";
            lblWeight.Text = "";
            lblAge.Text = "";
            lblRoomType.Text = "";
            lblRoom.Text = "";
            lblBed.Text = "";
        }
    }
}