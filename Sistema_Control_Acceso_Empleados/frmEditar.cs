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

        public frmEditar(string nombre, string apellido, string correo)
        {
            InitializeComponent();
            HelperUi.RedondearBordes(this, 20);
            HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
            txtNombre.Text = nombre;
            txtApellidos.Text = apellido;
            txtCorreo.Text = correo;
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            NombreEditado = txtNombre.Text;
            ApellidoEditado = txtApellidos.Text;
            CorreoEditado = txtCorreo.Text;

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
