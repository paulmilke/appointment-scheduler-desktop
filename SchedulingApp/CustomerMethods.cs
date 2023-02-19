using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
    class CustomerMethods
    {

        public static bool DeleteCustomer(int customerId)
        {
            string deleteCust = $"DELETE FROM customer WHERE customerId = {customerId}";
            MySqlCommand delete = new MySqlCommand(deleteCust, DatabaseConfiguration.dbconn);
            
            if (delete.ExecuteNonQuery() != 0)
            {
                MessageBox.Show($"{GlobalVariables.selectedCustomer.CustomerName} has been deleted.");
                return true;
            }
            else
            {
                return false; 
            }
        }

        public static bool AddEditCustomer(int addressId, string customerName)
        {
            //Checks to see if the customer already exists. 
            string checkCust = $"SELECT customerName FROM customer WHERE customerName = '{customerName}' AND addressId = {addressId}";
            MySqlCommand custCmd = new MySqlCommand(checkCust, DatabaseConfiguration.dbconn);

            if (custCmd.ExecuteScalar() != null && GlobalVariables.editCust == false)
            {
                MessageBox.Show("Customer already exists"); 
                return false;
            }
            else
            {

                //Edits customer if the edit customer page is being used
                if (GlobalVariables.editCust == true)
                {
                    string editCust = $"UPDATE customer SET customerName = '{customerName}', addressId = '{addressId}' WHERE customerId = {GlobalVariables.selectedCustomer.CustomerID}";
                    MySqlCommand edit = new MySqlCommand(editCust, DatabaseConfiguration.dbconn);

                    try
                    {
                        if (edit.ExecuteNonQuery() != 0)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Query executed without proper result.");
                            return false;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"Error adding customer with the following message: {ex}.");
                        return false;
                    }
                }
                else
                {
                    //Adds as new customer if not editing one that already exists. 
                    string addCust = $"INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy)" +
                        $"VALUES ('{customerName}', '{addressId}', 1, NOW(), '{GlobalVariables.user}', '{GlobalVariables.user}')";
                    MySqlCommand addCustCom = new MySqlCommand(addCust, DatabaseConfiguration.dbconn);

                    try
                    {
                        if (addCustCom.ExecuteNonQuery() != 0)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Query executed without proper result.");
                            return false;

                        }

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"Error adding customer. Error message: '{ex}'");
                        return false;
                    }
                }
            }
        }

        public static int AddEditAddress(string address, string address2, int cityId, string phone, string postal)
        {
            //Check to see if address exists.
            string checkAddress = $"SELECT addressId FROM address WHERE address = '{address}' AND cityId = {cityId} AND postalCode = '{postal}' AND phone = '{phone}'";
            MySqlCommand cmd = new MySqlCommand(checkAddress, DatabaseConfiguration.dbconn);
            Object check = cmd.ExecuteScalar();


            //If the address doesnt exist, add address and return the new id. 
            if (check == null && GlobalVariables.editCust == false)
            {
                string addAddress = $"INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy)" +
                    $"VALUES ('{address}', '{address2}', '{cityId}', '{postal}', '{phone}', NOW(), '{GlobalVariables.user}', '{GlobalVariables.user}')";
                MySqlCommand addAdd = new MySqlCommand(addAddress, DatabaseConfiguration.dbconn);
                addAdd.ExecuteNonQuery();

                return (Convert.ToInt32(addAdd.LastInsertedId)); 
            }
            
            else if (GlobalVariables.editCust == true)
            {
                //Edit address info for the specific customer that already exists. 
                string updateAddress = $"UPDATE address SET address = '{address}', address2 = '{address2}', cityId = {cityId}, phone = '{phone}', postalCode = '{postal}' " +
                    $"WHERE addressId = (SELECT addressId FROM customer WHERE customerId = {GlobalVariables.selectedCustomer.CustomerID})";
                MySqlCommand update = new MySqlCommand(updateAddress, DatabaseConfiguration.dbconn);
                update.ExecuteNonQuery();

                //Get Address ID from the updated address. Return it to properly use methods following. 
                string grabAddressId = $"SELECT addressId FROM customer WHERE customerId = {GlobalVariables.selectedCustomer.CustomerID}";
                MySqlCommand addressId = new MySqlCommand(grabAddressId, DatabaseConfiguration.dbconn); 
                return (Convert.ToInt32(addressId.ExecuteScalar()));
            }
            else
            {
                //Find id if the address already exists. 
                return (Convert.ToInt32(check.ToString()));
            }
        }

        public static int AddCity(int countryId, string city)
        {
            //Check to see if city exists already
            string cityCheck = $"SELECT cityId, city FROM city WHERE city = '{city}' AND countryId = {countryId}";
            MySqlCommand cmd = new MySqlCommand(cityCheck, DatabaseConfiguration.dbconn); 

            //If it doesn't exist, add it and return new city id. 
            if (cmd.ExecuteScalar() == null)
            {
                string addCity = $"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) VALUES ('{city}', '{countryId}',NOW(),'{GlobalVariables.user}', '{GlobalVariables.user}')";
                MySqlCommand cityCommand = new MySqlCommand(addCity, DatabaseConfiguration.dbconn);
                cityCommand.ExecuteNonQuery();

                return (Convert.ToInt32(cityCommand.LastInsertedId));
            }

            else
            {
                //Grab city id if it already exists
                Object obj = cmd.ExecuteScalar();
                int cityID = Convert.ToInt32(obj.ToString());

                return cityID;
            }

        }

        public static int AddCountry(string country)
        {
            //Check to see if country exists already. 
            string countryCheck = $"SELECT countryId, country FROM country WHERE country = '{country}'";
            MySqlCommand cmd = new MySqlCommand(countryCheck, DatabaseConfiguration.dbconn);



            //If it doesn't exist, add it and return the new country id. 
            if (cmd.ExecuteScalar() == null)
            {
                //Insert new country into database and grab new country id. 
                string addCountry = $"INSERT INTO country (country, createDate, createdBy, lastUpdateBy) VALUES ('{country}',NOW(), '{GlobalVariables.user}', '{GlobalVariables.user}')";
                MySqlCommand cmdAdd = new MySqlCommand(addCountry, DatabaseConfiguration.dbconn);
                cmdAdd.ExecuteNonQuery();

                return Convert.ToInt32(cmdAdd.LastInsertedId); 
            }
            else
            {
                //Grab country id of country that already exists. 
                Object obj = cmd.ExecuteScalar();
                int countryID = Convert.ToInt32(obj.ToString());

                return countryID; 
            }


        }

    }
}
