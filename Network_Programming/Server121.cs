using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerOne2One
{
	class Server121
	{
		static Byte[] Buffer;
		static Socket socket;

		static void Server() {
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Bind(new IPEndPoint(IPAddress.Any, 8888)); // Binding the socket, ipaddress + port.
			socket.Listen(100); // Maximum no of connections socket can listen at the same time.
			Console.WriteLine("Server started !");
			Console.WriteLine("Waiting for connection...");

			Socket accepted = socket.Accept(); // Created a new socket for newly created connection.
			Console.WriteLine("Connection accepted from  " + accepted.RemoteEndPoint);

			Byte[] msg = Encoding.Default.GetBytes("Connection successful"); // Converting the message to byte array.
			accepted.Send(msg, 0, msg.Length, 0); // Send it to the client machine

			string str1 = "", str2 = "";
			while (!str1.Equals("stop"))
			{
				Buffer = new Byte[accepted.SendBufferSize]; //initialized the buffer with the data coming from newly socket.
				int bytesRead = accepted.Receive(Buffer); //receiving data from socket and counting number of bytes. 

				byte[] formatted = new byte[bytesRead];
				for (int i = 0; i < bytesRead; i++)
				{
					formatted[i] = Buffer[i];
				}
				str1 = Encoding.ASCII.GetString(formatted);
				Console.Write("Client message :: " + str1);
				Console.WriteLine();
				Console.Write("Enter message :: ");
				str2 = Console.ReadLine();
				Byte[] Buffer2 = Encoding.Default.GetBytes(str2);
				accepted.Send(Buffer2, 0, Buffer2.Length, 0);
				Console.WriteLine("Sent successfully");
			}
			Console.Read();
			socket.Close();
			accepted.Close();
		}
		static void Main(string[] args) {
			//creating a socket instance.
			Server();
		}
	}
}
