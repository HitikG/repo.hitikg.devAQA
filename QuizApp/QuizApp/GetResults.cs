using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class GetResults : Form
    {
        private const int NoClose = 0x200;

        public GetResults(int Type, int Score, string GID, int PID)
        {
            InitializeComponent();
            int Swap = 0;
            System.Threading.Thread.Sleep(1000);
            WorkHorse W = new WorkHorse();
            Random Ran = new Random();

            if (Type == 1)
            {
                
                if (PID == 1)
                {
                    Swap = 2;
                    string OP = W.GetResults(GID, Swap);
                    int OS = Convert.ToInt32(OP);
                    LblP1S.Text = "Your score: " + Score.ToString();
                    LblP2S.Text = "Opponent's score: " + OP;

                    if (Score > OS)
                    {
                        LblWinner.Text = "You won!";
                    }
                    else if (OS > Score)
                    {
                        LblWinner.Text = "You lost!";
                    }
                    else
                    {
                        LblWinner.Text = "You drew!";
                    }
                }

                else if (PID == 2)
                {
                    Swap = 1;
                    string OP = W.GetResults(GID, Swap);
                    int OS = Convert.ToInt32(OP);
                    LblP1S.Text = "Your score: " + Score.ToString();
                    LblP2S.Text = "Opponent's score: " + OP;
                    if (Score > OS)
                    {
                        LblWinner.Text = "You won!";
                    }
                    else if (OS > Score)
                    {
                        LblWinner.Text = "You lost!";
                    }
                    else
                    {
                        LblWinner.Text = "You drew!";
                    }
                }
            }
            if (Type == 2)
            {
                int Comp = Ran.Next(0,10);
                LblP1S.Text = "Your score: " + Score.ToString();
                LblP2S.Text = "Computer's score: " + Comp;
                if (Score > Comp)
                {
                    LblWinner.Text = "You won!";
                }
                else if (Comp > Score)
                {
                    LblWinner.Text = "You lost!";
                }
                else
                {
                    LblWinner.Text = "You drew!";
                }
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | NoClose;
                return myCp;
            }
        } 
    }
}
