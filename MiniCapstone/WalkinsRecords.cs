using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniCapstone
{
    public partial class WalkinsRecords : Layout
    {
        private PrintDocument printDoc = new PrintDocument();
        public WalkinsRecords()
        {
            InitializeComponent();
            LoadData();
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);





        }



        public void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
                {
                    conn.Open();
                    string displayhistory = "SELECT * FROM Walkin_TBL  ORDER BY ScheduleDateTime DESC";
                    using (SqlCommand cmd = new SqlCommand(displayhistory, conn))
                    {
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
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }




        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Graphics and font setup
            Graphics g = e.Graphics;
            Font font = new Font("Arial", 10);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
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
                    if (guna2DataGridView1.Columns[cell.ColumnIndex].HeaderText == "ScheduleDateTime" && DateTime.TryParse(cellValue, out DateTime dateValue))
                    {
                        // Format the date to remove the time portion
                        cellValue = dateValue.ToString();
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

        private void Exportbtn_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        public void filter()
        {
            try
            {

                string selectedValue = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                System.Data.DataTable dataTable = new System.Data.DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM Walkin_TBL WHERE CAST(ScheduleDateTime AS DATE) = @data";
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


        public void MonthFilter()
        {
            try
            {
                if (!int.TryParse(monthtxt.Text, out int months) || months < 1 || months > 12)
                {
                    MessageBox.Show("Please select a valid month (1-12).");
                    return;
                }

                System.Data.DataTable dataTable = new System.Data.DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Walkin_TBL WHERE DATEPART(MONTH, ScheduleDateTime) = @data;";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@data", months);

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



        public void YearFilter()
        {
            try
            {
                // Validate and convert the selected year from the ComboBox
                if (!int.TryParse(Yeartxt.Text, out int year) || year < 1)
                {
                    MessageBox.Show("Please enter a valid year.");
                    return;
                }

                System.Data.DataTable dataTable = new System.Data.DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();

                    // Query to filter by year using DATEPART
                    string selectQuery = "SELECT * FROM Walkin_TBL WHERE DATEPART(YEAR, ScheduleDateTime) = @data;";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        // Bind the year parameter
                        command.Parameters.AddWithValue("@data", year);

                        // Use a SqlDataAdapter to fill the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        // Bind the results to the DataGridView
                        guna2DataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        public void SearchName()
        {
            try
            {

                string Name = SearchNametxt.Text.Trim();

                System.Data.DataTable dataTable = new System.Data.DataTable();

                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM Walkin_TBL WHERE ClientName = @data";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@data", Name);
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
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();

                    string ClearQuery = "SELECT * FROM Walkin_TBL";
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            clearfilter();
        }

        private void SearchNametxt_TextChanged(object sender, EventArgs e)
        {
            SearchName();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            SearchName();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            YearFilter();
        }

        private void monthtxt_TextChanged(object sender, EventArgs e)
        {
            MonthFilter();
        }
    }
}
