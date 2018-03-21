using System;
using System.Net.Sockets;
using System.IO;

namespace ClientOne2One
{
	public class Client
	{
		static public void Main(string[] Args)
		{
			TcpClient socketForServer;
			try
			{
				socketForServer = new TcpClient("127.0.0.1", 8888);
			}
			catch
			{
				Console.WriteLine(
				"Failed to connect to server at {0}:999", "localhost");
				return;
			}

			NetworkStream networkStream = socketForServer.GetStream();
			StreamReader streamReader =	new System.IO.StreamReader(networkStream);
			StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
			Console.WriteLine("*******This is client program who is connected to localhost on port No:10*****");

			try
			{
				string outputString;				
				{					
					Console.WriteLine("type:");
					string str = Console.ReadLine();
					while (str != "exit")
					{
						streamWriter.WriteLine(str);
						streamWriter.Flush();
						Console.WriteLine("type:");
						str = Console.ReadLine();
					}
					if (str == "exit")
					{
						streamWriter.WriteLine(str);
						streamWriter.Flush();

					}

				}
			}
			catch
			{
				Console.WriteLine("Exception reading from Server");
			}
			// tidy up
			networkStream.Close();
			Console.WriteLine("Press any key to exit from client program");
			Console.ReadKey();
		}

		private static string GetData()
		{
			//Ack from server
			return "ack";
		}
	}
}
