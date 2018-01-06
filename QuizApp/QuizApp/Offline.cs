using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Offline : Form
    {
        WorkHorse W = new WorkHorse();
        public int QNum = 1;
        public int Cor = 0;

        public string Username = "";
        bool GameDone = false;
        string Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        private static readonly Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int Port = 100;

        public Offline(string User)
        {
            InitializeComponent();
            Username = User;
            LblScore.Text = "Score: " + Cor;

            Incrementer();
            Timer.Enabled = true; // Enable the timer.
            Timer.Start();//Strart it
            Timer.Interval = 500; // The time per tick.
            progressBar1.Maximum = 10;
        }

        public async Task Incrementer()
        {
            while (QNum != 12)
            {
                GetQuestion();
                progressBar1.Value = 0;
                if (rBtn1.Checked == true)
                {
                    if (Cor != 10)
                    {
                        Cor++;
                        LblScore.Text = "Score: " + Cor;
                        rBtn1.Checked = false;
                    }
                }
                await Task.Delay(3000);
            }
        }

        public void GetQuestion()
        {
            if (QNum == 11)
            {
                GameDone = true;
                Timer.Stop();

                if (GameDone)
                {
                    W.SendResults(Username, Cor, "1111", Date, 1111);
                    GetResults G = new GetResults(2, Cor, "0", 0);
                    G.Show();
                    Visible = false;
                }
            }

            string Question = W.GetQ(QNum);
            string[] Qs = Question.Split(',');
            string Q = Qs[0];
            string A = Qs[1];
            string B = Qs[2];
            string C = Qs[3];
            string D = Qs[4];
            Random Ran = new Random();
            LblQn.Text = "Question " + QNum.ToString();
            QNum++;

            List<Point> ButtonList = new List<Point> { rBtn1.Location, rBtn2.Location, rBtn3.Location, rBtn4.Location }; //Defining Our Buttons
            var RadioButtons = new[] { rBtn1, rBtn2, rBtn3, rBtn4 }; //Defining Our Buttons
            var Location = ButtonList.OrderBy(x => Ran.Next(ButtonList.Count)).ToList(); //Shuffle Where The Buttons Are
            for (int i = 0; i < RadioButtons.Length; i++) //Change The Number Where The Buttons Are Displayed
            {
                RadioButtons[i].Location = Location[i];
            }

            LblQ.Text = Q;
            rBtn1.Text = A;
            rBtn2.Text = B;
            rBtn3.Text = C;
            rBtn4.Text = D;
        }
    }
}
