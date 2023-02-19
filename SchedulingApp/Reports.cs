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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form calendar = new CalendarSchedule();
            calendar.Show();
            reportsTextBox.Clear(); 
            GlobalVariables.monthNames.Clear();
            GlobalVariables.monthTypes.Clear();
        }

        private void typesButton_Click(object sender, EventArgs e)
        {
            ReportMethods.NumberOfAppointmentTypes();

            for (int i = 0; i<GlobalVariables.monthTypes.Count; ++i)
            {
                List<KeyValuePair<string, int>> temp = GlobalVariables.monthTypes.ElementAt(i);

                reportsTextBox.AppendText($"{GlobalVariables.monthNames.ElementAt(i)}" + " --> ");

                if (temp.Count == 0)
                {
                    reportsTextBox.AppendText("No Appointments" + System.Environment.NewLine); 
                }
                else
                {
                    for (int j = 0; j < temp.Count; ++j)
                    {
                        reportsTextBox.AppendText($"{temp.ElementAt(j).Key} [{temp.ElementAt(j).Value.ToString()}];");
                    }
                    reportsTextBox.AppendText(System.Environment.NewLine);
                }
                reportsTextBox.AppendText(System.Environment.NewLine);
            }
        }

        private void consultantScheduleButton_Click(object sender, EventArgs e)
        {
            ReportMethods.ConsultantSchedules(); 
        }

        //I used a lambda expression here since the method only has a single line of code to execute. This means I can leverage a
        //lamda expression to take the string named text as an input parameter and input it into the expression that follows the
        //lamda => symbol. In this case, the input parameter is used to append more text to my reports page. 
        public void SetReportsText(string text) => reportsTextBox.AppendText(text + System.Environment.NewLine); 

        //I used another lamda expression here with the same intention as above. The main difference is that this one does not require
        //any input parameters to call the expression. The ClearReportsText() method points directly to the method to clear my reports page. 
        public void ClearReportsText() => reportsTextBox.Clear();

        private void clientLocationsButton_Click(object sender, EventArgs e) => ReportMethods.ClientLocations();

    }
}
