using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
    public partial class AddEditAppointments : Form
    {
        public bool editAppointment = false; 
        public AddEditAppointments()
        {
            InitializeComponent();
        }

        private void AddEditAppointments_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource = AppointmentMethods.GrabCustomerNames();
            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.CustomFormat = "dddd, MMM dd, yyyy hh:mm tt";
            endDateTimePicker.Format = DateTimePickerFormat.Custom;
            endDateTimePicker.CustomFormat = "dddd, MMM dd, yyyy hh:mm tt"; 



            if (GlobalVariables.editApp == true)
            {
                addAppointmentButton.Text = "Update Appointment"; 
                customerComboBox.Text = GlobalVariables.selectedAppointment.CustomerName;
                startDateTimePicker.Value = GlobalVariables.selectedAppointment.Start;
                endDateTimePicker.Value = GlobalVariables.selectedAppointment.End;
                titleTextBox.Text = GlobalVariables.selectedAppointment.Title;
                descriptionTextBox.Text = GlobalVariables.selectedAppointment.Description;
                locationTextBox.Text = GlobalVariables.selectedAppointment.Location;
                contactTextBox.Text = GlobalVariables.selectedAppointment.Contact;
                typeTextBox.Text = GlobalVariables.selectedAppointment.AppointmentType;
                urlTextBox.Text = GlobalVariables.selectedAppointment.URL; 
            }
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            int GetCustomerId(string customerName)
            {
                string sql = $"SELECT customerId FROM customer WHERE customerName = '{customerName}'";
                MySqlCommand cmd = new MySqlCommand(sql, DatabaseConfiguration.dbconn);
                Object obj = cmd.ExecuteScalar();
                
                return (int.Parse(obj.ToString()));

            }
            int customerId = GetCustomerId(customerComboBox.SelectedValue.ToString());
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;
            string location = locationTextBox.Text;
            string contact = contactTextBox.Text;
            string type = typeTextBox.Text;
            string url = urlTextBox.Text;
            DateTime start = startDateTimePicker.Value;
            DateTime end = endDateTimePicker.Value;
            DateTime startTrimmed = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, 0);
            DateTime endTrimmed = new DateTime(end.Year, end.Month, end.Day, end.Hour, end.Minute, 0); 

            if(ValidateAppointmentInfo(startTrimmed, endTrimmed) == true)
            {
                bool tryAdding = AppointmentMethods.AddEditAppointments(customerId, title, description, location, contact, type, url, startTrimmed.ToUniversalTime(), endTrimmed.ToUniversalTime());
                if (tryAdding == true)
                {
                    CalendarSchedule form = new CalendarSchedule();
                    GlobalVariables.editApp = false;
                    form.Show();
                    this.Hide();
                    GlobalVariables.GetAlerts(); 
                }
            }
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddEditAppointments_FormClosed(object sender, FormClosedEventArgs e)
        {
            CalendarSchedule form = new CalendarSchedule();
            form.Show();
            GlobalVariables.editApp = false; 
            this.Hide();
        }

        private bool ValidateAppointmentInfo(DateTime start, DateTime end)
        {
            TimeSpan startOfBusiness = TimeSpan.FromHours(8);
            TimeSpan endOfBusiness = TimeSpan.FromHours(17); 

            if(start.TimeOfDay >= startOfBusiness && start.TimeOfDay <= endOfBusiness && end.TimeOfDay <= endOfBusiness && end.TimeOfDay >=startOfBusiness)
            {
                return true; 
            }
            else
            {
                MessageBox.Show("Ensure the appointment time is with the business hours of 8AM - 5PM"); 
                startLabel.BackColor = Color.Red;
                endLabel.BackColor = Color.Red; 
                return false; 
            }

        }
    }
}
