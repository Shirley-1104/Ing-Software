using Sistema_Control_Acceso_Empleados.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Sistema_Control_Acceso_Empleados
{
    public partial class FrmLogin : Form
    {
       
        public FrmLogin()
        {
            InitializeComponent();
            HelperUi.RedondearBordes(this, 20);
            HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var usuarioService = new UsuarioService();
            string correo = txtCorreo.Text.Trim();
            string clave = txtClave.Text;

            var usuario = usuarioService.AutenticarUsuario(correo, clave);

            if (usuario != null)
            {
                MessageBox.Show("Bienvenido " + usuario.Nombre + " (" + usuario.Rol + ")");
                UsuarioActual.UsuarioLogueado = usuario;
                if (usuario.Rol == "admin")
                {
                    FrmGestion gestion = new FrmGestion();
                    gestion.Show();
                    this.Hide();
                }
                else
                {
                    frmQR frm = new frmQR();
                    frm.Show();
                    this.Hide();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblMensaje_Click(object sender, EventArgs e)
        {

        }

        private void lblCorreo_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(70, 140, 210);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(178, 34, 34);
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(139, 0, 0);
        }

        private void btnCerrar_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            HelperUi.HabilitarMovimiento(this, pnlHeader);
        }
    }
}
