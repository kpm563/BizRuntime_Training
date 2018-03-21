using System;
using System.Net;
using System.Net.Sockets;

namespace ServerOne2One
{
	class ClientForm
	{
		public string ID
		{
			get;
			private set;
		}
		public IPEndPoint EndPoint
		{
			get;
			private set;
		}

		Socket socket;

		public ClientForm(Socket accepted)
		{
			socket = accepted;
			ID = Guid.NewGuid().ToString();
			EndPoint = (IPEndPoint)socket.RemoteEndPoint;
			socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
		}

		void Callback(IAsyncResult result)
		{
			try
			{
				socket.EndReceive(result);
				byte[] buffer = new byte[8192];
				int rec = socket.Receive(buffer, buffer.Length, 0);

				if (rec < buffer.Length)
				{
					Array.Resize<byte>(ref buffer, rec);
				}

				if (Recieved != null)
				{
					Recieved(this, buffer);
				}
				socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				close();

				if (Disconnected != null)
				{
					Disconnected(this);
				}
			}
		}

		public void close()
		{
			socket.Close();
			socket.Dispose();
		}
		public delegate void ClientRecievedHandler(ClientForm sender, byte[] data);
		public delegate void ClientDisconnectedHandler(ClientForm sender);

		public event ClientRecievedHandler Recieved;
		public event ClientDisconnectedHandler Disconnected;
	}
}
