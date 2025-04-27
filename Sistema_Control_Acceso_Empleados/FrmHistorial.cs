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
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }
    }
}
