using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PetjeOp {
    public class DatabaseListener {
        private string ConnectionString { get; set; }
        private SqlConnection Connection { get; set; }
        public string TrackedQuery { get; set; }

        public delegate void TrackedChangedHandler(SqlNotificationEventArgs eventArgs);
        public event TrackedChangedHandler OnChange;

        public DatabaseListener() {
            ConnectionString = "Data Source=176.31.253.42,119;Initial Catalog=kbs2;User ID=kbs2_live;Password=12";

            SqlDependency.Stop(ConnectionString);
            SqlDependency.Start(ConnectionString);

            Connection = new SqlConnection(ConnectionString);
        }

        public void Start() {
            if (TrackedQuery.Length > 0) {
                var command = new SqlCommand(TrackedQuery, Connection) {
                    Notification = null
                };

                var dependency = new SqlDependency(command);
                dependency.OnChange += TrackedChanged;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                Connection.Close();
            }
            else {
                Console.WriteLine("ERROR: Geen tracked query gevonden");
            }
        }

        void TrackedChanged(object sender, SqlNotificationEventArgs e) {
            var dependency = sender as SqlDependency;

            if (dependency != null)
                dependency.OnChange -= TrackedChanged;

            if (OnChange != null) {
                OnChange(e);
                Start();
            }
        }
    }
}
