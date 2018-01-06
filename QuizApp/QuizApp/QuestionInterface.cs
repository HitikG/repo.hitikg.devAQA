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
    public partial class QuestionInterface : Form
    {
        WorkHorse W = new WorkHorse();
        public int QNum = 1;
        public int Cor = 0;

        public string Username = "";
        public string GID = "";
        public int PID = 0;
        bool GameDone = false;
        string Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        private static readonly Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int Port = 100;

        public QuestionInterface(string User, string Game)
        {
            InitializeComponent();
            Username = User;
            LblScore.Text = "Score: " + Cor;
            PID = Game.FirstOrDefault(); //Split into induvidual variables
            GID = Game.Substring(1); //Split into induvidual variables
            string test = Game.ToString();

            if (test.Length > 4)
            {
                test = test.Substring(0, test.Length / 2);
                GID = test;
            }

            Incrementer();
            Timer.Enabled = true; // Enable the timer.
            Timer.Start();//Strart it
            Timer.Interval = 500; // The time per tick.
        }

        public async Task Incrementer()
        {
            while (QNum != 12)
            {
                GetQuestion();
                if (Rb1.Checked == true)
                {
                    if (Cor != 10)
                    {
                        Cor++;
                        LblScore.Text = "Score: " + Cor;
                        Rb1.Checked = false;
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
                if (GID.Length > 3)
                {
                    GID = GID.Substring(1);
                }
                if (PID == 49)
                {
                    PID = 1;
                }
                else if (PID == 50)
                {
                    PID = 2;
                }
                if (GameDone)
                {
                    W.SendResults(Username, Cor, GID, Date, PID);
                    GetResults G = new GetResults(1, Cor, GID, PID);
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
            LblQNum.Text = "Question " + QNum.ToString();
            QNum++;

            List<Point> ButtonList = new List<Point> { Rb1.Location, Rb2.Location, Rb3.Location, Rb4.Location }; //Defining Our Buttons
            var RadioButtons = new[] { Rb1, Rb2, Rb3, Rb4 }; //Defining Our Buttons
            var Location = ButtonList.OrderBy(x => Ran.Next(ButtonList.Count)).ToList(); //Shuffle Where The Buttons Are
            for (int i = 0; i < RadioButtons.Length; i++) //Change The Number Where The Buttons Are Displayed
            {
                RadioButtons[i].Location = Location[i];
            }

            LblQuestion.Text = Q;
            Rb1.Text = A;
            Rb2.Text = B;
            Rb3.Text = C;
            Rb4.Text = D;
        }
    }
}


