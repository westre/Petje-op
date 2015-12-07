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
            this.button2 = this.Factory.CreateRibbonButton();
            this.dropDown2 = this.Factory.CreateRibbonDropDown();
            this.dropDown1 = this.Factory.CreateRibbonDropDown();
            this.GrpResults = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.menu1 = this.Factory.CreateRibbonMenu();
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
            this.GrpQuestionnaire.Items.Add(this.button2);
            this.GrpQuestionnaire.Items.Add(this.dropDown2);
            this.GrpQuestionnaire.Items.Add(this.dropDown1);
            this.GrpQuestionnaire.Label = "Vragenlijst";
            this.GrpQuestionnaire.Name = "GrpQuestionnaire";
            // 
            // button2
            // 
            this.button2.Label = "Vragenlijst toevoegen";
            this.button2.Name = "button2";
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // dropDown2
            // 
            this.dropDown2.Label = "Afnamemomenten";
            this.dropDown2.Name = "dropDown2";
            this.dropDown2.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.dropDown2_SelectionChanged);
            // 
            // dropDown1
            // 
            this.dropDown1.Label = "Vragen";
            this.dropDown1.Name = "dropDown1";
            this.dropDown1.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.dropDown1_SelectionChanged);
            // 
            // GrpResults
            // 
            this.GrpResults.Items.Add(this.button1);
            this.GrpResults.Items.Add(this.menu1);
            this.GrpResults.Label = "Resultaten";
            this.GrpResults.Name = "GrpResults";
            // 
            // button1
            // 
            this.button1.Label = "Resulaten weergeven";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // menu1
            // 
            this.menu1.Label = "menu1";
            this.menu1.Name = "menu1";
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
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpResults;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpQuestionnaire;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown dropDown1;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown dropDown2;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
