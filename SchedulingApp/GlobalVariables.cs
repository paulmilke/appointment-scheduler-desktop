using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
    public static class GlobalVariables
    {
        public static string user = null;
        public static int userId;
        public static bool editCust = false;
        public static bool editApp = false; 
        public static Customer selectedCustomer;
        public static Appointments selectedAppointment;
        public static List<DateTime> appointmentTimes;
        public static string nextAppCustomer;
        public static DateTime nextAppTime;

        public static List<List<KeyValuePair<string, int>>> monthTypes = new List<List<KeyValuePair<string, int>>>();
        public static List<string> monthNames = new List<string>();


        public static List<List<Appointments>> userAppointments = new List<List<Appointments>>();
        public static List<string> users = new List<string>();


        public static Reports reportPage = new Reports();

        public static List<string> countries = new List<string>();


        //Below are variables and methods to call for alerts to alert that there is an appointment in the next 15 minutes. 

        public static BindingList<Appointments> appList = new BindingList<Appointments>();
        public static BindingList<Appointments> appTimes = new BindingList<Appointments>();
        public static System.Threading.Timer alertTimer;

        public static void GetFirstAlert()
        {
            DateTime date1 = DateTime.Today.Date;
            DateTime date2 = DateTime.Today.Date.AddDays(+1);
            appList = AppointmentMethods.GrabAppointments(date1, date2);

            DateTime now = DateTime.Now;
            DateTime nowTrimmed = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            DateTime fifteenForward = nowTrimmed.AddMinutes(15);


            for (int i = 0; i < appList.Count; ++i)
            {
                if (appList.ElementAt(i).Start >= fifteenForward)
                {
                    appTimes.Add(appList.ElementAt(i));
                }
            }

            if (appTimes.Count()>0 && appTimes.First().Start == fifteenForward)
            {
                GlobalVariables.nextAppTime = appTimes.First().Start;
                GlobalVariables.nextAppCustomer = appTimes.First().CustomerName;

                MessageBox.Show($"This is your 15 minute reminder for your appointment with {GlobalVariables.nextAppCustomer} at {GlobalVariables.nextAppTime}.");
                GetAlerts(); 
            }
            else
            {
                GetAlerts(); 
            }
        }

        public static void GetAlerts()
        {
            appList.Clear();
            appTimes.Clear();

            DateTime date1 = DateTime.Today.Date;
            DateTime date2 = DateTime.Today.Date.AddDays(+1);
            appList = AppointmentMethods.GrabAppointments(date1, date2);


            for (int i = 0; i < appList.Count; ++i)
            {
                if (appList.ElementAt(i).Start >= DateTime.Now.AddMinutes(15))
                {
                    appTimes.Add(appList.ElementAt(i));
                }
            }

            TimerCallback callback = new TimerCallback(ProcessTimerEvent);

            if (appTimes.Count > 0)
            {
                DateTime nextApp = appTimes.First().Start;
                GlobalVariables.nextAppTime = nextApp;
                GlobalVariables.nextAppCustomer = appTimes.First().CustomerName;
                if (nextApp > DateTime.Now)
                {
                    TimeSpan span = nextApp.AddMinutes(-15) - DateTime.Now;
                    int milliseconds = (int)span.TotalMilliseconds;
                    int refresh = 960000;

                    if (alertTimer == null)
                    {
                        alertTimer = new System.Threading.Timer(callback, null, milliseconds, refresh);

                    }
                    else
                    {
                        alertTimer.Change(milliseconds, refresh);
                    }

                }
            }
        }

        private static void ProcessTimerEvent(object obj)
        {
            MessageBox.Show($"This is your 15 minute reminder for your appointment with {GlobalVariables.nextAppCustomer} at {GlobalVariables.nextAppTime}.");
            //Get updated list. 
            GetAlerts();
        }

    }
}
