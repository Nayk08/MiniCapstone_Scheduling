using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniCapstone
{
    public partial class Signupform : Form
    {
        ArrayList Gender = new ArrayList();
        string fname, lname, email, gender, password, confirmpass, userName;
        long contactnum;
        Image IMG;
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        string passwordPattern = @"^[A-Z][a-zA-Z0-9]{7,}$";
        string contactNumberPattern = @"^(\d{10}|\d{3}[\s\-]?\d{3}[\s\-]?\d{4})$";

        public Signupform()
        {
            InitializeComponent();

            Gender.Add("Male");
            Gender.Add("Female");

            foreach (string i in Gender)
            {
                Gendercmbx.Items.Add(i);
            }



        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null) return null; // Return null if the image is not set
            using (var ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Save the image in JPEG format
                return ms.ToArray(); // Convert to byte array
            }
        }

        private void Signupform_Load(object sender, EventArgs e)
        {

        }

        private void Signupform_Load_1(object sender, EventArgs e)
        {
            Gendercmbx.Items.Insert(0, "---Choose Gender---");
            //set the text
            Gendercmbx.Text = "---Choose Gender---";

        }


        private void Gendercmbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)

        {
            Signup();
        }

        public void Signup()
        {
            try
            {
                // Retrieve input values
                fname = Fnametxt.Text.Trim();
                lname = Lnametxt.Text.Trim();
                gender = Gendercmbx.Text.Trim();
                email = Emailtxt.Text.Trim();
                userName = UserNametxt.Text.Trim();
                password = Passwordtxt.Text;
                confirmpass = Confirmpasstxt.Text;

                if (!long.TryParse(ContactNumtxt.Text.Trim(), out contactnum)) { MessageBox.Show("Enter a valid contact number."); return; }
                if (string.IsNullOrEmpty(userName)) { MessageBox.Show("Enter  Username"); return; }
                if (string.IsNullOrEmpty(fname)) { MessageBox.Show("Enter First name"); return; }
                if (string.IsNullOrEmpty(lname)) { MessageBox.Show("Enter Last name"); return; }
                if (string.IsNullOrEmpty(email)) { MessageBox.Show("Enter Email"); return; }
                if (gender == "---Choose Gender---" || string.IsNullOrEmpty(gender)) { MessageBox.Show("Select a valid Gender"); return; }
                if (contactnum <= 0) { MessageBox.Show("Enter a valid Contact number"); return; }
                if (string.IsNullOrEmpty(password)) { MessageBox.Show("Enter Password"); return; }
                if (string.IsNullOrEmpty(confirmpass)) { MessageBox.Show("Enter Confirm Password"); return; }
                if (password != confirmpass) { MessageBox.Show("Passwords do not match"); return; }
                if (!Regex.IsMatch(email, emailPattern)) { MessageBox.Show("Enter a valid email address."); return; }
                if (!Regex.IsMatch(password, passwordPattern)) { MessageBox.Show("Enter a valid password."); return; }
                if (!Regex.IsMatch(contactnum.ToString(), contactNumberPattern)) { MessageBox.Show("Enter a valid number."); return; }

                // Convert image to byte array
                byte[] imageBytes = ConvertImageToByteArray(ProfilePbx.Image);

                

                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    try
                    {
                        conn.Open();


                        // SQL Query for inserting data
                        string query = "INSERT INTO UserInfo_TBL (FirstName, LastName, Email, ContactNumber, Password, Picture,UserName) " +
                                       "VALUES (@FirstName, @LastName, @Email, @ContactNumber, @Password, @Picture,@Username)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Add parameters
                            cmd.Parameters.AddWithValue("@FirstName", fname);
                            cmd.Parameters.AddWithValue("@LastName", lname);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@ContactNumber", contactnum);
                            cmd.Parameters.AddWithValue("@Password", password); // Hash in production
                            cmd.Parameters.AddWithValue("@Picture", (object)imageBytes ?? DBNull.Value); // Handle null images
                            cmd.Parameters.AddWithValue("@Username", userName);

                            // Execute the query
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                                MessageBox.Show("User data inserted successfully!");
                            else
                                MessageBox.Show("Insertion failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

                // Success
                MessageBox.Show("Successfully Created");
                Login form = new Login();
                form.Show();
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please check your entries.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }






        private void guna2Button2_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpeg;*.jpg;*.png;*.tiff)|*.BMP;*.JPEG;*.JPG;*.PNG;*.TIFF";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        IMG = Image.FromFile(openFileDialog.FileName);
                        ProfilePbx.Image = IMG; // Display the image in the PictureBox
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to load image: " + ex.Message);
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Close();
        }
    }
}


