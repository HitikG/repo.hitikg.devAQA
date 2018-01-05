using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class UserArea : Form
    {
        public bool LoggedIn = false;
        WorkHorse W = new WorkHorse();

        public UserArea()
        {
            InitializeComponent();
        }

        private void UserArea_Load(object sender, EventArgs e)
        {
            PnlLogged.Visible = false;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (RbRegister.Checked == true)
            {
                /*if (W.CheckUser(TbUser.Text)) //Validates If The User Already Exists
                {
                    LblMessage.Text = "This Username Already Exists"; //Displays A Message
                    Clear();
                }*/
                
                 if (TbUser.Text == "" || TbPass.Text == "")
                {
                    LblMessage.Text = "You need to complete all fields";
                    Clear();
                }
                else if (TbUser.TextLength > 15 || TbPass.TextLength > 15)
                {
                    LblMessage.Text = "Your details need to be less than 15 characters";
                    Clear();
                }
                else
                {
                    W.Register(TbUser.Text, TbPass.Text);
                    PnlUnlogged.Visible = false;
                    LoggedIn = true;
                }
            }
            else if (RbLogin.Checked == true)
            {
                if (TbUser.Text == "" || TbPass.Text == "")
                {
                    LblMessage.Text = "You need to enter both your credentials";
                    Clear();
                }
                else if (TbUser.TextLength > 10 || TbPass.TextLength > 10)
                {
                    LblMessage.Text = "Your details need to be less than 15 characters";
                    Clear();
                }
                else if (W.Login(TbUser.Text, TbPass.Text))
                {
                    PnlUnlogged.Visible = false;
                    LoggedIn = true;
                }
                else
                {
                    LblMessage.Text = "There was no account assoicated with those details";
                }
            }
            else
            {
                LblMessage.Text = "Please select if you want to register or login";
            }
            if (LoggedIn == true)
            {
                PnlLogged.Visible = true;
            }
        }
        private void Clear()
        {
            TbUser.Text = ""; //Clears The Textbox
            TbPass.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EstablishConnection E = new EstablishConnection(TbUser.Text);
            E.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddQ A = new AddQ();
            A.Show();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            W.IP = TbIP.Text;
            panel1.Visible = false;
            PnlUnlogged.Visible = true;
        }




    }
}
