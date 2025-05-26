using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniCapstone
{
    public partial class Scheduler : Layout
    {
        int Month, Year;
        string clientname, sched, evnt;
        public static string static_month, static_year;

        public Scheduler()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void display()
        {
            DateTime now = DateTime.Now;
            Month = now.Month;
            Year = now.Year;
            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(Month);
            Monthyearlbl.Text = monthname + " " + Year;

            static_month = Month.ToString();
            static_year = Year.ToString();

            DateTime startofthemonth = new DateTime(Year, Month, 1);

            int days = DateTime.DaysInMonth(Year, Month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucbblank = new UserControlBlank();
                daycontainer.Controls.Add(ucbblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucbdays = new UserControlDays();
                ucbdays.days(i);
                daycontainer.Controls.Add(ucbdays);

            }

        }

        private void Scheduler_Load(object sender, EventArgs e)
        {
            display();

        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            Month++;
            if (Month > 12) { Month = 1; Year++; }
            if (Month < 1) { Month = 12; Year--; }
            static_month = Month.ToString();
            static_year = Year.ToString();
            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(Month);
            Monthyearlbl.Text = monthname + " " + Year;
            DateTime startofthemonth = new DateTime(Year, Month, 1);


            int days = DateTime.DaysInMonth(Year, Month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucbblank = new UserControlBlank();
                daycontainer.Controls.Add(ucbblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucbdays = new UserControlDays();
                ucbdays.days(i);
                daycontainer.Controls.Add(ucbdays);

            }
        }

        private void Previousbtn_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            Month--;

            if (Month > 12) { Month = 1; Year++; }
            if (Month < 1) { Month = 12; Year--; }
            static_month = Month.ToString();
            static_year = Year.ToString();
            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(Month);
            Monthyearlbl.Text = monthname + " " + Year;
            DateTime startofthemonth = new DateTime(Year, Month, 1);


            int days = DateTime.DaysInMonth(Year, Month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucbblank = new UserControlBlank();
                daycontainer.Controls.Add(ucbblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucbdays = new UserControlDays();
                ucbdays.days(i);
                daycontainer.Controls.Add(ucbdays);

            }
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {



        }
    }
}