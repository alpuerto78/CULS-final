
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.SqlClient;
using PagedList;
using System.Xml.Serialization;
using System.Windows.Forms;
namespace CULS_SERVER
{
    public partial class form_add_time : Form
    {
        //Databae variables handlers
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DB_conn dbcon = new DB_conn();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        //RFID variable handlers
        NFCReader NFC = new NFCReader();
        int retCode;
        int hCard;
        int hContext;
        int Protocol;
        public bool connActive = false;
        string readername = "";      // change depending on reader
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        public Card.SCARD_READERSTATE RdrState;
        public Card.SCARD_IO_REQUEST pioSendRequest;

         bool _flag_reader_remove = true;
   //     string image_id;

        //Networks variable handlers

        //Variable use for Connection Terminal
        //listener for SERVER andito si IP at port
      //  TcpListener listener = null;
       // TcpClient client;
        Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();
        CancellationTokenSource cancellation = new CancellationTokenSource();
        List<string> chat = new List<string>();


        public form_add_time()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());
            SelectDevice();
            establishContext();
            Reader_Status();
        }
        //Shadow in form
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void timer_reader_card_Tick(object sender, EventArgs e)
        {
            if (lbl_reader_status.Text == "Connected")
            {
                try
                {
                    NFC.Connect();
                    if (connectCard())
                    {
                        string cardUID = getcardUID();
                        txt_RFID_UID.Text = cardUID; //displaying on text block
                        _flag_reader_remove = true;
                    }
                }
                catch
                {
                    if (_flag_reader_remove)
                    {
                        _flag_reader_remove = false;
                        MessageBox.Show("Reader has been removed!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_RFID_UID.Clear();
                    }
                }
            }
            else
            {
                txt_RFID_UID.Clear();
            }
        }

        private void button_add_time_Click(object sender, EventArgs e)
        {
         
               // String clientName = "PC-02";
                String command = "COMMAND|ADDTIME|120|";
                chat.Clear();
                chat.Add("gChat");
                chat.Add(command);

                byte[] byData = ObjectToByteArray(chat);
       //     TcpClient client = new TcpClient(("127.0.0.1"),int.Parse(txt_TCP_add_time.Text));

          //  NetworkStream stm = client.GetStream();
           //     stm.Write(byData, 0, byData.Length);
           //     stm.Flush();

            
        }
        public byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
       
        private void Reader_Status()
        {
            NFCReader nfc = new NFCReader();
            try
            {
                nfc.Connect();
                lbl_reader_status.Text = "Connected";
            }
            catch
            {
                lbl_reader_status.Text = "Not Connected";
                try
                {
                    establishContext();
                    SelectDevice();
                }
                catch
                {
                    //return;
                }
            }
        }
        private void timer_reader_status_Tick(object sender, EventArgs e)
        {
            Reader_Status();
        }

        private void txt_RFID_UID_TextChanged(object sender, EventArgs e)
        {
            get_user_details();
        }

        //---------------------------------------------------------------------------------------------//
        //RFID Codes
        public void SelectDevice()
        {
            try
            {
                List<string> availableReaders = this.ListReaders();
                this.RdrState = new Card.SCARD_READERSTATE();
                readername = availableReaders[0].ToString();//selecting first device
                                                            //MessageBox.Show(readername);
                this.RdrState.RdrName = readername;
            }
            catch
            {
                //return;
                //basta wala itong gagawin
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        public List<string> ListReaders()
        {
            int ReaderCount = 0;
            List<string> AvailableReaderList = new List<string>();

            //Make sure a context has been established before 
            //retrieving the list of smartcard readers.
            retCode = Card.SCardListReaders(hContext, null, null, ref ReaderCount);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                //   MessageBox.Show(Card.GetScardErrMsg(retCode));
                connActive = false;
            }
            byte[] ReadersList = new byte[ReaderCount];

            //Get the list of reader present again but this time add sReaderGroup, retData as 2nd & 3rd parameter respectively.
            retCode = Card.SCardListReaders(hContext, null, ReadersList, ref ReaderCount);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                // MessageBox.Show(Card.GetScardErrMsg(retCode));
            }
            string rName = "";
            int indx = 0;
            if (ReaderCount > 0)
            {
                // Convert reader buffer to string
                while (ReadersList[indx] != 0)
                {

                    while (ReadersList[indx] != 0)
                    {
                        rName = rName + (char)ReadersList[indx];
                        indx = indx + 1;
                    }

                    //Add reader name to list
                    AvailableReaderList.Add(rName);
                    rName = "";
                    indx = indx + 1;
                }
            }
            return AvailableReaderList;
        }
        internal void establishContext()
        {
            retCode = Card.SCardEstablishContext(Card.SCARD_SCOPE_SYSTEM, 0, 0, ref hContext);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                //  MessageBox.Show("Check your device and please restart again", "Reader not connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("basta may error");

                connActive = false;
                return;
            }
        }
        public bool connectCard()
        {
            connActive = true;
            retCode = Card.SCardConnect(hContext, readername, Card.SCARD_SHARE_SHARED,
                      Card.SCARD_PROTOCOL_T0 | Card.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                //    MessageBox.Show(Card.GetScardErrMsg(retCode), "Card not available", MessageBoxButton.OK, MessageBoxImage.Error);
                connActive = false;
                return false;
            }
            return true;
        }
        private string getcardUID()//only for mifare 1k cards
        {
            string cardUID = "";
            byte[] receivedUID = new byte[256];
            Card.SCARD_IO_REQUEST request = new Card.SCARD_IO_REQUEST();
            request.dwProtocol = Card.SCARD_PROTOCOL_T1;
            request.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Card.SCARD_IO_REQUEST));
            byte[] sendBytes = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x04 }; //get UID command      for Mifare cards
            int outBytes = receivedUID.Length;
            int status = Card.SCardTransmit(hCard, ref request, ref sendBytes[0], sendBytes.Length, ref request, ref receivedUID[0], ref outBytes);

            if (status != Card.SCARD_S_SUCCESS)
            {
                cardUID = "Error";
            }
            else
            {
                cardUID = BitConverter.ToString(receivedUID.Take(4).ToArray()).Replace("-", string.Empty).ToUpper();
            }
            return cardUID;
        }
        public void devices()
        {
            List<string> availableReaders = this.ListReaders();
            this.RdrState = new Card.SCARD_READERSTATE();
            readername = availableReaders[0].ToString();//selecting first device

            this.RdrState.RdrName = readername;
            //   MessageBox.Show("Show Device :");
        }

        public void get_user_details()
        {
            //UPDATE TIME_REMAINING
            try
            {

                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                 cm.CommandText = "SP_ADD_TIME_USERS_DETAILS_SELECT";
                cm.Parameters.AddWithValue("@UID", txt_RFID_UID.Text);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    txt_usertype.Text = (dr["usertype_name"].ToString());
                   txt_stud_id_no.Text = (dr["stud_id_no"].ToString());
                   txt_firstname.Text = (dr["firstname"].ToString());
                    txt_lastname.Text = (dr["lastname"].ToString());
                   txt_dept.Text = (dr["dept_name"].ToString());
                  txt_course.Text = (dr["course_name"].ToString());

                    //basta pangcall to ng picture galing sa folder
                    string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    picbox_student.Image = Image.FromFile(paths + dr["imagepath"].ToString());


                    //      _time_remaining_check = (dr["time_remaining"].ToString());
//                    image_id = (dr["imagepath"].ToString());
                }
                cm.Parameters.Clear();
                cn.Close();


            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




    }
}