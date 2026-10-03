namespace HospitalPRAC.UI.AdminPatient
{
    partial class Patient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnAdmitPatient = new Button();
            label1 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnEdit = new Button();
            btnCancel = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panel2 = new Panel();
            dtpDOB = new DateTimePicker();
            txtContactNumber = new TextBox();
            txtAddress = new TextBox();
            cmbCivilStatus = new ComboBox();
            cmbSex = new ComboBox();
            label17 = new Label();
            txtAge = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            txtFullName = new TextBox();
            label4 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            cmbAdmissionType = new ComboBox();
            cmbRoom = new ComboBox();
            cmbDoctor = new ComboBox();
            txtReason = new TextBox();
            dtpAdmission = new DateTimePicker();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label3 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            label16 = new Label();
            panel6 = new Panel();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            btnDashboard = new Button();
            btnLogout = new Button();
            dgvPatients = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(btnAdmitPatient);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(115, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1076, 70);
            panel1.TabIndex = 0;
            // 
            // btnAdmitPatient
            // 
            btnAdmitPatient.BackColor = Color.Lime;
            btnAdmitPatient.FlatStyle = FlatStyle.Flat;
            btnAdmitPatient.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdmitPatient.Location = new Point(934, 12);
            btnAdmitPatient.Name = "btnAdmitPatient";
            btnAdmitPatient.Size = new Size(118, 33);
            btnAdmitPatient.TabIndex = 12;
            btnAdmitPatient.Text = "Admit Patient";
            btnAdmitPatient.UseVisualStyleBackColor = false;
            btnAdmitPatient.Click += btnAdmitPatient_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 16);
            label1.Name = "label1";
            label1.Size = new Size(94, 32);
            label1.TabIndex = 0;
            label1.Text = "Patient";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(159, 90);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(363, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(548, 84);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 33);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(128, 255, 128);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(691, 84);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(118, 33);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ActiveBorder;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(815, 84);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(118, 33);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(128, 255, 128);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(939, 84);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(118, 33);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 128, 128);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(1063, 84);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 33);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dtpDOB);
            panel2.Controls.Add(txtContactNumber);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(cmbCivilStatus);
            panel2.Controls.Add(cmbSex);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(txtAge);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtFullName);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(122, 297);
            panel2.Name = "panel2";
            panel2.Size = new Size(514, 251);
            panel2.TabIndex = 8;
            // 
            // dtpDOB
            // 
            dtpDOB.CustomFormat = "yyyy-MM-dd";
            dtpDOB.Format = DateTimePickerFormat.Short;
            dtpDOB.Location = new Point(102, 79);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(185, 23);
            dtpDOB.TabIndex = 32;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(128, 204);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(142, 23);
            txtContactNumber.TabIndex = 35;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(102, 171);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(392, 23);
            txtAddress.TabIndex = 34;
            // 
            // cmbCivilStatus
            // 
            cmbCivilStatus.FormattingEnabled = true;
            cmbCivilStatus.Location = new Point(102, 142);
            cmbCivilStatus.Name = "cmbCivilStatus";
            cmbCivilStatus.Size = new Size(142, 23);
            cmbCivilStatus.TabIndex = 33;
            // 
            // cmbSex
            // 
            cmbSex.FormattingEnabled = true;
            cmbSex.Location = new Point(102, 110);
            cmbSex.Name = "cmbSex";
            cmbSex.Size = new Size(142, 23);
            cmbSex.TabIndex = 32;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(21, 112);
            label17.Name = "label17";
            label17.Size = new Size(34, 16);
            label17.TabIndex = 24;
            label17.Text = "Sex:";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(333, 79);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(161, 23);
            txtAge.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(293, 81);
            label10.Name = "label10";
            label10.Size = new Size(34, 16);
            label10.TabIndex = 22;
            label10.Text = "Age:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(17, 206);
            label9.Name = "label9";
            label9.Size = new Size(105, 16);
            label9.TabIndex = 21;
            label9.Text = "Contact Number:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(21, 173);
            label8.Name = "label8";
            label8.Size = new Size(59, 16);
            label8.TabIndex = 20;
            label8.Text = "Address:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(20, 144);
            label7.Name = "label7";
            label7.Size = new Size(76, 16);
            label7.TabIndex = 19;
            label7.Text = "Civil Status:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 81);
            label5.Name = "label5";
            label5.Size = new Size(83, 16);
            label5.TabIndex = 11;
            label5.Text = "Date of Birth:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(102, 50);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(392, 23);
            txtFullName.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 52);
            label4.Name = "label4";
            label4.Size = new Size(70, 16);
            label4.TabIndex = 2;
            label4.Text = "Full Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 14);
            label2.Name = "label2";
            label2.Size = new Size(168, 23);
            label2.TabIndex = 1;
            label2.Text = "Personal Information";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(cmbAdmissionType);
            panel3.Controls.Add(cmbRoom);
            panel3.Controls.Add(cmbDoctor);
            panel3.Controls.Add(txtReason);
            panel3.Controls.Add(dtpAdmission);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(661, 297);
            panel3.Name = "panel3";
            panel3.Size = new Size(520, 251);
            panel3.TabIndex = 9;
            // 
            // cmbAdmissionType
            // 
            cmbAdmissionType.FormattingEnabled = true;
            cmbAdmissionType.Location = new Point(181, 166);
            cmbAdmissionType.Name = "cmbAdmissionType";
            cmbAdmissionType.Size = new Size(218, 23);
            cmbAdmissionType.TabIndex = 31;
            // 
            // cmbRoom
            // 
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(181, 137);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(218, 23);
            cmbRoom.TabIndex = 30;
            // 
            // cmbDoctor
            // 
            cmbDoctor.FormattingEnabled = true;
            cmbDoctor.Location = new Point(181, 108);
            cmbDoctor.Name = "cmbDoctor";
            cmbDoctor.Size = new Size(218, 23);
            cmbDoctor.TabIndex = 24;
            // 
            // txtReason
            // 
            txtReason.Location = new Point(181, 79);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(325, 23);
            txtReason.TabIndex = 24;
            // 
            // dtpAdmission
            // 
            dtpAdmission.CustomFormat = "MMM dd, yyyy hh:mm tt";
            dtpAdmission.Format = DateTimePickerFormat.Custom;
            dtpAdmission.Location = new Point(181, 50);
            dtpAdmission.Name = "dtpAdmission";
            dtpAdmission.Size = new Size(218, 23);
            dtpAdmission.TabIndex = 29;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(72, 168);
            label15.Name = "label15";
            label15.Size = new Size(103, 16);
            label15.TabIndex = 28;
            label15.Text = "Admission Type:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(130, 144);
            label14.Name = "label14";
            label14.Size = new Size(45, 16);
            label14.TabIndex = 27;
            label14.Text = "Room:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(67, 110);
            label13.Name = "label13";
            label13.Size = new Size(108, 16);
            label13.TabIndex = 26;
            label13.Text = "Admitting Doctor:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(38, 81);
            label12.Name = "label12";
            label12.Size = new Size(137, 16);
            label12.TabIndex = 25;
            label12.Text = "Reason for Admission:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(15, 52);
            label11.Name = "label11";
            label11.Size = new Size(160, 16);
            label11.TabIndex = 24;
            label11.Text = "Admission Date and Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 14);
            label3.Name = "label3";
            label3.Size = new Size(146, 23);
            label3.TabIndex = 2;
            label3.Text = "Admission Details";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(button6);
            panel4.Controls.Add(button7);
            panel4.Controls.Add(button8);
            panel4.Controls.Add(button9);
            panel4.Controls.Add(btnDashboard);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(116, 583);
            panel4.TabIndex = 10;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.AppWorkspace;
            panel5.Controls.Add(label16);
            panel5.Location = new Point(150, 116);
            panel5.Name = "panel5";
            panel5.Size = new Size(147, 104);
            panel5.TabIndex = 2;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(21, 20);
            label16.Name = "label16";
            label16.Size = new Size(110, 29);
            label16.TabIndex = 0;
            label16.Text = "Hi, Admin!";
            // 
            // panel6
            // 
            panel6.Location = new Point(122, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 79);
            panel6.TabIndex = 1;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(0, 0, 64);
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(0, 217);
            button6.Name = "button6";
            button6.Size = new Size(116, 41);
            button6.TabIndex = 1;
            button6.Text = "Manage User";
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(0, 0, 64);
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(0, 179);
            button7.Name = "button7";
            button7.Size = new Size(116, 41);
            button7.TabIndex = 1;
            button7.Text = "Room";
            button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(0, 0, 64);
            button8.FlatStyle = FlatStyle.Popup;
            button8.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Location = new Point(0, 141);
            button8.Name = "button8";
            button8.Size = new Size(116, 41);
            button8.TabIndex = 1;
            button8.Text = "Admitting";
            button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.BackColor = Color.MidnightBlue;
            button9.FlatStyle = FlatStyle.Popup;
            button9.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.White;
            button9.Location = new Point(0, 106);
            button9.Name = "button9";
            button9.Size = new Size(116, 38);
            button9.TabIndex = 1;
            button9.Text = "Patient";
            button9.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(0, 0, 64);
            btnDashboard.FlatStyle = FlatStyle.Popup;
            btnDashboard.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 66);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(116, 41);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.ActiveBorder;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(1049, 550);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(118, 33);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(186, 142);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.Size = new Size(900, 136);
            dgvPatients.TabIndex = 12;
            // 
            // Patient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 582);
            Controls.Add(dgvPatients);
            Controls.Add(btnLogout);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Controls.Add(btnEdit);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(panel1);
            Name = "Patient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Patient";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnEdit;
        private Button btnCancel;
        private Button btnUpdate;
        private Label label1;
        private Button btnDelete;
        private ListBox listBox1;
        private Panel panel2;
        private Label label4;
        private Label label2;
        private Panel panel3;
        private Label label3;
        private Label label9;
        private Label label8;
        private Label label7;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private TextBox textBox7;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox3;
        private Label label5;
        private TextBox txtFullName;
        private TextBox txtAge;
        private Label label10;
        private ComboBox cmbAdmissionType;
        private ComboBox cmbRoom;
        private ComboBox cmbDoctor;
        private TextBox txtReason;
        private DateTimePicker dtpAdmission;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Panel panel4;
        private Panel panel5;
        private Label label16;
        private Panel panel6;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button btnDashboard;
        private Button btnAdmitPatient;
        private Button btnLogout;
        private TextBox txtContactNumber;
        private TextBox txtAddress;
        private ComboBox cmbCivilStatus;
        private ComboBox cmbSex;
        private Label label17;
        private DataGridView dgvPatients;
        private DateTimePicker dtpDOB;
    }
}