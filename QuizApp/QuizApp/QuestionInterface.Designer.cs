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
            this.LblQuestion = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LblScore = new System.Windows.Forms.Label();
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
            this.Rb1.AutoSize = true;
            this.Rb1.Location = new System.Drawing.Point(570, 285);
            this.Rb1.Name = "Rb1";
            this.Rb1.Size = new System.Drawing.Size(14, 13);
            this.Rb1.TabIndex = 2;
            this.Rb1.UseVisualStyleBackColor = true;
            // 
            // Rb2
            // 
            this.Rb2.AutoSize = true;
            this.Rb2.Location = new System.Drawing.Point(570, 325);
            this.Rb2.Name = "Rb2";
            this.Rb2.Size = new System.Drawing.Size(14, 13);
            this.Rb2.TabIndex = 3;
            this.Rb2.UseVisualStyleBackColor = true;
            // 
            // Rb3
            // 
            this.Rb3.AutoSize = true;
            this.Rb3.Location = new System.Drawing.Point(570, 365);
            this.Rb3.Name = "Rb3";
            this.Rb3.Size = new System.Drawing.Size(14, 13);
            this.Rb3.TabIndex = 4;
            this.Rb3.UseVisualStyleBackColor = true;
            // 
            // Rb4
            // 
            this.Rb4.AutoSize = true;
            this.Rb4.Location = new System.Drawing.Point(570, 405);
            this.Rb4.Name = "Rb4";
            this.Rb4.Size = new System.Drawing.Size(14, 13);
            this.Rb4.TabIndex = 6;
            this.Rb4.UseVisualStyleBackColor = true;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Location = new System.Drawing.Point(570, 515);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(75, 23);
            this.BtnSubmit.TabIndex = 0;
            this.BtnSubmit.Text = "Submit";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Visible = false;
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
            // LblScore
            // 
            this.LblScore.AutoSize = true;
            this.LblScore.Location = new System.Drawing.Point(12, 9);
            this.LblScore.Name = "LblScore";
            this.LblScore.Size = new System.Drawing.Size(38, 13);
            this.LblScore.TabIndex = 9;
            this.LblScore.Text = "Score:";
            // 
            // QuestionInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.LblScore);
            this.Controls.Add(this.LblQuestion);
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
        private System.Windows.Forms.Label LblQuestion;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LblScore;
    }
}