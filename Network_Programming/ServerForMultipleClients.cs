using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerOne2One
{
	class ServerForMultipleClients
	{
		static Dictionary<string, ClientHandler> dSockets = new Dictionary<string, ClientHandler>();
		static int i = 1;
		static Socket socket;
		static Socket accepted;

		//Creating the socket and after binding, making ready for any request.
		static void Connection()
		{
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
			socket.Listen(0);
		}

		static void Operation()
		{
			while (true)
			{
				// accepted the incoming request
				accepted = socket.Accept();
				try
				{
					byte[] Buffer = new byte[8192];
					int receivedData = accepted.Receive(Buffer, 0, Buffer.Length, 0);
					Array.Resize(ref Buffer, receivedData);
					string received = Encoding.Default.GetString(Buffer);
					Console.WriteLine(received + " Joined.....");
					byte[] sendData = Encoding.Default.GetBytes(received);
					accepted.Send(sendData, 0, sendData.Length, 0);

					byte[] BufferNew = new byte[8192];
					int receivedDataNew = accepted.Receive(BufferNew, 0, BufferNew.Length, 0);
					Array.Resize(ref BufferNew, receivedDataNew);
					string ReceivedNew = Encoding.Default.GetString(BufferNew);

					ClientHandler match = new ClientHandler(accepted, received, ReceivedNew, dSockets);
					dSockets.Add(received, match);

					new Thread(match.Run).Start();
					new Thread(match.Send).Start();					
					i++;
				}
				catch
				{
					Console.WriteLine("Hello");
				}
			}
		}

		static void Main(string[] args)
		{
			Console.WriteLine("WelCome To Chat Server");
			Connection();
			Operation();

		}
	}

	class ClientHandler
	{
		private string name;
		Socket socket;
		bool isLoggedIn;
		string[] firstName;
		static ClientHandler handler;
		Dictionary<string, ClientHandler> dSockets;

		public ClientHandler(Socket socket, string name, string con, Dictionary<string, ClientHandler> choice)
		{
			this.name = name;
			this.socket = socket;
			this.isLoggedIn = true;
			dSockets = choice;
			this.firstName = con.Split('|');
		}

		public void Run()
		{
			string received;
			while (true)
			{
				try
				{
					byte[] Buffer = new byte[8192];
					int receivedData = socket.Receive(Buffer, 0, Buffer.Length, 0);
					Array.Resize(ref Buffer, receivedData);
					received = Encoding.Default.GetString(Buffer);

					Console.WriteLine(received);
					string[] st = received.Split('#');
					string recipient = st[0];
					string MsgToSend = st[1];

					if (MsgToSend.Equals("exit"))
					{
						dSockets.Remove(recipient);
						this.isLoggedIn = false;
						this.socket.Close();
						break;
					}


					foreach (KeyValuePair<string, ClientHandler> val in dSockets)
					{
						ClientHandler mc = (ClientHandler)val.Value;

						if (mc.name.Equals(recipient))
						{
							handler = mc;
						}
						for (int i = 0; i < handler.firstName.Length; i++)
						{

							if (!(mc.name.Equals(recipient)) && mc.isLoggedIn == true && mc.name.Equals(handler.firstName[i]))
							{
								byte[] sData = Encoding.Default.GetBytes(this.name + " : " + MsgToSend);
								mc.socket.Send(sData, 0, sData.Length, 0);
								break;
							}
						}
					}


				}
				catch (Exception e)
				{

					Console.WriteLine(e.Message);
				}
			}
		}

		public void Send()
		{
			if (socket != null)
			{
				while (true)
				{
					string msg = Console.ReadLine();
					foreach (KeyValuePair<string, ClientHandler> val in dSockets)
					{
						ClientHandler mc = (ClientHandler)val.Value;
						byte[] sData = Encoding.Default.GetBytes("Server : " + msg);
						mc.socket.Send(sData, 0, sData.Length, 0);
					}


				}
			}
		}
	}
}
