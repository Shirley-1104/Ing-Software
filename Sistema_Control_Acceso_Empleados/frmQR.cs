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
            try
            {
                HelperUi.RedondearBordes(this, 20);
                HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
                camara = new CamaraService();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar: " + ex.Message);
            }
        }

        private void btnIgnorar_Click(object sender, EventArgs e)
        {
            try
            {
                camara?.Detener();
                FrmHistorial historial = new FrmHistorial();
                historial.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            try
            {
                camara?.Detener();
                FrmHistorial historial = new FrmHistorial();
                historial.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                camara?.Detener();
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                HelperUi.HabilitarMovimiento(this, pnlHeader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                camara?.Detener();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pbScanner_Click(object sender, EventArgs e)
        {
        }

        private void frmQR_Load(object sender, EventArgs e)
        {
            try
            {
                var camarasDisponibles = camara.ObtenerCamarasDisponibles();

                comboBox1.Items.Clear();
                foreach (var nombreCamara in camarasDisponibles)
                {
                    comboBox1.Items.Add(nombreCamara);
                }

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    IniciarCamara();
                }
                else
                {
                    MessageBox.Show("No se encontró una cámara.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }

        private void IniciarCamara()
        {
            try
            {
                int indiceCamara = comboBox1.SelectedIndex;

                camara.FrameRecibido -= OnFrameRecibido;
                camara.CodigoDetectado -= OnCodigoDetectado;

                if (!camara.Iniciar(indiceCamara))
                {
                    MessageBox.Show("No se pudo iniciar la cámara.");
                    return;
                }


                camara.FrameRecibido += OnFrameRecibido;
                camara.CodigoDetectado += OnCodigoDetectado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar cámara: " + ex.Message);
            }
        }

        private void OnFrameRecibido(Bitmap frame)
        {
            try
            {
                pbScanner.Image = frame;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error frame: " + ex.Message);
            }
        }

        private void OnCodigoDetectado(string codigo)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    try
                    {
                        camara.Detener();
                        var usuario = UsuarioActual.UsuarioLogueado;
                        if (usuario == null)
                        {
                            MessageBox.Show("No hay un usuario autenticado.");
                            Task.Delay(1000).ContinueWith(_ => Invoke(new Action(() => IniciarCamara())));
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
                            Task.Delay(1000).ContinueWith(_ => Invoke(new Action(() => IniciarCamara())));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar QR: " + ex.Message);
                        Task.Delay(1000).ContinueWith(_ => Invoke(new Action(() => IniciarCamara())));
                    }
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error código detectado: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    IniciarCamara();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar cámara: " + ex.Message);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                camara?.Detener();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar: " + ex.Message);
            }
            base.OnFormClosed(e);
        }
    }
}