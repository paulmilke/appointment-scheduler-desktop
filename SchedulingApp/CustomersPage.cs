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
    public partial class CustomersPage : Form
    {
        BindingList<Customer> customerList = new BindingList<Customer>();

        public CustomersPage()
        {
            InitializeComponent();
        }

        private void CustomersPage_Load(object sender, EventArgs e)
        {
            customerList = Customer.GrabCustomers();
            customersDataGridView.DataSource = customerList;
            customersDataGridView.ClearSelection();
            deleteCustomerButton.Enabled = false;
            editCustomerButton.Enabled = false; 

        }

        private void CustomersPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            CalendarSchedule form = new CalendarSchedule();
            this.Hide();
            form.Show(); 
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {

            AddEditCustomer form = new AddEditCustomer();
            form.Show(); 
            this.Hide(); 
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to edit.");
            }
            else
            {
                GlobalVariables.editCust = true;
                AddEditCustomer form = new AddEditCustomer();
                form.Show(); 
                this.Hide();
            }
        }

        private void customersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = customersDataGridView.CurrentRow.Index;
            GlobalVariables.selectedCustomer = customerList.ElementAt(index);
            editCustomerButton.Enabled = true;
            deleteCustomerButton.Enabled = true; 
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerMethods.DeleteCustomer(GlobalVariables.selectedCustomer.CustomerID);
            CustomersPage_Load(sender,e);
        }
    }
} 
