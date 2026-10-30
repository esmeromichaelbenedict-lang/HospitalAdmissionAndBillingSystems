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
            label4 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 10);
            label1.Name = "label1";
            label1.Size = new Size(239, 32);
            label1.TabIndex = 0;
            label1.Text = "Patient Information";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(182, 114);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(628, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(834, 108);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(136, 37);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 54);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 3;
            label2.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLight;
            label3.Location = new Point(40, 54);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 4;
            label3.Text = "Room No.:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(161, 54);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(13, 15);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlLight;
            label5.Location = new Point(40, 84);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 6;
            label5.Text = "Bed No.:";
            // 
            // dgvPatients
            // 
            dgvPatients.BackgroundColor = Color.LightGray;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(80, 197);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.Size = new Size(1220, 172);
            dgvPatients.TabIndex = 7;
            dgvPatients.RowLeave += dgvPatients_CellClick;
            // 
            // lblRoomNo
            // 
            lblRoomNo.AutoSize = true;
            lblRoomNo.BackColor = SystemColors.ControlLight;
            lblRoomNo.Location = new Point(167, 54);
            lblRoomNo.Name = "lblRoomNo";
            lblRoomNo.Size = new Size(13, 15);
            lblRoomNo.TabIndex = 8;
            lblRoomNo.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(265, 54);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 9;
            label7.Text = "First Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(497, 54);
            label8.Name = "label8";
            label8.Size = new Size(30, 15);
            label8.TabIndex = 10;
            label8.Text = "M.I.:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(369, 54);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(13, 15);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "0";
            // 
            // lblMI
            // 
            lblMI.AutoSize = true;
            lblMI.Location = new Point(549, 54);
            lblMI.Name = "lblMI";
            lblMI.Size = new Size(13, 15);
            lblMI.TabIndex = 12;
            lblMI.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(34, 84);
            label11.Name = "label11";
            label11.Size = new Size(58, 15);
            label11.TabIndex = 13;
            label11.Text = "Birthdate:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(265, 84);
            label12.Name = "label12";
            label12.Size = new Size(31, 15);
            label12.TabIndex = 14;
            label12.Text = "Age:";
            // 
            // lblBirthdate
            // 
            lblBirthdate.AutoSize = true;
            lblBirthdate.Location = new Point(161, 84);
            lblBirthdate.Name = "lblBirthdate";
            lblBirthdate.Size = new Size(13, 15);
            lblBirthdate.TabIndex = 15;
            lblBirthdate.Text = "0";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(369, 84);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(13, 15);
            lblAge.TabIndex = 16;
            lblAge.Text = "0";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(34, 114);
            label15.Name = "label15";
            label15.Size = new Size(28, 15);
            label15.TabIndex = 17;
            label15.Text = "Sex:";
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Location = new Point(161, 114);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(13, 15);
            lblSex.TabIndex = 18;
            lblSex.Text = "0";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(34, 144);
            label17.Name = "label17";
            label17.Size = new Size(52, 15);
            label17.TabIndex = 19;
            label17.Text = "Address:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(161, 144);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(13, 15);
            lblAddress.TabIndex = 20;
            lblAddress.Text = "0";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = SystemColors.ControlLight;
            label19.Location = new Point(265, 114);
            label19.Name = "label19";
            label19.Size = new Size(74, 15);
            label19.TabIndex = 21;
            label19.Text = "Contact No.:";
            // 
            // lblContactNo
            // 
            lblContactNo.AutoSize = true;
            lblContactNo.Location = new Point(369, 114);
            lblContactNo.Name = "lblContactNo";
            lblContactNo.Size = new Size(13, 15);
            lblContactNo.TabIndex = 22;
            lblContactNo.Text = "0";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = SystemColors.ControlLight;
            label21.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(8, 166);
            label21.Name = "label21";
            label21.Size = new Size(271, 32);
            label21.TabIndex = 23;
            label21.Text = "Accompanying person";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(34, 206);
            label22.Name = "label22";
            label22.Size = new Size(64, 15);
            label22.TabIndex = 24;
            label22.Text = "Full Name:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(34, 236);
            label23.Name = "label23";
            label23.Size = new Size(75, 15);
            label23.TabIndex = 25;
            label23.Text = "Relationship:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(35, 265);
            label24.Name = "label24";
            label24.Size = new Size(74, 15);
            label24.TabIndex = 26;
            label24.Text = "Contact No.:";
            // 
            // lblAccName
            // 
            lblAccName.AutoSize = true;
            lblAccName.Location = new Point(161, 206);
            lblAccName.Name = "lblAccName";
            lblAccName.Size = new Size(13, 15);
            lblAccName.TabIndex = 27;
            lblAccName.Text = "0";
            // 
            // lblAccRelationship
            // 
            lblAccRelationship.AutoSize = true;
            lblAccRelationship.Location = new Point(161, 236);
            lblAccRelationship.Name = "lblAccRelationship";
            lblAccRelationship.Size = new Size(13, 15);
            lblAccRelationship.TabIndex = 28;
            lblAccRelationship.Text = "0";
            // 
            // lblAccContact
            // 
            lblAccContact.AutoSize = true;
            lblAccContact.Location = new Point(161, 265);
            lblAccContact.Name = "lblAccContact";
            lblAccContact.Size = new Size(13, 15);
            lblAccContact.TabIndex = 29;
            lblAccContact.Text = "0";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.BackColor = SystemColors.ControlLight;
            label28.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.Location = new Point(14, 10);
            label28.Name = "label28";
            label28.Size = new Size(202, 32);
            label28.TabIndex = 30;
            label28.Text = "Bed Information";
            // 
            // lblBedNo
            // 
            lblBedNo.AutoSize = true;
            lblBedNo.BackColor = SystemColors.ControlLight;
            lblBedNo.Location = new Point(167, 84);
            lblBedNo.Name = "lblBedNo";
            lblBedNo.Size = new Size(13, 15);
            lblBedNo.TabIndex = 31;
            lblBedNo.Text = "0";
            // 
            // btnView
            // 
            btnView.BackColor = Color.FromArgb(128, 255, 128);
            btnView.FlatStyle = FlatStyle.Popup;
            btnView.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnView.ForeColor = Color.Black;
            btnView.Location = new Point(549, 236);
            btnView.Name = "btnView";
            btnView.Size = new Size(115, 45);
            btnView.TabIndex = 32;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.BackColor = SystemColors.ControlLight;
            label30.Location = new Point(40, 114);
            label30.Name = "label30";
            label30.Size = new Size(92, 15);
            label30.TabIndex = 33;
            label30.Text = "Admission date:";
            // 
            // lblAdmissionDate
            // 
            lblAdmissionDate.AutoSize = true;
            lblAdmissionDate.BackColor = SystemColors.ControlLight;
            lblAdmissionDate.Location = new Point(167, 114);
            lblAdmissionDate.Name = "lblAdmissionDate";
            lblAdmissionDate.Size = new Size(13, 15);
            lblAdmissionDate.TabIndex = 34;
            lblAdmissionDate.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(49, 152);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(140, 32);
            label4.TabIndex = 38;
            label4.Text = "Patient List";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Location = new Point(2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1371, 88);
            panel1.TabIndex = 86;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(lblLastName);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnView);
            panel2.Controls.Add(lblAccContact);
            panel2.Controls.Add(lblAccRelationship);
            panel2.Controls.Add(lblAccName);
            panel2.Controls.Add(label24);
            panel2.Controls.Add(label23);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(lblContactNo);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(lblAddress);
            panel2.Controls.Add(lblSex);
            panel2.Controls.Add(lblAge);
            panel2.Controls.Add(lblBirthdate);
            panel2.Controls.Add(lblMI);
            panel2.Controls.Add(lblFirstName);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(80, 384);
            panel2.Name = "panel2";
            panel2.Size = new Size(693, 304);
            panel2.TabIndex = 87;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(lblAdmissionDate);
            panel3.Controls.Add(label30);
            panel3.Controls.Add(lblBedNo);
            panel3.Controls.Add(label28);
            panel3.Controls.Add(lblRoomNo);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(794, 384);
            panel3.Name = "panel3";
            panel3.Size = new Size(310, 195);
            panel3.TabIndex = 88;
            // 
            // CashierDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1370, 749);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvPatients);
            Name = "CashierDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CashierDashboard";
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private Label label4;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}