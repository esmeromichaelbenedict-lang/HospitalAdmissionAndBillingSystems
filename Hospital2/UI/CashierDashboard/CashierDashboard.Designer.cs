namespace Hospital2.UI.CashierDashboard
{
    partial class CashierDashboard
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
            label1 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            label2 = new Label();
            label3 = new Label();
            lblLastName = new Label();
            label5 = new Label();
            dgvPatients = new DataGridView();
            lblRoomNo = new Label();
            label7 = new Label();
            label8 = new Label();
            lblFirstName = new Label();
            lblMI = new Label();
            label11 = new Label();
            label12 = new Label();
            lblBirthdate = new Label();
            lblAge = new Label();
            label15 = new Label();
            lblSex = new Label();
            label17 = new Label();
            lblAddress = new Label();
            label19 = new Label();
            lblContactNo = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            lblAccName = new Label();
            lblAccRelationship = new Label();
            lblAccContact = new Label();
            label28 = new Label();
            lblBedNo = new Label();
            btnView = new Button();
            label30 = new Label();
            lblAdmissionDate = new Label();
            dgvBedInformation = new DataGridView();
            lblAdmission = new Label();
            label4 = new Label();
            dgvPatientInformation = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBedInformation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPatientInformation).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(44, 330);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(226, 31);
            label1.TabIndex = 0;
            label1.Text = "Patient Information";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.DarkGray;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(34, 30);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(807, 31);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.Highlight;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(849, 30);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(175, 31);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 381);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 23);
            label2.TabIndex = 3;
            label2.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(815, 381);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(91, 23);
            label3.TabIndex = 4;
            label3.Text = "Room No.:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(181, 381);
            lblLastName.Margin = new Padding(4, 0, 4, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(19, 23);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(815, 414);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(75, 23);
            label5.TabIndex = 6;
            label5.Text = "Bed No.:";
            // 
            // dgvPatients
            // 
            dgvPatients.BackgroundColor = Color.DarkGray;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(34, 90);
            dgvPatients.Margin = new Padding(4, 5, 4, 5);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.Size = new Size(1127, 224);
            dgvPatients.TabIndex = 7;
            dgvPatients.RowLeave += dgvPatients_CellClick;
            // 
            // lblRoomNo
            // 
            lblRoomNo.AutoSize = true;
            lblRoomNo.Location = new Point(936, 381);
            lblRoomNo.Margin = new Padding(4, 0, 4, 0);
            lblRoomNo.Name = "lblRoomNo";
            lblRoomNo.Size = new Size(19, 23);
            lblRoomNo.TabIndex = 8;
            lblRoomNo.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(339, 381);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(96, 23);
            label7.TabIndex = 9;
            label7.Text = "First Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(638, 381);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(42, 23);
            label8.TabIndex = 10;
            label8.Text = "M.I.:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(473, 381);
            lblFirstName.Margin = new Padding(4, 0, 4, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(19, 23);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "0";
            // 
            // lblMI
            // 
            lblMI.AutoSize = true;
            lblMI.Location = new Point(704, 381);
            lblMI.Margin = new Padding(4, 0, 4, 0);
            lblMI.Name = "lblMI";
            lblMI.Size = new Size(19, 23);
            lblMI.TabIndex = 12;
            lblMI.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(61, 414);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(84, 23);
            label11.TabIndex = 13;
            label11.Text = "Birthdate:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(364, 414);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(44, 23);
            label12.TabIndex = 14;
            label12.Text = "Age:";
            // 
            // lblBirthdate
            // 
            lblBirthdate.AutoSize = true;
            lblBirthdate.Location = new Point(181, 414);
            lblBirthdate.Margin = new Padding(4, 0, 4, 0);
            lblBirthdate.Name = "lblBirthdate";
            lblBirthdate.Size = new Size(19, 23);
            lblBirthdate.TabIndex = 15;
            lblBirthdate.Text = "0";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(473, 414);
            lblAge.Margin = new Padding(4, 0, 4, 0);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(19, 23);
            lblAge.TabIndex = 16;
            lblAge.Text = "0";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(83, 450);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(40, 23);
            label15.TabIndex = 17;
            label15.Text = "Sex:";
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Location = new Point(181, 450);
            lblSex.Margin = new Padding(4, 0, 4, 0);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(19, 23);
            lblSex.TabIndex = 18;
            lblSex.Text = "0";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(61, 482);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(74, 23);
            label17.TabIndex = 19;
            label17.Text = "Address:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(181, 482);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(19, 23);
            lblAddress.TabIndex = 20;
            lblAddress.Text = "0";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(61, 514);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(106, 23);
            label19.TabIndex = 21;
            label19.Text = "Contact No.:";
            // 
            // lblContactNo
            // 
            lblContactNo.AutoSize = true;
            lblContactNo.Location = new Point(181, 514);
            lblContactNo.Margin = new Padding(4, 0, 4, 0);
            lblContactNo.Name = "lblContactNo";
            lblContactNo.Size = new Size(19, 23);
            lblContactNo.TabIndex = 22;
            lblContactNo.Text = "0";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(61, 547);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(181, 23);
            label21.TabIndex = 23;
            label21.Text = "Accompanying person";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(61, 582);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(91, 23);
            label22.TabIndex = 24;
            label22.Text = "Full Name:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(61, 617);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(107, 23);
            label23.TabIndex = 25;
            label23.Text = "Relationship:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(61, 653);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(106, 23);
            label24.TabIndex = 26;
            label24.Text = "Contact No.:";
            // 
            // lblAccName
            // 
            lblAccName.AutoSize = true;
            lblAccName.Location = new Point(181, 582);
            lblAccName.Margin = new Padding(4, 0, 4, 0);
            lblAccName.Name = "lblAccName";
            lblAccName.Size = new Size(19, 23);
            lblAccName.TabIndex = 27;
            lblAccName.Text = "0";
            // 
            // lblAccRelationship
            // 
            lblAccRelationship.AutoSize = true;
            lblAccRelationship.Location = new Point(181, 617);
            lblAccRelationship.Margin = new Padding(4, 0, 4, 0);
            lblAccRelationship.Name = "lblAccRelationship";
            lblAccRelationship.Size = new Size(19, 23);
            lblAccRelationship.TabIndex = 28;
            lblAccRelationship.Text = "0";
            // 
            // lblAccContact
            // 
            lblAccContact.AutoSize = true;
            lblAccContact.Location = new Point(181, 653);
            lblAccContact.Margin = new Padding(4, 0, 4, 0);
            lblAccContact.Name = "lblAccContact";
            lblAccContact.Size = new Size(19, 23);
            lblAccContact.TabIndex = 29;
            lblAccContact.Text = "0";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.Location = new Point(791, 330);
            label28.Margin = new Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new Size(191, 31);
            label28.TabIndex = 30;
            label28.Text = "Bed Information";
            // 
            // lblBedNo
            // 
            lblBedNo.AutoSize = true;
            lblBedNo.Location = new Point(936, 414);
            lblBedNo.Margin = new Padding(4, 0, 4, 0);
            lblBedNo.Name = "lblBedNo";
            lblBedNo.Size = new Size(19, 23);
            lblBedNo.TabIndex = 31;
            lblBedNo.Text = "0";
            // 
            // btnView
            // 
            btnView.BackColor = Color.Green;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(638, 630);
            btnView.Margin = new Padding(4, 5, 4, 5);
            btnView.Name = "btnView";
            btnView.Size = new Size(122, 37);
            btnView.TabIndex = 32;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(815, 450);
            label30.Margin = new Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new Size(131, 23);
            label30.TabIndex = 33;
            label30.Text = "Admission date:";
            // 
            // lblAdmissionDate
            // 
            lblAdmissionDate.AutoSize = true;
            lblAdmissionDate.Location = new Point(1201, 627);
            lblAdmissionDate.Margin = new Padding(4, 0, 4, 0);
            lblAdmissionDate.Name = "lblAdmissionDate";
            lblAdmissionDate.Size = new Size(19, 23);
            lblAdmissionDate.TabIndex = 34;
            lblAdmissionDate.Text = "0";
            // 
            // dgvBedInformation
            // 
            dgvBedInformation.BackgroundColor = SystemColors.Control;
            dgvBedInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBedInformation.Location = new Point(780, 322);
            dgvBedInformation.Name = "dgvBedInformation";
            dgvBedInformation.RowHeadersWidth = 51;
            dgvBedInformation.Size = new Size(381, 363);
            dgvBedInformation.TabIndex = 36;
            // 
            // lblAdmission
            // 
            lblAdmission.AutoSize = true;
            lblAdmission.Location = new Point(984, 450);
            lblAdmission.Margin = new Padding(4, 0, 4, 0);
            lblAdmission.Name = "lblAdmission";
            lblAdmission.Size = new Size(19, 23);
            lblAdmission.TabIndex = 37;
            lblAdmission.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.DarkGray;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(44, 101);
            label4.Name = "label4";
            label4.Size = new Size(134, 31);
            label4.TabIndex = 38;
            label4.Text = "Patient List";
            // 
            // dgvPatientInformation
            // 
            dgvPatientInformation.BackgroundColor = SystemColors.Control;
            dgvPatientInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatientInformation.GridColor = SystemColors.WindowText;
            dgvPatientInformation.Location = new Point(34, 322);
            dgvPatientInformation.Name = "dgvPatientInformation";
            dgvPatientInformation.RowHeadersWidth = 51;
            dgvPatientInformation.Size = new Size(740, 363);
            dgvPatientInformation.TabIndex = 39;
            // 
            // CashierDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1193, 697);
            Controls.Add(label4);
            Controls.Add(lblAdmission);
            Controls.Add(label12);
            Controls.Add(label7);
            Controls.Add(lblLastName);
            Controls.Add(label17);
            Controls.Add(label15);
            Controls.Add(label11);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblAdmissionDate);
            Controls.Add(label30);
            Controls.Add(btnView);
            Controls.Add(lblBedNo);
            Controls.Add(label28);
            Controls.Add(lblAccContact);
            Controls.Add(lblAccRelationship);
            Controls.Add(lblAccName);
            Controls.Add(label24);
            Controls.Add(label23);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(lblContactNo);
            Controls.Add(label19);
            Controls.Add(lblAddress);
            Controls.Add(lblSex);
            Controls.Add(lblAge);
            Controls.Add(lblBirthdate);
            Controls.Add(lblMI);
            Controls.Add(lblFirstName);
            Controls.Add(label8);
            Controls.Add(lblRoomNo);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvPatients);
            Controls.Add(dgvBedInformation);
            Controls.Add(dgvPatientInformation);
            Margin = new Padding(4, 5, 4, 5);
            Name = "CashierDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CashierDashboard";
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBedInformation).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPatientInformation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label2;
        private Label label3;
        private Label lblLastName;
        private Label label5;
        private DataGridView dgvPatients;
        private Label lblRoomNo;
        private Label label7;
        private Label label8;
        private Label lblFirstName;
        private Label lblMI;
        private Label label11;
        private Label label12;
        private Label lblBirthdate;
        private Label lblAge;
        private Label label15;
        private Label lblSex;
        private Label label17;
        private Label lblAddress;
        private Label label19;
        private Label lblContactNo;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label lblAccName;
        private Label lblAccRelationship;
        private Label lblAccContact;
        private Label label28;
        private Label lblBedNo;
        private Button btnView;
        private Label label30;
        private Label lblAdmissionDate;
        private DataGridView dataGridView1;
        private DataGridView dgvBedInformation;
        private Label lblAdmission;
        private Label label4;
        private DataGridView dgvPatientInformation;
    }
}