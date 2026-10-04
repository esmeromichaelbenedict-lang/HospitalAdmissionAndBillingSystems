namespace HospitalPRAC.UI.RoomUI
{
    partial class AdminRoomUI
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
            panel5 = new Panel();
            label16 = new Label();
            panel6 = new Panel();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            btnDashboard = new Button();
            panel1 = new Panel();
            label1 = new Label();
            dgvPatients = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panel2 = new Panel();
            label17 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            textBox2 = new TextBox();
            btnTransfer = new Button();
            dateTimePicker1 = new DateTimePicker();
            lblNewRate = new Label();
            cbBedNo = new ComboBox();
            label3 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label18 = new Label();
            btnEdit = new Button();
            btnCancel = new Button();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
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
            panel4.Size = new Size(116, 750);
            panel4.TabIndex = 11;
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
            button7.BackColor = Color.MidnightBlue;
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
            button9.BackColor = Color.FromArgb(0, 0, 64);
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
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(116, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1254, 70);
            panel1.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 16);
            label1.Name = "label1";
            label1.Size = new Size(81, 32);
            label1.TabIndex = 0;
            label1.Text = "Room";
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(303, 141);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.Size = new Size(900, 227);
            dgvPatients.TabIndex = 13;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(150, 87);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(363, 23);
            txtSearch.TabIndex = 14;
            // 
            // btnSearch
            // 
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(531, 80);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 33);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(196, 404);
            panel2.Name = "panel2";
            panel2.Size = new Size(514, 270);
            panel2.TabIndex = 18;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(10, 110);
            label17.Name = "label17";
            label17.Size = new Size(76, 16);
            label17.TabIndex = 24;
            label17.Text = "Room Type:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(17, 206);
            label9.Name = "label9";
            label9.Size = new Size(63, 16);
            label9.TabIndex = 21;
            label9.Text = "Admitted:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(10, 173);
            label8.Name = "label8";
            label8.Size = new Size(71, 16);
            label8.TabIndex = 20;
            label8.Text = "Daily Rate:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 144);
            label7.Name = "label7";
            label7.Size = new Size(58, 16);
            label7.TabIndex = 19;
            label7.Text = "Bed No.:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 81);
            label5.Name = "label5";
            label5.Size = new Size(69, 16);
            label5.TabIndex = 11;
            label5.Text = "Room No.:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 52);
            label4.Name = "label4";
            label4.Size = new Size(52, 16);
            label4.TabIndex = 2;
            label4.Text = "Patient:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 14);
            label2.Name = "label2";
            label2.Size = new Size(201, 25);
            label2.TabIndex = 1;
            label2.Text = "Personal Information";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(comboBox4);
            panel3.Controls.Add(comboBox3);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(btnTransfer);
            panel3.Controls.Add(dateTimePicker1);
            panel3.Controls.Add(lblNewRate);
            panel3.Controls.Add(cbBedNo);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label18);
            panel3.Location = new Point(767, 404);
            panel3.Name = "panel3";
            panel3.Size = new Size(508, 270);
            panel3.TabIndex = 36;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(102, 204);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(302, 23);
            textBox2.TabIndex = 37;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(207, 233);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(83, 26);
            btnTransfer.TabIndex = 39;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(102, 171);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(302, 23);
            dateTimePicker1.TabIndex = 38;
            // 
            // lblNewRate
            // 
            lblNewRate.AutoSize = true;
            lblNewRate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewRate.Location = new Point(102, 144);
            lblNewRate.Name = "lblNewRate";
            lblNewRate.Size = new Size(15, 17);
            lblNewRate.TabIndex = 37;
            lblNewRate.Text = "0";
            // 
            // cbBedNo
            // 
            cbBedNo.FormattingEnabled = true;
            cbBedNo.Location = new Point(102, 110);
            cbBedNo.Name = "cbBedNo";
            cbBedNo.Size = new Size(233, 23);
            cbBedNo.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(35, 112);
            label3.Name = "label3";
            label3.Size = new Size(58, 16);
            label3.TabIndex = 24;
            label3.Text = "Bed No.:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(36, 206);
            label11.Name = "label11";
            label11.Size = new Size(55, 16);
            label11.TabIndex = 21;
            label11.Text = "Reason:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(21, 173);
            label12.Name = "label12";
            label12.Size = new Size(70, 16);
            label12.TabIndex = 20;
            label12.Text = "Date/Time:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(20, 144);
            label13.Name = "label13";
            label13.Size = new Size(67, 16);
            label13.TabIndex = 19;
            label13.Text = "New Rate:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(24, 81);
            label14.Name = "label14";
            label14.Size = new Size(69, 16);
            label14.TabIndex = 11;
            label14.Text = "Room No.:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(17, 52);
            label15.Name = "label15";
            label15.Size = new Size(76, 16);
            label15.TabIndex = 2;
            label15.Text = "Room Type:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(17, 14);
            label18.Name = "label18";
            label18.Size = new Size(143, 25);
            label18.TabIndex = 1;
            label18.Text = "Transfer Room";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(128, 255, 128);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(1035, 80);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(118, 33);
            btnEdit.TabIndex = 37;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ActiveBorder;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(1186, 80);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(118, 33);
            btnCancel.TabIndex = 38;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(102, 79);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(233, 23);
            comboBox3.TabIndex = 40;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(102, 50);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(233, 23);
            comboBox4.TabIndex = 41;
            // 
            // AdminRoomUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(btnCancel);
            Controls.Add(btnEdit);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvPatients);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Name = "AdminRoomUI";
            Text = "AdminRoomUI";
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel4;
        private Panel panel5;
        private Label label16;
        private Panel panel6;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button btnDashboard;
        private Panel panel1;
        private Label label1;
        private DataGridView dgvPatients;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button button1;
        private Button button2;
        private Panel panel2;
        private Label label17;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label2;
        private Panel panel3;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label3;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label18;
        private Button btnTransfer;
        private DateTimePicker dateTimePicker1;
        private Label lblNewRate;
        private ComboBox cbBedNo;
        private TextBox textBox2;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private Button btnEdit;
        private Button btnCancel;
    }
}