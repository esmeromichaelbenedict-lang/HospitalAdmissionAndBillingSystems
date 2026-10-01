namespace HospitalPRAC.UI.AdminPatient
{
    partial class Patient
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
            button9 = new Button();
            SuspendLayout();
            // 
            // button9
            // 
            button9.BackColor = Color.Red;
            button9.FlatStyle = FlatStyle.Popup;
            button9.ForeColor = Color.Black;
            button9.Location = new Point(1044, 68);
            button9.Name = "button9";
            button9.Size = new Size(124, 33);
            button9.TabIndex = 8;
            button9.Text = "Delete";
            button9.UseVisualStyleBackColor = false;
            // 
            // Patient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 521);
            Controls.Add(button9);
            Name = "Patient";
            Text = "Patient";
            ResumeLayout(false);
        }

        #endregion
        private Button button9;
    }
}