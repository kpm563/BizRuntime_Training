using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientOne2One
{
	class Client121
	{
		static Socket socket;
		static void Main(string[] args) {
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);

			try
			{
				socket.Connect(endPoint);
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine("Do you want to continue(yes/no)?");
				string choice = Console.ReadLine();
				if (choice == "yes")
					Main(args);
				else
					return;
			}

			Byte[] bytes = new Byte[255];
			int length = socket.Receive(bytes, 0, bytes.Length, 0);
			Array.Resize(ref bytes, length);
			Console.WriteLine(Encoding.Default.GetString(bytes));

			string str1 = "", str2 = "";
			while (!str1.Equals("stop")) {
				Console.Write("Enter Text : ");
				str1 = Console.ReadLine();
				Byte[] data1 = Encoding.ASCII.GetBytes(str1);
				socket.Send(data1);
				Console.WriteLine("Send Successful");

				int rData = socket.Receive(bytes, 0, bytes.Length, 0);
				Array.Resize(ref bytes, rData);
				str2 = Encoding.Default.GetString(bytes);
				Console.WriteLine("Server message :: " + str2);
			}
			Console.WriteLine("Press any key");
			Console.ReadKey();
			socket.Close();
		}
	}
}
