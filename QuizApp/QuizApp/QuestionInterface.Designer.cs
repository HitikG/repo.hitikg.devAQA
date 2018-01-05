namespace QuizApp
{
    partial class QuestionInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LblQNum = new System.Windows.Forms.Label();
            this.Rb1 = new System.Windows.Forms.RadioButton();
            this.Rb2 = new System.Windows.Forms.RadioButton();
            this.Rb3 = new System.Windows.Forms.RadioButton();
            this.Rb4 = new System.Windows.Forms.RadioButton();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LblQuestion = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblQNum
            // 
            this.LblQNum.AutoSize = true;
            this.LblQNum.Location = new System.Drawing.Point(1194, 9);
            this.LblQNum.Name = "LblQNum";
            this.LblQNum.Size = new System.Drawing.Size(49, 13);
            this.LblQNum.TabIndex = 0;
            this.LblQNum.Text = "Question";
            // 
            // Rb1
            // 
            this.Rb1.AutoCheck = false;
            this.Rb1.AutoSize = true;
            this.Rb1.Location = new System.Drawing.Point(569, 284);
            this.Rb1.Name = "Rb1";
            this.Rb1.Size = new System.Drawing.Size(14, 13);
            this.Rb1.TabIndex = 2;
            this.Rb1.UseVisualStyleBackColor = true;
            // 
            // Rb2
            // 
            this.Rb2.AutoCheck = false;
            this.Rb2.AutoSize = true;
            this.Rb2.Location = new System.Drawing.Point(569, 325);
            this.Rb2.Name = "Rb2";
            this.Rb2.Size = new System.Drawing.Size(14, 13);
            this.Rb2.TabIndex = 3;
            this.Rb2.UseVisualStyleBackColor = true;
            // 
            // Rb3
            // 
            this.Rb3.AutoCheck = false;
            this.Rb3.AutoSize = true;
            this.Rb3.Location = new System.Drawing.Point(569, 363);
            this.Rb3.Name = "Rb3";
            this.Rb3.Size = new System.Drawing.Size(14, 13);
            this.Rb3.TabIndex = 4;
            this.Rb3.UseVisualStyleBackColor = true;
            // 
            // Rb4
            // 
            this.Rb4.AutoCheck = false;
            this.Rb4.AutoSize = true;
            this.Rb4.Location = new System.Drawing.Point(569, 402);
            this.Rb4.Name = "Rb4";
            this.Rb4.Size = new System.Drawing.Size(14, 13);
            this.Rb4.TabIndex = 6;
            this.Rb4.UseVisualStyleBackColor = true;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Location = new System.Drawing.Point(569, 513);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(75, 23);
            this.BtnSubmit.TabIndex = 0;
            this.BtnSubmit.Text = "Submit";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(563, 599);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 1;
            // 
            // LblQuestion
            // 
            this.LblQuestion.AutoSize = true;
            this.LblQuestion.Location = new System.Drawing.Point(563, 88);
            this.LblQuestion.Name = "LblQuestion";
            this.LblQuestion.Size = new System.Drawing.Size(35, 13);
            this.LblQuestion.TabIndex = 8;
            this.LblQuestion.Text = "label1";
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Score: 3";
            // 
            // QuestionInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblQuestion);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Rb4);
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.Rb3);
            this.Controls.Add(this.Rb2);
            this.Controls.Add(this.Rb1);
            this.Controls.Add(this.LblQNum);
            this.Name = "QuestionInterface";
            this.Text = "QuestionInterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblQNum;
        private System.Windows.Forms.RadioButton Rb1;
        private System.Windows.Forms.RadioButton Rb2;
        private System.Windows.Forms.RadioButton Rb3;
        private System.Windows.Forms.RadioButton Rb4;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LblQuestion;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label label1;
    }
}