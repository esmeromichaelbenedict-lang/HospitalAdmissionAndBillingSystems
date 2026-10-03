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
            button4 = new Button();
            button3 = new Button();
            btnPatient = new Button();
            panel3 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel5 = new Panel();
            label5 = new Label();
            lblAvailableRoomCount = new Label();
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
            button1.BackColor = Color.FromArgb(0, 0, 64);
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
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(btnPatient);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(116, 503);
            panel1.TabIndex = 0;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(192, 0, 0);
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(0, 462);
            button7.Name = "button7";
            button7.Size = new Size(116, 41);
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
            // button4
            // 
            button4.BackColor = Color.FromArgb(0, 0, 64);
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(0, 179);
            button4.Name = "button4";
            button4.Size = new Size(116, 41);
            button4.TabIndex = 1;
            button4.Text = "Room";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 0, 64);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(0, 141);
            button3.Name = "button3";
            button3.Size = new Size(116, 41);
            button3.TabIndex = 1;
            button3.Text = "Admitting";
            button3.UseVisualStyleBackColor = false;
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
            panel3.Controls.Add(label1);
            panel3.Location = new Point(115, -1);
            panel3.Name = "panel3";
            panel3.Size = new Size(688, 66);
            panel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(137, 32);
            label1.TabIndex = 0;
            label1.Text = "Hi, Admin!";
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
            panel5.Controls.Add(label5);
            panel5.Controls.Add(lblAvailableRoomCount);
            panel5.Controls.Add(pictureBox1);
            panel5.Location = new Point(150, 119);
            panel5.Name = "panel5";
            panel5.Size = new Size(131, 100);
            panel5.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 77);
            label5.Name = "label5";
            label5.Size = new Size(102, 17);
            label5.TabIndex = 4;
            label5.Text = "Available room";
            // 
            // lblAvailableRoomCount
            // 
            lblAvailableRoomCount.AutoSize = true;
            lblAvailableRoomCount.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvailableRoomCount.Location = new Point(87, 30);
            lblAvailableRoomCount.Name = "lblAvailableRoomCount";
            lblAvailableRoomCount.Size = new Size(16, 20);
            lblAvailableRoomCount.TabIndex = 4;
            lblAvailableRoomCount.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = HospitalPRAC.Properties.Resources._4564982;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(12, 16);
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
            panel6.Location = new Point(397, 119);
            panel6.Name = "panel6";
            panel6.Size = new Size(131, 100);
            panel6.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(45, 77);
            label7.Name = "label7";
            label7.Size = new Size(52, 17);
            label7.TabIndex = 5;
            label7.Text = "Patient";
            // 
            // lblPatientCount
            // 
            lblPatientCount.AutoSize = true;
            lblPatientCount.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPatientCount.Location = new Point(96, 30);
            lblPatientCount.Name = "lblPatientCount";
            lblPatientCount.Size = new Size(16, 20);
            lblPatientCount.TabIndex = 5;
            lblPatientCount.Text = "0";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = HospitalPRAC.Properties.Resources.add;
            pictureBox2.InitialImage = HospitalPRAC.Properties.Resources.download__1_;
            pictureBox2.Location = new Point(18, 16);
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
            panel7.Location = new Point(638, 119);
            panel7.Name = "panel7";
            panel7.Size = new Size(131, 100);
            panel7.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(90, 30);
            label9.Name = "label9";
            label9.Size = new Size(16, 20);
            label9.TabIndex = 6;
            label9.Text = "0";
            // 
            // lblUserCount
            // 
            lblUserCount.AutoSize = true;
            lblUserCount.BackColor = Color.Transparent;
            lblUserCount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserCount.ForeColor = Color.Black;
            lblUserCount.Location = new Point(46, 77);
            lblUserCount.Name = "lblUserCount";
            lblUserCount.Size = new Size(35, 17);
            lblUserCount.TabIndex = 6;
            lblUserCount.Text = "User";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.Center;
            pictureBox3.Image = HospitalPRAC.Properties.Resources.user;
            pictureBox3.InitialImage = HospitalPRAC.Properties.Resources.download__1_;
            pictureBox3.Location = new Point(16, 16);
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
            label10.Location = new Point(136, 262);
            label10.Name = "label10";
            label10.Size = new Size(222, 32);
            label10.TabIndex = 4;
            label10.Text = "Recent Dashboard";
            // 
            // dgvRecentAdmissions
            // 
            dgvRecentAdmissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentAdmissions.Location = new Point(150, 306);
            dgvRecentAdmissions.Name = "dgvRecentAdmissions";
            dgvRecentAdmissions.Size = new Size(619, 182);
            dgvRecentAdmissions.TabIndex = 5;
            // 
            // AdminDashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 500);
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
        private Button button4;
        private Button button3;
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