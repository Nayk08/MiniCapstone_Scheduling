using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Data;
using System.Reflection;
using System.Collections;
using Microsoft.Office.Interop.Word;

namespace MiniCapstone
{
    public partial class AppointmentRecords : Layout
    {
   


        private PrintDocument printDoc = new PrintDocument();  // Create a PrintDocument object

        public AppointmentRecords()
        {
            InitializeComponent();
            LoadData();
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);  // Subscribe to PrintPage event
        }

        public void filter()
        {
            try
            {

                string selectedValue = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                System.Data.DataTable dataTable = new System.Data.DataTable();



                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString = ConnectionString.connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM Transaction_TBL WHERE ScheduleDate = @data";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@data", selectedValue);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                        guna2DataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void clearfilter()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString = ConnectionString.connectionString))
                {
                    connection.Open();

                    string ClearQuery = "SELECT * FROM Transaction_TBL";
                    using (SqlCommand command = new SqlCommand(ClearQuery, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            System.Data.DataTable eventTable = new System.Data.DataTable();
                            eventTable.Load(reader);

                            // Bind the data to the DataGridView
                            guna2DataGridView1.DataSource = eventTable;
                        }
                    }


                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString = ConnectionString.connectionString))
                {
                    conn.Open();
                    string displayhistory = "SELECT * FROM Transaction_TBL  ORDER BY Appointment DESC";
                    using (SqlCommand cmd = new SqlCommand(displayhistory, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            System.Data.DataTable eventTable = new System.Data.DataTable();
                            eventTable.Load(reader);

                            // Bind the data to the DataGridView
                            guna2DataGridView1.DataSource = eventTable;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // Method to print the DataGridView
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Graphics and font setup
            Graphics g = e.Graphics;
            System.Drawing.Font font = new System.Drawing.Font("Arial", 10);
            System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float rowHeight = 25; // Row height
            float columnWidth = e.MarginBounds.Width / guna2DataGridView1.Columns.Count; // Equal width for all columns

            // Pen for drawing grid lines
            Pen gridPen = Pens.Black;

            // Alignment setup
            StringFormat centerAlign = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Draw column headers
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                // Header text centered
                RectangleF headerRect = new RectangleF(x, y, columnWidth, rowHeight);
                g.DrawString(column.HeaderText, headerFont, Brushes.Black, headerRect, centerAlign);
                g.DrawRectangle(gridPen, x, y, columnWidth, rowHeight);
                x += columnWidth;
            }

            // Move to the next row after headers
            y += rowHeight;
            x = e.MarginBounds.Left;

            // Draw data rows
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Skip new rows

                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Check if the current column is "ScheduleDate"
                    string cellValue = cell.Value?.ToString() ?? string.Empty;
                    if (guna2DataGridView1.Columns[cell.ColumnIndex].HeaderText == "ScheduleDate" && DateTime.TryParse(cellValue, out DateTime dateValue))
                    {
                        // Format the date to remove the time portion
                        cellValue = dateValue.ToString("MM/dd/yyyy"); // Only the date
                    }

                    // Cell text centered
                    RectangleF cellRect = new RectangleF(x, y, columnWidth, rowHeight);
                    g.DrawString(cellValue, font, Brushes.Black, cellRect, centerAlign);
                    g.DrawRectangle(gridPen, x, y, columnWidth, rowHeight);
                    x += columnWidth;
                }

                // Move to the next row
                y += rowHeight;
                x = e.MarginBounds.Left;

                // Check if the content overflows the page
                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true; // Signal to print the next page
                    return;
                }
            }

            e.HasMorePages = false; // No more pages to print
        }




        // Method to trigger the print operation
        private void Exportbtn_Click(object sender, EventArgs e)
        {
            // Show print dialog and if the user clicks "OK", print the data
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AppointmentRecords_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            clearfilter();
        }
    }
}
