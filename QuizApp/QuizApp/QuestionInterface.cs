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
        public int Cor = 6;

        public string Username = "";
        public int GameID = 0;
        string Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        private static readonly Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int Port = 100;

        public QuestionInterface(string User, int Game)
        {
            InitializeComponent();
            Username = User;
            string test = Game.ToString();
            GameID = Game;
            if (test.Length > 3)
            {
                test = test.Substring(0, test.Length / 2);
                GameID = Convert.ToInt32(test);
            }
            Incrementer();
            Timer.Enabled = true; // Enable the timer.
            Timer.Start();//Strart it
            Timer.Interval = 500; // The time per tick.
            progressBar1.Maximum = 10;

        }

        public async Task Incrementer()
        {
            while (QNum != 11)
            {
                Rb1.Checked = false;
                GetQuestion();
                await Task.Delay(500);
                progressBar1.Value = 0;
                if (Rb1.Checked == true)
                {
                    if (Cor != 10)
                    { Cor++; }
                }
            }
        }

        public void GetQuestion()
        {
            if (QNum == 10)
            {
                LblQuestion.Text = "Done" + Cor;
                Timer.Stop();
                W.SendResults(Username, Cor, GameID, Date);
            }

            Rb1.Checked = false;


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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 10)
            {
                progressBar1.Value++;
            }
            else
            {
                Timer.Stop();
            }
        }
    }
}


