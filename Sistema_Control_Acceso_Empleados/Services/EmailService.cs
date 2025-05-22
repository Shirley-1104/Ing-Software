using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Control_Acceso_Empleados.Services
{
    public static class EmailService
    {
        public static void EnviarCorreoConQR(string destino, string qrCodeTexto, byte[] qrBytes)
        {
            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress("ccreyb@gmail.com");
            mensaje.To.Add(destino);
            mensaje.Subject = "Tu código QR de acceso";
            mensaje.Body = "Adjunto encontrarás tu código QR para ingresar al sistema.";

            using (MemoryStream ms = new MemoryStream(qrBytes))
            {
                Attachment adjunto = new Attachment(ms, "codigo_qr.png", "image/png");
                mensaje.Attachments.Add(adjunto);

                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                cliente.Credentials = new NetworkCredential("ccreyb@gmail.com", "ootc altw qido lryb");
                cliente.EnableSsl = true;

                cliente.Send(mensaje);
            }
        }
    }
}
