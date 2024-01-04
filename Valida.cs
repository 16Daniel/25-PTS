using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _25_PUNTOS
{
    class Valida
    {
        //Conexion SQL
        SqlConnection cnn;
        Conexion dirCon = new Conexion();
        
        
        public bool VerifyConnection()
        {
            cnn = dirCon.crearConexion();
           
            try
            {
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
