using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp
{
    public class AppointmentReport : Appointments
    {
        private string userName { get; set; }
        public AppointmentReport(string username, int appointmentId, int customerId, string customerName, string appointmentType, DateTime start, DateTime end, string title, string description, string location, string contact, string url):base(appointmentId, customerId, customerName, appointmentType, start, end, title, description, location, contact, url)
        {
            UserName = username; 
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value; 
            }
        }
    }
}
