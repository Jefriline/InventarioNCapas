using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class ConexionMYSQL : ConexionDB
    {
        private MySqlConnection connection;
        string cadenaConexion;

        public ConexionMYSQL()
        {
            cadenaConexion = "Database=" + database +
                              "; Datasource=" + server +
                              "; User Id=" + user +
                              "; Password=" + password;
            connection = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection Getconnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {

            }
            return connection;
        }
    }
}
