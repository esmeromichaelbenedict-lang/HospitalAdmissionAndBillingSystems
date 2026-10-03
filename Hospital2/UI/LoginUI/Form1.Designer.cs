namespace Hospital2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            pnlLogin = new Panel();
            label4 = new Label();
            label3 = new Label();
            pictureBoxHospital = new PictureBox();
            pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHospital).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.CornflowerBlue;
            btnLogin.Location = new Point(220, 329);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(138, 32);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Control;
            txtPassword.Location = new Point(167, 284);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(244, 23);
            txtPassword.TabIndex = 6;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.Control;
            txtUsername.ForeColor = SystemColors.WindowText;
            txtUsername.Location = new Point(167, 233);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(244, 23);
            txtUsername.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(167, 214);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 8;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(167, 265);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 9;
            label2.Text = "Password";
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.Controls.Add(label4);
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Location = new Point(366, 11);
            pnlLogin.Margin = new Padding(2, 2, 2, 2);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(586, 517);
            pnlLogin.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(210, 171);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(174, 19);
            label4.TabIndex = 11;
            label4.Text = "Please login to your account";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(188, 134);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(212, 37);
            label3.TabIndex = 10;
            label3.Text = "Welcome Back!";
            // 
            // pictureBoxHospital
            // 
            pictureBoxHospital.Image = HospitalPRAC.Properties.Resources.login1;
            pictureBoxHospital.Location = new Point(-6, -3);
            pictureBoxHospital.Margin = new Padding(2, 2, 2, 2);
            pictureBoxHospital.Name = "pictureBoxHospital";
            pictureBoxHospital.Size = new Size(359, 596);
            pictureBoxHospital.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHospital.TabIndex = 12;
            pictureBoxHospital.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(963, 539);
            Controls.Add(pictureBoxHospital);
            Controls.Add(pnlLogin);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHospital).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel pnlLogin;
        private Label label4;
        private Label label3;
        private PictureBox pictureBoxHospital;
    }
}
