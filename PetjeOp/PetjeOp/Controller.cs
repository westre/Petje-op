using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp {
    public class Controller {
        public MasterController MasterController { get; set; }

        public Controller(MasterController masterController) {
            MasterController = masterController;
        }
    }
}
