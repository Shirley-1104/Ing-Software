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
                Bitmap frame = (Bitmap)args.Frame.Clone();
                FrameRecibido?.Invoke(frame);

                var resultado = lectorQR.Decode(frame);
                if (resultado != null)
                    CodigoDetectado?.Invoke(resultado.Text);
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
