using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ComapnyHierarchy
{
	public class CEO {
		public ArrayList employee = new ArrayList();
		public void CeoMethod() {
			employee.Add("CEO");
		}

		public void Show()
		{
			string[] employeeArray = (string[])employee.ToArray(typeof(string));
			foreach (string value in employeeArray)
			{
				Console.WriteLine(value);
			}
		}

		//Writting into file 
		public void WriteInToFile()
		{
			StreamWriter sw = null;
			try
			{
				string[] employeeArray = (string[])employee.ToArray(typeof(string));
				sw = File.CreateText(@"E:\FileIO\Users\CSharp_Data\Employee.txt");
				foreach (string element in employeeArray)
				{
					sw.WriteLine(element);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception ::" + e.Message);
			}
			finally
			{
				sw.Close();	
			}
		}
		
		//Reading from file 
		public void ReadFromFile()
		{
			Console.WriteLine("\nReading data from file ::");
			StreamReader sr = null;
			try
			{
				sr = File.OpenText(@"E:\FileIO\Users\CSharp_Data\Employee.txt");
				Console.WriteLine(sr.ReadToEnd());
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception :: " + e.Message);
			}
			finally
			{
				sr.Close();
			}
		}

		//Writting reading same time
		public void WriteFile()
		{
			string[] employeeArray = (string[])employee.ToArray(typeof(string));
			string textFilePath = @"E:\FileIO\Users\CSharp_Data\ReadWriteST.txt";
			FileStream fileStream = File.Open(textFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);	
			foreach (string str in employeeArray)
			{
				byte[] vs = Encoding.Default.GetBytes(str);
				fileStream.Write(vs, 0, vs.Length);
			}
			fileStream.Position = 0;
			//ReadFile();
		}

		public void ReadFile()
		{
			string textFilePath = @"E:\FileIO\Users\CSharp_Data\ReadWriteST.txt";
			if (File.Exists(textFilePath))
			{
				FileStream fs = File.Open(textFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				StreamReader streamReader = new StreamReader(fs);
				string str = streamReader.ReadToEnd();
				Console.WriteLine(str);
			}
			//WriteFile();
		}


		// Serialization process
		public void SerializeMethod() {
			try
			{
				using (Stream fs = new FileStream(@"E:\FileIO\Users\CSharp_Data\SerializedEmployee.xml", FileMode.Create))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(ArrayList));
					xmlSerializer.Serialize(fs, employee);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception :: " + e.Message);
			}
			employee = null;
		}

		// Deserialization process
		public void DeserializeMethod() {
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ArrayList));
			try
			{
				using (FileStream fs = File.OpenRead(@"E:\FileIO\Users\CSharp_Data\SerializedEmployee.xml"))
				{
					employee = (ArrayList)xmlSerializer.Deserialize(fs);
				}
			}
			catch (Exception e) {
				Console.WriteLine("Exception :: " + e.Message);
			}
			Console.WriteLine("Reading data after deserialization :: ");
			Show();
		}
	}

	class CTO : CEO {
		public void CtoMethod() {
			CeoMethod();
			employee.Add("CTO");
		}		
	}

	class VpQa : CEO {
		public void VpQaMethod() {
			CeoMethod();
			employee.Add("VP Q&A");
		}		
	}

	class TeamLeaders : CTO {
		public void TLMethod1() {
			CtoMethod();
			employee.Add("Programer's Team Leader 1");				
		}

		public void TLMethod2()
		{
			CtoMethod();
			employee.Add("Programer's Team Leader 2");
		}

		public void TLMethod3()
		{
			CtoMethod();
			employee.Add("Programer's Team Leader 3");
		}
	}
		
	class Programers : TeamLeaders {
		public void Programer1Method() {
			TLMethod1();
			employee.Add("TL1 Team Programmer 1");
			employee.Add("TL1 Team Programmer 2");
			employee.Add("TL1 Team Programmer 3");
			//Console.WriteLine();
		}
		public void Programer2Method()
		{
			TLMethod2();
			employee.Add("TL2 Team Programmer 1");
			employee.Add("TL2 Team Programmer 2");
			employee.Add("TL2 Team Programmer 3");
			//Console.WriteLine();
		}
		public void Programer3Method()
		{
			TLMethod3();
			employee.Add("TL3 Team Programmer 1");
			employee.Add("TL3 Team Programmer 2");
			employee.Add("TL3 Team Programmer 3");
			//Console.WriteLine();
		}
	}

	class QATeamLeaders : VpQa {
		public void QATeam1Method() {
			VpQaMethod();
			employee.Add("QA Team Leader 1");
		}
		public void QATeam2Method()
		{
			VpQaMethod();
			employee.Add("QA Team Leader 2");
		}
		public void QATeam3Method()
		{
			VpQaMethod();
			employee.Add("QA Team Leader 3");
		}
	}
	
	class Testers : QATeamLeaders {
		public void Tester1Method() {
			QATeam1Method();
			employee.Add("QA1 Team Tester 1");
			employee.Add("QA1 Team Tester 2");
			employee.Add("QA1 Team Tester 3");
			//Console.WriteLine();
		}

		public void Tester2Method()
		{
			QATeam2Method();
			employee.Add("QA2 Team Tester 1");
			employee.Add("QA2 Team Tester 2");
			employee.Add("QA2 Team Tester 3");
			//Console.WriteLine();
		}

		public void Tester3Method()
		{
			QATeam3Method();
			employee.Add("QA3 Team Tester 1");
			employee.Add("QA3 Team Tester 2");
			employee.Add("QA3 Team Tester 3");
			//Console.WriteLine();
		}
	}

	class Program
	{
		//internal static void Testing()
		//{
		//	log4net.Config.BasicConfigurator.Configure();
		//	log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
		//	try
		//	{
		//		log.Debug("This is a Debug message");
		//		log.Info("This is a Info message");
		//		log.Warn("This is a Warning message");
		//		log.Error("This is an Error message");
		//		log.Fatal("This is a Fatal message");

		//		string str = String.Empty;
		//		string subStr = str.Substring(0, 4); //this line will create error as the string "str" is empty.  
		//	}
		//	catch (Exception ex)
		//	{
		//		log.Error("Error Message: " + ex.Message.ToString(), ex);
		//	}
		//}


		static void Main(string[] args)
		{
			log4net.Config.BasicConfigurator.Configure();
			log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));


			Console.WriteLine("Employees Hierarchy of a Software company :: ");
			CEO cEOObject = new CEO();
			log.Info("Adding CEO in the list...");
			cEOObject.CeoMethod();
			//cEOObject.Show();			

			CTO cTOObject = new CTO();
			log.Info("Adding CTO in the list...");
			cTOObject.CtoMethod();
			//cTOObject.Show();

			VpQa vpQaObject = new VpQa();
			log.Info("Adding VP-QA in the list...");
			vpQaObject.VpQaMethod();
			//vpQaObject.Show();

			TeamLeaders teamLeadersObject = new TeamLeaders();
			log.Info("Adding Team Leaders in the list...");
			teamLeadersObject.TLMethod1();
			teamLeadersObject.TLMethod2();
			teamLeadersObject.TLMethod3();
			//teamLeader1Object.Show();

			Programers programersObject = new Programers();
			log.Info("Showing Hyrarchy till Programmer1 Level...");
			programersObject.Programer1Method();
			//programersObject.Show();
			//Console.WriteLine();

			//log.Info("Showing Hyrarchy till Programmer2 Level...");
			//programersObject.Programer2Method();
			//programersObject.Show();
			//Console.WriteLine();
			//log.Info("Showing Hyrarchy till Programmer3 Level...");
			//programersObject.Programer3Method();
			//programersObject.Show();
			//Console.WriteLine();

			//log.Info("Writting List into File...");
			//programersObject.WriteInToFile();
			//log.Info("Reading List from File...");
			//programersObject.ReadFromFile();
			log.Info("Writting List into File using serialization...");
			programersObject.SerializeMethod();
			log.Info("Reading List from File using Deserialization...");
			programersObject.DeserializeMethod();
			//log.Info("Writting List into File While Reading...");
			//programersObject.WriteFile();
			//log.Info("Reading List from File While Writting...");
			//programersObject.ReadFile();



			QATeamLeaders qATeamLeadersObject = new QATeamLeaders();
			qATeamLeadersObject.QATeam1Method();
			qATeamLeadersObject.QATeam2Method();
			qATeamLeadersObject.QATeam3Method();
			//qATeamLeadersObject.Show();

			Testers testersObject = new Testers();
			testersObject.Tester1Method();
			//testersObject.Show();
			//Console.WriteLine();
			testersObject.Tester2Method();
			//testersObject.Show();
			//Console.WriteLine();
			testersObject.Tester3Method();
			//testersObject.Show();

			//cEOObject.WriteInToFile();
			//cEOObject.ReadFromFile();

			//testersObject.WriteInToFile();
			//testersObject.ReadFromFile();
			//testersObject.SerializeMethod();
			//testersObject.DeserializeMethod();

			//Testing();

			Console.Read();
		}
	}
}
