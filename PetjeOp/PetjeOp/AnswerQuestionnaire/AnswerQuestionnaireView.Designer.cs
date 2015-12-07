using System;
using System.Windows.Forms;

namespace PetjeOp {
    partial class AnswerQuestionnaireView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnswerQuestionnaireView));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlButton_Logout_Background = new System.Windows.Forms.Panel();
            this.lblTitle_Logout_Title = new System.Windows.Forms.Label();
            this.pbIcon_Logout_Icon = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle_Results_Title = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.VraagBox = new System.Windows.Forms.CheckedListBox();
            this.alignPanel = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlButton_Logout_Background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Logout_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.viewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHeader.BackgroundImage")));
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Controls.Add(this.pnlButton_Logout_Background);
            this.pnlHeader.Controls.Add(this.pbLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1334, 59);
            this.pnlHeader.TabIndex = 2;
            // 
            // pnlButton_Logout_Background
            // 
            this.pnlButton_Logout_Background.BackColor = System.Drawing.Color.Transparent;
            this.pnlButton_Logout_Background.BackgroundImage = global::PetjeOp.Properties.Resources.Button_Background;
            this.pnlButton_Logout_Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlButton_Logout_Background.Controls.Add(this.lblTitle_Logout_Title);
            this.pnlButton_Logout_Background.Controls.Add(this.pbIcon_Logout_Icon);
            this.pnlButton_Logout_Background.Location = new System.Drawing.Point(0, 0);
            this.pnlButton_Logout_Background.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButton_Logout_Background.Name = "pnlButton_Logout_Background";
            this.pnlButton_Logout_Background.Size = new System.Drawing.Size(165, 40);
            this.pnlButton_Logout_Background.TabIndex = 15;
            // 
            // lblTitle_Logout_Title
            // 
            this.lblTitle_Logout_Title.AutoSize = true;
            this.lblTitle_Logout_Title.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle_Logout_Title.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTitle_Logout_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(98)))));
            this.lblTitle_Logout_Title.Location = new System.Drawing.Point(61, 9);
            this.lblTitle_Logout_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle_Logout_Title.Name = "lblTitle_Logout_Title";
            this.lblTitle_Logout_Title.Size = new System.Drawing.Size(83, 23);
            this.lblTitle_Logout_Title.TabIndex = 14;
            this.lblTitle_Logout_Title.Text = "Uitloggen";
            // 
            // pbIcon_Logout_Icon
            // 
            this.pbIcon_Logout_Icon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon_Logout_Icon.BackgroundImage = global::PetjeOp.Properties.Resources.Button_Logout_Icon;
            this.pbIcon_Logout_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon_Logout_Icon.Location = new System.Drawing.Point(30, 9);
            this.pbIcon_Logout_Icon.Margin = new System.Windows.Forms.Padding(2);
            this.pbIcon_Logout_Icon.Name = "pbIcon_Logout_Icon";
            this.pbIcon_Logout_Icon.Size = new System.Drawing.Size(21, 25);
            this.pbIcon_Logout_Icon.TabIndex = 4;
            this.pbIcon_Logout_Icon.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImage = global::PetjeOp.Properties.Resources.WinQ_Logo;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogo.Location = new System.Drawing.Point(8, 7);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(150, 50);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblTitle_Results_Title
            // 
            this.lblTitle_Results_Title.AutoSize = true;
            this.lblTitle_Results_Title.Anchor = AnchorStyles.Top;
            this.lblTitle_Results_Title.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle_Results_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_Results_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(98)))));
            this.lblTitle_Results_Title.Name = "lblTitle_Results_Title";
            this.lblTitle_Results_Title.TabIndex = 4;
            this.lblTitle_Results_Title.Text = "Resultaten";
            // 
            // viewPanel
            this.viewPanel.AutoSize = true;
            this.viewPanel.Dock = DockStyle.Fill;
            this.viewPanel.Controls.Add(this.alignPanel);
            this.viewPanel.Margin = new System.Windows.Forms.Padding(2);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.TabIndex = 4;
            // 
            // PnlLogin
            // 
            this.alignPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.alignPanel.AutoSize = true;
            this.alignPanel.Location = new System.Drawing.Point(-(this.alignPanel.Width / 2), 0);
            this.alignPanel.Controls.Add(this.VraagBox);
            this.alignPanel.Controls.Add(this.lblTitle_Results_Title);
            this.alignPanel.Name = "alignPanel";
            this.alignPanel.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.VraagBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VraagBox.FormattingEnabled = true;
            this.VraagBox.Location = new System.Drawing.Point(0, 50);
            this.VraagBox.Name = "checkedListBox1";
            this.VraagBox.Size = new System.Drawing.Size(448, 148);
            this.VraagBox.TabIndex = 10;
            // 
            // AnswerQuestionnaireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.pnlHeader);
            this.Name = "AnswerQuestionnaireView";
            this.Dock = DockStyle.Fill;
            this.Resize += new System.EventHandler(this.logOutBtn);
            this.pnlHeader.ResumeLayout(false);
            this.pnlButton_Logout_Background.ResumeLayout(false);
            this.pnlButton_Logout_Background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Logout_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.viewPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

        }

        private void scaleBanner()
        {
            pnlHeader.Size = new System.Drawing.Size(Controller.MasterController.Size.Width, pnlHeader.Size.Height);
        }

        #endregion
        public System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.PictureBox pbIcon_Logout_Icon;
        public System.Windows.Forms.Label lblTitle_Results_Title;
        private System.Windows.Forms.Label lblTitle_Logout_Title;
        public System.Windows.Forms.Panel pnlButton_Logout_Background;
        public Panel viewPanel;
        public Panel alignPanel;

        private void logOutBtn(object sender, EventArgs e)
        {
            pnlButton_Logout_Background.Location = new System.Drawing.Point((pnlHeader.Size.Width - pnlButton_Logout_Background.Size.Width - 10), 12);
        }

        public CheckedListBox VraagBox { get; set; }
    }
}
