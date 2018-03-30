using System;

namespace ADO_Project
{
	class Program
	{
		static void Main(string[] args)
		{
			log4net.Config.BasicConfigurator.Configure();

			//CreateTable table = new CreateTable();
			//table.CreateTableMethod();

			//InsertData insert = new InsertData();
			//insert.OpenConnection();
			//insert.Insert();

			ShowData data = new ShowData();
			data.OpenConnection();
			data.GetData();

			Console.WriteLine("Press any key to exit!");
			Console.Read();
		}
	}
}
