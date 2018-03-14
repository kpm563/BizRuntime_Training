using System;
using System.IO;
using System.Text;

namespace ComapnyHierarchy
{
	class ReadWriteST
	{
		static string textFilePath = @"E:\FileIO\Users\CSharp_Data\ReadWriteST.txt";
		public void WriteFile() {			
			FileStream fileStream = File.Open(textFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			string[] someData = { "ram", "shyam", "mohan" };
			foreach (string str in someData) {
				byte[] vs = Encoding.Default.GetBytes(str);
				fileStream.Write(vs, 0, vs.Length);				
			}
			fileStream.Position = 0;
		}

		public void ReadFile()
		{
			if (File.Exists(textFilePath))
			{
					FileStream fs = File.Open(textFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					StreamReader streamReader = new StreamReader(fs);
					string str = streamReader.ReadToEnd();
					Console.WriteLine(str);
			}
		}

		static void Main(string[] args) {
			ReadWriteST readWriteST = new ReadWriteST();
			readWriteST.WriteFile();
			readWriteST.ReadFile();
			Console.Read();
		}
	}
}
