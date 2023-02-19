using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
	public static class DatabaseConfiguration
	{
		public static string dbConnString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
		public static MySqlConnection dbconn = new MySqlConnection(dbConnString);
		
		public static bool NewDatabaseConnection()
		{
			try
			{
				dbconn.Open();

				return true; 

			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);

				return false; 
			}
		}

		public static void CloseDatabaseConnection() 
		{
			dbconn.Close(); 
		}
	}
}
