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
	

	public partial class LoginPage : Form
	{
		string failedLogin = "";
		public LoginPage()
		{
			InitializeComponent();
		}

		private void LoginPage_Load(object sender, EventArgs e)
		{
			DatabaseConfiguration.NewDatabaseConnection();

			List<string> languageStrings = LoginCredentialCheck.LanguageCheck();
			statusLabel.Text = languageStrings.ElementAt(0);
			userNameLabel.Text = languageStrings.ElementAt(1);
			passwordLabel.Text = languageStrings.ElementAt(2);
			failedLogin = languageStrings.ElementAt(3);
			loginButton.Text = languageStrings.ElementAt(4);

			GlobalVariables.GetFirstAlert();
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			string userName = userNameTextBox.Text;
			string password = passwordTextbox.Text;

			int check = LoginCredentialCheck.CheckLoginCredentials(userName, password);

			if (check != 0)
			{

				CalendarSchedule form = new CalendarSchedule();
				form.Show(); 
				this.Hide();
				GlobalVariables.user = userName;
				GlobalVariables.userId = check;
				FileLogging.FileLogText(GlobalVariables.user);
			}
			else
			{
				statusLabel.Text = failedLogin;
				statusLabel.BackColor = Color.Salmon; 
			}
		}

    }
}
