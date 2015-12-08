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
            this.btnAllQuestions = this.Factory.CreateRibbonButton();
            this.GrpResults = this.Factory.CreateRibbonGroup();
            this.btnViewResultsPPT = this.Factory.CreateRibbonButton();
            this.WinQ.SuspendLayout();
            this.GrpQuestionnaire.SuspendLayout();
            this.GrpResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // WinQ
            // 
            this.WinQ.Groups.Add(this.GrpQuestionnaire);
            this.WinQ.Groups.Add(this.GrpResults);
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
            // btnAllQuestions
            // 
            this.btnAllQuestions.Label = "Alle vragen toevoegen";
            this.btnAllQuestions.Name = "btnAllQuestions";
            this.btnAllQuestions.Visible = false;
            this.btnAllQuestions.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAllQuestions_Click);
            // 
            // GrpResults
            // 
            this.GrpResults.Items.Add(this.btnViewResultsPPT);
            this.GrpResults.Label = "Resultaten";
            this.GrpResults.Name = "GrpResults";
            this.GrpResults.Visible = false;
            // 
            // btnViewResultsPPT
            // 
            this.btnViewResultsPPT.Label = "Resulaten weergeven";
            this.btnViewResultsPPT.Name = "btnViewResultsPPT";
            this.btnViewResultsPPT.Visible = false;
            this.btnViewResultsPPT.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnViewResultsPPT_Click);
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
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
