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
            MasterController MasterController = new MasterController();
            LoginView LoginView = new LoginView((LoginController)MasterController.GetController(typeof(LoginController)));
            DialogResult Login = LoginView.ShowDialog();
            if (Login == DialogResult.OK)
            {
                Application.Run(MasterController);
            }
            else
            {
                Application.Exit();
            }        
            
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
