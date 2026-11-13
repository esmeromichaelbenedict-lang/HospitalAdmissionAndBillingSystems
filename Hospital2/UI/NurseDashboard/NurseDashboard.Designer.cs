namespace Hospital2.UI.NurseDashboard
{
    partial class NurseDashboard
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
            label1 = new Label();
            cmbAnalgesics = new ComboBox();
            cmbBetaBlockers = new ComboBox();
            cmbIVFluids = new ComboBox();
            cmbSyringeIVCannula = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAdd = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            lblBed = new Label();
            lblRoom = new Label();
            lblRoomType = new Label();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            label20 = new Label();
            lblWeight = new Label();
            lblHeight = new Label();
            lblSex = new Label();
            lblAge = new Label();
            lblDOB = new Label();
            lblFullName = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            dgvPatients = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGreen;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -1);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1375, 44);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 8);
            label1.Name = "label1";
            label1.Size = new Size(309, 37);
            label1.TabIndex = 0;
            label1.Text = "Welcome back, Nurse! ";
            // 
            // cmbAnalgesics
            // 
            cmbAnalgesics.FormattingEnabled = true;
            cmbAnalgesics.Location = new Point(214, 26);
            cmbAnalgesics.Margin = new Padding(3, 2, 3, 2);
            cmbAnalgesics.Name = "cmbAnalgesics";
            cmbAnalgesics.Size = new Size(266, 23);
            cmbAnalgesics.TabIndex = 1;
            // 
            // cmbBetaBlockers
            // 
            cmbBetaBlockers.FormattingEnabled = true;
            cmbBetaBlockers.Location = new Point(214, 64);
            cmbBetaBlockers.Margin = new Padding(3, 2, 3, 2);
            cmbBetaBlockers.Name = "cmbBetaBlockers";
            cmbBetaBlockers.Size = new Size(266, 23);
            cmbBetaBlockers.TabIndex = 2;
            // 
            // cmbIVFluids
            // 
            cmbIVFluids.FormattingEnabled = true;
            cmbIVFluids.Location = new Point(214, 101);
            cmbIVFluids.Margin = new Padding(3, 2, 3, 2);
            cmbIVFluids.Name = "cmbIVFluids";
            cmbIVFluids.Size = new Size(266, 23);
            cmbIVFluids.TabIndex = 3;
            // 
            // cmbSyringeIVCannula
            // 
            cmbSyringeIVCannula.FormattingEnabled = true;
            cmbSyringeIVCannula.Location = new Point(214, 140);
            cmbSyringeIVCannula.Margin = new Padding(3, 2, 3, 2);
            cmbSyringeIVCannula.Name = "cmbSyringeIVCannula";
            cmbSyringeIVCannula.Size = new Size(266, 23);
            cmbSyringeIVCannula.TabIndex = 4;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(10, 65);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(562, 23);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(578, 61);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 28);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DarkGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(297, 199);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(87, 31);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(131, 29);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 8;
            label2.Text = "Analgesics:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(120, 67);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 9;
            label3.Text = "BetaBlockers:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(146, 104);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 10;
            label4.Text = "IVFluids:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Location = new Point(94, 143);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 11;
            label5.Text = "SyringeIVCannula:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblBed);
            panel2.Controls.Add(lblRoom);
            panel2.Controls.Add(lblRoomType);
            panel2.Controls.Add(label23);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(lblWeight);
            panel2.Controls.Add(lblHeight);
            panel2.Controls.Add(lblSex);
            panel2.Controls.Add(lblAge);
            panel2.Controls.Add(lblDOB);
            panel2.Controls.Add(lblFullName);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(39, 372);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(571, 292);
            panel2.TabIndex = 12;
            panel2.Paint += panel2_Paint;
            // 
            // lblBed
            // 
            lblBed.AutoSize = true;
            lblBed.Location = new Point(448, 143);
            lblBed.Name = "lblBed";
            lblBed.Size = new Size(13, 15);
            lblBed.TabIndex = 18;
            lblBed.Text = "0";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Location = new Point(448, 101);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(13, 15);
            lblRoom.TabIndex = 17;
            lblRoom.Text = "0";
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(448, 64);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(13, 15);
            lblRoomType.TabIndex = 16;
            lblRoomType.Text = "0";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(332, 143);
            label23.Name = "label23";
            label23.Size = new Size(77, 15);
            label23.TabIndex = 15;
            label23.Text = "Bed Number:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(367, 101);
            label22.Name = "label22";
            label22.Size = new Size(42, 15);
            label22.TabIndex = 14;
            label22.Text = "Room:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(339, 64);
            label21.Name = "label21";
            label21.Size = new Size(70, 15);
            label21.TabIndex = 13;
            label21.Text = "Room Type:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(379, 9);
            label20.Name = "label20";
            label20.Size = new Size(132, 19);
            label20.TabIndex = 12;
            label20.Text = "Room Information";
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Location = new Point(120, 215);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(13, 15);
            lblWeight.TabIndex = 11;
            lblWeight.Text = "0";
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Location = new Point(120, 177);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(13, 15);
            lblHeight.TabIndex = 10;
            lblHeight.Text = "0";
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Location = new Point(120, 143);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(13, 15);
            lblSex.TabIndex = 9;
            lblSex.Text = "0";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(120, 250);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(13, 15);
            lblAge.TabIndex = 9;
            lblAge.Text = "0";
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(120, 104);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(13, 15);
            lblDOB.TabIndex = 8;
            lblDOB.Text = "0";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(120, 64);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(13, 15);
            lblFullName.TabIndex = 7;
            lblFullName.Text = "0";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(59, 250);
            label13.Name = "label13";
            label13.Size = new Size(31, 15);
            label13.TabIndex = 6;
            label13.Text = "Age:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(42, 215);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 5;
            label12.Text = "Weight:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(44, 177);
            label11.Name = "label11";
            label11.Size = new Size(46, 15);
            label11.TabIndex = 4;
            label11.Text = "Height:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(63, 143);
            label10.Name = "label10";
            label10.Size = new Size(27, 15);
            label10.TabIndex = 3;
            label10.Text = "Sex:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 104);
            label9.Name = "label9";
            label9.Size = new Size(76, 15);
            label9.TabIndex = 2;
            label9.Text = "Date of Birth:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 64);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 1;
            label8.Text = "Full Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(9, 9);
            label7.Name = "label7";
            label7.Size = new Size(139, 19);
            label7.TabIndex = 0;
            label7.Text = "Patient Information";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(cmbSyringeIVCannula);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(cmbIVFluids);
            panel3.Controls.Add(btnAdd);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(cmbBetaBlockers);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(cmbAnalgesics);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(701, 372);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(630, 292);
            panel3.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(210, 101);
            label6.Name = "label6";
            label6.Size = new Size(88, 20);
            label6.TabIndex = 15;
            label6.Text = "Patient List";
            // 
            // dgvPatients
            // 
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(226, 124);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.Size = new Size(875, 223);
            dgvPatients.TabIndex = 16;
            // 
            // NurseDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(dgvPatients);
            Controls.Add(label6);
            Controls.Add(panel2);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "NurseDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NurseDashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox cmbAnalgesics;
        private ComboBox cmbBetaBlockers;
        private ComboBox cmbIVFluids;
        private ComboBox cmbSyringeIVCannula;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAdd;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel2;
        private Panel panel3;
        private Label label7;
        private Label label6;
        private DataGridView dgvPatients;
        private Label label8;
        private Label lblWeight;
        private Label lblHeight;
        private Label lblSex;
        private Label lblAge;
        private Label lblDOB;
        private Label lblFullName;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label lblBed;
        private Label lblRoom;
        private Label lblRoomType;
        private Label label23;
    }
}