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
            lblContact = new Label();
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
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 306);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Patient Information";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(87, 73);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(336, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(439, 67);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(136, 36);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 336);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 3;
            label2.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(791, 341);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 4;
            label3.Text = "Room No.:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(202, 336);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(13, 15);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(791, 371);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 6;
            label5.Text = "Bed No.:";
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(91, 133);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.Size = new Size(820, 125);
            dgvPatients.TabIndex = 7;
            dgvPatients.RowLeave += dgvPatients_CellClick;
            // 
            // lblRoomNo
            // 
            lblRoomNo.AutoSize = true;
            lblRoomNo.Location = new Point(873, 341);
            lblRoomNo.Name = "lblRoomNo";
            lblRoomNo.Size = new Size(13, 15);
            lblRoomNo.TabIndex = 8;
            lblRoomNo.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(287, 336);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 9;
            label7.Text = "First Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(504, 336);
            label8.Name = "label8";
            label8.Size = new Size(30, 15);
            label8.TabIndex = 10;
            label8.Text = "M.I.:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(411, 336);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(13, 15);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "0";
            // 
            // lblMI
            // 
            lblMI.AutoSize = true;
            lblMI.Location = new Point(573, 336);
            lblMI.Name = "lblMI";
            lblMI.Size = new Size(13, 15);
            lblMI.TabIndex = 12;
            lblMI.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(88, 371);
            label11.Name = "label11";
            label11.Size = new Size(58, 15);
            label11.TabIndex = 13;
            label11.Text = "Birthdate:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(287, 371);
            label12.Name = "label12";
            label12.Size = new Size(31, 15);
            label12.TabIndex = 14;
            label12.Text = "Age:";
            // 
            // lblBirthdate
            // 
            lblBirthdate.AutoSize = true;
            lblBirthdate.Location = new Point(202, 371);
            lblBirthdate.Name = "lblBirthdate";
            lblBirthdate.Size = new Size(13, 15);
            lblBirthdate.TabIndex = 15;
            lblBirthdate.Text = "0";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(411, 371);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(13, 15);
            lblAge.TabIndex = 16;
            lblAge.Text = "0";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(88, 409);
            label15.Name = "label15";
            label15.Size = new Size(28, 15);
            label15.TabIndex = 17;
            label15.Text = "Sex:";
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Location = new Point(202, 409);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(13, 15);
            lblSex.TabIndex = 18;
            lblSex.Text = "0";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(91, 445);
            label17.Name = "label17";
            label17.Size = new Size(52, 15);
            label17.TabIndex = 19;
            label17.Text = "Address:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(287, 445);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(13, 15);
            lblAddress.TabIndex = 20;
            lblAddress.Text = "0";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(91, 483);
            label19.Name = "label19";
            label19.Size = new Size(97, 15);
            label19.TabIndex = 21;
            label19.Text = "Contact number:";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(242, 483);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(13, 15);
            lblContact.TabIndex = 22;
            lblContact.Text = "0";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(76, 521);
            label21.Name = "label21";
            label21.Size = new Size(127, 15);
            label21.TabIndex = 23;
            label21.Text = "Accompanying person";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(91, 558);
            label22.Name = "label22";
            label22.Size = new Size(64, 15);
            label22.TabIndex = 24;
            label22.Text = "Full Name:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(91, 596);
            label23.Name = "label23";
            label23.Size = new Size(75, 15);
            label23.TabIndex = 25;
            label23.Text = "Relationship:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(91, 635);
            label24.Name = "label24";
            label24.Size = new Size(97, 15);
            label24.TabIndex = 26;
            label24.Text = "Contact number:";
            // 
            // lblAccName
            // 
            lblAccName.AutoSize = true;
            lblAccName.Location = new Point(305, 558);
            lblAccName.Name = "lblAccName";
            lblAccName.Size = new Size(13, 15);
            lblAccName.TabIndex = 27;
            lblAccName.Text = "0";
            // 
            // lblAccRelationship
            // 
            lblAccRelationship.AutoSize = true;
            lblAccRelationship.Location = new Point(202, 596);
            lblAccRelationship.Name = "lblAccRelationship";
            lblAccRelationship.Size = new Size(13, 15);
            lblAccRelationship.TabIndex = 28;
            lblAccRelationship.Text = "0";
            // 
            // lblAccContact
            // 
            lblAccContact.AutoSize = true;
            lblAccContact.Location = new Point(242, 635);
            lblAccContact.Name = "lblAccContact";
            lblAccContact.Size = new Size(13, 15);
            lblAccContact.TabIndex = 29;
            lblAccContact.Text = "0";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(776, 306);
            label28.Name = "label28";
            label28.Size = new Size(93, 15);
            label28.TabIndex = 30;
            label28.Text = "Bed Information";
            // 
            // lblBedNo
            // 
            lblBedNo.AutoSize = true;
            lblBedNo.Location = new Point(873, 371);
            lblBedNo.Name = "lblBedNo";
            lblBedNo.Size = new Size(13, 15);
            lblBedNo.TabIndex = 31;
            lblBedNo.Text = "0";
            // 
            // btnView
            // 
            btnView.Location = new Point(450, 624);
            btnView.Name = "btnView";
            btnView.Size = new Size(136, 36);
            btnView.TabIndex = 32;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(791, 409);
            label30.Name = "label30";
            label30.Size = new Size(92, 15);
            label30.TabIndex = 33;
            label30.Text = "Admission date:";
            // 
            // lblAdmissionDate
            // 
            lblAdmissionDate.AutoSize = true;
            lblAdmissionDate.Location = new Point(934, 409);
            lblAdmissionDate.Name = "lblAdmissionDate";
            lblAdmissionDate.Size = new Size(13, 15);
            lblAdmissionDate.TabIndex = 34;
            lblAdmissionDate.Text = "0";
            // 
            // CashierDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1370, 749);
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
            Controls.Add(lblContact);
            Controls.Add(label19);
            Controls.Add(lblAddress);
            Controls.Add(label17);
            Controls.Add(lblSex);
            Controls.Add(label15);
            Controls.Add(lblAge);
            Controls.Add(lblBirthdate);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(lblMI);
            Controls.Add(lblFirstName);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(lblRoomNo);
            Controls.Add(dgvPatients);
            Controls.Add(label5);
            Controls.Add(lblLastName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "CashierDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CashierDashboard";
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
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
        private Label lblContact;
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
    }
}