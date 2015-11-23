using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;
using Office = Microsoft.Office.Core

namespace PetjeOpPowerPoint
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Windows[1].Selection.SlideRange[1].SlideIndex + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
            PowerPoint.Shape textBox = currentSld.Shapes.AddTextbox(
               Office.MsoTextOrientation.msoTextOrientationHorizontal, 250, 250, 500, 50);
            textBox.TextFrame.TextRange.InsertAfter("Deze dia is toegevoegd met de knop");





        }
    }
}
