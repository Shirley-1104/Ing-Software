using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sistema_Control_Acceso_Empleados
{
    public static class HelperUi
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public static void HabilitarMovimiento(Form formulario, Control areaArrastre)
        {
            areaArrastre.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(formulario.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }
        public static void RedondearBordes(Form formulario, int radio)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(formulario.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(formulario.Width - radio, formulario.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, formulario.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();
            formulario.Region = new Region(path);
        }
        public static void AplicarBordeRedondeado(Form formulario, int radio, Color colorBorde, float grosorBorde = 2f)
        {
            formulario.Paint += (s, e) =>
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(0, 0, radio, radio, 180, 90);
                    path.AddArc(formulario.Width - radio, 0, radio, radio, 270, 90);
                    path.AddArc(formulario.Width - radio, formulario.Height - radio, radio, radio, 0, 90);
                    path.AddArc(0, formulario.Height - radio, radio, radio, 90, 90);
                    path.CloseFigure();

                    using (Pen pen = new Pen(colorBorde, grosorBorde))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }
    }
}
