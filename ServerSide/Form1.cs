using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSide
{

    public partial class Form1 : Form
    {
        public List<string> words;
        private Server server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled=false;
            words = new List<string>()
            {
                "petao","metar","kokos","mravi","rakun"
            };
            server= new Server();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r=new Random();
            textBox1.Text = words[r.Next(0,words.Count)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==null || textBox1.Text.Length==0)
            {
                MessageBox.Show("Odaberite rec");
                return;
            }
            server.GameAnswer = textBox1.Text;
            Thread thread = new Thread(server.Start);
            thread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(var i in Server.clients)
            {
                i.EndConnection();
            }
            server.socket.Close();
        }
    }
}
