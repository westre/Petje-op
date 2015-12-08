using PetjeOp.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MasterController MasterController = new MasterController(); //Aanmaken van MasterController, het hoofdscherm
            // Login dialog laten zien en wachten op resultaat.
            LoginView LoginView = new LoginView((LoginController)MasterController.GetController(typeof(LoginController)));            
            if (LoginView.ShowDialog() == DialogResult.OK) //Als login dialog OK returnt dan MasterController uitvoeren
            {
                //MasterController runnen als hoofdapplicaties
                Application.Run(MasterController); 
            }
            else
            {
                //Als login dialog iets anders dan OK returnt dan sluit hij de applicatie af, dus o.a. bij sluiten
                Application.Exit(); 
            }        
            
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
