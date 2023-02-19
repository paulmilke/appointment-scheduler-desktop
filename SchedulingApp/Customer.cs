using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp
{
    public class Customer
    {
        private int customerId { get; set; }
        private string customerName { get; set; }
        private string address { get; set; }
        private string address2 { get; set; }
        private string postal { get; set; }
        private string city { get; set; }
        private string country { get; set; }
        private string phone { get; set; }

        public Customer(int id, string name, string address, string address2, string postal, string city, string country, string phone)
        {
            CustomerID = id;
            CustomerName = name;
            Address = address;
            Address2 = address2;
            Postal = postal;
            City = city;
            Country = country;
            Phone = phone; 
 
        }

        public static BindingList<Customer> GrabCustomers()
        {
            BindingList<Customer> customerList = new BindingList<Customer>(); 

            string customerQuery = "SELECT customerId, customerName, address, address2, postalCode, city, country, phone FROM customer JOIN address ON customer.addressId = address.addressId JOIN city ON address.cityId = city.cityId JOIN country ON city.countryId = country.countryId";
            MySqlCommand cmd = new MySqlCommand(customerQuery, DatabaseConfiguration.dbconn);
            MySqlDataReader reader = cmd.ExecuteReader(); 

            while (reader.Read())
            {
                int id = reader.GetInt32("customerId"); 
                string name = reader.GetString("customerName");
                string address = reader.GetString("address");
                string address2 = reader.GetString("address2");
                string postal = reader.GetString("postalCode");
                string city = reader.GetString("city");
                string country = reader.GetString("country");
                string phone = reader.GetString("phone");


                Customer C = new Customer(id, name, address, address2, postal, city, country, phone);
                customerList.Add(C);
            }

            reader.Close(); 
            return customerList;
        }

        public int CustomerID
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

        public string Address
        {
            get
            {
                return address; 
            }
            set
            {
                address = value; 
            }
        }

        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value; 
            }
        }
        public string Postal
        {
            get
            {
                return postal;
            }
            set
            {
                postal = value;
            }
        }
        public string City
        {
            get
            {
                return city; 
            }
            set
            {
                city = value; 
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value; 
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

    }

}
