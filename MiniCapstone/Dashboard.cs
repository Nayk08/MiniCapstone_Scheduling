using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Guna.UI2.WinForms;

namespace MiniCapstone
{
    public partial class Dashboard : Layout
    {


        public Dashboard()
        {
            InitializeComponent();

            AppointmentDisplay();
            WalkinDisplay();
            displaytotalCount();

        }

        public void Displayall()
        {

        }

        public void displaytotalCount()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString = ConnectionString.connectionString))
                {
                    conn.Open();
                    string display = @"
                SELECT COUNT(*) AS TotalWalkInsToday
                FROM (
                    SELECT ScheduleDateTime AS DateField
                    FROM Walkin_TBL
                    WHERE CAST(ScheduleDateTime AS DATE) = CAST(GETDATE() AS DATE)
                    
                    UNION ALL
                    
                    SELECT ScheduleDate AS DateField
                    FROM Transaction_TBL
                    WHERE CAST(ScheduleDate AS DATE) = CAST(GETDATE() AS DATE)
                ) AS CombinedTables;";

                    using (SqlCommand cmd = new SqlCommand(display, conn))
                    {
                        int walkins = (int)cmd.ExecuteScalar();
                        label1.Text = walkins.ToString();
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void AppointmentDisplay()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString = ConnectionString.connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Transaction_TBL WHERE CAST(ScheduleDate AS DATE) = CAST(GETDATE() AS DATE)";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();



                    adapter.Fill(dataTable);

                    // Example: Display the total number of rows for today in a label
                    int rowCount = dataTable.Rows.Count;
                    label9.Text = $"Today's Appointments";
                    label4.Text = rowCount.ToString();

                    // Example: Bind data to a DataGridView
                    guna2DataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void WalkinDisplay()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Walkin_TBL WHERE CAST(ScheduleDateTime AS DATE) = CAST(GETDATE() AS DATE)";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();



                    adapter.Fill(dataTable);

                    // Example: Display the total number of rows for today in a label
                    int rowCount = dataTable.Rows.Count;
                   
                    label7.Text = rowCount.ToString();

                    // Example: Bind data to a DataGridView
                    guna2DataGridView2.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }











        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
