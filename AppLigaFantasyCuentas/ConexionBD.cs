using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using System.Data.SqlClient;


namespace AppLigaFantasyCuentas
{
    public class ConexionBD
    {
        private SQLiteConnection miConexionSql;

        public ConexionBD()
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            miConexionSql = new SQLiteConnection(cadena);
        }

        public SQLiteConnection ObtenerConexion()
        {
            return miConexionSql;
        }

    }
}
