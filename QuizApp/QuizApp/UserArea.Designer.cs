namespace QuizApp
{
    partial class UserArea
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
            this.TbUser = new System.Windows.Forms.TextBox();
            this.BtnRegister = new System.Windows.Forms.Button();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.LblMessage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.RbLogin = new System.Windows.Forms.RadioButton();
            this.RbRegister = new System.Windows.Forms.RadioButton();
            this.PnlUnlogged = new System.Windows.Forms.Panel();
            this.PnlLogged = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.TbIP = new System.Windows.Forms.TextBox();
            this.LblDisplay = new System.Windows.Forms.Label();
            this.PnlUnlogged.SuspendLayout();
            this.PnlLogged.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbUser
            // 
            this.TbUser.Location = new System.Drawing.Point(570, 108);
            this.TbUser.Name = "TbUser";
            this.TbUser.Size = new System.Drawing.Size(100, 20);
            this.TbUser.TabIndex = 3;
            // 
            // BtnRegister
            // 
            this.BtnRegister.Location = new System.Drawing.Point(570, 247);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(100, 23);
            this.BtnRegister.TabIndex = 0;
            this.BtnRegister.Text = "Go!";
            this.BtnRegister.UseVisualStyleBackColor = true;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(570, 166);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(100, 20);
            this.TbPass.TabIndex = 4;
            // 
            // LblMessage
            // 
            this.LblMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblMessage.Location = new System.Drawing.Point(445, 204);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(350, 25);
            this.LblMessage.TabIndex = 78;
            this.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(570, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Multiplayer Mode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(570, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Single Player Mode";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RbLogin
            // 
            this.RbLogin.AutoSize = true;
            this.RbLogin.Location = new System.Drawing.Point(588, 55);
            this.RbLogin.Name = "RbLogin";
            this.RbLogin.Size = new System.Drawing.Size(51, 17);
            this.RbLogin.TabIndex = 2;
            this.RbLogin.TabStop = true;
            this.RbLogin.Text = "Login";
            this.RbLogin.UseVisualStyleBackColor = true;
            // 
            // RbRegister
            // 
            this.RbRegister.AutoSize = true;
            this.RbRegister.Location = new System.Drawing.Point(588, 17);
            this.RbRegister.Name = "RbRegister";
            this.RbRegister.Size = new System.Drawing.Size(64, 17);
            this.RbRegister.TabIndex = 1;
            this.RbRegister.TabStop = true;
            this.RbRegister.Text = "Register";
            this.RbRegister.UseVisualStyleBackColor = true;
            // 
            // PnlUnlogged
            // 
            this.PnlUnlogged.Controls.Add(this.RbLogin);
            this.PnlUnlogged.Controls.Add(this.RbRegister);
            this.PnlUnlogged.Controls.Add(this.TbUser);
            this.PnlUnlogged.Controls.Add(this.LblMessage);
            this.PnlUnlogged.Controls.Add(this.BtnRegister);
            this.PnlUnlogged.Controls.Add(this.TbPass);
            this.PnlUnlogged.Location = new System.Drawing.Point(12, 159);
            this.PnlUnlogged.Name = "PnlUnlogged";
            this.PnlUnlogged.Size = new System.Drawing.Size(1240, 310);
            this.PnlUnlogged.TabIndex = 79;
            this.PnlUnlogged.Visible = false;
            // 
            // PnlLogged
            // 
            this.PnlLogged.Controls.Add(this.button1);
            this.PnlLogged.Controls.Add(this.button2);
            this.PnlLogged.Location = new System.Drawing.Point(12, 156);
            this.PnlLogged.Name = "PnlLogged";
            this.PnlLogged.Size = new System.Drawing.Size(1240, 509);
            this.PnlLogged.TabIndex = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSubmit);
            this.panel1.Controls.Add(this.TbIP);
            this.panel1.Controls.Add(this.LblDisplay);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 138);
            this.panel1.TabIndex = 79;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Location = new System.Drawing.Point(588, 98);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(75, 23);
            this.BtnSubmit.TabIndex = 5;
            this.BtnSubmit.Text = "Enter";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // TbIP
            // 
            this.TbIP.Location = new System.Drawing.Point(575, 63);
            this.TbIP.Name = "TbIP";
            this.TbIP.Size = new System.Drawing.Size(100, 20);
            this.TbIP.TabIndex = 4;
            // 
            // LblDisplay
            // 
            this.LblDisplay.AutoSize = true;
            this.LblDisplay.Location = new System.Drawing.Point(560, 30);
            this.LblDisplay.Name = "LblDisplay";
            this.LblDisplay.Size = new System.Drawing.Size(131, 13);
            this.LblDisplay.TabIndex = 3;
            this.LblDisplay.Text = "Please enter the Server IP";
            // 
            // UserArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnlUnlogged);
            this.Controls.Add(this.PnlLogged);
            this.Name = "UserArea";
            this.Text = "QuizApp";
            this.Load += new System.EventHandler(this.UserArea_Load);
            this.PnlUnlogged.ResumeLayout(false);
            this.PnlUnlogged.PerformLayout();
            this.PnlLogged.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TbUser;
        private System.Windows.Forms.Button BtnRegister;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton RbLogin;
        private System.Windows.Forms.RadioButton RbRegister;
        private System.Windows.Forms.Panel PnlUnlogged;
        private System.Windows.Forms.Panel PnlLogged;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.TextBox TbIP;
        private System.Windows.Forms.Label LblDisplay;
    }
}

