using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Control_Acceso_Empleados.Data
{
    internal class BaseDatos
    {
        private static string connectionString = "Server=yamanote.proxy.rlwy.net;Port=59831;Database=railway;Uid=root;Pwd=GuJxbaYqZBgnvBIvKMhwXmOjywCepGlG;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
