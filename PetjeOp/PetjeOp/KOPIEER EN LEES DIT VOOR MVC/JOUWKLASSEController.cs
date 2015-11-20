using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp {
    public class JOUWKLASSEController : Controller {
        public JOUWKLASSEView View { get; set; }
        public JOUWKLASSEModel Model { get; set; }

        public JOUWKLASSEController(MasterController masterController) : base(masterController) {
            Model = new JOUWKLASSEModel();
            View = new JOUWKLASSEView(this);
        }
    }
}
