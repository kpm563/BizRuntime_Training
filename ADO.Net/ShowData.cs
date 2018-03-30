using System;
using System.Data.SqlClient;

namespace ADO_Project
{
	class ShowData
	{
		static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CreateTable));

		SqlConnection connection = null;
		public void OpenConnection()
		{
			try
			{
				string address = @"Data Source=.\SQLSERVER;Initial Catalog=BizRuntime;Persist Security Info=True;User ID=sa;Password=prince";
				connection = new SqlConnection(address);
				connection.Open();
				log.Info("Connected to DB!");
			}
			catch (Exception e)
			{
				log.Error("Error :: " + e.Message);
			}
		}

		public void GetData() {
			log.Info("Enter customerId :: ");
			int customerId = Convert.ToInt32(Console.ReadLine());

			string getData = @"SELECT Customers.CustomerId, Customers.CustomerName, Customers.CustomerAge, Orders.OrderId,  Orders.OrderName, Orders.Price FROM Orders INNER JOIN Customers ON Orders.CustomerId=Customers.CustomerId";

			try
			{
				SqlCommand command = new SqlCommand(getData, connection);
				SqlDataReader reader = command.ExecuteReader();

				for (int i = 1; i < reader.FieldCount; i++)
				{
					Console.Write(reader.GetName(i) + "\t ");
				}
								
				Console.WriteLine("\n========================================================================================");
				
				while (reader.Read())
				{
					if (customerId == (int) reader["CustomerId"])
					{
						for (int i = 1; i < reader.FieldCount; i++)
						{
							Console.Write(reader[i] + "\t       ");
						}
						Console.Write("\n");
					}
				}
				Console.WriteLine("========================================================================================");
			}
			catch (Exception e)
			{
				log.Error("Error :: " + e.Message);
			}
			finally {
				if (connection != null) {
					connection.Close();
				}
			}
		}
	}
}
