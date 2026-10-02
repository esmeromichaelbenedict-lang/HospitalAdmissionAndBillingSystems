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
            cbAnalgesics = new ComboBox();
            cbBetaBlockers = new ComboBox();
            cbIVFluids = new ComboBox();
            cbSyringeIVCannula = new ComboBox();
            textBox1 = new TextBox();
            btnSearch = new Button();
            btnAdd = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            listBox1 = new ListBox();
            label6 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGreen;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(823, 58);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 10);
            label1.Name = "label1";
            label1.Size = new Size(384, 46);
            label1.TabIndex = 0;
            label1.Text = "Welcome back, Nurse! ";
            // 
            // cbAnalgesics
            // 
            cbAnalgesics.FormattingEnabled = true;
            cbAnalgesics.Location = new Point(686, 178);
            cbAnalgesics.Name = "cbAnalgesics";
            cbAnalgesics.Size = new Size(125, 28);
            cbAnalgesics.TabIndex = 1;
            // 
            // cbBetaBlockers
            // 
            cbBetaBlockers.FormattingEnabled = true;
            cbBetaBlockers.Location = new Point(660, 229);
            cbBetaBlockers.Name = "cbBetaBlockers";
            cbBetaBlockers.Size = new Size(151, 28);
            cbBetaBlockers.TabIndex = 2;
            // 
            // cbIVFluids
            // 
            cbIVFluids.FormattingEnabled = true;
            cbIVFluids.Location = new Point(660, 280);
            cbIVFluids.Name = "cbIVFluids";
            cbIVFluids.Size = new Size(151, 28);
            cbIVFluids.TabIndex = 3;
            // 
            // cbSyringeIVCannula
            // 
            cbSyringeIVCannula.FormattingEnabled = true;
            cbSyringeIVCannula.Location = new Point(686, 325);
            cbSyringeIVCannula.Name = "cbSyringeIVCannula";
            cbSyringeIVCannula.Size = new Size(125, 28);
            cbSyringeIVCannula.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 87);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(387, 27);
            textBox1.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(415, 81);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(130, 38);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DarkGreen;
            btnAdd.Location = new Point(639, 386);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 41);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(598, 181);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 8;
            label2.Text = "Analgesics:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(557, 232);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 9;
            label3.Text = "BetaBlockers:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(591, 288);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 10;
            label4.Text = "IVFluids:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(553, 333);
            label5.Name = "label5";
            label5.Size = new Size(127, 20);
            label5.TabIndex = 11;
            label5.Text = "SyringeIVCannula:";
            // 
            // panel2
            // 
            panel2.Controls.Add(label7);
            panel2.Location = new Point(12, 143);
            panel2.Name = "panel2";
            panel2.Size = new Size(520, 131);
            panel2.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.Location = new Point(550, 143);
            panel3.Name = "panel3";
            panel3.Size = new Size(272, 284);
            panel3.TabIndex = 13;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 321);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(520, 164);
            listBox1.TabIndex = 14;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 293);
            label6.Name = "label6";
            label6.Size = new Size(107, 25);
            label6.TabIndex = 15;
            label6.Text = "Patient List";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(10, 12);
            label7.Name = "label7";
            label7.Size = new Size(168, 23);
            label7.TabIndex = 0;
            label7.Text = "Patient Information";
            // 
            // NurseDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 498);
            Controls.Add(label6);
            Controls.Add(listBox1);
            Controls.Add(panel2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnAdd);
            Controls.Add(btnSearch);
            Controls.Add(textBox1);
            Controls.Add(cbSyringeIVCannula);
            Controls.Add(cbIVFluids);
            Controls.Add(cbBetaBlockers);
            Controls.Add(cbAnalgesics);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Margin = new Padding(3, 4, 3, 4);
            Name = "NurseDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NurseDashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox cbAnalgesics;
        private ComboBox cbBetaBlockers;
        private ComboBox cbIVFluids;
        private ComboBox cbSyringeIVCannula;
        private TextBox textBox1;
        private Button btnSearch;
        private Button btnAdd;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel2;
        private Panel panel3;
        private ListBox listBox1;
        private Label label7;
        private Label label6;
    }
}