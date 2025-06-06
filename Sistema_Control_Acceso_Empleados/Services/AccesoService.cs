using MySql.Data.MySqlClient;
using Sistema_Control_Acceso_Empleados.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sistema_Control_Acceso_Empleados.Services
{
    public class AccesoService
    {
        public static DataTable ObtenerAccesos()
        {
            var tabla = new DataTable();

            try
            {
                using (var conn = BaseDatos.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT u.nombre, u.apellido, a.fecha_hora, a.metodo, a.motivo, a.llego_tarde
                FROM accesos a
                INNER JOIN usuarios u ON a.usuario_id = u.id
                ORDER BY a.fecha_hora DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener accesos: " + ex.Message);
            }

            return tabla;
        }
        public static DataTable ObtenerAccesosPorUsuario(int usuarioId)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (var conn = BaseDatos.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT a.id, a.fecha_hora, a.metodo, a.motivo, a.llego_tarde,
                       u.nombre, u.apellido
                FROM accesos a
                INNER JOIN usuarios u ON a.usuario_id = u.id
                WHERE a.usuario_id = @usuarioId
                ORDER BY a.fecha_hora DESC;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            tabla.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener accesos por usuario: " + ex.Message);
            }

            return tabla;
        }
    }
}
