using Sistema_Control_Acceso_Empleados.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Control_Acceso_Empleados
{
    public partial class frmQR : Form
    {
        private CamaraService camara;
        public frmQR()
        {
            InitializeComponent();
            HelperUi.RedondearBordes(this, 20);
            HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
            camara = new CamaraService();
        }

        private void btnIgnorar_Click(object sender, EventArgs e)
        {
            FrmHistorial historial = new FrmHistorial();
            historial.Show();
            this.Hide();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            FrmHistorial historial = new FrmHistorial();
            historial.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            HelperUi.HabilitarMovimiento(this, pnlHeader);
        }

        private void btnCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void pbScanner_Click(object sender, EventArgs e)
        {

        }

        private void frmQR_Load(object sender, EventArgs e)
        {
            if (!camara.Iniciar())
            {
                MessageBox.Show("No se encontró una cámara.");
                return;
            }

            camara.FrameRecibido += frame =>
            {
                pbScanner.Image = frame;
            };

            camara.CodigoDetectado += codigo =>
            {
                Invoke(new Action(() =>
                {
                    lblQR.Text = codigo;
                    camara.Detener();
                    var usuario = UsuarioActual.UsuarioLogueado;
                    if (usuario == null)
                    {
                        MessageBox.Show("No hay un usuario autenticado.");
                        return;
                    }

                    var qrValido = QrService.ValidarCodigoQR(usuario.Id, codigo);

                    if (qrValido)
                    {
                        MessageBox.Show("Acceso permitido. Código válido.");
                    }
                    else
                    {
                        MessageBox.Show("Acceso denegado. Código QR inválido o no corresponde al usuario.");
                    }
                }));
            };
        }
    }
}
