namespace HospitalPRAC.UI.AdminAdmitPatient
{
    partial class AdmitPatient
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
            panel4 = new Panel();
            button1 = new Button();
            panel5 = new Panel();
            label16 = new Label();
            panel6 = new Panel();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            btnPatient = new Button();
            btnDashboard = new Button();
            panel1 = new Panel();
            btnAdmitPatient = new Button();
            label1 = new Label();
            panel3 = new Panel();
            comboBox1 = new ComboBox();
            label6 = new Label();
            cmbAdmissionType = new ComboBox();
            cmbRoom = new ComboBox();
            cmbDoctor = new ComboBox();
            txtReasonForAdmission = new TextBox();
            dtpAdmissionDateTime = new DateTimePicker();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            dtpDateOfBirth = new DateTimePicker();
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
            dgvServices = new DataGridView();
            panel7 = new Panel();
            btnAddService = new Button();
            textBox1 = new TextBox();
            cmbService = new ComboBox();
            lblServiceFee = new Label();
            label19 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 0, 64);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(button6);
            panel4.Controls.Add(button7);
            panel4.Controls.Add(button8);
            panel4.Controls.Add(btnPatient);
            panel4.Controls.Add(btnDashboard);
            panel4.Location = new Point(1, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(116, 583);
            panel4.TabIndex = 12;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 0, 0);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 542);
            button1.Name = "button1";
            button1.Size = new Size(116, 41);
            button1.TabIndex = 3;
            button1.Text = "Logout";
            button1.UseVisualStyleBackColor = false;
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
            button8.BackColor = Color.MidnightBlue;
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
            // btnPatient
            // 
            btnPatient.BackColor = Color.FromArgb(0, 0, 64);
            btnPatient.FlatStyle = FlatStyle.Popup;
            btnPatient.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPatient.ForeColor = Color.White;
            btnPatient.Location = new Point(0, 106);
            btnPatient.Name = "btnPatient";
            btnPatient.Size = new Size(116, 38);
            btnPatient.TabIndex = 1;
            btnPatient.Text = "Patient";
            btnPatient.UseVisualStyleBackColor = false;
            btnPatient.Click += btnPatient_Click;
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
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(btnAdmitPatient);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(116, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1076, 70);
            panel1.TabIndex = 11;
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
            label1.Size = new Size(171, 32);
            label1.TabIndex = 0;
            label1.Text = "Admit Patient";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(cmbAdmissionType);
            panel3.Controls.Add(cmbRoom);
            panel3.Controls.Add(cmbDoctor);
            panel3.Controls.Add(txtReasonForAdmission);
            panel3.Controls.Add(dtpAdmissionDateTime);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(661, 300);
            panel3.Name = "panel3";
            panel3.Size = new Size(520, 251);
            panel3.TabIndex = 14;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(181, 166);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(218, 23);
            comboBox1.TabIndex = 33;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(92, 171);
            label6.Name = "label6";
            label6.Size = new Size(83, 16);
            label6.TabIndex = 32;
            label6.Text = "Bed Number:";
            // 
            // cmbAdmissionType
            // 
            cmbAdmissionType.FormattingEnabled = true;
            cmbAdmissionType.Location = new Point(181, 199);
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
            // txtReasonForAdmission
            // 
            txtReasonForAdmission.Location = new Point(181, 79);
            txtReasonForAdmission.Name = "txtReasonForAdmission";
            txtReasonForAdmission.Size = new Size(325, 23);
            txtReasonForAdmission.TabIndex = 24;
            // 
            // dtpAdmissionDateTime
            // 
            dtpAdmissionDateTime.CustomFormat = "MMM dd, yyyy hh:mm tt";
            dtpAdmissionDateTime.Format = DateTimePickerFormat.Custom;
            dtpAdmissionDateTime.Location = new Point(181, 50);
            dtpAdmissionDateTime.Name = "dtpAdmissionDateTime";
            dtpAdmissionDateTime.Size = new Size(218, 23);
            dtpAdmissionDateTime.TabIndex = 29;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(72, 201);
            label15.Name = "label15";
            label15.Size = new Size(103, 16);
            label15.TabIndex = 28;
            label15.Text = "Admission Type:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(130, 142);
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
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dtpDateOfBirth);
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
            panel2.Location = new Point(124, 300);
            panel2.Name = "panel2";
            panel2.Size = new Size(514, 251);
            panel2.TabIndex = 13;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.CustomFormat = "yyyy-MM-dd";
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(102, 79);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(185, 23);
            dtpDateOfBirth.TabIndex = 32;
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
            // dgvServices
            // 
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Location = new Point(124, 81);
            dgvServices.Name = "dgvServices";
            dgvServices.Size = new Size(512, 199);
            dgvServices.TabIndex = 15;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(btnAddService);
            panel7.Controls.Add(textBox1);
            panel7.Controls.Add(cmbService);
            panel7.Controls.Add(lblServiceFee);
            panel7.Controls.Add(label19);
            panel7.Controls.Add(label22);
            panel7.Controls.Add(label23);
            panel7.Controls.Add(label24);
            panel7.Location = new Point(664, 81);
            panel7.Name = "panel7";
            panel7.Size = new Size(517, 199);
            panel7.TabIndex = 36;
            // 
            // btnAddService
            // 
            btnAddService.BackColor = Color.Lime;
            btnAddService.FlatStyle = FlatStyle.Flat;
            btnAddService.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddService.Location = new Point(79, 127);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(206, 33);
            btnAddService.TabIndex = 13;
            btnAddService.Text = "Add Service";
            btnAddService.UseVisualStyleBackColor = false;
            btnAddService.Click += btnAddService_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(128, 204);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(142, 23);
            textBox1.TabIndex = 35;
            // 
            // cmbService
            // 
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(120, 43);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(191, 23);
            cmbService.TabIndex = 32;
            // 
            // lblServiceFee
            // 
            lblServiceFee.AutoSize = true;
            lblServiceFee.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblServiceFee.Location = new Point(163, 85);
            lblServiceFee.Name = "lblServiceFee";
            lblServiceFee.Size = new Size(14, 16);
            lblServiceFee.TabIndex = 24;
            lblServiceFee.Text = "0";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(17, 206);
            label19.Name = "label19";
            label19.Size = new Size(105, 16);
            label19.TabIndex = 21;
            label19.Text = "Contact Number:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.Location = new Point(20, 85);
            label22.Name = "label22";
            label22.Size = new Size(79, 16);
            label22.TabIndex = 11;
            label22.Text = "Service Fee:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label23.Location = new Point(20, 45);
            label23.Name = "label23";
            label23.Size = new Size(94, 16);
            label23.TabIndex = 2;
            label23.Text = "Select Service:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(12, 12);
            label24.Name = "label24";
            label24.Size = new Size(75, 23);
            label24.TabIndex = 1;
            label24.Text = "Services";
            // 
            // AdmitPatient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 582);
            Controls.Add(panel7);
            Controls.Add(dgvServices);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "AdmitPatient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdmitPatient";
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Panel panel5;
        private Label label16;
        private Panel panel6;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button btnPatient;
        private Button btnDashboard;
        private Panel panel1;
        private Button btnAdmitPatient;
        private Label label1;
        private Panel panel3;
        private ComboBox cmbAdmissionType;
        private ComboBox cmbRoom;
        private ComboBox cmbDoctor;
        private TextBox txtReasonForAdmission;
        private DateTimePicker dtpAdmissionDateTime;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label3;
        private Panel panel2;
        private DateTimePicker dtpDateOfBirth;
        private TextBox txtContactNumber;
        private TextBox txtAddress;
        private ComboBox cmbCivilStatus;
        private ComboBox cmbSex;
        private Label label17;
        private TextBox txtAge;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private TextBox txtFullName;
        private Label label4;
        private Label label2;
        private DataGridView dgvServices;
        private Panel panel7;
        private Button btnAddService;
        private TextBox textBox1;
        private ComboBox cmbService;
        private Label lblServiceFee;
        private Label label19;
        private Label label22;
        private Label label23;
        private Label label24;
        private ComboBox comboBox1;
        private Label label6;
        private Button button1;
    }
}