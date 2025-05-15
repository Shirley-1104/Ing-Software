using AForge.Video.DirectShow;
using ZXing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Control_Acceso_Empleados.Services
{
    public class CamaraService
    {
        public FilterInfoCollection Dispositivos { get; private set; }
        public VideoCaptureDevice FuenteVideo { get; private set; }
        public event Action<Bitmap> FrameRecibido;
        public event Action<string> CodigoDetectado;

        private readonly BarcodeReader lectorQR;

        public CamaraService()
        {
            lectorQR = new BarcodeReader();
            Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        public bool Iniciar()
        {
            if (Dispositivos.Count == 0)
                return false;

            FuenteVideo = new VideoCaptureDevice(Dispositivos[0].MonikerString);
            FuenteVideo.NewFrame += (sender, args) =>
            {
                try
                {
                    // Clona el frame original
                    Bitmap frameParaMostrar = (Bitmap)args.Frame.Clone();
                    Bitmap frameParaDecodificar = (Bitmap)args.Frame.Clone();

                    // Mostrar en PictureBox
                    FrameRecibido?.Invoke(frameParaMostrar);

                    // Intentar decodificar
                    var resultado = lectorQR.Decode(frameParaDecodificar);
                    if (resultado != null)
                    {
                        CodigoDetectado?.Invoke(resultado.Text);
                    }

                    frameParaDecodificar.Dispose();
                }
                catch (Exception ex)
                {
                    // Por si se produce otra excepción, evitar que crashee la app
                    Console.WriteLine("Error al procesar frame: " + ex.Message);
                }
            };

            FuenteVideo.Start();
            return true;
        }

        public void Detener()
        {
            if (FuenteVideo != null && FuenteVideo.IsRunning)
                FuenteVideo.SignalToStop();
        }
    }
}
