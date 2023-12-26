using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class Form1 : Form
    {
        Socket socket;
        NetworkStream stream;
        BinaryFormatter formatter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0.0.1", 9999);
                formatter=new BinaryFormatter();
                stream = new NetworkStream(socket);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGuess.Text.Length != 1 || !Char.IsLetter(txtGuess.Text[0]))
                {
                    MessageBox.Show("Nepravilan unos");
                    return;
                }
                Request request = new Request();
                request.Guess = txtGuess.Text[0];
                formatter.Serialize(stream, request);
                var response = (Response)formatter.Deserialize(stream);
                lblZivoti.Text = $"Broj pokusaja {response.NumberOfAttempts}|10";
                if (response.IsCorrect == false)
                {
                    lblPokusaji.Text += request.Guess + ",";
                }
                else
                {
                    var temp = txt1.Text.ToCharArray();
                    foreach (var i in response.Positions)
                    {
                        temp[i] = request.Guess;
                    }
                    txt1.Text = new string(temp);
                }

                if (response.NumberOfCorrectGuesses == 5)
                {
                    MessageBox.Show("Pogodili ste rec, molimo sacekajte kraj igre");
                    Thread t = new Thread(WaitForResult); t.Start();
                }

                if (response.NumberOfAttempts == 10 && response.NumberOfCorrectGuesses < 5)
                {
                    MessageBox.Show("Iskoristili ste svih 10 pokusaja, molimo sacekajte kraj igre");
                    Thread t = new Thread(WaitForResult); t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void WaitForResult()
        {
            var result = (Result)formatter.Deserialize(stream);
            this.Invoke(new Action(() => 
            {
                MessageBox.Show(result.Message);
            }));
            socket.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket.Close();
        }
    }
}
