using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MiniCapstone
{
    public partial class AppointmentForm : Form
    {
        string clientname, sched, evnt;
        int appointmentID;
     

        public string ClientName { get { return clientname; } set { clientname = value; } }
        public string Schedule { get { return sched; } set { sched = value; } }
        public string Events { get { return evnt; } set { evnt = value; } }
        public AppointmentForm()
        {
            InitializeComponent();
            ArrayList H = new ArrayList();
            ArrayList ampm = new ArrayList();

            ampm.Add("AM");
            ampm.Add("PM");

            foreach (var item in ampm)
            {
                AmPmcmb.Items.Add(item);
            }


            for (int i = 01; i <= 12; i++)
            {
                Hourcmb.Items.Add(i.ToString("D2"));
            }

            for (int i = 00; i <= 59; i++)
            {
                Minutecmb.Items.Add(i.ToString("D2"));
            }

        }





        public void Appointment()
        {
            try
            {
                // Gather input values
                clientname = ClientNametxt.Text.Trim();
                sched = Datetxt.Text.Trim(); // Date as string (e.g., "MM/DD/YYYY")
                evnt = Eventtxt.Text.Trim();

                // Validate client name, schedule, and event
                if (string.IsNullOrEmpty(clientname)) { MessageBox.Show("Enter a Client name"); return; }
                if (string.IsNullOrEmpty(sched)) { MessageBox.Show("Enter a schedule"); return; }
                if (string.IsNullOrEmpty(evnt)) { MessageBox.Show("Enter an event"); return; }

                // Parse time inputs
                if (!int.TryParse(Hourcmb.SelectedItem?.ToString(), out int hour) ||
                    !int.TryParse(Minutecmb.SelectedItem?.ToString(), out int minute) ||
                    string.IsNullOrEmpty(AmPmcmb.SelectedItem?.ToString()))
                {
                    MessageBox.Show("Enter a valid time.");
                    return;
                }

                string ampm = AmPmcmb.SelectedItem.ToString();
                // Convert time to 24-hour format
                if (ampm == "PM" && hour != 12) hour += 12;
                if (ampm == "AM" && hour == 12) hour = 0;

                TimeSpan selectedTime = new TimeSpan(hour, minute, 0);
                TimeSpan startTime = new TimeSpan(8, 0, 0);
                TimeSpan endTime = new TimeSpan(16, 0, 0);

                if (selectedTime < startTime || selectedTime > endTime)
                {
                    MessageBox.Show("Appointment time must be between 8:00 AM and 4:00 PM.");
                    return;
                }


                // Parse date and combine with time
                DateTime scheduleDate;
                if (!DateTime.TryParse(sched, out scheduleDate))
                {
                    MessageBox.Show("Enter a valid schedule date.");
                    return;
                }
                DateTime fullScheduleDateTime = scheduleDate.Add(new TimeSpan(hour, minute, 0)); // Combine date and time

                if (fullScheduleDateTime < DateTime.Now)
                {
                    MessageBox.Show("Invalid date");
                    return;
                }
                // Database operations
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString = ConnectionString.connectionString))
                {
                    conn.Open();

                    // Check for existing booking at the same date and time
                    string checkQuery = "SELECT COUNT(*) FROM Transaction_TBL WHERE ScheduleDate = @ScheduleDate AND Appointment = @Appointment";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ScheduleDate", scheduleDate.Date); // Only the date
                        checkCmd.Parameters.AddWithValue("@Appointment", fullScheduleDateTime.TimeOfDay); // Time as TimeSpan

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("The selected time has already been booked. Please choose a different time.");
                            return;
                        }
                    }

                    // Insert the new appointment
                    string appointmentQuery = "INSERT INTO Transaction_TBL (ClientName, ScheduleDate, Appointment, Event) " +
                                              "VALUES (@Client, @ScheduleDate, @Appointment, @Event)";

                    using (SqlCommand cmd = new SqlCommand(appointmentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", clientname);
                        cmd.Parameters.AddWithValue("@ScheduleDate", scheduleDate.Date); // Only the date
                        cmd.Parameters.AddWithValue("@Appointment", fullScheduleDateTime.TimeOfDay); // Time as TimeSpan
                        cmd.Parameters.AddWithValue("@Event", evnt);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            MessageBox.Show("User data inserted successfully!");
                        else
                            MessageBox.Show("Insertion failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            this.Close();
        }



        public void Update()
        {
            try
            {

                clientname = ClientNametxt.Text.Trim();
                sched = Datetxt.Text.Trim();
                evnt = Eventtxt.Text.Trim();

                // Try parsing the Appointment ID
                if (!int.TryParse(SchedIDtxt.Text.Trim(), out appointmentID) || appointmentID <= 0)
                {
                    MessageBox.Show("Enter a valid Appointment ID");
                    return;
                }

                // Validate client name, schedule, and event
                if (string.IsNullOrEmpty(clientname))
                {
                    MessageBox.Show("Enter a Client name");
                    return;
                }
                if (string.IsNullOrEmpty(sched))
                {
                    MessageBox.Show("Enter a schedule");
                    return;
                }
                if (string.IsNullOrEmpty(evnt))
                {
                    MessageBox.Show("Enter an event");
                    return;
                }

                // Parse time inputs
                if (!int.TryParse(Hourcmb.SelectedItem?.ToString(), out int hour) ||
                    !int.TryParse(Minutecmb.SelectedItem?.ToString(), out int minute) ||
                    string.IsNullOrEmpty(AmPmcmb.SelectedItem?.ToString()))
                {
                    MessageBox.Show("Enter a valid time.");
                    return;
                }

                string ampm = AmPmcmb.SelectedItem.ToString();
                // Convert time to 24-hour format
                if (ampm == "PM" && hour != 12) hour += 12;
                if (ampm == "AM" && hour == 12) hour = 0;

                TimeSpan selectedTime = new TimeSpan(hour, minute, 0);
                TimeSpan startTime = new TimeSpan(8, 0, 0); // 8:00 AM
                TimeSpan endTime = new TimeSpan(16, 0, 0); // 4:00 PM



                if (selectedTime < startTime || selectedTime > endTime)
                {
                    MessageBox.Show("Appointment time must be between 8:00 AM and 4:00 PM.");
                    return;
                }

                // Parse date and combine with time
                DateTime scheduleDate;
                if (!DateTime.TryParse(sched, out scheduleDate))
                {
                    MessageBox.Show("Enter a valid schedule date.");
                    return;
                }

                DateTime fullScheduleDateTime = scheduleDate.Add(new TimeSpan(hour, minute, 0));

                if (fullScheduleDateTime < DateTime.Now)
                {
                    MessageBox.Show("Invalid date");
                    return;
                }

                // Database operations
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString = ConnectionString.connectionString))
                {
                    conn.Open();

                    // Check if the record exists
                    string checkQuery = "SELECT COUNT(*) FROM Transaction_TBL WHERE Schedule_ID = @Schedule_ID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Schedule_ID", appointmentID);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show("The specified appointment ID does not exist.");
                            return;
                        }
                    }

                    // Update the specific record
                    string updateQuery = "UPDATE Transaction_TBL SET ClientName = @ClientName, ScheduleDate = @ScheduleDate, Appointment = @Appointment, Event = @Event WHERE Schedule_ID = @Schedule_ID";


                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClientName", clientname);
                        cmd.Parameters.AddWithValue("@ScheduleDate", scheduleDate.Date); // Only the date
                        cmd.Parameters.AddWithValue("@Appointment", fullScheduleDateTime.TimeOfDay); // Time as TimeSpan
                        cmd.Parameters.AddWithValue("@Event", evnt);
                        cmd.Parameters.AddWithValue("@Schedule_ID", appointmentID); // Pass the unique ID of the record to update

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {

                            MessageBox.Show("User data updated successfully!");



                        }
                        else
                            MessageBox.Show("Update failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            this.Close();
        }


        public void WalkIn()
        {

            try
            {
                clientname = ClientNametxt.Text.Trim();
                evnt = Eventtxt.Text.Trim();
                DateTime sched = DateTime.Now;
                string selectedDay = UserControlDays.static_day;

                if (string.IsNullOrEmpty(clientname)) { MessageBox.Show("Enter Client Name"); return; }
                if (string.IsNullOrEmpty(evnt)) { MessageBox.Show("Enter Appointment"); return; }

                // Convert selectedDay to a date for comparison
                if (!int.TryParse(selectedDay, out int day))
                {
                    MessageBox.Show("Invalid selected day format.");
                    return;
                }

                DateTime selectedDate = new DateTime(sched.Year, sched.Month, day);

                if (selectedDate.Date != sched.Date)
                {
                    MessageBox.Show("The date must be the current date.");
                    return;
                }

                TimeSpan startTime = new TimeSpan(8, 0, 0); // 8:00 AM
                TimeSpan endTime = new TimeSpan(16, 30, 0); // 4:30 PM
                TimeSpan currentTime = sched.TimeOfDay;


                if (currentTime < startTime || currentTime > endTime)
                {
                    MessageBox.Show("Walk-in is only allowed between 8:00 AM and 4:30 PM.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString = ConnectionString.connectionString))
                {
                    conn.Open();
                    string walkin = "INSERT INTO Walkin_TBL (ClientName, ScheduleDateTime,Appointment)" +
                        "VALUES(@ClientName, @ScheduleDateTime,@Appointment)";

                    using (SqlCommand cmd = new SqlCommand(walkin, conn))
                    {
                        cmd.Parameters.AddWithValue("@Clientname", clientname);
                        cmd.Parameters.AddWithValue("@ScheduleDateTime", sched);
                        cmd.Parameters.AddWithValue("@Appointment", evnt);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User data insert successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }

                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            this.Close();
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            Appointment();

        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            Datetxt.Text = Scheduler.static_month + "/" + UserControlDays.static_day + "/" + Scheduler.static_year;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            Update();

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            WalkIn();
        }
    }
}
