namespace QuizApp
{
    partial class EstablishConnection
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
            this.BtnConnect = new System.Windows.Forms.Button();
            this.LblConnect = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.LblOn = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(12, 42);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 23);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // LblConnect
            // 
            this.LblConnect.AutoSize = true;
            this.LblConnect.Location = new System.Drawing.Point(12, 9);
            this.LblConnect.Name = "LblConnect";
            this.LblConnect.Size = new System.Drawing.Size(0, 13);
            this.LblConnect.TabIndex = 3;
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(521, 168);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(0, 13);
            this.LblStatus.TabIndex = 4;
            // 
            // LblOn
            // 
            this.LblOn.AutoSize = true;
            this.LblOn.Location = new System.Drawing.Point(991, 47);
            this.LblOn.Name = "LblOn";
            this.LblOn.Size = new System.Drawing.Size(0, 13);
            this.LblOn.TabIndex = 5;
            // 
            // EstablishConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 478);
            this.Controls.Add(this.LblOn);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.LblConnect);
            this.Controls.Add(this.BtnConnect);
            this.Name = "EstablishConnection";
            this.Text = "EstablishConnection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label LblConnect;
        private System.Windows.Forms.Label LblStatus;
        public System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.Label LblOn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}