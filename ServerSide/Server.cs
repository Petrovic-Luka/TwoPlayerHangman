using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSide
{
    public class Server
    {
        public Socket socket;
        public string GameAnswer;
        public static List<ClientHandler> clients = new List<ClientHandler>();

        public Server()
        {
            socket=new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            socket.Bind(endPoint);
            socket.Listen(5);
        }

        public void Start()
        {
            for (int i = 0; i < 2; i++)
            {
                Socket clientSocket = socket.Accept();
                ClientHandler client=new ClientHandler(clientSocket,GameAnswer);
                clients.Add(client);
                Thread thread = new Thread(client.HandleRequests);
                thread.Start();
            }
            while(clients.Any(x=>x.game.IsOver==false))
            {
                Thread.Sleep(500);
            }

            Result result= new Result();
            if (clients[0].game.Guessed == true && clients[1].game.Guessed == true)
            {
                if (clients[0].game.NumberOfAttempts < clients[1].game.NumberOfAttempts)
                {
                    result.Message = "1st won";
                }
                else if (clients[0].game.NumberOfAttempts > clients[1].game.NumberOfAttempts)
                {
                    result.Message = "2nd won";
                }
                else
                {
                    result.Message = "Tie";
                }
            }
            else if(clients[0].game.Guessed == true && clients[1].game.Guessed == false)
            {
                result.Message = "1st won";
            }
            else if (clients[0].game.Guessed == false && clients[1].game.Guessed == true)
            {
                result.Message = "2nd won";
            }
            else
            {
                result.Message = "Server won";
            }

            foreach(var i in clients)
            {
                i.SendResult(result);
                i.EndConnection();
            }

        }

    }
}
