using HospitalPRAC;
using HospitalPRAC.BusinessLogic.Controller;
using HospitalPRAC.Model;
using System;
using System.Windows.Forms;

namespace Hospital2.UI.CashierDashboard
{
    public partial class CashierDashboard : Form
    {
        private readonly CashierController _controller = new CashierController();

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
        private void CashierDashboard_Load(object? sender, EventArgs e)
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
        private void btnSearch_Click(object? sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            LoadPatients(kw);
            ClearDetails();

            if (kw != "" && dgvPatients.Rows.Count == 0)
                MessageBox.Show("Walang nahanap na patient.", "Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Enter key sa textbox
        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
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
            try
            {
                dgvPatients.DataSource = _controller.SearchPatients(keyword);
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
            string[] hidden =
            {
                nameof(PatientRecord.FullName), nameof(PatientRecord.Suffix),
                nameof(PatientRecord.Age), nameof(PatientRecord.Sex),
                nameof(PatientRecord.Address), nameof(PatientRecord.CivilStatus),
                nameof(PatientRecord.Weight), nameof(PatientRecord.Height),
                nameof(PatientRecord.CompanionName), nameof(PatientRecord.CompanionRelationship),
                nameof(PatientRecord.CompanionContact)
            };

            foreach (string name in hidden)
                if (dgvPatients.Columns.Contains(name))
                    dgvPatients.Columns[name].Visible = false;

            dgvPatients.Columns[nameof(PatientRecord.PatientID)].HeaderText = "Patient ID";
            dgvPatients.Columns[nameof(PatientRecord.LastName)].HeaderText = "Last Name";
            dgvPatients.Columns[nameof(PatientRecord.FirstName)].HeaderText = "First Name";
            dgvPatients.Columns[nameof(PatientRecord.MiddleName)].HeaderText = "Middle Name";
            dgvPatients.Columns[nameof(PatientRecord.DateOfBirth)].HeaderText = "Birthdate";
            dgvPatients.Columns[nameof(PatientRecord.DateOfBirth)].DefaultCellStyle.Format = "MMM dd, yyyy";
            dgvPatients.Columns[nameof(PatientRecord.ContactNumber)].HeaderText = "Contact No.";

            // Ayusin ang pagkakasunod-sunod ng columns
            string[] order =
            {
                nameof(PatientRecord.PatientID), nameof(PatientRecord.LastName),
                nameof(PatientRecord.FirstName), nameof(PatientRecord.MiddleName),
                nameof(PatientRecord.DateOfBirth), nameof(PatientRecord.ContactNumber)
            };
            for (int i = 0; i < order.Length; i++)
                dgvPatients.Columns[order[i]].DisplayIndex = i;
        }

        // ---------------------------------------------------------
        // 3. PAG PINILI ANG ROW -> PUNUIN ANG DETAILS
        // ---------------------------------------------------------
        private void dgvPatients_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // header click

            if (dgvPatients.Rows[e.RowIndex].DataBoundItem is not PatientRecord patient) return;

            ShowDetails(patient);
        }

        private void ShowDetails(PatientRecord patient)
        {
            selectedPatientId = patient.PatientID;

            try
            {
                PatientDetails d = _controller.GetDetails(patient);

                // --- Patient Information ---
                lblLastName.Text = d.LastName;
                lblFirstName.Text = d.FirstName;
                lblMI.Text = d.MiddleInitial;
                lblBirthdate.Text = d.Birthdate;
                lblAge.Text = d.Age;
                lblSex.Text = d.Sex;
                lblAddress.Text = d.Address;
                lblContactNo.Text = d.ContactNo;

                // --- Accompanying person ---
                lblAccName.Text = d.AccName;
                lblAccRelationship.Text = d.AccRelationship;
                lblAccContact.Text = d.AccContact;

                // --- Bed Information ---
                lblRoomNo.Text = d.RoomNo;
                lblBedNo.Text = d.BedNo;
                lblAdmissionDate.Text = d.AdmissionDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-load ng details ng patient:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------
        // 4. VIEW BUTTON
        // ---------------------------------------------------------
        private void btnView_Click(object? sender, EventArgs e)
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
    }
}