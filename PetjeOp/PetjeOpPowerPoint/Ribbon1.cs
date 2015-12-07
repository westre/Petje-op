﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;
using Office = Microsoft.Office.Core;
using PetjeOp;

namespace PetjeOpPowerPoint
{
    public partial class Ribbon1
    {
        private Database DB;
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            DB = new Database();


            // functie voor initialiseren dropdown Questions

            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem emptyQuestions = this.Factory.CreateRibbonDropDownItem();
            emptyQuestions.Label = "";
            ddQuestions.Items.Add(emptyQuestions);

            // functie voor vullen dropdown afnamemomenten
            
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem emptyExams = this.Factory.CreateRibbonDropDownItem();
            emptyExams.Label = "";
            ddExams.Items.Add(emptyExams);

            List<Exam> exams = DB.GetExams();

            foreach (Exam x in exams)
            {
                Microsoft.Office.Tools.Ribbon.RibbonDropDownItem exam = this.Factory.CreateRibbonDropDownItem();
                exam.Label = "AFNAMEMOMENT: " + x.questionnaire.Name + ", VAK: " + x.questionnaire.Subject +  ", STARTTIJD: " +  Convert.ToString(x.starttime) + ", EINDTIJD: " + Convert.ToString(x.endtime);
                ddExams.Items.Add(exam);
                
                int index = ddExams.Items.IndexOf(exam);
                ddExams.Items[index].Tag = x;
                
            }



           

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            double barHeight = 300;

            double percentage1 = 1.00;
            double barHeight1 = barHeight * percentage1;

            double percentage2 = 0.60;
            double barHeight2 = barHeight * percentage2;

            double percentage3 = 0.80;
            double barHeight3 = barHeight * percentage3;

            PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);

            PowerPoint.Shape shape = currentSld.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 10, 10, 100, Convert.ToInt32(barHeight1));
            PowerPoint.Shape shape1 = currentSld.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 120, 10 + 300 - (int)barHeight2, 100, Convert.ToInt32(barHeight2));

            PowerPoint.Shape shape2 = currentSld.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 230, 10 + 300 - (int)barHeight3, 100, Convert.ToInt32(barHeight3));
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {

            Questionnaire testquest = DB.GetQuestionnaire(5);
           
            foreach (Question q in testquest.Questions)
            {
                PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
                PowerPoint.Shape textBox = currentSld.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 200, 100, 500, 50);
                textBox.TextFrame.TextRange.InsertAfter(q.Description);
                textBox.TextFrame.TextRange.Font.Size = 30;
                
            }
        }

        private void btnLogo_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, RibbonControlEventArgs e)
        {
            
        }

        private void ddQuestions_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            
            Question question = (Question)ddQuestions.SelectedItem.Tag;
            PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
            PowerPoint.Shape textBox = currentSld.Shapes.AddTextbox(
            Office.MsoTextOrientation.msoTextOrientationHorizontal, 200, 100, 500, 50);
            textBox.TextFrame.TextRange.InsertAfter(question.Description);
            textBox.TextFrame.TextRange.Font.Size = 30;

        }

        private void ddExams_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            // functie voor vullen dropdown vragen
            ddQuestions.Items.Clear();
            btnAllQuestions.Visible = true;

            Exam chosen = (Exam)ddExams.SelectedItem.Tag;
            
      

            Questionnaire testquest = DB.GetQuestionnaire(chosen.questionnaire.ID);

            foreach (Question q in testquest.Questions)
            {
                Microsoft.Office.Tools.Ribbon.RibbonDropDownItem question = this.Factory.CreateRibbonDropDownItem();
                question.Label = q.Description;
                ddQuestions.Items.Add(question);
                int index = ddQuestions.Items.IndexOf(question);
                ddQuestions.Items[index].Tag = q;
            }
        }

        private void btnAllQuestions_Click(object sender, RibbonControlEventArgs e)
        {
            Exam chosen = (Exam)ddExams.SelectedItem.Tag;
            Questionnaire testquest = DB.GetQuestionnaire(chosen.questionnaire.ID);
            foreach (Question q in testquest.Questions)
            {
                PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
                PowerPoint.Shape textBox = currentSld.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 200, 100, 500, 50);
                textBox.TextFrame.TextRange.InsertAfter(q.Description);
                textBox.TextFrame.TextRange.Font.Size = 30;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }
    }
}
