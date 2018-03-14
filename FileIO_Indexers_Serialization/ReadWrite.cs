using System;
using System.IO;
using System.Text;
using System.Threading;

namespace ComapnyHierarchy
{
	class ReadWrite
	{
		static void Main(string[] args)
		{
			ThreadStart jobwrite = new ThreadStart(Writer);

			Thread threadWrite = new Thread(jobwrite);

			threadWrite = new Thread(jobwrite);
			threadWrite.Name = "Write";
			threadWrite.Start();

			ThreadStart jobread = new ThreadStart(Reader);

			Thread threadread = new Thread(jobread);

			threadread = new Thread(jobread);
			threadread.Name = "read";
			threadread.Start();

			threadWrite.Join();
			threadread.Join();
			Console.Read();
		}

		private static void Reader()
		{
			try
			{
				for (int i = 0; i < 100; i++)
				{
					using (FileStream fs = File.Open(@"E:\FileIO\Users\CSharp_Data\ReadWrite.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						StreamReader sr = new StreamReader(fs);
						string str = sr.ReadToEnd();

						sr.Close();
						fs.Close();

						Console.Write("Read: " + str + Environment.NewLine);
					}
					System.Threading.Thread.Sleep(10);
				}
			}
			catch (Exception ex)
			{
				Console.Write("read" + ex.ToString());
				Console.Read();
			}
		}

		private static void Writer()
		{
			try
			{
				for (int i = 0; i < 100; i++)
				{
					string status = i.ToString();
					using (FileStream fs = File.Open(@"E:\FileIO\Users\CSharp_Data\ReadWrite.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
					{
						byte[] bytes = Encoding.ASCII.GetBytes(status);
						fs.Write(bytes, 0, bytes.Length);
						fs.Close();
						Console.Write("Write:" + status + Environment.NewLine);
					}
					System.Threading.Thread.Sleep(10);
				}
			}
			catch (Exception ex)
			{
				Console.Write("write" + ex.ToString());
				Console.Read();
			}
		}
	}
}
