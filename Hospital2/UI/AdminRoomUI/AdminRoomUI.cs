using Hospital2.UI;
using HospitalPRAC.UI.AdminAdmitPatient;
using HospitalPRAC.UI.AdminPatient;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HospitalPRAC.UI.RoomUI
{
    public partial class AdminRoomUI : Form
    {
        string connStr = @"Data Source=MIKEE-ESMERO\SQLEXPRESS;Initial Catalog=UserModel;Integrated Security=True;TrustServerCertificate=True;";

        int admissionId, patientId, currentRoomId;
        int? currentBedId;
        DateTime admissionDate;
        bool loading;
        public AdminRoomUI()
        {
            InitializeComponent();

            dgvPatients.ReadOnly = true;
            dgvPatients.MultiSelect = false;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        DataTable GetTable(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
            {
                da.SelectCommand.Parameters.AddRange(parameters);
                da.Fill(dt);
            }
            return dt;
        }

        void Room_Load(object sender, EventArgs e)
        {
            LoadPatients("");
        }

        void LoadPatients(string keyword)
        {
            dgvPatients.DataSource = GetTable(@"
                SELECT a.admission_id, p.PatientID, p.FullName AS Patient,
                       r.room_number AS Room, r.room_type AS Type,
                       b.bed_number AS Bed, r.daily_rate AS Rate,
                       a.admission_date AS Admitted, a.room_id, a.bed_id
                FROM dbo.admissions a
                JOIN dbo.Patient p ON p.PatientID = a.PatientID
                JOIN dbo.rooms r ON r.room_id = a.room_id
                LEFT JOIN dbo.Beds b ON b.bed_id = a.bed_id
                WHERE p.FullName LIKE '%' + @kw + '%'
                ORDER BY p.FullName",
                new SqlParameter("@kw", keyword));

            dgvPatients.Columns["admission_id"].Visible = false;
            dgvPatients.Columns["PatientID"].Visible = false;
            dgvPatients.Columns["room_id"].Visible = false;
            dgvPatients.Columns["bed_id"].Visible = false;
            dgvPatients.Columns["Rate"].DefaultCellStyle.Format = "N2";
            dgvPatients.Columns["Admitted"].DefaultCellStyle.Format = "MMM dd, yyyy h:mm tt";

            dgvPatients.CurrentCell = null;
            dgvPatients.ClearSelection();
            ClearAll();
        }

        void ClearAll()
        {
            admissionId = 0;
            lblPatientName.Text = "";
            lblRoomNo.Text = "";
            lblRoomType.Text = "";
            lblBedNo.Text = "";
            lblRate.Text = "";
            lblAdmitted.Text = "";
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

        void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPatients(txtSearch.Text.Trim());
        }

        void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            ClearAll();
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Click a patient in the list first.");
                return;
            }

            DataGridViewRow row = dgvPatients.SelectedRows[0];

            admissionId = Convert.ToInt32(row.Cells["admission_id"].Value);
            patientId = Convert.ToInt32(row.Cells["PatientID"].Value);
            currentRoomId = Convert.ToInt32(row.Cells["room_id"].Value);
            admissionDate = Convert.ToDateTime(row.Cells["Admitted"].Value);

            if (row.Cells["bed_id"].Value == DBNull.Value)
                currentBedId = null;
            else
                currentBedId = Convert.ToInt32(row.Cells["bed_id"].Value);

            lblPatientName.Text = row.Cells["Patient"].Value.ToString();
            lblRoomNo.Text = row.Cells["Room"].Value.ToString();
            lblRoomType.Text = row.Cells["Type"].Value.ToString();
            lblBedNo.Text = currentBedId == null ? "Not assigned" : row.Cells["Bed"].Value.ToString();
            lblRate.Text = "₱" + Convert.ToDecimal(row.Cells["Rate"].Value).ToString("N2");
            lblAdmitted.Text = admissionDate.ToString("MMM dd, yyyy h:mm tt");

            ResetTransfer();

            dtpTransfer.Value = DateTime.Now;

            loading = true;
            cboRoomType.DataSource = GetTable("SELECT DISTINCT room_type FROM dbo.rooms");
            cboRoomType.DisplayMember = "room_type";
            cboRoomType.SelectedIndex = -1;
            loading = false;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            dgvPatients.CurrentCell = null;
            dgvPatients.ClearSelection();
            ClearAll();
        }

        void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading || cboRoomType.SelectedIndex < 0) return;

            loading = true;
            cboBed.DataSource = null;
            lblNewRate.Text = "";
            cboRoom.DataSource = GetTable(@"
                SELECT room_id, room_number FROM dbo.rooms
                WHERE room_type = @type
                AND room_id IN (SELECT room_id FROM dbo.Beds WHERE status = 'Available')
                ORDER BY room_number",
                new SqlParameter("@type", cboRoomType.Text));
            cboRoom.DisplayMember = "room_number";
            cboRoom.ValueMember = "room_id";
            cboRoom.SelectedIndex = -1;
            loading = false;
        }

        void cboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading || cboRoom.SelectedIndex < 0) return;

            loading = true;
            lblNewRate.Text = "";
            cboBed.DataSource = GetTable(@"
                SELECT bed_id, bed_number, daily_rate FROM dbo.Beds
                WHERE room_id = @room AND status = 'Available'
                ORDER BY bed_number",
                new SqlParameter("@room", Convert.ToInt32(cboRoom.SelectedValue)));
            cboBed.DisplayMember = "bed_number";
            cboBed.ValueMember = "bed_id";
            cboBed.SelectedIndex = -1;
            loading = false;
        }

        void cboBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading || cboBed.SelectedIndex < 0) return;

            DataRowView bed = (DataRowView)cboBed.SelectedItem;
            lblNewRate.Text = "₱" + Convert.ToDecimal(bed["daily_rate"]).ToString("N2");
        }

        void btnTransfer_Click(object sender, EventArgs e)
        {
            if (admissionId == 0)
            {
                MessageBox.Show("Click a patient and press Edit first.");
                return;
            }
            if (cboBed.SelectedIndex < 0)
            {
                MessageBox.Show("Select a room and bed.");
                return;
            }
            if (txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Enter a reason.");
                return;
            }

            int newRoomId = Convert.ToInt32(cboRoom.SelectedValue);
            int newBedId = Convert.ToInt32(cboBed.SelectedValue);

            if (currentBedId == newBedId)
            {
                MessageBox.Show("The patient is already in that bed.");
                return;
            }
            if (dtpTransfer.Value < admissionDate)
            {
                MessageBox.Show("Transfer date cannot be earlier than the admission date.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE dbo.Beds SET status = 'Occupied' WHERE bed_id = @bed AND status = 'Available'", con, tx);
                    cmd.Parameters.AddWithValue("@bed", newBedId);
                    if (cmd.ExecuteNonQuery() == 0)
                        throw new Exception("That bed is no longer available.");

                    if (currentBedId != null)
                    {
                        cmd = new SqlCommand("UPDATE dbo.Beds SET status = 'Available' WHERE bed_id = @bed", con, tx);
                        cmd.Parameters.AddWithValue("@bed", currentBedId.Value);
                        cmd.ExecuteNonQuery();
                    }

                    cmd = new SqlCommand(
                        "UPDATE dbo.admissions SET room_id = @room, bed_id = @bed WHERE admission_id = @id", con, tx);
                    cmd.Parameters.AddWithValue("@room", newRoomId);
                    cmd.Parameters.AddWithValue("@bed", newBedId);
                    cmd.Parameters.AddWithValue("@id", admissionId);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(@"
                        INSERT INTO dbo.RoomTransfer
                        (PatientID, from_room_id, to_room_id, from_bed_id, to_bed_id, transfer_datetime, transfer_reason)
                        VALUES (@patient, @fromRoom, @toRoom, @fromBed, @toBed, @date, @reason)", con, tx);
                    cmd.Parameters.AddWithValue("@patient", patientId);
                    cmd.Parameters.AddWithValue("@fromRoom", currentRoomId);
                    cmd.Parameters.AddWithValue("@toRoom", newRoomId);
                    cmd.Parameters.AddWithValue("@fromBed", (object)currentBedId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@toBed", newBedId);
                    cmd.Parameters.AddWithValue("@date", dtpTransfer.Value);
                    cmd.Parameters.AddWithValue("@reason", txtReason.Text.Trim());
                    cmd.ExecuteNonQuery();

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            MessageBox.Show("Patient transferred.");
            LoadPatients(txtSearch.Text.Trim());
        }

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