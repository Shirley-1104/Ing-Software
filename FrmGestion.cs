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
    public partial class FrmGestion : Form
    {
        public FrmGestion()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            FrmAutorizacionManual formAut = new FrmAutorizacionManual();
            formAut.ShowDialog();
        }
    }
}
