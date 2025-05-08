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
    public partial class FrmHistorial : Form
    {
        public FrmHistorial()
        {
            InitializeComponent();
            HelperUi.RedondearBordes(this, 20);
            HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            // Crear columnas
            dgvHistorial.ColumnCount = 3;
            dgvHistorial.Columns[0].Name = "Fecha";
            dgvHistorial.Columns[1].Name = "Tipo de Acceso";
            dgvHistorial.Columns[2].Name = "Motivo";

            // Simular datos
            dgvHistorial.Rows.Add(DateTime.Now.ToString(), "QR", "-");
            dgvHistorial.Rows.Add(DateTime.Now.AddDays(-1).ToString(), "Manual", "Ingreso por contingencia");
            dgvHistorial.Rows.Add(DateTime.Now.AddDays(-1).ToString(), "Manual", "Ingreso por contingencia");
            dgvHistorial.Rows.Add(DateTime.Now.AddDays(-1).ToString(), "Manual", "Ingreso por contingencia");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            HelperUi.HabilitarMovimiento(this, pnlHeader);
        }

        private void FrmHistorial_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void btnCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
