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
    public partial class frmGestionAcceso : Form
    {
        public frmGestionAcceso(string id, string nombre)
        {
            InitializeComponent();
            CargarDgv();
            lblTitulo.Text = $"Historial de acceso de: {nombre}";
        }
        private void CargarDgv()
        {
            dgvHistorial.ColumnCount = 3;
            dgvHistorial.Columns[0].Name = "Fecha";
            dgvHistorial.Columns[1].Name = "Tipo de Acceso";
            dgvHistorial.Columns[2].Name = "Motivo";

            dgvHistorial.Rows.Add(DateTime.Now.ToString(), "QR", "-");
            dgvHistorial.Rows.Add(DateTime.Now.AddDays(-1).ToString(), "Manual", "Ingreso por contingencia");
        }
       
    }
}
