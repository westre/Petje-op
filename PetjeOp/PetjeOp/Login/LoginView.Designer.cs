namespace PetjeOp.Login
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnVraagOverzicht = new System.Windows.Forms.Button();
            this.btnAnswerQuestion = new System.Windows.Forms.Button();
            this.PnlLogin = new System.Windows.Forms.Panel();
            this.pnlButton_Logout_Background = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Error = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PnlLogin.SuspendLayout();
            this.pnlButton_Logout_Background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::PetjeOp.Properties.Resources.WinQ_Logo;
            this.pictureBox2.Location = new System.Drawing.Point(46, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(156, 54);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // btnVraagOverzicht
            // 
            this.btnVraagOverzicht.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVraagOverzicht.Location = new System.Drawing.Point(209, 113);
            this.btnVraagOverzicht.Name = "btnVraagOverzicht";
            this.btnVraagOverzicht.Size = new System.Drawing.Size(57, 22);
            this.btnVraagOverzicht.TabIndex = 3;
            this.btnVraagOverzicht.Text = "vraag";
            this.btnVraagOverzicht.UseVisualStyleBackColor = true;
            this.btnVraagOverzicht.Click += new System.EventHandler(this.btnVraagOverzicht_Click);
            // 
            // btnAnswerQuestion
            // 
            this.btnAnswerQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAnswerQuestion.Location = new System.Drawing.Point(209, 130);
            this.btnAnswerQuestion.Name = "btnAnswerQuestion";
            this.btnAnswerQuestion.Size = new System.Drawing.Size(57, 21);
            this.btnAnswerQuestion.TabIndex = 5;
            this.btnAnswerQuestion.Text = "Answer";
            this.btnAnswerQuestion.UseVisualStyleBackColor = true;
            this.btnAnswerQuestion.Click += new System.EventHandler(this.btnAnswerQuestion_Click);
            // 
            // PnlLogin
            // 
            this.PnlLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PnlLogin.AutoSize = true;
            this.PnlLogin.Controls.Add(this.textBox1);
            this.PnlLogin.Controls.Add(this.pnlButton_Logout_Background);
            this.PnlLogin.Controls.Add(this.Error);
            this.PnlLogin.Location = new System.Drawing.Point(39, 96);
            this.PnlLogin.Name = "PnlLogin";
            this.PnlLogin.Size = new System.Drawing.Size(169, 96);
            this.PnlLogin.TabIndex = 4;
            // 
            // pnlButton_Logout_Background
            // 
            this.pnlButton_Logout_Background.BackColor = System.Drawing.Color.Transparent;
            this.pnlButton_Logout_Background.BackgroundImage = global::PetjeOp.Properties.Resources.Button_Background;
            this.pnlButton_Logout_Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlButton_Logout_Background.Controls.Add(this.label2);
            this.pnlButton_Logout_Background.Controls.Add(this.pictureBox1);
            this.pnlButton_Logout_Background.Location = new System.Drawing.Point(2, 44);
            this.pnlButton_Logout_Background.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButton_Logout_Background.Name = "pnlButton_Logout_Background";
            this.pnlButton_Logout_Background.Size = new System.Drawing.Size(165, 40);
            this.pnlButton_Logout_Background.TabIndex = 16;
            this.pnlButton_Logout_Background.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 14F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(98)))));
            this.label2.Location = new System.Drawing.Point(61, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Inloggen";
            this.label2.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(30, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 25);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.ForeColor = System.Drawing.Color.DarkRed;
            this.Error.Location = new System.Drawing.Point(23, 3);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(120, 13);
            this.Error.TabIndex = 5;
            this.Error.Text = "Woops.. Er ging iets mis";
            this.Error.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(26, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 20);
            this.textBox1.TabIndex = 2;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 193);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnVraagOverzicht);
            this.Controls.Add(this.btnAnswerQuestion);
            this.Controls.Add(this.PnlLogin);
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PnlLogin.ResumeLayout(false);
            this.PnlLogin.PerformLayout();
            this.pnlButton_Logout_Background.ResumeLayout(false);
            this.pnlButton_Logout_Background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnVraagOverzicht;
        private System.Windows.Forms.Button btnAnswerQuestion;
        private System.Windows.Forms.Panel PnlLogin;
        public System.Windows.Forms.Panel pnlButton_Logout_Background;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Error;
        private System.Windows.Forms.TextBox textBox1;
    }
}