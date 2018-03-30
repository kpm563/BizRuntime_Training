using System;
using System.Data.SqlClient;

namespace ADO_Project
{
	/// <summary>
	/// This class is designed for performing create table operation on sqlserver.It is having a function which will be creating a table when ever called.
	/// </summary>
	class CreateTable
	{
		static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CreateTable));



		/// <summary>
		/// This method is being used for creating a table.
		/// </summary>
		public void CreateTableMethod() {
			SqlConnection con = null;

			try {
				log.Info("Enter Table Name :: ");
				string tableName = Console.ReadLine();

				log.Info("Enter Table details :: ");
				string tableDetails = Console.ReadLine();

				string address = @"Data Source=.\SQLSERVER;Initial Catalog=BizRuntime;Persist Security Info=True;User ID=sa;Password=prince";
				con = new SqlConnection(address);				
				con.Open();
				log.Info("Connected to DB!");
				
				SqlCommand command = new SqlCommand("create table " + tableName+"("+tableDetails+")", con);
				command.ExecuteNonQuery();
				log.Info("Table created succesfully!");

			}
			catch (Exception e) {
				log.Error("Error ::" + e.Message);
			}
			finally {
				con.Close();
			}
		}
	}
}
