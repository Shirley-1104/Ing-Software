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
    public class UsuarioService
    {
        public bool RegistrarUsuario(Usuario usuario)
        {
            try
            {
                using (var conn = BaseDatos.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO usuarios (nombre, apellido, correo, contraseña, rol)
                             VALUES (@nombre, @apellido, @correo, @contraseña, @rol);
                             SELECT LAST_INSERT_ID();";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@rol", usuario.Rol);

                    int nuevoUsuarioId = Convert.ToInt32(cmd.ExecuteScalar());

                    string codigoQR = Guid.NewGuid().ToString();
                    DateTime fechaGeneracion = DateTime.Now;

                    string insertQR = @"INSERT INTO codigos_qr(usuario_id, codigo, fecha_generacion, valido)
                                VALUES (@usuario_id, @codigo, @fecha_generacion, 1);";

                    var cmdQR = new MySqlCommand(insertQR, conn);
                    cmdQR.Parameters.AddWithValue("@usuario_id", nuevoUsuarioId);
                    cmdQR.Parameters.AddWithValue("@codigo", codigoQR);
                    cmdQR.Parameters.AddWithValue("@fecha_generacion", fechaGeneracion);

                    cmdQR.ExecuteNonQuery();
                    byte[] qrBytes = QrService.GenerarQRBytes(codigoQR);
                    EmailService.EnviarCorreoConQR(usuario.Correo, codigoQR, qrBytes);

                    return true;
                }
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }
        public Usuario AutenticarUsuario(string correo, string contraseña)
        {
            try
            {
                var conn = BaseDatos.GetConnection();
                conn.Open();

                string query = "SELECT * FROM usuarios WHERE correo = @correo";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@correo", correo);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string hash = reader["contraseña"].ToString();


                        if (BCrypt.Net.BCrypt.Verify(contraseña, hash))
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString(),
                                Correo = reader["correo"].ToString(),
                                Rol = reader["rol"].ToString()
                            };
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar usuario: " + ex.Message);
                return null;
            }
        }
    }
}
