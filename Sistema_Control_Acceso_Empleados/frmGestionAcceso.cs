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
    public partial class frmGestionAcceso : Form
    {
        private int _idUsuario;
        public frmGestionAcceso(int id, string nombre)
        {
            _idUsuario = id;
            InitializeComponent();
            CargarDgv();
            HelperUi.RedondearBordes(this, 20);
            HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
            lblTitulo.Text = $"Historial de acceso de: {nombre}";
        }
        private void CargarDgv()
        {
            try
            {
                var tabla = AccesoService.ObtenerAccesosPorUsuario(_idUsuario);
                dgvHistorial.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message);
            }
        }

        private void frmGestionAcceso_Load(object sender, EventArgs e)
        {

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
