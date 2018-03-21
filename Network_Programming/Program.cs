using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerOne2One
{
	class Program
	{
		static byte[] Buffer { get; set; }
		static Socket socket;

		static void Main(string[] args)
		{
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Bind(new IPEndPoint(IPAddress.Any, 8888));
			Console.WriteLine("Server started...");
			Console.WriteLine("Waiting for a connection.....");
			socket.Listen(100);

			Socket accepted = socket.Accept();
			Console.WriteLine("Connection eshtablished from  :: " + accepted.RemoteEndPoint);
			Byte[] con = Encoding.Default.GetBytes("Connected Successfull");
			accepted.Send(con, 0, con.Length, 0);

			Buffer = new byte[accepted.SendBufferSize]; // default buffer size is 8192
			int bytesRead = accepted.Receive(Buffer);

			byte[] formatted = new byte[bytesRead];
			for (int i = 0; i < bytesRead; i++) {
				formatted[i] = Buffer[i];
			}

			string strData = Encoding.ASCII.GetString(formatted);
			Console.Write(strData + Environment.NewLine);
			Console.Read();
			socket.Close();
			accepted.Close();

		}
	}
}
