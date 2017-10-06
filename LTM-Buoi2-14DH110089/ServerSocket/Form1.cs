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
namespace ServerSocket
{
    public partial class FormServer : Form
    {
        Socket server;
        Socket client;
        public FormServer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object Sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 12345);
            server.Bind(ipep);
            server.Listen(10);
            client = server.Accept();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(textBox2.Text);
            client.Send(data);
            listBox1.Items.Add("Server: " + textBox2.Text);
            data = new byte[1024];
            client.Receive(data);
            listBox1.Items.Add("Client:" + Encoding.ASCII.GetString(data));
        }

        private void FormServer_Load(object sender, EventArgs e)
        {

        }
    }
}
