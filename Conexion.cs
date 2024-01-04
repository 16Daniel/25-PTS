using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace _25_PUNTOS
{
    class Conexion
    {
        public SqlConnection crearConexion()
        {
            //SqlConnection conexion = new SqlConnection("Data Source=192.168.1.3;Initial Catalog=UAQUERETARO;User Id=sa;Password=masterkey");
            SqlConnection conexion = new SqlConnection(ConfigurationManager.AppSettings["conexion"]);

            //SqlConnection conexion = new SqlConnection("Data Source=APLLAP;Initial Catalog=UAQUERETARO;User Id=sa;Password=masterkey");
            return conexion;
        }
    }
}
