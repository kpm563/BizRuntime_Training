using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientOne2One
{
	class Client122
	{
		static Socket socket;
		static byte[] bytes = new byte[1000];

		static void GetConnect() {
			Console.WriteLine("Enter server IP address :: ");
			string address = Console.ReadLine();
			Console.WriteLine("Enter port number :: ");
			int port = Convert.ToInt16(Console.ReadLine());

			try
			{
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(address), port);
				socket.Connect(endPoint);
			}
			catch (Exception e) {
				Console.WriteLine("Error :: " + e.Message);
				Console.WriteLine("Do you want to continue(yes/no)?");
				string choice = Console.ReadLine();
				if (choice == "yes")
					Main();
				else
					return;
			}
		}

		static void GetData() {
			try
			{				
				int recievedData = socket.Receive(bytes, 0, bytes.Length, 0);
				Array.Resize(ref bytes, recievedData);
				Console.WriteLine(Encoding.Default.GetString(bytes));
			}
			catch (Exception e) {
				Console.WriteLine("Error :: " + e.Message);
			}
		}

		static void SendData() {
			string str1 = "", str2 = "";
			try
			{
				while (!str1.Equals("exit"))
				{
					Console.WriteLine("Enter message ::");
					str1 = Console.ReadLine();
					Byte[] message = Encoding.Default.GetBytes(str1);
					socket.Send(message);

					int recievedData = socket.Receive(bytes, 0, bytes.Length, 0);
					Array.Resize(ref bytes, recievedData);

					str2 = Encoding.Default.GetString(bytes);
					Console.WriteLine("Server's message :: " + str2);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Error :: " + e.Message);
			}
			finally {
				socket.Close();
			}
		}

		static void Main() {
			GetConnect();
			GetData();
			SendData();

			Console.ReadKey();
		}
	}
}
