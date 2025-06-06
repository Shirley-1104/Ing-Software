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
            try
            {
                lectorQR = new BarcodeReader();
                Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al inicializar CamaraService: " + ex.Message);
            }
        }

        public List<string> ObtenerCamarasDisponibles()
        {
            List<string> camaras = new List<string>();
            try
            {
                Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                for (int i = 0; i < Dispositivos.Count; i++)
                {
                    camaras.Add(Dispositivos[i].Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener cámaras: " + ex.Message);
            }
            return camaras;
        }

        public bool Iniciar()
        {
            return Iniciar(0);
        }

        public bool Iniciar(int deviceIndex)
        {
            try
            {
                Detener();

                Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (Dispositivos.Count == 0 || deviceIndex >= Dispositivos.Count || deviceIndex < 0)
                    return false;

                FuenteVideo = new VideoCaptureDevice(Dispositivos[deviceIndex].MonikerString);
                FuenteVideo.NewFrame += (sender, args) =>
                {
                    try
                    {
                        Bitmap frameParaMostrar = (Bitmap)args.Frame.Clone();
                        Bitmap frameParaDecodificar = (Bitmap)args.Frame.Clone();
                        FrameRecibido?.Invoke(frameParaMostrar);
                        var resultado = lectorQR.Decode(frameParaDecodificar);
                        if (resultado != null)
                        {
                            CodigoDetectado?.Invoke(resultado.Text);
                        }
                        frameParaDecodificar.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al procesar frame: " + ex.Message);
                    }
                };
                FuenteVideo.Start();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar cámara: " + ex.Message);
                return false;
            }
        }

        public void Detener()
        {
            try
            {
                if (FuenteVideo != null && FuenteVideo.IsRunning)
                    FuenteVideo.SignalToStop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al detener cámara: " + ex.Message);
            }
        }
    }
}