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
    public partial class frmEditar : Form
    {
        public string NombreEditado { get; private set; }
        public string ApellidoEditado { get; private set; }
        public string CorreoEditado { get; private set; }
        public string ContraseñaEditada { get; private set; }
        public bool CambioContraseña { get; private set; }

        public frmEditar(string nombre, string apellido, string correo)
        {
            InitializeComponent();
            HelperUi.RedondearBordes(this, 20);
            HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
            txtNombre.Text = nombre;
            txtApellidos.Text = apellido;
            txtCorreo.Text = correo;

            txtContraseña.Text = "";
            txtConfirmarContraseña.Text = "";
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Nombre, apellidos y correo son campos obligatorios.",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtContraseña.Text))
            {

                if (txtContraseña.Text != txtConfirmarContraseña.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

  
                string clave = txtContraseña.Text.Trim();
                ContraseñaEditada = BCrypt.Net.BCrypt.HashPassword(clave);
                CambioContraseña = true;
            }
            else
            {
                ContraseñaEditada = null;
                CambioContraseña = false;
            }

            NombreEditado = txtNombre.Text.Trim();
            ApellidoEditado = txtApellidos.Text.Trim();
            CorreoEditado = txtCorreo.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            HelperUi.HabilitarMovimiento(this, pnlHeader);
        }

        private void btnCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}