using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Data.SqlClient;



namespace CULS_Client
{
    class NetworkClient
    {
        public static TcpClient clientSocket;
        public static NetworkStream serverStream = default(NetworkStream);
        static string readData = null;
        static Thread ctThread;
        static String _terminalname = System.Environment.MachineName;

        static List<string> nowChatting = new List<string>();
        static List<string> chat = new List<string>();

        static string _ipAd = "127.0.0.1";
        static SqlConnection cn = new SqlConnection();
        static SqlCommand cm = new SqlCommand();
        static SqlDataReader dr;

        static string _title = "COMPUTER USAGE LIMITER SYSTEM";
        static bool _flag_socket = false;
        static int attempt_recon = 0;
        public static void ConnectClient()
        {
            //get the ipaddress in the database
            DB_conn dbcon = new DB_conn();
            cn = new SqlConnection(dbcon.GetConnection());
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from tbl_network_configuration", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    _ipAd = dr["server_ipAD"].ToString();
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            clientSocket = new TcpClient();
           
                if (_flag_socket == false)
                {
                    try
                    {
                        clientSocket.Connect(_ipAd, 5000);
                        readData = "Connected to Server ";

                        serverStream = clientSocket.GetStream();
                        byte[] outStream = Encoding.ASCII.GetBytes(_terminalname + "$");
                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();

                        ctThread = new Thread(getMessage);
                        ctThread.Start();
                        _flag_socket = true;
                    }
                    catch (Exception er)
                    {
                       // attempt_recon++;
             
                       //ReconnectClient();

                    }
                }
           
        }
        public static void ReconnectClient()
        {
            //get the ipaddress in the database
            DB_conn dbcon = new DB_conn();
            cn = new SqlConnection(dbcon.GetConnection());
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from tbl_network_configuration", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    _ipAd = dr["server_ipAD"].ToString();
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            clientSocket = new TcpClient();
      
            while (attempt_recon>=1 && _flag_socket==false)
            {
                MessageBox.Show(attempt_recon.ToString());
                if (_flag_socket == false)
                {
                    try
                    {
                        clientSocket.Connect(_ipAd, 5000);
                        readData = "Connected to Server ";

                        serverStream = clientSocket.GetStream();
                        byte[] outStream = Encoding.ASCII.GetBytes(_terminalname + "$");
                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();

                        ctThread = new Thread(getMessage);
                        ctThread.Start();
                        _flag_socket = true;
                        attempt_recon = 0;
                    }
                    catch (Exception er)
                    {
                        attempt_recon++;
                    }
                }
            }
        }
        private static void getMessage()
        {
            try
            {
                while (true)
                {
                    serverStream = clientSocket.GetStream();
                    byte[] inStream = new byte[10025];
                    serverStream.Read(inStream, 0, inStream.Length);
                    List<string> parts = null;

                    if (!SocketConnected(clientSocket))
                    {
                        MessageBox.Show("You've been Disconnected");
                        ctThread.Abort();
                        clientSocket.Close();
                        serverStream.Close();
                        //btnConnect.Enabled = true;
                    }

                    parts = (List<string>)ByteArrayToObject(inStream);
                    switch (parts[0])
                    {
                        case "gChat":
                            readData = "" + parts[1];
                            NetworkCommand.CommandText(parts[1]);

                            break;
                    }

                    if (readData[0].Equals('\0'))
                    {
                        readData = "Reconnect Again";
                        DialogResult dialog = MessageBox.Show(readData);

                        //this.Invoke((MethodInvoker)delegate // To Write the Received data
                        //{
                        //    btnConnect.Enabled = true;
                        //});

                        ctThread.Abort();
                        clientSocket.Close();
                        serverStream.Close();
                        break;
                    }
                    chat.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "networkclient");

                ctThread.Abort();
                clientSocket.Close();
                //btnConnect.Enabled = true;
               // Console.WriteLine(e);
            }

        }
        static bool SocketConnected(TcpClient s) //check whether client is connected server
        {
            bool flag = false;
            try
            {
                bool part1 = s.Client.Poll(10, SelectMode.SelectRead);
                bool part2 = (s.Available == 0);
                if (part1 && part2)
                {
                    //indicator.BackColor = Color.Red;
                    //this.Invoke((MethodInvoker)delegate // cross threads
                    //{
                    //    btnConnect.Enabled = true;
                    //});
                    flag = false;
                }
                else
                {
                    //indicator.BackColor = Color.Green;
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "networkclient");

            }
            return flag;
        }
        public static byte[] ObjectToByteArray(object _Object)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, _Object);
                return stream.ToArray();
            }
        }

        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        public static void SendCommandToServer(string message)
        {
            try
            {
                if (!message.Equals(""))
                {
                    chat.Add("gChat");
                    chat.Add(message);

                    byte[] outStream = ObjectToByteArray(chat);

                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    message = "";
                    chat.Clear();
                }
            }
            catch (Exception ex)
            {
                  MessageBox.Show(ex.Message, "networkclient");
            }

        }
        static int attempt = 0;
        public static void KeepAlive(string message)
        {
            if (_flag_socket == true)
            {
                try
                {
                    if (!message.Equals(""))
                    {
                        chat.Add("gChat");
                        chat.Add(message);

                        byte[] outStream = ObjectToByteArray(chat);

                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();
                        message = "";
                        chat.Clear();
                    }
                }
                catch (Exception ex)
                {

                    attempt++;
                    if (attempt == 5)
                    {
                        attempt = 0;
                        ctThread.Abort();
                        clientSocket.Close();
                        serverStream.Dispose();
                        _flag_socket = false;
                        ConnectClient();
                    }
                }
            }
        }

        public static void close_client()
        {
            ctThread.Abort();
            clientSocket.Close();
            serverStream.Dispose();

        }

    }

}
