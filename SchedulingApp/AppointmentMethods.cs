using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
    class AppointmentMethods
    {

        public static bool DeleteAppointment(int appointmentId)
        {
            string deleteAppointment = $"DELETE FROM appointment WHERE appointmentId = {appointmentId}";
            MySqlCommand delete = new MySqlCommand(deleteAppointment, DatabaseConfiguration.dbconn);
            int del = delete.ExecuteNonQuery(); 
            if (del != 0)
            {
                MessageBox.Show($"Appointment with {GlobalVariables.selectedAppointment.CustomerName} has been deleted.");
                return true;
            }
            else
            {
                return false; 
            }

        }
        public static BindingList<Appointments> GrabAppointments(DateTime date1, DateTime date2)
        {
            BindingList<Appointments> appList = new BindingList<Appointments>();
            string appSql = $"SELECT appointmentId, appointment.customerId, customerName, type, start, end, title, description, location, contact, url FROM appointment JOIN customer ON appointment.customerId = customer.customerId WHERE start BETWEEN '{date1.ToUniversalTime().ToString("yyyy/MM/dd hh:mm:ss")}' AND '{date2.ToUniversalTime().ToString("yyyy/MM/dd hh:mm:ss")}' ORDER BY start"; 
            MySqlCommand cmd = new MySqlCommand(appSql, DatabaseConfiguration.dbconn);
            MySqlDataReader reader = cmd.ExecuteReader(); 

            while (reader.Read())
            {
                int appointmentId = reader.GetInt32("appointmentId");
                int customerId = reader.GetInt32("customerId");
                string customerName = reader.GetString("customerName");
                string type = reader.GetString("type");
                DateTime start = reader.GetDateTime("start").ToLocalTime();
                DateTime end = reader.GetDateTime("end").ToLocalTime();
                string title = reader.GetString("title");
                string description = reader.GetString("description");
                string location = reader.GetString("location");
                string contact = reader.GetString("contact");
                string url = reader.GetString("url");

                Appointments A = new Appointments(appointmentId, customerId, customerName, type, start, end, title, description, location, contact, url);
                appList.Add(A);
            }
            reader.Close(); 
            return appList; 
        }

        public static bool AddEditAppointments(int customerId, string title, string description, string location, string contact, string type, string url, DateTime start, DateTime end)
        {
            //This is the query to check if our appointment times are going to overlap with another appointment. 
            string checkOverlap = $"SELECT appointmentId FROM appointment WHERE start BETWEEN '{start.ToString("yyyy/MM/dd HH:mm:ss")}' AND '{end.ToString("yyyy/MM/dd HH:mm:ss")}' OR end BETWEEN '{start.ToString("yyyy/MM/dd HH:mm:ss")}' AND '{end.ToString("yyyy/MM/dd HH:mm:ss")}'";
            MySqlCommand overCmd = new MySqlCommand(checkOverlap, DatabaseConfiguration.dbconn);
            Object overlapReturn = overCmd.ExecuteScalar();

                try
                {
                    if (GlobalVariables.editApp == false)
                    {

                        if (overlapReturn == null)
                        {
                            string addApp = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy)" +
                                            $"VALUES ({customerId}, {GlobalVariables.userId}, '{title}', '{description}', '{location}', '{contact}', '{type}', '{url}', '{start.ToString("yyyy/MM/dd HH:mm:ss")}', '{end.ToString("yyyy/MM/dd HH:mm:ss")}', NOW(), '{GlobalVariables.user}','{GlobalVariables.user}')";
                            MySqlCommand cmd = new MySqlCommand(addApp, DatabaseConfiguration.dbconn);
                            Object obj = cmd.ExecuteNonQuery();

                            if (obj != null)
                            {
                                MessageBox.Show("Successfully added appointment");
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Appointments cannot be overlapping. Please change the appointment time.");
                            return false; 
                        }
                    }
                    else
                    {
                        if (overlapReturn == null || (int)overlapReturn == GlobalVariables.selectedAppointment.AppointmentId)
                        {


                            string editApp = $"UPDATE appointment SET customerId = {customerId}, userId = {GlobalVariables.userId}, title = '{title}', description = '{description}', location = '{location}', contact = '{contact}', type = '{type}', url ='{url}',start = '{start.ToUniversalTime().ToString("yyyy/MM/dd HH:mm")}', end = '{end.ToUniversalTime().ToString("yyyy/MM/dd HH:mm")}', lastUpdateBy = '{GlobalVariables.user}' WHERE appointmentId = {GlobalVariables.selectedAppointment.AppointmentId}";
                            MySqlCommand cmd = new MySqlCommand(editApp, DatabaseConfiguration.dbconn);
                            Object obj = cmd.ExecuteNonQuery();

                            if (obj != null)
                            {
                                MessageBox.Show("Successfully updated appointment.");
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Appointments cannot be overlapping. Please change the appointment time.");
                            return false; 
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error with SQL: {ex}");
                    return false;
                }
            
        }

        public static List<string> GrabCustomerNames()
        {
            List<string> customers = new List<string>();
            string sql = "SELECT customerName FROM customer";
            MySqlCommand cmd = new MySqlCommand(sql, DatabaseConfiguration.dbconn);

            MySqlDataReader reader = cmd.ExecuteReader(); 

            while (reader.Read())
            {
                string s = reader.GetString("customerName");
                customers.Add(s); 
            }
            reader.Close();
            return customers;
        }


    }
}
