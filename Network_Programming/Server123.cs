using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerOne2One
{
	class Server123
	{
		private static byte[] _buffer = new byte[1024];
		private static List<Socket> _clientSockets = new List<Socket>();
		private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		private void SetUpServer() {
			Console.WriteLine("Setting up server...");
			_serverSocket.Bind(new IPEndPoint(IPAddress.Any, 8888));
			_serverSocket.Listen(5); // This is limit of pending connections.
			_serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
		}

		private void AcceptCallback(IAsyncResult result) {
			Socket socket = _serverSocket.EndAccept(result);
			_clientSockets.Add(socket);
			socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback), socket);
			_serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
		}

		private static void RecieveCallback(IAsyncResult result) {
			Socket socket = (Socket)result.AsyncState;
			int recieved = socket.EndReceive(result);
			byte[] dataBuffer = new byte[recieved];
			Array.Copy(_buffer, dataBuffer, recieved);

			string text = Encoding.ASCII.GetString(dataBuffer);

			Console.WriteLine("Text recieved :: " + text);

			if (text.ToLower() == "get time") {
				byte[] data = Encoding.ASCII.GetBytes(DateTime.Now.ToLongTimeString());
				socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
			}
		}

		private static void SendCallback(IAsyncResult result) {
			Socket socket = (Socket)result.AsyncState;
			socket.EndSend(result);
		}

	}
}
