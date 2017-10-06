using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    
    public partial class Formclient : Form
    {
        Socket client;
        public Formclient()
        {
            InitializeComponent();
        }
        private void Form1_Load(object Sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"),12345);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data;
            data = Encoding.ASCII.GetBytes(textBox2.Text);
            client.Send(data);
            listBox1.Items.Add("Client:" + textBox2.Text);
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Server" + Encoding.ASCII.GetString(data));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"),12345);
            client.Connect(ipep);
            byte[] data;
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Server:" + Encoding.ASCII.GetString(data));
        }


    }
}
