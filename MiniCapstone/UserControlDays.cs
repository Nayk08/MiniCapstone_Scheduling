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
    public partial class UserControlDays : UserControl
    {
        public static string static_day;
        

        public UserControlDays()
        {
            InitializeComponent();
        }

        public void days(int numday)
        {
            label1.Text = numday + "";
        }
        private void UserControlDays_Load(object sender, EventArgs e)
        {
            displayEvent();
        }

        private void displayEvent()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString = ConnectionString.connectionString))
                {
                    conn.Open();

                    // Prepare and execute SQL query
                    string query = @"
                SELECT COUNT(*) 
                FROM Transaction_TBL 
                WHERE ScheduleDate = @Date AND 
                      Appointment BETWEEN @StartTime AND @EndTime";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Construct a valid DateTime object
                        if (int.TryParse(Scheduler.static_year, out int year) &&
                            int.TryParse(Scheduler.static_month, out int month) &&
                            int.TryParse(label1.Text, out int day))
                        {
                            DateTime scheduleDate = new DateTime(year, month, day);
                            cmd.Parameters.AddWithValue("@Date", scheduleDate.Date);
                            cmd.Parameters.AddWithValue("@StartTime", new TimeSpan(8, 0, 0)); // 8:00 AM
                            cmd.Parameters.AddWithValue("@EndTime", new TimeSpan(16, 0, 0)); // 4:00 PM

                            // Execute the query
                            int appointmentCount = (int)cmd.ExecuteScalar();

                            // Check if the day is fully booked
                            if (appointmentCount >= 8) // Assuming one appointment per hour
                            {
                                eventlbl.Text = "Full \n Appointmented";
                            }
                            else if (appointmentCount > 0)
                            {
                                eventlbl.Text = "Booked";
                            }
                            else
                            {
                                eventlbl.Text = "No \n Appointments";
                            }

                            // Disable past dates
                            if (scheduleDate < DateTime.Now.Date)
                            {
                                eventlbl.Text = "Disabled";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: Invalid date format.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = label1.Text;
            timer1.Start();

            if (TryParseDate(out DateTime selectedDate) && selectedDate < DateTime.Now.Date)
            {
                MessageBox.Show("This date is in the past. Events cannot be created or edited for past dates.",
                                "Date Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AppointmentForm eventForm = new AppointmentForm();
                eventForm.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }

        private void UserControlDays_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {

            if (TryParseDate(out DateTime selectedDate) && selectedDate < DateTime.Now.Date)
            {
                MessageBox.Show("This date is in the past. Events cannot be created or edited for past dates.",
                                "Date Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EventScheduleList eventScheduleList = new EventScheduleList();
                eventScheduleList.Show();
                eventScheduleList.DisplaySchdeulelist(selectedDate);
            }





        }

        private bool TryParseDate(out DateTime parsedDate)
        {
            parsedDate = default;

            if (int.TryParse(Scheduler.static_year, out int year) &&
                int.TryParse(Scheduler.static_month, out int month) &&
                int.TryParse(label1.Text, out int day))
            {
                try
                {
                    parsedDate = new DateTime(year, month, day);
                    return true;
                }
                catch
                {

                    return false;
                }
            }

            return false;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}