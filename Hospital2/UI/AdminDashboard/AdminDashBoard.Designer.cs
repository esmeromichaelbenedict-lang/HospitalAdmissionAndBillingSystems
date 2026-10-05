namespace Hospital2.UI
{
    partial class AdminDashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashBoard));
            button1 = new Button();
            panel1 = new Panel();
            button7 = new Button();
            panel4 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            button5 = new Button();
            btnRoom = new Button();
            btnAdmitting = new Button();
            btnPatient = new Button();
            panel3 = new Panel();
            lblAvailableRoomCount = new Label();
            label1 = new Label();
            label2 = new Label();
            panel5 = new Panel();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            panel6 = new Panel();
            label7 = new Label();
            lblPatientCount = new Label();
            pictureBox2 = new PictureBox();
            panel7 = new Panel();
            label9 = new Label();
            lblUserCount = new Label();
            pictureBox3 = new PictureBox();
            label10 = new Label();
            dgvRecentAdmissions = new DataGridView();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecentAdmissions).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.MidnightBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 66);
            button1.Name = "button1";
            button1.Size = new Size(116, 41);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(btnRoom);
            panel1.Controls.Add(btnAdmitting);
            panel1.Controls.Add(btnPatient);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(116, 759);
            panel1.TabIndex = 0;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(192, 0, 0);
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(-1, 656);
            button7.Name = "button7";
            button7.Size = new Size(117, 41);
            button7.TabIndex = 3;
            button7.Text = "Logout";
            button7.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.AppWorkspace;
            panel4.Controls.Add(label3);
            panel4.Location = new Point(150, 116);
            panel4.Name = "panel4";
            panel4.Size = new Size(147, 104);
            panel4.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 20);
            label3.Name = "label3";
            label3.Size = new Size(110, 29);
            label3.TabIndex = 0;
            label3.Text = "Hi, Admin!";
            // 
            // panel2
            // 
            panel2.Location = new Point(122, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 79);
            panel2.TabIndex = 1;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(0, 0, 64);
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(0, 217);
            button5.Name = "button5";
            button5.Size = new Size(116, 41);
            button5.TabIndex = 1;
            button5.Text = "Manage User";
            button5.UseVisualStyleBackColor = false;
            // 
            // btnRoom
            // 
            btnRoom.BackColor = Color.FromArgb(0, 0, 64);
            btnRoom.FlatStyle = FlatStyle.Popup;
            btnRoom.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRoom.ForeColor = Color.White;
            btnRoom.Location = new Point(0, 179);
            btnRoom.Name = "btnRoom";
            btnRoom.Size = new Size(116, 41);
            btnRoom.TabIndex = 1;
            btnRoom.Text = "Room";
            btnRoom.UseVisualStyleBackColor = false;
            btnRoom.Click += btnRoom_Click;
            // 
            // btnAdmitting
            // 
            btnAdmitting.BackColor = Color.FromArgb(0, 0, 64);
            btnAdmitting.FlatStyle = FlatStyle.Popup;
            btnAdmitting.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdmitting.ForeColor = Color.White;
            btnAdmitting.Location = new Point(0, 141);
            btnAdmitting.Name = "btnAdmitting";
            btnAdmitting.Size = new Size(116, 41);
            btnAdmitting.TabIndex = 1;
            btnAdmitting.Text = "Admitting";
            btnAdmitting.UseVisualStyleBackColor = false;
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
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(lblAvailableRoomCount);
            panel3.Location = new Point(115, -1);
            panel3.Name = "panel3";
            panel3.Size = new Size(1269, 66);
            panel3.TabIndex = 1;
            // 
            // lblAvailableRoomCount
            // 
            lblAvailableRoomCount.AutoSize = true;
            lblAvailableRoomCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvailableRoomCount.Location = new Point(7, 10);
            lblAvailableRoomCount.Name = "lblAvailableRoomCount";
            lblAvailableRoomCount.Size = new Size(154, 37);
            lblAvailableRoomCount.TabIndex = 4;
            lblAvailableRoomCount.Text = "Hi, Admin!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(109, 64);
            label1.Name = "label1";
            label1.Size = new Size(15, 17);
            label1.TabIndex = 0;
            label1.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(136, 77);
            label2.Name = "label2";
            label2.Size = new Size(138, 32);
            label2.TabIndex = 1;
            label2.Text = "Dashboard";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(label1);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(pictureBox1);
            panel5.Location = new Point(287, 119);
            panel5.Name = "panel5";
            panel5.Size = new Size(180, 158);
            panel5.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(37, 125);
            label5.Name = "label5";
            label5.Size = new Size(102, 17);
            label5.TabIndex = 4;
            label5.Text = "Available room";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = HospitalPRAC.Properties.Resources._4564982;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(21, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ActiveBorder;
            panel6.Controls.Add(label7);
            panel6.Controls.Add(lblPatientCount);
            panel6.Controls.Add(pictureBox2);
            panel6.Location = new Point(567, 119);
            panel6.Name = "panel6";
            panel6.Size = new Size(180, 158);
            panel6.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(73, 125);
            label7.Name = "label7";
            label7.Size = new Size(52, 17);
            label7.TabIndex = 5;
            label7.Text = "Patient";
            // 
            // lblPatientCount
            // 
            lblPatientCount.AutoSize = true;
            lblPatientCount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPatientCount.Location = new Point(124, 64);
            lblPatientCount.Name = "lblPatientCount";
            lblPatientCount.Size = new Size(15, 17);
            lblPatientCount.TabIndex = 5;
            lblPatientCount.Text = "0";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = HospitalPRAC.Properties.Resources.add;
            pictureBox2.InitialImage = HospitalPRAC.Properties.Resources.download__1_;
            pictureBox2.Location = new Point(34, 47);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(56, 53);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ActiveBorder;
            panel7.Controls.Add(label9);
            panel7.Controls.Add(lblUserCount);
            panel7.Controls.Add(pictureBox3);
            panel7.Location = new Point(891, 119);
            panel7.Name = "panel7";
            panel7.Size = new Size(180, 158);
            panel7.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(78, 121);
            label9.Name = "label9";
            label9.Size = new Size(35, 17);
            label9.TabIndex = 6;
            label9.Text = "User";
            // 
            // lblUserCount
            // 
            lblUserCount.AutoSize = true;
            lblUserCount.BackColor = Color.Transparent;
            lblUserCount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserCount.ForeColor = Color.Black;
            lblUserCount.Location = new Point(128, 70);
            lblUserCount.Name = "lblUserCount";
            lblUserCount.Size = new Size(15, 17);
            lblUserCount.TabIndex = 6;
            lblUserCount.Text = "0";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.Center;
            pictureBox3.Image = HospitalPRAC.Properties.Resources.user;
            pictureBox3.InitialImage = HospitalPRAC.Properties.Resources.download__1_;
            pictureBox3.Location = new Point(31, 47);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(56, 53);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(136, 328);
            label10.Name = "label10";
            label10.Size = new Size(222, 32);
            label10.TabIndex = 4;
            label10.Text = "Recent Dashboard";
            // 
            // dgvRecentAdmissions
            // 
            dgvRecentAdmissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentAdmissions.Location = new Point(136, 363);
            dgvRecentAdmissions.Name = "dgvRecentAdmissions";
            dgvRecentAdmissions.Size = new Size(1126, 182);
            dgvRecentAdmissions.TabIndex = 5;
            // 
            // AdminDashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(dgvRecentAdmissions);
            Controls.Add(label10);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(label2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "AdminDashBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminDashBoard";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecentAdmissions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private Panel panel2;
        private Button button5;
        private Button btnRoom;
        private Button btnAdmitting;
        private Button btnPatient;
        private Panel panel3;
        private Label label1;
        private Panel panel4;
        private Label label3;
        private Label label2;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Label label5;
        private Label lblAvailableRoomCount;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label7;
        private Label lblPatientCount;
        private Label lblUserCount;
        private PictureBox pictureBox3;
        private Label label9;
        private Label label10;
        private Button button7;
        private DataGridView dgvRecentAdmissions;
    }
}