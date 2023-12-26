using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    public class ClientHandler
    {
        public Socket socket;
        public Game game;
        public string gameAnswer;
        NetworkStream stream;
        BinaryFormatter formatter;

        public ClientHandler(Socket socket, string gameAnswer)
        {
            this.socket = socket;
            formatter = new BinaryFormatter();
            stream = new NetworkStream(socket);
            game = new Game();
            game.Answer = gameAnswer;
        }

        public void HandleRequests()
        {
            while (!game.IsOver)
            {
                Request request= (Request)formatter.Deserialize(stream);
                var response = game.checkGuess(request);
                formatter.Serialize(stream, response);
            }
        }

        public void SendResult(Result result)
        {
            formatter.Serialize(stream, result);
        }

        public void EndConnection()
        {
            socket.Close();
        }
    }
}
