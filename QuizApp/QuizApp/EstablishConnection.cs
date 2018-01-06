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

//Complete rebulid done on 31/08/17

namespace QuizApp
{
    public partial class EstablishConnection : Form
    {
        private static readonly Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int Port = 100;
        public string Username = "";
        WorkHorse W = new WorkHorse();
        public string GlobalTemp = "";

        public EstablishConnection(string Passthrough)
        {
            InitializeComponent();
            Username = Passthrough;
            ConnectToServer(); //Call connection
            GetUsers();
            LblOn.Text = GlobalTemp + " user(s) online";
        }
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            
            SendRequest(); //Tell server we're online
            ReceiveResponse(); //Get server messages
            Worker.DoWork += new DoWorkEventHandler(Worker_DoWork); //Create event handler
            Worker.RunWorkerAsync(); //Start background event handler
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
        }

        public void ConnectToServer()
        {
            int ConAttempts = 0; //Initialise counter
            string test = W.GetIP();
            while (!ClientSocket.Connected) //While we're not connected
            {
                try
                {
                    ConAttempts++; //Increment attempts                   
                    ClientSocket.Connect("86.137.50.242", Port); //Try to connect
                }
                catch (SocketException)
                {
                    LblConnect.Text = "Error"; //Display error
                }
            }
        }

        private void SendRequest()
        {
            string request = "ready"; //Tell server we're waiting
            SendString(request); //Call function to convert string
        }
        public string GetUsers()
        {
            string text = "howmany";
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
            System.Threading.Thread.Sleep(1000);
            GetCountRes();
            return GlobalTemp;
            
        }

        private void GetCountRes()
        {
            var buffer = new byte[2048]; //Create buffer
            int received = ClientSocket.Receive(buffer, SocketFlags.None); //Get messages
            if (received == 0) return;
            var data = new byte[received]; //Convert data
            Array.Copy(buffer, data, received); //Store data
            GlobalTemp = Encoding.ASCII.GetString(data); //Convert to string
        }

        private static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text); //Convert string to bytearray
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None); //Send to server
        }
        private void ReceiveResponse()
        {
            var buffer = new byte[2048]; //Create buffer
            int received = ClientSocket.Receive(buffer, SocketFlags.None); //Get messages
            if (received == 0) return;
            var data = new byte[received]; //Convert data
            Array.Copy(buffer, data, received); //Store data
            string text = Encoding.ASCII.GetString(data); //Convert to string
            LblStatus.Invoke((Action)delegate
            {
                LblStatus.Text = text; //Have to do this to use two threads and access UI
            });
            if (LblStatus.Text.Any(char.IsDigit)) //If there's a number
            {
                string VerifyNum = new String(text.ToCharArray().Where(c => Char.IsDigit(c)).ToArray()); //Get number in string
                string GameID = VerifyNum;
                LblConnect.Invoke((Action)delegate //Have to do this to avoid crashing UI
                {
                    LblConnect.Text = VerifyNum; //Set label with GameID
                    QuestionInterface Q = new QuestionInterface(Username, GameID); //Call new form
                    Q.Show(); //Show it
                    Visible = false;
                });

            }
        }
        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            while (LblConnect.Text == "") //While there's no GameID
            {                
                ReceiveResponse(); //Wait for server
                if (LblConnect.Text != "")
                {
                    Worker.Dispose(); //Kill worker            
                }
            }
        }
    }
}
