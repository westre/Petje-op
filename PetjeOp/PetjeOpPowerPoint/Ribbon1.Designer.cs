namespace PetjeOpPowerPoint
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WinQ = this.Factory.CreateRibbonTab();
            this.GrpQuestionnaire = this.Factory.CreateRibbonGroup();
            this.ddExams = this.Factory.CreateRibbonDropDown();
            this.ddQuestions = this.Factory.CreateRibbonDropDown();
            this.GrpResults = this.Factory.CreateRibbonGroup();
            this.grpSlide = this.Factory.CreateRibbonGroup();
            this.btnAllQuestions = this.Factory.CreateRibbonButton();
            this.btnViewResultsPPT = this.Factory.CreateRibbonButton();
            this.btnReset = this.Factory.CreateRibbonButton();
            this.btnSlideInfo = this.Factory.CreateRibbonButton();
            this.WinQ.SuspendLayout();
            this.GrpQuestionnaire.SuspendLayout();
            this.GrpResults.SuspendLayout();
            this.grpSlide.SuspendLayout();
            this.SuspendLayout();
            // 
            // WinQ
            // 
            this.WinQ.Groups.Add(this.GrpQuestionnaire);
            this.WinQ.Groups.Add(this.GrpResults);
            this.WinQ.Groups.Add(this.grpSlide);
            this.WinQ.Label = "WinQ";
            this.WinQ.Name = "WinQ";
            // 
            // GrpQuestionnaire
            // 
            this.GrpQuestionnaire.Items.Add(this.ddExams);
            this.GrpQuestionnaire.Items.Add(this.ddQuestions);
            this.GrpQuestionnaire.Items.Add(this.btnAllQuestions);
            this.GrpQuestionnaire.Label = "Vragen toevoegen";
            this.GrpQuestionnaire.Name = "GrpQuestionnaire";
            // 
            // ddExams
            // 
            this.ddExams.Label = "Afnamemomenten";
            this.ddExams.Name = "ddExams";
            this.ddExams.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ddExams_SelectionChanged);
            // 
            // ddQuestions
            // 
            this.ddQuestions.Label = "Dia per vraag";
            this.ddQuestions.Name = "ddQuestions";
            this.ddQuestions.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ddQuestions_SelectionChanged);
            // 
            // GrpResults
            // 
            this.GrpResults.Items.Add(this.btnViewResultsPPT);
            this.GrpResults.Items.Add(this.btnReset);
            this.GrpResults.Label = "Resultaten";
            this.GrpResults.Name = "GrpResults";
            // 
            // grpSlide
            // 
            this.grpSlide.Items.Add(this.btnSlideInfo);
            this.grpSlide.Name = "grpSlide";
            // 
            // btnAllQuestions
            // 
            this.btnAllQuestions.Label = "Alle vragen toevoegen";
            this.btnAllQuestions.Name = "btnAllQuestions";
            this.btnAllQuestions.Visible = false;
            this.btnAllQuestions.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAllQuestions_Click);
            // 
            // btnViewResultsPPT
            // 
            this.btnViewResultsPPT.Label = "";
            this.btnViewResultsPPT.Name = "btnViewResultsPPT";
            // 
            // btnReset
            // 
            this.btnReset.Label = "Opnieuw stellen";
            this.btnReset.Name = "btnReset";
            this.btnReset.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnReset_Click);
            // 
            // btnSlideInfo
            // 
            this.btnSlideInfo.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSlideInfo.Label = "Dia informatie";
            this.btnSlideInfo.Name = "btnSlideInfo";
            this.btnSlideInfo.ShowImage = true;
            this.btnSlideInfo.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSlideInfo_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.WinQ);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.WinQ.ResumeLayout(false);
            this.WinQ.PerformLayout();
            this.GrpQuestionnaire.ResumeLayout(false);
            this.GrpQuestionnaire.PerformLayout();
            this.GrpResults.ResumeLayout(false);
            this.GrpResults.PerformLayout();
            this.grpSlide.ResumeLayout(false);
            this.grpSlide.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab WinQ;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnViewResultsPPT;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpResults;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpQuestionnaire;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown ddQuestions;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAllQuestions;
        public Microsoft.Office.Tools.Ribbon.RibbonDropDown ddExams;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpSlide;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSlideInfo;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnReset;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
