using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace CULS_Client

{
    class NetworkCommand
    {
        static SqlConnection cn = new SqlConnection();
        static SqlCommand cm = new SqlCommand();
        static SqlDataReader dr;

        public static string _title = "COMPUTER USAGE LIMITER SYSTEM";
        public static void CommandText(string command)
        {
            string[] receiveTextSplit = command.Split('|');

            if (receiveTextSplit[0] == "COMMAND")
            {
                if (receiveTextSplit[1]=="ADDTIME")
                {
                    if (receiveTextSplit[2] == "LIMITED"|| receiveTextSplit[2] == "UNLIMITED")
                    {
                        //input receiveTextSplit[3] ==time remaining
                        //input receiveTextSplit[4] ==User RFID
                        //input receiveTextSplit[5] ==username
                        DB_conn dbcon = new DB_conn();
                        cn = new SqlConnection(dbcon.GetConnection());
                        Timer_Client.UpdateTerminalStatus(receiveTextSplit[2], receiveTextSplit[3], receiveTextSplit[4]);
                    }
                    
                }
                else if (receiveTextSplit[1] == "RESTART")
                {
                    //cmd to restart pc 
                    CmdClass cmd = new CmdClass();
                    cmd.ExecuteCommand("shutdown -r");
                  //  MessageBox.Show("goods");
                }
                else if (receiveTextSplit[1] == "SHUTDOWN")
                {
                    //cmd to restart pc 
                    CmdClass cmd = new CmdClass();
                    cmd.ExecuteCommand("shutdown -s");
                }
                else if (receiveTextSplit[1] == "LOGOUT")
                {
                    MessageBox.Show("LOGOUT PC", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

    }
}
