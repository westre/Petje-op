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
        public bool Subscribed { get; set; }

        public delegate void TrackedChangedHandler(SqlNotificationEventArgs eventArgs);
        public event TrackedChangedHandler OnChange;

        private SqlDependency dependency;
        public DatabaseListener() {
            ConnectionString = Properties.Settings.Default.kbs2ConnectionLiveString;

            // Altijd zeker van zijn
            SqlDependency.Stop(ConnectionString);
            SqlDependency.Start(ConnectionString);

            // Maak nieuwe connectie
            Connection = new SqlConnection(ConnectionString);
        }

        public void Start() {
            // Hebben we een query
            if (TrackedQuery.Length > 0) {
                // Maak een nieuwe command aan
                var command = new SqlCommand(TrackedQuery, Connection) {
                    Notification = null
                };

                // Dependency aanmaken die wordt afgevuurd wanneer er ook maar iets wordt veranderd aan de resultaten van de query
                dependency = new SqlDependency(command);
                dependency.OnChange += TrackedChanged;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                // Query uitvoeren
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                Connection.Close();

                Subscribed = true;
            }
        }
        public void Stop()
        {
            if(Subscribed) {
                dependency.OnChange -= TrackedChanged;
                Subscribed = false;
            } 
        }

        void TrackedChanged(object sender, SqlNotificationEventArgs e) {
            var dependency = sender as SqlDependency;

            // Het is een single-fire event, dus moeten we eerst unsubscriben
            if (dependency != null)
                dependency.OnChange -= TrackedChanged;

            // Hebben we subscribers?
            if (OnChange != null) {
                // Dan geven we een notificatie aan al onze subscribers
                OnChange(e);

                // Dan subscriben we weer aan de dependency
                Start();
            }
        }
    }
}
