using MySql.Data.MySqlClient;
using Sistema_Control_Acceso_Empleados.Data;
using Sistema_Control_Acceso_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Control_Acceso_Empleados.Services
{
    internal class UsuarioService
    {
        public bool RegistrarUsuario(Usuario usuario)
        {
            try
            {
                var conn = BaseDatos.GetConnection();
                conn.Open();

                string query = "INSERT INTO usuarios (nombre, apellido, correo, contraseña, rol) VALUES (@nombre, @apellido, @correo, @contraseña, @rol)";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) 
                {
                    MessageBox.Show("El correo ya está registrado. Usa otro.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al registrar usuario: " + ex.Message, "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }
            
        }
    }
}
