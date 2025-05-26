
using Microsoft.Data.SqlClient;

namespace MiniCapstone
{
    public partial class Login : Form
    {
        public static string username, password;

        

        public Login()
        {
            InitializeComponent();
            Passwordtxt.UseSystemPasswordChar = true;
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (guna2CheckBox1.Checked == true)
            {
                Passwordtxt.UseSystemPasswordChar = false;
            }
            else
            {
                Passwordtxt.UseSystemPasswordChar = true;
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Signupform form = new Signupform();
            form.Show();
            this.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            username = Usernametxt.Text.Trim();
            password = Passwordtxt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (ValidateLogin(username, password))
            {
                MessageBox.Show("Login successful!");

                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }



        private bool ValidateLogin(string username, string password)
        {
          

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM UserInfo_TBL WHERE UserName = @UserName AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@Password", password); // In production, use hashed passwords.

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0; // Return true if a matching record is found.
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }


    }
}



