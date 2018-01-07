using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;

namespace QuizApp
{
    class WorkHorse
    {
        private static readonly Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int Port = 100;
        private string GlobalTemp = "";
        public string IP = "";

        public void ConnectTS()
        {
            int ConAttempts = 0; //Initialise counter

            while (!ClientSocket.Connected) //While we're not connected
            {
                try
                {
                    ConAttempts++; //Increment attempts                   
                    ClientSocket.Connect(IP, Port); //Try to connect
                }
                catch (SocketException)
                {
                    if (ConAttempts == 2)
                    {
                        System.Windows.Forms.MessageBox.Show("Server is down! Exiting..."); //WinForms
                        System.Environment.Exit(1);
                    }

                }
            }
        }


        public void Register(string Username, string Password)
        {
            ConnectTS();
            string text = "newuser" + "," + Username + "," + Password;
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
        }

        public bool Login(string Username, string Password)
        {
            ConnectTS();
            string text = "login" + "," + Username + "," + Password;
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
            ReceiveResponse();
            if (GlobalTemp == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Add(string S, string Q, string A, string B, string C, string D)
        {
            ConnectTS();
            string text = "addq" + "," + S + "," + Q + "," + A + "," + B + "," + C + "," + D;
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
        }

        public string GetQ(int Num)
        {
            ConnectTS();
            string QNum = Convert.ToString(Num);
            string text = "getq" + "," + QNum;
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
            System.Threading.Thread.Sleep(1000);
            ReceiveResponse();
            return GlobalTemp;
        }

        public void SendResults(string Username, int Score, string RandomID, string Date, int PlayerID)
        {
            ConnectTS();
            string text = "scores" + "," + Username + "," + Score + "," + RandomID + "," + Date + "," + PlayerID;
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
        }
        public string GetResults(string RandomID, int PlayerID)
        {
            ConnectTS();
            string text = "fscores" + "," + RandomID + "," + PlayerID;
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
            System.Threading.Thread.Sleep(1000);
            ReceiveResponse();
            return GlobalTemp;
        }

        private void ReceiveResponse()
        {
            var buffer = new byte[2048]; //Create buffer
            int received = ClientSocket.Receive(buffer, SocketFlags.None); //Get messages
            if (received == 0) return;
            var data = new byte[received]; //Convert data
            Array.Copy(buffer, data, received); //Store data
            GlobalTemp = Encoding.ASCII.GetString(data); //Convert to string
        }

        public bool CheckUser(string Username) //Checks If The User Exists
        {
            ConnectTS();
            string text = "existing" + "," + Username;
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
            System.Threading.Thread.Sleep(1000);
            ReceiveResponse();
            if (GlobalTemp == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LoggedIn(string Username) //Checks If The User Exists
        {
            ConnectTS();
            string text = "duplicate" + "," + Username;
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
            System.Threading.Thread.Sleep(1000);
            ReceiveResponse();
            if (GlobalTemp == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetIP()
        {
            return IP;
        }
        /*public int GetRows()
        {
            string UserQuery = "SELECT COUNT(*) FROM Questions";
            SqlConnection UserConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["CSData"].ConnectionString);
            SqlCommand UserCmd = new SqlCommand(UserQuery, UserConnect);
            UserConnect.Open();
            int count = (int)UserCmd.ExecuteScalar();
            UserConnect.Close();
            return count;
        }*/


    }
}
