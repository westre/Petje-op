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
            this.PnlLogin = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.txtLoginCode = new System.Windows.Forms.TextBox();
            this.pnlButton_Logout_Background = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.pnlButton_Logout_Background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackgroundImage = global::PetjeOp.Properties.Resources.WinQ_Logo;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(46, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(156, 54);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.DoubleClick += new System.EventHandler(this.pictureBox2_DoubleClick);
            // 
            // PnlLogin
            // 
            this.PnlLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PnlLogin.AutoSize = true;
            this.PnlLogin.Controls.Add(this.txtLoginCode);
            this.PnlLogin.Controls.Add(this.pbLoading);
            this.PnlLogin.Controls.Add(this.pnlButton_Logout_Background);
            this.PnlLogin.Controls.Add(this.Error);
            this.PnlLogin.Location = new System.Drawing.Point(39, 70);
            this.PnlLogin.Name = "PnlLogin";
            this.PnlLogin.Size = new System.Drawing.Size(177, 96);
            this.PnlLogin.TabIndex = 4;
            // 
            // pbLoading
            // 
            this.pbLoading.BackColor = System.Drawing.Color.Transparent;
            this.pbLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLoading.Location = new System.Drawing.Point(142, 13);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(32, 32);
            this.pbLoading.TabIndex = 8;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // txtLoginCode
            // 
            this.txtLoginCode.AcceptsReturn = true;
            this.txtLoginCode.Location = new System.Drawing.Point(26, 19);
            this.txtLoginCode.Name = "txtLoginCode";
            this.txtLoginCode.Size = new System.Drawing.Size(117, 20);
            this.txtLoginCode.TabIndex = 2;
            this.txtLoginCode.Text = "2222222";
            this.txtLoginCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginCode_KeyDown);
            // 
            // pnlButton_Logout_Background
            // 
            this.pnlButton_Logout_Background.BackColor = System.Drawing.Color.Transparent;
            this.pnlButton_Logout_Background.BackgroundImage = global::PetjeOp.Properties.Resources.Button_Background;
            this.pnlButton_Logout_Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlButton_Logout_Background.Controls.Add(this.label2);
            this.pnlButton_Logout_Background.Controls.Add(this.pictureBox1);
            this.pnlButton_Logout_Background.Location = new System.Drawing.Point(2, 44);
            this.pnlButton_Logout_Background.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.Error.Location = new System.Drawing.Point(30, 4);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(74, 13);
            this.Error.TabIndex = 5;
            this.Error.Text = "Onjuiste Login";
            this.Error.Visible = false;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(235, 173);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.PnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(251, 212);
            this.MinimumSize = new System.Drawing.Size(251, 212);
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - WinQ";
            this.Load += new System.EventHandler(this.LoginView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PnlLogin.ResumeLayout(false);
            this.PnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.pnlButton_Logout_Background.ResumeLayout(false);
            this.pnlButton_Logout_Background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel PnlLogin;
        public System.Windows.Forms.Panel pnlButton_Logout_Background;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label Error;
        public System.Windows.Forms.TextBox txtLoginCode;
        public System.Windows.Forms.PictureBox pbLoading;
    }
}