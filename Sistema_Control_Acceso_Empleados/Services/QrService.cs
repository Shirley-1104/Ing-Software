    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZXing.QrCode.Internal;
    using QRCoder;
    using MySql.Data.MySqlClient;
    using Sistema_Control_Acceso_Empleados.Data;
    using System.Windows;

    namespace Sistema_Control_Acceso_Empleados.Services
    {
        public static class QrService
        {

            public static byte[] GenerarQRBytes(string contenido)
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
                using (Bitmap bitmap = qrCode.GetGraphic(20))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        return ms.ToArray(); 
                    }
                }
            }
            public static bool ValidarCodigoQR(int usuarioId, string codigoEscaneado)
            {
                try
                {
                    var conn = BaseDatos.GetConnection();
                    conn.Open();

                    string query = @"SELECT COUNT(*) FROM codigos_qr 
                             WHERE usuario_id = @usuarioId 
                             AND codigo = @codigo 
                             AND valido = 1";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                    cmd.Parameters.AddWithValue("@codigo", codigoEscaneado);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        string insert = @"INSERT INTO accesos (usuario_id, fecha_hora, metodo, motivo, llego_tarde) 
                                  VALUES (@usuarioId, @fechaHora, @metodo, NULL, @llegoTarde)";

                        var insertCmd = new MySqlCommand(insert, conn);
                        insertCmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                        insertCmd.Parameters.AddWithValue("@fechaHora", DateTime.Now);
                        insertCmd.Parameters.AddWithValue("@metodo", "qr");
                        insertCmd.Parameters.AddWithValue("@llegoTarde", false);

                        insertCmd.ExecuteNonQuery();

                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al validar Qr");
                    return false;
                }
            }
        }
    

    }
