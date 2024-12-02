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

namespace FinalProject_RAD
{
    public partial class CalendarControl : UserControl
    {
        // Variables to track the current month and year
        int currentYear = DateTime.Now.Year;
        int currentMonth = DateTime.Now.Month;

        public CalendarControl()
        {
            InitializeComponent();
            ConfigureTableLayout();
        }

        private void ConfigureTableLayout()
        {
            // Ensure the TableLayoutPanel has appropriate dimensions
            tableLayoutPanel1.ColumnCount = 7; // 7 days in a week
            tableLayoutPanel1.Dock = DockStyle.None;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            // Set equal column widths
            for (int i = 0; i < 7; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 7));
            }

            // Add day labels (static row)
            AddDayLabels();
        }

        private void AddDayLabels()
        {
            // Use localized day names
            string[] daysOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;

            for (int i = 0; i < 7; i++)
            {
                Label dayLabel = new Label
                {
                    Text = daysOfWeek[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 130, 163)
                };
                tableLayoutPanel1.Controls.Add(dayLabel, i, 0); // Add to the first row
            }
        }

        private void PopulateCalendar(int year, int month)
        {
            // Clear existing day cells
            ClearDayCells();

            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startDay = (int)firstDay.DayOfWeek;

            // Determine required rows dynamically
            int totalCells = startDay + daysInMonth;
            int requiredRows = (totalCells > 35) ? 7 : 6;

            tableLayoutPanel1.RowCount = requiredRows;
            tableLayoutPanel1.RowStyles.Clear();
            for (int i = 0; i < requiredRows; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / requiredRows));
            }

            // Fill in days from the previous month
            DateTime prevMonth = firstDay.AddMonths(-1);
            int lastDayPrevMonth = DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);
            int firstDayToShow = lastDayPrevMonth - startDay + 1;

            for (int i = 0; i < startDay; i++)
            {
                Label prevMonthLabel = new Label
                {
                    Text = firstDayToShow.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 10, FontStyle.Italic),
                    ForeColor = Color.Gray
                };
                tableLayoutPanel1.Controls.Add(prevMonthLabel, i, 1);
                firstDayToShow++;
            }

            // Fill in days for the current month
            int dayCounter = 1;
            for (int i = startDay; i < startDay + daysInMonth; i++)
            {
                Label dayLabel = new Label
                {
                    Text = dayCounter.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 10),
                    BackColor = Color.Transparent,
                    Tag = new DateTime(year, month, dayCounter)
                };

                // Highlight today's date
                if (year == DateTime.Now.Year && month == DateTime.Now.Month && dayCounter == DateTime.Now.Day)
                {
                    dayLabel.BackColor = Color.FromArgb(255, 130, 163);
                    dayLabel.Font = new Font("Arial", 10, FontStyle.Bold);
                }

                dayLabel.Click += (sender, e) =>
                {
                    DateTime selectedDate = (DateTime)((Label)sender).Tag;
                    MessageBox.Show($"Selected Date: {selectedDate:MMMM dd, yyyy}");
                };

                int row = i / 7 + 1; // Calculate row based on index
                int col = i % 7;     // Column is the remainder
                tableLayoutPanel1.Controls.Add(dayLabel, col, row);
                dayCounter++;
            }

            // Fill in days for the next month
            DateTime nextMonth = firstDay.AddMonths(1);
            int nextMonthDayCounter = 1;
            int remainingCells = totalCells > 35 ? 42 - totalCells : 35 - totalCells;

            for (int i = 0; i < remainingCells; i++)
            {
                Label nextMonthLabel = new Label
                {
                    Text = nextMonthDayCounter.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 10, FontStyle.Italic),
                    ForeColor = Color.Gray
                };

                int col = (startDay + daysInMonth + i) % 7;  // Column position
                int row = (startDay + daysInMonth + i) / 7 + 1; // Row position
                tableLayoutPanel1.Controls.Add(nextMonthLabel, col, row);
                nextMonthDayCounter++;
            }

            // Update the TextBox to display the current month and year
            txtMonthYear.Text = new DateTime(year, month, 1).ToString("MMMM yyyy");
        }

        private void ClearDayCells()
        {
            // Remove all controls except for the first row (day labels)
            for (int i = tableLayoutPanel1.Controls.Count - 1; i >= 7; i--)
            {
                tableLayoutPanel1.Controls.RemoveAt(i);
            }
        }

        private void CalendarControl_Load(object sender, EventArgs e)
        {
            PopulateCalendar(currentYear, currentMonth);
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            currentMonth--;
            if (currentMonth < 1)
            {
                currentMonth = 12;
                currentYear--;
            }
            PopulateCalendar(currentYear, currentMonth);
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            currentMonth++;
            if (currentMonth > 12)
            {
                currentMonth = 1;
                currentYear++;
            }
            PopulateCalendar(currentYear, currentMonth);
        }

        private void btnPrevYear_Click(object sender, EventArgs e)
        {
            currentYear--;
            PopulateCalendar(currentYear, currentMonth);
        }

        private void btnNextYear_Click(object sender, EventArgs e)
        {
            currentYear++;
            PopulateCalendar(currentYear, currentMonth);
        }
    }
}
