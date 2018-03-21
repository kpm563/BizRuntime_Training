//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Windows.Forms;
//namespace ServerOne2One
//{
//	public class ServerForm
//	{
//		//static List<Socket> sockets;
//		//static Listener listener;
//		static void Main() {
//			//listener = new Listener(8888);
//			//listener.SocketAccepted += new Listener.SocketHandler(listener_socketAccepted);
//			//listener.Start();
//			//sockets = new List<Socket>();

//			Application.EnableVisualStyles();
//			Application.SetCompatibleTextRenderingDefault(false);
//			Application.Run(new ClinetForm1());

//			Console.Read();
//		}

//		//private static void listener_socketAccepted(Socket accepted)
//		//{
//		//	Console.WriteLine("New Connection :: {0}\n{1}\n===============================", accepted.RemoteEndPoint, DateTime.Now);
//		//	//sockets.Add(accepted);
//		//}
//	}

//	public class Listener {
//		Socket socket;
//		public bool Listening{
//			get;
//			private set;
//		}

//		public int Port
//		{
//			get;
//			private set;
//		}
//		public Listener(int port) {
//			Port = port;
//			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//		}

//		public void Start() {
//			if (Listening)
//			{
//				return;
//			}
//			socket.Bind(new IPEndPoint(IPAddress.Any, 8888));
//			socket.Listen(0);

//			socket.BeginAccept(Callback, null);
//			Listening = true;
//		}

//		public void Stop() {
//			if (!Listening) {
//				socket.Close();
//				socket.Dispose();
//				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//			}
//		}

//		void Callback(IAsyncResult result)
//		{
//			try {
//				Socket socket = this.socket.EndAccept(result);
//				if (SocketAccepted != null) {
//					SocketAccepted(socket);
//				}
//				this.socket.BeginAccept(Callback, null);
//			}
//			catch (Exception e) {
//				Console.WriteLine(e.Message);
//			}
//		}

//		public delegate void SocketHandler(Socket accepted);
//		public event SocketHandler SocketAccepted;

//	}
//}
