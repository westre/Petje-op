using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PetjeOp {
    public class YoranHierKijken {
        public YoranHierKijken() {
            DatabaseListener changeListener = new DatabaseListener();
            changeListener.TrackedQuery = "SELECT name FROM [dbo].[test_table_pls_ignore]";
            changeListener.OnChange += ChangeListener_OnChange;
            changeListener.Start();
        }

        private void ChangeListener_OnChange(SqlNotificationEventArgs eventArgs) {
            Console.WriteLine("Record changed: " + eventArgs.Info + ", " + eventArgs.Source + ", " + eventArgs.Type);
        }
    }
}
