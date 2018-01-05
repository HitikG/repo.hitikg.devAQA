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
    public partial class AddQ : Form
    {
        public AddQ()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkHorse W = new WorkHorse();

            string LS= textBox1.Text+","+textBox2.Text+","+textBox3.Text+","+textBox4.Text+","+textBox5.Text+","+ textBox6.Text;

            W.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);/*

            string UserQuery = "INSERT INTO Questions (Subject, Question, CorrectAnswer, AnswerA, AnswerB, AnswerC) Values (@Subject, @Question, @CorrectAnswer, @AnswerA, @AnswerB, @AnswerC)";//Adding Into Our Database To Add To The Likes
            SqlConnection UserConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["CsData"].ConnectionString);
            SqlCommand UserCmd = new SqlCommand(UserQuery, UserConnect); //Our Query To Execute

            UserCmd.Parameters.AddWithValue("@Subject", textBox1.Text);  //Adds It To Check
            UserCmd.Parameters.AddWithValue("@Question", textBox2.Text);  //Adds It To Check
            UserCmd.Parameters.AddWithValue("@CorrectAnswer", textBox3.Text);  //Adds It To Check
            UserCmd.Parameters.AddWithValue("@AnswerA", textBox4.Text);  //Adds It To Check
            UserCmd.Parameters.AddWithValue("@AnswerB", textBox5.Text);  //Adds It To Check
            UserCmd.Parameters.AddWithValue("@AnswerC", textBox6.Text);  //Adds It To Check

            UserConnect.Open(); //Opens Our Connection
            UserCmd.ExecuteNonQuery(); //Execute Our Query
            UserConnect.Close(); //Close Our Connection
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();*/
        }
    }
}
