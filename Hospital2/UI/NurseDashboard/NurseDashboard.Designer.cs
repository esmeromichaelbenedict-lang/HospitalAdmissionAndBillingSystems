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
            lblWelcome = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            cbAnalgesics = new ComboBox();
            cbBetaBlockers = new ComboBox();
            cbIVFluids = new ComboBox();
            cbSyringeIVCannula = new ComboBox();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            btnAdd = new Button();
            listBox1 = new ListBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGreen;
            panel1.Controls.Add(lblWelcome);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1059, 55);
            panel1.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(3, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(375, 46);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome back, Nurse!";
            lblWelcome.Click += label1_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(50, 100);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(128, 23);
            lblSearch.TabIndex = 1;
            lblSearch.Text = " Search Patient:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(175, 96);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(218, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(399, 93);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(119, 33);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // cbAnalgesics
            // 
            cbAnalgesics.FormattingEnabled = true;
            cbAnalgesics.Items.AddRange(new object[] { "Juan Dela Cruz", "Maria Santos", "Pedro Reyes", "Ana Garcia" });
            cbAnalgesics.Location = new Point(886, 207);
            cbAnalgesics.Name = "cbAnalgesics";
            cbAnalgesics.Size = new Size(151, 28);
            cbAnalgesics.TabIndex = 4;
            // 
            // cbBetaBlockers
            // 
            cbBetaBlockers.FormattingEnabled = true;
            cbBetaBlockers.Location = new Point(858, 264);
            cbBetaBlockers.Name = "cbBetaBlockers";
            cbBetaBlockers.Size = new Size(179, 28);
            cbBetaBlockers.TabIndex = 6;
            // 
            // cbIVFluids
            // 
            cbIVFluids.FormattingEnabled = true;
            cbIVFluids.Location = new Point(858, 319);
            cbIVFluids.Name = "cbIVFluids";
            cbIVFluids.Size = new Size(179, 28);
            cbIVFluids.TabIndex = 7;
            // 
            // cbSyringeIVCannula
            // 
            cbSyringeIVCannula.FormattingEnabled = true;
            cbSyringeIVCannula.Location = new Point(886, 372);
            cbSyringeIVCannula.Name = "cbSyringeIVCannula";
            cbSyringeIVCannula.Size = new Size(145, 28);
            cbSyringeIVCannula.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.Location = new Point(852, 529);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(185, 47);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(22, 460);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(703, 244);
            listBox1.TabIndex = 10;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(22, 174);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(703, 239);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Patient Information";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(788, 215);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 12;
            label1.Text = "Analgesics:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(755, 267);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 13;
            label2.Text = "BetaBlockers:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(788, 322);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 14;
            label3.Text = "IVFluids:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(747, 375);
            label4.Name = "label4";
            label4.Size = new Size(133, 20);
            label4.TabIndex = 15;
            label4.Text = "Syringe/IVCannula:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 419);
            label5.Name = "label5";
            label5.Size = new Size(163, 38);
            label5.TabIndex = 16;
            label5.Text = "Patient List";
            // 
            // NurseDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 715);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(listBox1);
            Controls.Add(btnAdd);
            Controls.Add(cbSyringeIVCannula);
            Controls.Add(cbIVFluids);
            Controls.Add(cbBetaBlockers);
            Controls.Add(cbAnalgesics);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "NurseDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NurseDashboard";
            Load += NurseDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblWelcome;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private ComboBox cbAnalgesics;
        private ComboBox cbBetaBlockers;
        private ComboBox cbIVFluids;
        private ComboBox cbSyringeIVCannula;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Button btnAdd;
        private ListBox listBox1;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}