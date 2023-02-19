using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp
{
    public class Appointments
    {
        private int appointmentId { get; set; }
        private int customerId { get; set; }
        private string customerName { get; set; }
        private string appointmentType { get; set; }
        private DateTime start { get; set; }
        private DateTime end { get; set; }
        private string title {get; set;}
        private string description { get; set; }
        private string location { get; set; }
        private string contact { get; set; }
        private string url { get; set; }

        public Appointments(int appointmentId, int customerId, string customerName, string appointmentType, DateTime start, DateTime end, string title, string description, string location, string contact, string url)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            CustomerName = customerName;
            AppointmentType = appointmentType;
            Start = start;
            End = end;
            Title = title;
            Description = description;
            Location = location;
            Contact = contact;
            URL = url; 

        }

        public int AppointmentId
        {
            get
            {
                return appointmentId; 
            }
            set
            {
                appointmentId = value; 
            }
        }
        public int CustomerId
        {
            get
            {
                return customerId; 
            }
            set
            {
                customerId = value; 
            }
        }
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value; 
            }
        }
        public string AppointmentType
        {
            get
            {
                return appointmentType;
            }
            set
            {
                appointmentType = value; 
            }
        }
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value; 
            }
        }
        public DateTime End
        {
            get
            {
                return end; 
            }
            set
            {
                end = value; 
            }
        }
        public string Title
        {
            get
            {
                return title; 
            }
            set
            {
                title = value; 
            }
        }
        public string Description
        {
            get
            {
                return description; 
            }
            set
            {
                description = value; 
            }
        }
        public string Location
        {
            get
            {
                return location; 
            }
            set
            {
                location = value; 
            }
        }
        public string Contact
        {
            get
            {
                return contact; 
            }
            set
            {
                contact = value; 
            }
        }
        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

    }
}
