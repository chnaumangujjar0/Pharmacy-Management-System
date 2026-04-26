using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PharmacyMS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }



        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsernameBox.Text.Trim();
            string password = txtPasswordBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Username and Password!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p";

            using (SqlConnection con = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                con.Open();
                int result = (int)cmd.ExecuteScalar();

                if (result == 1)
                {
                    MessageBox.Show("✅ Welcome " + username + "!", "Login Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide(); // ← Hide login, open dashboard
                }
                else
                {
                    MessageBox.Show("❌ Wrong Username or Password!", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPasswordBox.Clear();      // Clear password only
                    txtUsernameBox.Focus();
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Set Enter key to trigger login
            this.AcceptButton = btnLogin;
        }
    }
}
