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
            string clave = txtClave.Text.Trim();
            string claveHash = BCrypt.Net.BCrypt.HashPassword(clave);
            var usuario = new Usuario
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellidos.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Contraseña = claveHash,
                Rol = "empleado"
            };

            var service = new UsuarioService();
            if (service.RegistrarUsuario(usuario))
                MessageBox.Show("Registro exitoso");
            else
                MessageBox.Show("Error en el registro");
        }
    }
}
