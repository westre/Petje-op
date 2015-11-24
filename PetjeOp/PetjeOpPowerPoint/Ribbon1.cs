using System;
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
            //PowerPoint.Shape textBox = currentSld.Shapes.AddTextbox(
            //   Office.MsoTextOrientation.msoTextOrientationHorizontal, 250, 250, 500, 50);
            //textBox.TextFrame.TextRange.InsertAfter("Deze dia is toegevoegd met de knop");
            PowerPoint.Shape shape = currentSld.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 10, 10, 100, Convert.ToInt32(barHeight1));
            PowerPoint.Shape shape1 = currentSld.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 120, 10 + 300 - (int)barHeight2, 100, Convert.ToInt32(barHeight2));
            
            PowerPoint.Shape shape2 = currentSld.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 230, 10 + 300 - (int)barHeight3, 100, Convert.ToInt32(barHeight3));
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Questionnaire testquest = DB.GetQuestionnaire(1);
            if(testquest != null)
            {
                //Questionnaire testquest = new Questionnaire("test");
                MultipleChoiceQuestion testquestion = new MultipleChoiceQuestion("Wat is 1+1?");
                testquest.addQuestion(testquestion);
                MultipleChoiceQuestion testquestion1 = new MultipleChoiceQuestion("Wat is 2+2?");
                testquest.addQuestion(testquestion1);
                MultipleChoiceQuestion testquestion2 = new MultipleChoiceQuestion("Wat is 3+3?");
                testquest.addQuestion(testquestion2);
                MultipleChoiceQuestion testquestion3 = new MultipleChoiceQuestion("Wat is 4+4?");
                testquest.addQuestion(testquestion3);
            }
            else
            {
                //Error, geen data kunnen ophalen of andere db error
            }

            MultipleChoiceQuestion testquestion4 = DB.GetQuestion(1);
            if(testquestion4 != null)
            {
                testquest.addQuestion(testquestion4);
            }            

            foreach (Question q in testquest.Questions)
            {
                PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
                PowerPoint.Shape textBox = currentSld.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 250, 250, 500, 50);
                textBox.TextFrame.TextRange.InsertAfter(q.Description);
            }  
        }
    }
}
