using Sistema_Control_Acceso_Empleados.Models;
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
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
            HelperUi.RedondearBordes(this, 20);
            HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
        }

        private bool EsCorreoValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            HelperUi.HabilitarMovimiento(this, pnlHeader);
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellidos.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El campo de nombre no puede estar vacío.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("El campo de apellido no puede estar vacío.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return;
            }

            if (string.IsNullOrEmpty(correo))
            {
                MessageBox.Show("El campo de correo no puede estar vacío.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (!EsCorreoValido(correo))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacío.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }


            string claveHash = BCrypt.Net.BCrypt.HashPassword(clave);

            var usuario = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Contraseña = claveHash,
                Rol = "empleado"
            };

            var service = new UsuarioService();
            if (service.RegistrarUsuario(usuario))
            {
                MessageBox.Show("Registro exitoso. Se ha enviado un código QR a su correo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error en el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}