using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Form1
{
    public partial class Sever : Form
    {
        public Sever()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
       
        private void Sever_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
                Send(item);

            AddMessage(tbSend.Text);
            tbSend.Clear();
        }


        IPEndPoint IP;
        Socket sever;
        List<Socket> clientList;

        void Connect()
        {
            clientList = new List<Socket>();
            int port = int.Parse(tbPort.Text);
            IP = new IPEndPoint(IPAddress.Any, port);
            sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            sever.Bind(IP);

            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        sever.Listen(100);
                        Socket client = sever.Accept();
                        clientList.Add(client);

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, port);
                    sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });

            Listen.IsBackground = true;
            Listen.Start();
        }

        void Send(Socket client)
        {
            if (client != null && tbSend.Text != string.Empty)
            {
                client.Send(Serialize(tbSend.Text));
            }
        }

        void Receive(object obj)
        {
            Socket client = (Socket)obj;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);

                    foreach(Socket item in clientList)
                    {
                        if(item != null && item != client)
                            item.Send(Serialize(message));
                    }

                    AddMessage(message);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }

        void AddMessage(string s)
        {
            lvScreen.Items.Add(new ListViewItem() { Text = s });
        }

        byte[] Serialize(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            MemoryStream stream = new MemoryStream();
            return Encoding.UTF8.GetBytes(json);
        }

        object Deserialize(byte[] data)
        {
            string json = Encoding.UTF8.GetString(data);
            return JsonConvert.DeserializeObject(json);
        }

        void Close()
        {
            sever.Close();
        }
    }
}
