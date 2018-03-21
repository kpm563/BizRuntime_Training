//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Net;
//using System.Net.Sockets;

//namespace ServerOne2One
//{
//	public partial class ClinetForm1 : Form
//	{
//		Listener listener;

//		public ClinetForm1()
//		{
//			InitializeComponent();
//			listener = new Listener(8888);
//			listener.SocketAccepted += new Listener.SocketHandler(listener_socketAccepted);
//		}

//		private void listener_socketAccepted(Socket accepted)
//		{
//			ClientForm client = new ClientForm(/*e*/);
//			client.Recieved += new ClientForm.ClientRecievedHandler(Client_Received);
//			client.Disconnected += new ClientForm.ClientDisconnectedHandler(client_Disconnected);
//			Invoke((MethodInvoker)delegate
//			{
//				ListViewItem item = new ListViewItem();
//				item.Text = client.EndPoint.ToString();
//				item.SubItems.Add(client.ID);
//				item.SubItems.Add("message");
//				item.SubItems.Add("time");
//				lstClient.Items.Add(item);
//			});
//		}

//		private void client_Disconnected(ClientForm sender)
//		{
//			Invoke((MethodInvoker)delegate
//			{
//				for (int i = 0; i < lstClient.Items.Count; i++) {
//					ClientForm client = lstClient.Items[i].Tag as ClientForm;
//					if (client.ID == sender.ID) {
//						lstClient.Items.RemoveAt(i);
//						break;
//					}
//				}
//			});
//		}

//		private void Client_Received(ClientForm sender, byte[] data)
//		{
//			Invoke((MethodInvoker)delegate
//			{
//				for (int i = 0; i < lstClient.Items.Count; i++) {
//					ClientForm client = lstClient.Items[i].Tag as ClientForm;
//					if (client.ID == sender.ID) {
//						lstClient.Items[i].SubItems[2].Text = Encoding.Default.GetString(data);
//						lstClient.Items[i].SubItems[3].Text = DateTime.Now.ToString();
//						break;
//					}
//				}
//			});
//		}
//	}
//}
