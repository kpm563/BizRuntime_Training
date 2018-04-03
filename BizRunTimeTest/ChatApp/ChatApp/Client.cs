using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatApp
    {
        public class MulClient
        {
            static int ServerPort = 8888;
            static Socket socket;
            static string name = "";
            static string msg = "";
            public static void Send()
            {
                while (true)
                {

                    msg = Console.ReadLine();
                    try
                    {

                        byte[] sData = Encoding.Default.GetBytes(name + "#" + msg);
                    socket.Send(sData, 0, sData.Length, 0);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            public static void Read()
            {

                while (true)
                {
                    if (msg.Equals("exit"))
                        return;
                    try
                    {
                        // read the message sent to this client
                        byte[] Buffer = new byte[8192];
                        int rec = socket.Receive(Buffer, 0, Buffer.Length, 0);
                        Array.Resize(ref Buffer, rec);
                        string dis = Encoding.Default.GetString(Buffer);
                        Console.WriteLine(dis);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e);
                    }
                }
            }

            static void Connection()
            {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.Write("Enter Name : ");
                name = Console.ReadLine();
                Console.WriteLine("Connecting.....");

                IPEndPoint ed = new IPEndPoint(IPAddress.Parse("127.0.0.1"), ServerPort);

                try
                {
                socket.Connect(ed);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                byte[] send = Encoding.Default.GetBytes(name);
                socket.Send(send, 0, send.Length, 0);
                byte[] Buf = new byte[255];
                int rec = socket.Receive(Buf, 0, Buf.Length, 0);
                Array.Resize(ref Buf, rec);
                string dis = Encoding.Default.GetString(Buf);
                Console.WriteLine(dis + " Connected.....");
                Console.Write("Enter Message U want To Connect:");
                string conn = Console.ReadLine();
                send = Encoding.Default.GetBytes(conn);
                socket.Send(send, 0, send.Length, 0);
            }


            static void Main(string[] args)
            {
                try
                {
                    Connection();
                    Thread sendMessage = new Thread(new ThreadStart(Send));
                    Thread readMessage = new Thread(new ThreadStart(Read));

                    sendMessage.Start();
                    readMessage.Start();
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
    }

