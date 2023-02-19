using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
    class ReportMethods
    {
        public static void ClientLocations()
        {
            //Clear the reports text before pulling report. 
            GlobalVariables.reportPage.ClearReportsText();

            //Clear the global variable for the report. 
            GlobalVariables.countries.Clear(); 

            //Pull list of countries from database and populatae them into our global variable. 
            string countrySql = "SELECT country FROM country";
            MySqlCommand countryCmd = new MySqlCommand(countrySql, DatabaseConfiguration.dbconn);

            MySqlDataReader reader = countryCmd.ExecuteReader(); 

            while (reader.Read())
            {
                string country = reader.GetString("country");
                GlobalVariables.countries.Add(country); 
            }
            reader.Close();

            //Pull list of cities that are from each country in our list from above. 
            for (int i = 0; i < GlobalVariables.countries.Count(); ++i)
            {
                GlobalVariables.reportPage.SetReportsText($"Country: {GlobalVariables.countries.ElementAt(i)}"); 
                string citySql = $"SELECT city FROM city JOIN country ON city.countryId = country.countryId WHERE country = '{GlobalVariables.countries.ElementAt(i)}'";
                MySqlCommand cityCmd = new MySqlCommand(citySql, DatabaseConfiguration.dbconn);
                MySqlDataReader cityReader = cityCmd.ExecuteReader(); 
                while (cityReader.Read())
                {
                    string city = cityReader.GetString("city");
                    GlobalVariables.reportPage.SetReportsText(city); 
                }
                cityReader.Close();
                GlobalVariables.reportPage.SetReportsText(""); 
            }
        }

        public static void ConsultantSchedules()
        {
            //Clear the reports text before pulling report. 
            GlobalVariables.reportPage.ClearReportsText();

            //Clear the lists from global variables. 
            GlobalVariables.users.Clear(); 


            // Get users from database into a list. 
            string userSql = "Select userName FROM user";
            MySqlCommand cmd = new MySqlCommand(userSql, DatabaseConfiguration.dbconn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string user = reader.GetString("userName");
                GlobalVariables.users.Add(user);
            }
            reader.Close();

            for (int i = 0; i < GlobalVariables.users.Count(); ++i)                  
            {
                string appSql = $"SELECT customerName, start, end, type FROM appointment JOIN customer ON appointment.customerId = customer.customerId JOIN user ON appointment.userId = user.userId WHERE userName = '{GlobalVariables.users.ElementAt(i)}' ";
                MySqlCommand appCmd = new MySqlCommand(appSql, DatabaseConfiguration.dbconn);
                MySqlDataReader appReader = appCmd.ExecuteReader();

                GlobalVariables.reportPage.SetReportsText($"Consultant: {GlobalVariables.users.ElementAt(i)}");

                while (appReader.Read())
                {
                    string newLine = $"{appReader.GetString("customerName")} {appReader.GetString("start")} {appReader.GetString("end")} {appReader.GetString("type")}";
                    GlobalVariables.reportPage.SetReportsText(newLine); 
                }
                appReader.Close();
                GlobalVariables.reportPage.SetReportsText("");

            }
        }

        public static void NumberOfAppointmentTypes()
        {
            //Clear the reports area before performing report. 
            GlobalVariables.reportPage.ClearReportsText();
            //Clear global variables for report. 
            GlobalVariables.monthTypes.Clear();
            GlobalVariables.monthNames.Clear();

            DateTime today = DateTime.Today.AddMonths(-1);
            DateTime firstDate = new DateTime(today.Year, today.Month, 1);

            List<DateTime> dates = new List<DateTime> {};
            

            for (int i = 1; i < 12; ++i)
            {
                dates.Add(firstDate.AddMonths(i));
                dates.Add(firstDate.AddMonths(i+1).AddTicks(-1));
            }


            int j = 0;
            for (int i = 0; i < dates.Count(); ++i)
            {

                string sql = $"SELECT type, count(type) AS total FROM appointment WHERE start BETWEEN '{dates.ElementAt(i).ToUniversalTime().ToString("yyyy/MM/dd")}' AND '{dates.ElementAt(1 + i).ToUniversalTime().ToString("yyyy/MM/dd")}' GROUP BY type";
                MySqlCommand cmd = new MySqlCommand(sql, DatabaseConfiguration.dbconn);
                MySqlDataReader reader = cmd.ExecuteReader();
                List<KeyValuePair<string, int>> temp = new List<KeyValuePair<string, int>>();
                GlobalVariables.monthTypes.Add(temp);

                GlobalVariables.monthNames.Add(dates.ElementAt(i).ToString("MMMM")); 

                while (reader.Read())
                {

                    string type = reader.GetString("type");
                    int count = (int)reader.GetInt64("total");

                    GlobalVariables.monthTypes.ElementAt(j).Add(new KeyValuePair<string, int>(type, count));

                }
                j++;
                reader.Close();
                i++;

            }
        }
    }
}
