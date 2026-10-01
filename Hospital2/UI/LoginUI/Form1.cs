using Hospital2.BusinessLogic.Controller;
using Hospital2.Model;
using Hospital2.UI;
using Hospital2.UI.CashierDashboard;

using Hospital2.UI.NurseDashboard;

namespace Hospital2
{
    public partial class Form1 : Form
    {
        private UserController userController;
        public Form1()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserModel matchingUser = userController.ValidateUser(txtUsername.Text, txtPassword.Text);

                if (matchingUser != null)
                {
                    this.Hide();

                    switch (matchingUser.Role)
                    {
                        case "Nurse":
                            NurseDashboard nurseForm = new NurseDashboard();
                            nurseForm.FormClosed += (s, args) => this.Close();
                            nurseForm.Show();
                            break;

                        case "Admin":
                            AdminDashBoard adminForm = new AdminDashBoard();
                            adminForm.FormClosed += (s, args) => this.Close();
                            adminForm.Show();
                            break;

                        case "Cashier":
                            CashierDashboard cashierForm = new CashierDashboard();
                            cashierForm.FormClosed += (s, args) => this.Close();
                            cashierForm.Show();
                            break;

                        default:
                            MessageBox.Show("Walang dashboard para sa role na: " + matchingUser.Role);
                            this.Show();
                            break;
                    }
                }
                else
                {
                    throw new Exception("Invalid Credentials");
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                this.Show();
            }

        }
    }
}
