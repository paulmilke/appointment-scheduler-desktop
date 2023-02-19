using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
    public partial class CalendarSchedule : Form
    {
        //Universal variables for the CalendarSchedule form. 
        DateTime date1 = DateTime.Today.Date;
        DateTime date2 = DateTime.Today.Date.AddDays(+1);
        BindingList<Appointments> appList = new BindingList<Appointments>();
        int rowindex;

        public CalendarSchedule()
        {
            InitializeComponent();
        }

        private void CalendarSchedule_Load(object sender, EventArgs e)
        {
            //On load, finds appointments for today 
            appList = AppointmentMethods.GrabAppointments(date1, date2);
            appointmentDataGridView.DataSource = appList;
 

            //Sets variables to default values
            dailyRadioButton.Checked = true;
            appointmentDataGridView.ClearSelection();
            editAppointmentButton.Enabled = false;
            deleteAppointmentButton.Enabled = false;
        }


        private void viewCustomersButton_Click(object sender, EventArgs e)
        {
            CustomersPage form = new CustomersPage();
            form.Show(); 
            this.Hide();
        }

        private void CalendarSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (dailyRadioButton.Checked == true && weeklyRadioButton.Checked == false && monthlyRadioButton.Checked == false)
            {
                DateTime selectedDate = monthCalendar.SelectionRange.Start;
                date1 = selectedDate.Date;
                date2 = selectedDate.Date.AddDays(1);
                appList = AppointmentMethods.GrabAppointments(date1, date2);
                appointmentDataGridView.DataSource = appList;
            }
            else if (weeklyRadioButton.Checked == true && dailyRadioButton.Checked == false && monthlyRadioButton.Checked == false)
            {
                int dayOfWeek = (int)monthCalendar.SelectionRange.Start.DayOfWeek;
                DateTime date1 = monthCalendar.SelectionRange.Start.AddDays(-dayOfWeek);
                DateTime date2 = date1.AddDays(7); 
                monthCalendar.SetSelectionRange(date1, date2);
                appList = AppointmentMethods.GrabAppointments(date1, date2);
                appointmentDataGridView.DataSource = appList;

            }
            else if (monthlyRadioButton.Checked == true && dailyRadioButton.Checked == false && weeklyRadioButton.Checked == false)
            {
                DateTime selectedDate = monthCalendar.SelectionRange.Start;
                int daysInMonth = DateTime.DaysInMonth(monthCalendar.SelectionRange.Start.Year, monthCalendar.SelectionRange.Start.Month);
                DateTime startOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                DateTime endOfMonth = startOfMonth.AddDays(daysInMonth).AddTicks(-1);
                monthCalendar.SetSelectionRange(startOfMonth, endOfMonth);
                appList = AppointmentMethods.GrabAppointments(startOfMonth, endOfMonth);
                appointmentDataGridView.DataSource = appList; 
            }
            else
            {
                dailyRadioButton.Checked = true;
                weeklyRadioButton.Checked = false;
                monthlyRadioButton.Checked = false; 
            }


        }

        private void dailyRadioButton_Click(object sender, EventArgs e)
        {
            monthCalendar.MaxSelectionCount = 1; 
            weeklyRadioButton.Checked = false;
            monthlyRadioButton.Checked = false;



        }

        private void weeklyRadioButton_Click(object sender, EventArgs e)
        {
            dailyRadioButton.Checked = false;
            monthlyRadioButton.Checked = false; 
            monthCalendar.MaxSelectionCount = 7;

        }

        private void monthlyRadioButton_Click(object sender, EventArgs e)
        {
            dailyRadioButton.Checked = false;
            weeklyRadioButton.Checked = false;
            monthCalendar.MaxSelectionCount = 31; 
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            AddEditAppointments form = new AddEditAppointments();
            form.Show();
            this.Hide(); 
        }

        private void editAppointmentButton_Click(object sender, EventArgs e)
        {
            GlobalVariables.editApp = true;
            AddEditAppointments form = new AddEditAppointments();
            form.Show();
            this.Hide();
        }

        private void appointmentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowindex = appointmentDataGridView.CurrentRow.Index;
            GlobalVariables.selectedAppointment = appList.ElementAt(rowindex);
            editAppointmentButton.Enabled = true;
            deleteAppointmentButton.Enabled = true; 
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            AppointmentMethods.DeleteAppointment(GlobalVariables.selectedAppointment.AppointmentId);
            appList.RemoveAt(rowindex);
            appointmentDataGridView.ClearSelection();
            editAppointmentButton.Enabled = false;
            deleteAppointmentButton.Enabled = false; 
        }

        private void viewReportsButton_Click(object sender, EventArgs e)
        {
            GlobalVariables.reportPage.ShowDialog(); 
            this.Hide();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar.RemoveAllBoldedDates(); 
        }
    }
}
