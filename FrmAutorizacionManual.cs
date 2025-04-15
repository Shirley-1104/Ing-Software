using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemControlAccesoEmpleados
{
    public partial class FrmAutorizacionManual : Form
    {
        public FrmAutorizacionManual()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreoUser.Text.Trim();
            string motivo = txtMotivo.Text.Trim();

            if (correo == "" || motivo == "")
            {
                lblResultado.Text = "Debe completar todos los campos.";
                lblResultado.ForeColor = Color.Red;
                return;
            }

            // Simular guardado en base de datos (más adelante lo implementamos de verdad)
            string fechaHora = DateTime.Now.ToString();

            lblResultado.ForeColor = Color.Green;
            lblResultado.Text = $"Acceso autorizado para {correo} el {fechaHora}";

            // Aquí iría el INSERT en la base de datos
        }
    }
}
