using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp {
    public interface IEnvironment {
        Panel GetViewPanel();
        UserControl GetView();
        Panel GetHeaderPanel();
        Panel GetLogoutButton();
    }
}
