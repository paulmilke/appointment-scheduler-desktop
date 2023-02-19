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
    public partial class AddEditCustomer : Form
    {
        public AddEditCustomer()
        {
            InitializeComponent();
        }

        public bool ValidateCustomerInfo()
        {
            int validationCount = 0; 

            //Validtate there is a name. 
            if (nameTextbox.Text == "" || nameTextbox.Text.Any(char.IsLetter) == false)
            {
                nameTextbox.BackColor = Color.Red;
            }
            else
            {
                nameTextbox.BackColor = Color.White;
                ++validationCount;
            }

            //Validate Postal. 
            if (postalCodeTextbox.Text == "" || postalCodeTextbox.Text.Count() != 5 || postalCodeTextbox.Text.All(char.IsDigit) == false)
            {
                postalCodeTextbox.BackColor = Color.Red;
            }
            else
            {
                postalCodeTextbox.BackColor = Color.White;
                ++validationCount;
            }

            if (address1Textbox.Text == "" || address1Textbox.Text.Any(char.IsLetter) == false)
            {
                address1Textbox.BackColor = Color.Red;

            }
            else
            {
                address1Textbox.BackColor = Color.White;
                ++validationCount;
            }
            if (cityTextbox.Text == "" || cityTextbox.Text.Any(char.IsLetter) == false)
            {
                cityTextbox.BackColor = Color.Red;

            }
            else
            {
                cityTextbox.BackColor = Color.White;
                ++validationCount;
            }
            if (countryTextbox.Text == "" || countryTextbox.Text.Any(char.IsLetter) == false)
            {
                countryTextbox.BackColor = Color.Red;

            }
            else
            {
                countryTextbox.BackColor = Color.White;
                ++validationCount;
            }
            if (phoneNumberTextbox.Text == "" || phoneNumberTextbox.Text.Count() != 10 || phoneNumberTextbox.Text.All(char.IsDigit) == false)
            {
                phoneNumberTextbox.BackColor = Color.Red;

            }
            else
            {
                phoneNumberTextbox.BackColor = Color.White;
                ++validationCount;
            }
            if(validationCount == 6)
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }


        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            if (ValidateCustomerInfo() == true)
            {
                string name = nameTextbox.Text;
                string address1 = address1Textbox.Text;
                string address2 = address2Textbox.Text;
                string city = cityTextbox.Text;
                string country = countryTextbox.Text;
                string phone = phoneNumberTextbox.Text;
                string postal = postalCodeTextbox.Text;

                if (GlobalVariables.editCust == false)
                {
                        int cId = CustomerMethods.AddCountry(country);
                        int cityId = CustomerMethods.AddCity(cId, city);
                        int addressId = CustomerMethods.AddEditAddress(address1, address2, cityId, phone, postal);
                        bool tryAdd = CustomerMethods.AddEditCustomer(addressId, name);
                    if (tryAdd == true)
                    {

                        // Close the form and open the Customer page again. 
                        GlobalVariables.editCust = false;
                        CustomersPage newForm = new CustomersPage();
                        newForm.Show();
                        this.Hide();
                    }
                }

                else
                {
                    int cId = CustomerMethods.AddCountry(country);
                    int cityId = CustomerMethods.AddCity(cId, city);
                    int addressId = CustomerMethods.AddEditAddress(address1, address2, cityId, phone, postal);
                    bool tryUpdate = CustomerMethods.AddEditCustomer(addressId, name);

                    if(tryUpdate == true)
                    {
                        // Close the form and open the Customer page again.
                        GlobalVariables.editCust = false;
                        CustomersPage newForm = new CustomersPage();
                        newForm.Show();
                        this.Hide();
                    }
                }

            }
            else
            {
                MessageBox.Show("Please correct the customer data."); 
            }
        }

        private void AddEditCustomer_Load(object sender, EventArgs e)
        {
            

            if (GlobalVariables.editCust == true)
            {

                addCustomerButton.Text = "Update Customer";
                int customerId = GlobalVariables.selectedCustomer.CustomerID;
                string getCustomerData = $"SELECT customerName, address, address2, city, " +
                    $"postalCode, country, phone FROM customer JOIN address ON customer.addressId = address.addressId " +
                    $"JOIN city ON address.cityId = city.cityId JOIN country ON city.countryId = " +
                    $"country.countryId WHERE customerId = {customerId}";

                MySqlCommand cmd = new MySqlCommand(getCustomerData, DatabaseConfiguration.dbconn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    nameTextbox.Text = reader.GetString("customerName");
                    address1Textbox.Text = reader.GetString("address");
                    address2Textbox.Text = reader.GetString("address2");
                    cityTextbox.Text = reader.GetString("city");
                    postalCodeTextbox.Text = reader.GetString("postalCode");
                    countryTextbox.Text = reader.GetString("country");
                    phoneNumberTextbox.Text = reader.GetString("phone"); 
                }

                reader.Close();
            }


        }

        private void AddEditCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            CustomersPage form = new CustomersPage();
            form.Show(); 
        }
    }
}
