using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;

namespace PetjeOpPowerPoint
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.SlideSelectionChanged += Application_SlideSelectionChanged;
        }

        private void Application_SlideSelectionChanged(PowerPoint.SlideRange SldRange) {
            PowerPoint.Slide slide = Application.ActivePresentation.Slides.FindBySlideID(SldRange.SlideID);

            if(slide.Tags["questionId"] != null && slide.Tags["questionId"].Length > 0)
                System.Windows.Forms.MessageBox.Show(slide.Tags["questionId"]);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Application.SlideSelectionChanged -= Application_SlideSelectionChanged;
        }

        void Application_PresentationNewSlide(PowerPoint.Slide Sld)
        {
          
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            this.Application.PresentationNewSlide += new PowerPoint.EApplication_PresentationNewSlideEventHandler(Application_PresentationNewSlide);
        }

        #endregion
    }
}
