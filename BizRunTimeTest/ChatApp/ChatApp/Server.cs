using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatApp
{
    class ServerForMultipleClients
    {
        static Dictionary<string, ClientHandler> dictionarySockect = new Dictionary<string, ClientHandler>();
        static int i = 1;
        static Socket socket;
        static Socket accepted;

        //Creating the socket and after binding, making ready for any request.
        static void Connection()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888));
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

                    ClientHandler match = new ClientHandler(accepted, received, ReceivedNew, dictionarySockect);
                    dictionarySockect.Add(received, match);

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
        string option;        
        Dictionary<string, ClientHandler> dictionarySockets;


        public ClientHandler(Socket socket, string name, string option, Dictionary<string, ClientHandler> choice)
        {

            this.name = name;
            this.socket = socket;
            this.isLoggedIn = true;
            dictionarySockets = choice;            
            this.option = option;
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
                    string[] stringData = received.Split('#');
                    string recipient = stringData[0];
                    string messageToSend = stringData[1];
                    if (messageToSend.Equals("exit"))
                    {
                        dictionarySockets.Remove(recipient);
                        this.isLoggedIn = false;
                        this.socket.Close();
                        break;
                    }
                    if ((option.ToLower()).Equals("all"))
                    {
                        foreach (KeyValuePair<string, ClientHandler> values in dictionarySockets)
                        {
                            ClientHandler clientHandler = (ClientHandler)values.Value;
                            if (clientHandler.isLoggedIn == true)
                            {
                                byte[] sendData = Encoding.Default.GetBytes(this.name + " : " + messageToSend);
                                clientHandler.socket.Send(sendData, 0, sendData.Length, 0);
                            }

                        }
                    }
                    else if ((option.ToLower()).Equals("exceptme"))
                    {
                        foreach (KeyValuePair<string, ClientHandler> values in dictionarySockets)
                        {
                            ClientHandler clientHandler = (ClientHandler)values.Value;
                            if (!(clientHandler.name.Equals(recipient)) && clientHandler.isLoggedIn == true)
                            {
                                byte[] sendData = Encoding.Default.GetBytes(this.name + " : " + messageToSend);
                                clientHandler.socket.Send(sendData, 0, sendData.Length, 0);
                            }
                        }
                    }
                    else if ((option.ToLower()).Equals("none")) { }
                    else if ((option.ToLower()).Equals("self"))
                    {
                        foreach (KeyValuePair<string, ClientHandler> values in dictionarySockets)
                        {
                            ClientHandler clientHandler = (ClientHandler)values.Value;
                            if ((clientHandler.name.Equals(recipient)) && clientHandler.isLoggedIn == true)
                            {
                                byte[] sendData = Encoding.Default.GetBytes(this.name + " : " + messageToSend);
                                clientHandler.socket.Send(sendData, 0, sendData.Length, 0);
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
                    string message = Console.ReadLine();
                    foreach (KeyValuePair<string, ClientHandler> val in dictionarySockets)
                    {
                        ClientHandler mc = (ClientHandler)val.Value;
                        byte[] sData = Encoding.Default.GetBytes("Server : " + message);
                        mc.socket.Send(sData, 0, sData.Length, 0);
                    }
                }
            }
        }
    }
}

