namespace QuizApp
{
    partial class GetResults
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
            this.LblP1S = new System.Windows.Forms.Label();
            this.LblP2S = new System.Windows.Forms.Label();
            this.Done = new System.Windows.Forms.Button();
            this.LblWinner = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblP1S
            // 
            this.LblP1S.AutoSize = true;
            this.LblP1S.Location = new System.Drawing.Point(103, 72);
            this.LblP1S.Name = "LblP1S";
            this.LblP1S.Size = new System.Drawing.Size(78, 13);
            this.LblP1S.TabIndex = 0;
            this.LblP1S.Text = "Your Score: 10";
            // 
            // LblP2S
            // 
            this.LblP2S.AutoSize = true;
            this.LblP2S.Location = new System.Drawing.Point(87, 124);
            this.LblP2S.Name = "LblP2S";
            this.LblP2S.Size = new System.Drawing.Size(110, 13);
            this.LblP2S.TabIndex = 1;
            this.LblP2S.Text = "Opponent\'s Score: 10";
            // 
            // Done
            // 
            this.Done.Location = new System.Drawing.Point(105, 200);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 23);
            this.Done.TabIndex = 2;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // LblWinner
            // 
            this.LblWinner.AutoSize = true;
            this.LblWinner.Location = new System.Drawing.Point(118, 13);
            this.LblWinner.Name = "LblWinner";
            this.LblWinner.Size = new System.Drawing.Size(48, 13);
            this.LblWinner.TabIndex = 3;
            this.LblWinner.Text = "You lost!";
            // 
            // GetResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.LblWinner);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.LblP2S);
            this.Controls.Add(this.LblP1S);
            this.Name = "GetResults";
            this.Text = "GetResults";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblP1S;
        private System.Windows.Forms.Label LblP2S;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Label LblWinner;
    }
}