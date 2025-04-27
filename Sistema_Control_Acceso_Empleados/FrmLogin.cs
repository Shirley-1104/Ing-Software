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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string clave = txtClave.Text;

            if (correo == "admin@empresa.com" && clave == "1234")
            {
                FrmGestion gestion = new FrmGestion();
                gestion.Show();
                this.Hide();
            }
            else if (correo == "empleado@empresa.com" && clave == "1234")
            {
                FrmHistorial historial = new FrmHistorial();
                historial.Show();
                this.Hide();
            }
            else
            {
                lblMensaje.Text = "Correo o contraseña incorrectos.";
            }
        }
    }
}
