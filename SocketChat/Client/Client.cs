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
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            Send();
            AddMessage(tbSend.Text);
        }

        IPEndPoint IP;
        Socket client;

        void Connect()
        {
            int port = int.Parse(tbPort.Text);
            IP = new IPEndPoint(IPAddress.Parse(tbSIP.Text), port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
                MessageBox.Show("Đã kết nối sever!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối sever!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        void Close()
        {
            client.Close();
        }

        void Send()
        {
            if (tbSend.Text != string.Empty)
                client.Send(Serialize(tbSend.Text));
        }

        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);

                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }
        }

        void AddMessage(string s)
        {
            lvScreen.Items.Add(new ListViewItem() { Text = s });
            tbSend.Clear();
        }

        /// <summary>
        /// Phân mảnh
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Đóng kết nối khi đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
