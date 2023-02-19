using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp
{
	static class LoginCredentialCheck
	{
		public static int CheckLoginCredentials(string username, string password) 
		{
			int userId = 0;
			string loginQuery = $"SELECT userId FROM user WHERE userName = '{username.Trim()}' AND password = '{password.Trim()}'";
			MySqlCommand loginCmd = new MySqlCommand(loginQuery, DatabaseConfiguration.dbconn);
			Object obj = loginCmd.ExecuteScalar();
			
			if (obj != null)
			{
				userId = int.Parse(obj.ToString());
				return userId; 
			}
			else
			{
				return userId; 
			}

		}

		public static List<string> LanguageCheck() 
		{
			CultureInfo language = CultureInfo.CurrentCulture;
			string languageName = language.Name;

			switch (languageName)
			{
				case "en-US":
					List<string> english = new List<string> {"Please enter your Username and Password to login.", "Username", "Password", "Failed to login. Please check your Username or Password.", "Login"};
					return english;
				case "es-MX":
					List<string> spanish = new List<string> { "Introduzca su nombre de usuario y contraseña para iniciar sesión.", "Nombre de usuario", "Contraseña", "Error al iniciar sesión. Por favor, compruebe su nombre de usuario o contraseña.", "Inicia sesión" };
					return spanish;
				default:
					List<string> englishDefault = new List<string> { "Please enter your Username and Password to login.", "Username", "Password", "Failed to login. Please check your Username or Password.", "Login"};
					return englishDefault;
			}

		}
	}
}
