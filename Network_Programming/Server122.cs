using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerOne2One
{
	class Server122
	{
		static string hostName = "", myIp = "", client;
		static Socket socket, accepted;
		static Thread thread;

		//This will show the IP Address of server machine
		static string ShowIp() {			
			try
			{
				hostName = Dns.GetHostName();
				Console.WriteLine(hostName);
				myIp = Dns.GetHostByName(hostName).AddressList[0].ToString();
				Console.WriteLine(myIp);				
			}
			catch (Exception e) {
				Console.WriteLine("Error :: " + e.Message);
			}
			return myIp;
		}

		static void GetConnection() {
			try
			{
				IPAddress address = IPAddress.Parse(ShowIp());
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Bind(new IPEndPoint(IPAddress.Any, 8888));
				socket.Listen(100);
				Console.WriteLine("Server started.!\nWaiting for client connection...");
				accepted = socket.Accept();
				//Console.WriteLine("Connection accepted from  " + accepted.RemoteEndPoint);
				//Byte[] message = Encoding.Default.GetBytes("Connection successful.!");
				//accepted.Send(message, 0, message.Length, 0);
			}
			catch (Exception e) {
				Console.WriteLine("Error :: " + e.Message);
			}
		}		

		static void RecieveData() {
			try
			{
				while (true)
				{
					Thread.Sleep(500);
					byte[] Buffer = new byte[1000];
					int bytesRead = accepted.Receive(Buffer, 0, Buffer.Length, 0);
					Array.Resize(ref Buffer, bytesRead);
					Console.WriteLine(Encoding.Default.GetString(Buffer));
				}
			}
			catch (Exception e) {
				Console.WriteLine("Error :: " + e.Message);
			}
		}

		static void SendData() {
			try
			{
				thread = new Thread(RecieveData);
				thread.Start();
				string message = "connected";
				while (true)
				{
					if (message.Equals("exit"))
					{
						socket.Close();
						break;
					}
					Console.WriteLine("Please Enter Your Name ");
					client = Console.ReadLine();
					byte[] sendData = Encoding.Default.GetBytes(">>" + client + ":: >>" + message);
					accepted.Send(sendData, 0, sendData.Length, 0);
					message = Console.ReadLine();
				}
			}
			catch (Exception e) {
				Console.WriteLine("Error :: " + e.Message);
			}
		}

		static void Main() {
			ShowIp();
			GetConnection();
			RecieveData();
			SendData();

			Console.ReadKey();
		}		
	}
}