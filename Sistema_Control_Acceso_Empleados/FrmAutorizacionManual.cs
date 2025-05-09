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
    public partial class FrmAutorizacionManual : Form
    {
        public FrmAutorizacionManual()
        {
            InitializeComponent();
            HelperUi.RedondearBordes(this, 20);
            HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
        }


        private void txtCorreoUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmAutorizacionManual_Load(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void btnAutorizar_Click_1(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string motivo = txtMotivo.Text.Trim();
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
