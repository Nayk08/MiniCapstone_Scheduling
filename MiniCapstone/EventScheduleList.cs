using Azure;
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
    public partial class EventScheduleList : Form
    {
        



        public EventScheduleList()
        {
            InitializeComponent();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {


        }

        public void refreshData(DateTime selectedDate)
        {
            DisplaySchdeulelist(selectedDate);
        }


        public void DisplaySchdeulelist(DateTime selectedDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();

                    string Displayschedlist = "SELECT * FROM Transaction_TBL WHERE ScheduleDate = @date ORDER BY Appointment ASC";

                    using (SqlCommand cmd = new SqlCommand(Displayschedlist, conn))
                    {
                        // Ensure only the date is passed to the parameter
                        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.Date)).Value = selectedDate.Date;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable eventTable = new DataTable();
                            eventTable.Load(reader);

                            // Bind the data to the DataGridView
                            guna2DataGridView1.DataSource = eventTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void EventScheduleList_Load(object sender, EventArgs e)
        {

        }

        public void Delete(string clientName, string scheduleDate, string operation)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrWhiteSpace(clientName) || string.IsNullOrWhiteSpace(scheduleDate) || string.IsNullOrWhiteSpace(operation))
                    {
                        MessageBox.Show("Please provide valid data.");
                    }
                    else
                    {
                        string deleteQuery = "DELETE FROM Transaction_TBL WHERE ClientName = @ClientName AND ScheduleDate = @ScheduleDate AND Appointment = @Appointment";

                        using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ClientName", clientName);
                            command.Parameters.AddWithValue("@ScheduleDate", scheduleDate);
                            command.Parameters.AddWithValue("@Operation", operation);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully.");
                                refreshData(DateTime.Parse(scheduleDate));
                            }
                            else
                            {
                                MessageBox.Show("No record found with the provided details.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

     







        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string clientName = guna2DataGridView1.SelectedRows[0].Cells["ClientName"].Value.ToString();
                string scheduleDate = guna2DataGridView1.SelectedRows[0].Cells["ScheduleDate"].Value.ToString();
                string Appointment = guna2DataGridView1.SelectedRows[0].Cells["Appointment"].Value.ToString();

                // Call Delete to delete the selected record
                Delete(clientName, scheduleDate, Appointment);


            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }


        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            AppointmentForm eventForm = new AppointmentForm();
            eventForm.Show();
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
