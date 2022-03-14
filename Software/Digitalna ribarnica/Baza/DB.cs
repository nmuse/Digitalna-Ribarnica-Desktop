using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    /// <summary>
    /// Author: Nikola Muše
    /// Author: Anabela Pranjić
    /// Author: Božo Kvesić
    /// </summary>
    public class DB
    {

        private static DB instance;
        public static DB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DB();
                }

                return instance;
            }
        }

        public string ConnectionString { get; private set; }

        public SqlConnection Connection { get; private set; }

        private DB()
        {
            ConnectionString = @"Data Source = 31.147.204.119\PISERVER,1433; Initial Catalog = PI20_001_DB; User=PI20_001_User; Password='H;T&)d%q'";
            Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Nije moguće spajanje s bazom. Provjerite internetsku vezu!");
                System.Windows.Forms.Application.Exit();
            }
           
        }

        public void CloseConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
            }
        }

        public SqlDataReader DohvatiDataReader(string sqlUpit)
        {
            try
            {
                SqlCommand command = new SqlCommand(sqlUpit, Connection);
                return command.ExecuteReader();
            }
            catch (Exception)
            {

                System.Windows.Forms.Application.Exit();
            }
            SqlDataReader reader = null;
            return reader;
        }

        public object DohvatiVrijednost(string sqlUpit)
        {
            SqlCommand command = new SqlCommand(sqlUpit, Connection);
            return command.ExecuteScalar();
        }

        public int IzvrsiUpit(string sqlUpit)
        {
            try
            {
                SqlCommand command = new SqlCommand(sqlUpit, Connection);
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show("Nije moguće izbrisati korisnika koji ima kreirane ponude");
                return 0;
            }
       
        }

        public int ExecuteParamQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, Connection);
                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }
                return (int)command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }  
        }
    }
}
