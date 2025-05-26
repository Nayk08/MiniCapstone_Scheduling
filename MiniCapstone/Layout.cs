using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniCapstone
{
    public partial class Layout : Form
    {



        public Layout()
        {
            InitializeComponent();
            guna2Panel1.BackColor = ColorTranslator.FromHtml("#252525");



        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void adminShowValues(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return;
            }

            // Debug statements to log the username and password
            Console.WriteLine($"Username: {username}, Password: {password}");

            try
            {
                string displayQuery = "SELECT UserName, PICTURE FROM UserInfo_TBL WHERE UserName = @username AND Password = @password";

                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    using (SqlCommand command = new SqlCommand(displayQuery, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Namelbl.Text = reader["UserName"].ToString();

                                if (reader["PICTURE"] != DBNull.Value)
                                {
                                    byte[] pictureData = (byte[])reader["PICTURE"];
                                    using (MemoryStream ms = new MemoryStream(pictureData))
                                    {
                                        Imagepic.Image = Image.FromStream(ms);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No matching user found in the database.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }




        private void Dashboard_Load(object sender, EventArgs e)

        {

            adminShowValues(Login.username, Login.password);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Scheduler scheduler = new Scheduler();
            scheduler.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void guna2Button1_MouseEnter(object sender, EventArgs e)
        {
            Dashboardbtn.BackColor = ColorTranslator.FromHtml("#4e31aa");
        }

        private void Dashboardbtn_MouseLeave(object sender, EventArgs e)
        {
            Dashboardbtn.BackColor = ColorTranslator.FromHtml("#252525");
        }

        private void Dashboardbtn_MouseHover(object sender, EventArgs e)
        {

        }

        private void Schedulerbtn_MouseEnter(object sender, EventArgs e)
        {
            Schedulerbtn.BackColor = ColorTranslator.FromHtml("#4e31aa");
        }

        private void Schedulerbtn_MouseLeave(object sender, EventArgs e)
        {
            Schedulerbtn.BackColor = ColorTranslator.FromHtml("#252525");
        }

        private void Recordsbtn_Click(object sender, EventArgs e)
        {
            AppointmentRecords history = new AppointmentRecords();
            history.Show();
            this.Hide();
        }

        private void Recordsbtn_MouseEnter(object sender, EventArgs e)
        {
            Recordsbtn.BackColor = ColorTranslator.FromHtml("#4e31aa");
        }

        private void Recordsbtn_MouseLeave(object sender, EventArgs e)
        {
            Recordsbtn.BackColor = ColorTranslator.FromHtml("#252525");
        }





        private void Logoutbtn_MouseEnter(object sender, EventArgs e)
        {
            Logoutbtn.BackColor = ColorTranslator.FromHtml("#4e31aa");
        }

        private void Logoutbtn_MouseLeave(object sender, EventArgs e)
        {
            Logoutbtn.BackColor = ColorTranslator.FromHtml("#252525");
        }

        private void Walkinbtn_Click(object sender, EventArgs e)
        {
            WalkinsRecords walkinsRecords = new WalkinsRecords();
            walkinsRecords.Show();
            this.Hide();
        }
    }
}
