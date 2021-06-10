using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace controlApp.Datos
{
    internal static class conexionMaestra
    {
        public static SqlConnection conexion = new SqlConnection(@"Data source = edwsilme-PC\SQLEXPRESS; Initial Catalog = USERSDB; Integrated Security=true");

        public static void abrir()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        public static void cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
