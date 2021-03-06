﻿using System;
using System.Windows.Forms;

namespace PetjeOp {
    partial class StudentView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentView));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlButton_Logout_Background = new System.Windows.Forms.Panel();
            this.lblTitle_Logout_Title = new System.Windows.Forms.Label();
            this.pbIcon_Logout_Icon = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlButton_QuestionnaireOverview_Background = new System.Windows.Forms.Panel();
            this.pbIcon_QuestionnaireOverview_Icon = new System.Windows.Forms.PictureBox();
            this.lblTitle_QuestionnaireOverview_Title = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlButton_Logout_Background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Logout_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlButton_QuestionnaireOverview_Background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_QuestionnaireOverview_Icon)).BeginInit();
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
            this.pnlHeader.Controls.Add(this.pnlButton_QuestionnaireOverview_Background);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(902, 59);
            this.pnlHeader.TabIndex = 2;
            // 
            // pnlButton_Logout_Background
            // 
            this.pnlButton_Logout_Background.BackColor = System.Drawing.Color.Transparent;
            this.pnlButton_Logout_Background.BackgroundImage = global::PetjeOp.Properties.Resources.Button_Background;
            this.pnlButton_Logout_Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlButton_Logout_Background.Controls.Add(this.lblTitle_Logout_Title);
            this.pnlButton_Logout_Background.Controls.Add(this.pbIcon_Logout_Icon);
            this.pnlButton_Logout_Background.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlButton_Logout_Background.Location = new System.Drawing.Point(0, 0);
            this.pnlButton_Logout_Background.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButton_Logout_Background.Name = "pnlButton_Logout_Background";
            this.pnlButton_Logout_Background.Size = new System.Drawing.Size(165, 40);
            this.pnlButton_Logout_Background.TabIndex = 15;
            this.pnlButton_Logout_Background.Click += new System.EventHandler(this.Logout);
            // 
            // lblTitle_Logout_Title
            // 
            this.lblTitle_Logout_Title.AutoSize = true;
            this.lblTitle_Logout_Title.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle_Logout_Title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle_Logout_Title.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTitle_Logout_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(98)))));
            this.lblTitle_Logout_Title.Location = new System.Drawing.Point(61, 9);
            this.lblTitle_Logout_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle_Logout_Title.Name = "lblTitle_Logout_Title";
            this.lblTitle_Logout_Title.Size = new System.Drawing.Size(83, 23);
            this.lblTitle_Logout_Title.TabIndex = 14;
            this.lblTitle_Logout_Title.Text = "Uitloggen";
            this.lblTitle_Logout_Title.Click += new System.EventHandler(this.Logout);
            // 
            // pbIcon_Logout_Icon
            // 
            this.pbIcon_Logout_Icon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon_Logout_Icon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbIcon_Logout_Icon.BackgroundImage")));
            this.pbIcon_Logout_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon_Logout_Icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbIcon_Logout_Icon.Location = new System.Drawing.Point(30, 9);
            this.pbIcon_Logout_Icon.Margin = new System.Windows.Forms.Padding(2);
            this.pbIcon_Logout_Icon.Name = "pbIcon_Logout_Icon";
            this.pbIcon_Logout_Icon.Size = new System.Drawing.Size(21, 25);
            this.pbIcon_Logout_Icon.TabIndex = 4;
            this.pbIcon_Logout_Icon.TabStop = false;
            this.pbIcon_Logout_Icon.Click += new System.EventHandler(this.Logout);
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
            // pnlButton_QuestionnaireOverview_Background
            // 
            this.pnlButton_QuestionnaireOverview_Background.BackColor = System.Drawing.Color.Transparent;
            this.pnlButton_QuestionnaireOverview_Background.BackgroundImage = global::PetjeOp.Properties.Resources.Button_Background;
            this.pnlButton_QuestionnaireOverview_Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlButton_QuestionnaireOverview_Background.Controls.Add(this.pbIcon_QuestionnaireOverview_Icon);
            this.pnlButton_QuestionnaireOverview_Background.Controls.Add(this.lblTitle_QuestionnaireOverview_Title);
            this.pnlButton_QuestionnaireOverview_Background.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlButton_QuestionnaireOverview_Background.Location = new System.Drawing.Point(198, 13);
            this.pnlButton_QuestionnaireOverview_Background.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButton_QuestionnaireOverview_Background.Name = "pnlButton_QuestionnaireOverview_Background";
            this.pnlButton_QuestionnaireOverview_Background.Size = new System.Drawing.Size(165, 40);
            this.pnlButton_QuestionnaireOverview_Background.TabIndex = 15;
            this.pnlButton_QuestionnaireOverview_Background.Click += new System.EventHandler(this.goToMain);
            // 
            // pbIcon_QuestionnaireOverview_Icon
            // 
            this.pbIcon_QuestionnaireOverview_Icon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon_QuestionnaireOverview_Icon.BackgroundImage = global::PetjeOp.Properties.Resources.Button_QuestionnaireOverview_Icon;
            this.pbIcon_QuestionnaireOverview_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon_QuestionnaireOverview_Icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbIcon_QuestionnaireOverview_Icon.Location = new System.Drawing.Point(17, 10);
            this.pbIcon_QuestionnaireOverview_Icon.Margin = new System.Windows.Forms.Padding(2);
            this.pbIcon_QuestionnaireOverview_Icon.Name = "pbIcon_QuestionnaireOverview_Icon";
            this.pbIcon_QuestionnaireOverview_Icon.Size = new System.Drawing.Size(21, 21);
            this.pbIcon_QuestionnaireOverview_Icon.TabIndex = 6;
            this.pbIcon_QuestionnaireOverview_Icon.TabStop = false;
            this.pbIcon_QuestionnaireOverview_Icon.Click += new System.EventHandler(this.goToMain);
            // 
            // lblTitle_QuestionnaireOverview_Title
            // 
            this.lblTitle_QuestionnaireOverview_Title.AutoSize = true;
            this.lblTitle_QuestionnaireOverview_Title.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle_QuestionnaireOverview_Title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle_QuestionnaireOverview_Title.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblTitle_QuestionnaireOverview_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(98)))));
            this.lblTitle_QuestionnaireOverview_Title.Location = new System.Drawing.Point(42, 8);
            this.lblTitle_QuestionnaireOverview_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle_QuestionnaireOverview_Title.Name = "lblTitle_QuestionnaireOverview_Title";
            this.lblTitle_QuestionnaireOverview_Title.Size = new System.Drawing.Size(111, 23);
            this.lblTitle_QuestionnaireOverview_Title.TabIndex = 12;
            this.lblTitle_QuestionnaireOverview_Title.Text = "Vragenlijsten";
            this.lblTitle_QuestionnaireOverview_Title.Click += new System.EventHandler(this.goToMain);
            // 
            // viewPanel
            // 
            this.viewPanel.AutoSize = true;
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 59);
            this.viewPanel.Margin = new System.Windows.Forms.Padding(2);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(902, 91);
            this.viewPanel.TabIndex = 4;
            // 
            // StudentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.pnlHeader);
            this.Name = "StudentView";
            this.Size = new System.Drawing.Size(902, 150);
            this.Resize += new System.EventHandler(this.logOutBtn);
            this.pnlHeader.ResumeLayout(false);
            this.pnlButton_Logout_Background.ResumeLayout(false);
            this.pnlButton_Logout_Background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Logout_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlButton_QuestionnaireOverview_Background.ResumeLayout(false);
            this.pnlButton_QuestionnaireOverview_Background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_QuestionnaireOverview_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void goToMain(object sender, EventArgs args)
        {
            ExamOverviewStudentController aqc = (ExamOverviewStudentController)Controller.MasterController.GetController(typeof(ExamOverviewStudentController));
            Controller.MasterController.SetController(aqc);
        }

        public void Logout(object sender, EventArgs args)
        {
            Controller.MasterController.Logout();
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
        private System.Windows.Forms.Label lblTitle_Logout_Title;
        public System.Windows.Forms.Panel pnlButton_Logout_Background;
        public Panel viewPanel;

        private void logOutBtn(object sender, EventArgs e)
        {
            pnlButton_Logout_Background.Location = new System.Drawing.Point((pnlHeader.Size.Width - pnlButton_Logout_Background.Size.Width - 10), 12);
            pnlButton_QuestionnaireOverview_Background.Location = new System.Drawing.Point((pnlHeader.Size.Width - pnlButton_Logout_Background.Size.Width * 2 - 10), 12);
        }

        private Panel pnlButton_QuestionnaireOverview_Background;
        private PictureBox pbIcon_QuestionnaireOverview_Icon;
        private Label lblTitle_QuestionnaireOverview_Title;
    }
}
