using Sistema_Control_Acceso_Empleados.Models;
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
    public partial class frmEmpleados : Form

    {
        private List<Usuario> listaUsuarios = new List<Usuario>();
        private UsuarioService usuarioService = new UsuarioService();

        private int filaSeleccionada = -1;
        public frmEmpleados()
        {
            InitializeComponent();
            CargarEmpleados();
            HelperUi.RedondearBordes(this, 20);
            HelperUi.AplicarBordeRedondeado(this, 20, Color.FromArgb(45, 45, 48), 10f);
        }
        private void CargarEmpleados()
        {
            listaUsuarios = usuarioService.ObtenerUsuariosEmpleados();
            dgvEmpleados.DataSource = listaUsuarios;
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                DialogResult confirmacion = MessageBox.Show(
            "¿Estás seguro de que deseas eliminar este empleado?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

                if (confirmacion == DialogResult.Yes)
                {
                    dgvEmpleados.Rows.RemoveAt(filaSeleccionada);
                    filaSeleccionada = -1;
                    txtSeleccionado.Clear();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila primero.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                DataGridViewRow fila = dgvEmpleados.Rows[filaSeleccionada];
                string nombre = fila.Cells[1].Value?.ToString();
                string apellido = fila.Cells[2].Value?.ToString();
                string correo = fila.Cells[3].Value?.ToString();

                frmEditar editor = new frmEditar(nombre, apellido, correo);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    fila.Cells[1].Value = editor.NombreEditado;
                    fila.Cells[2].Value = editor.ApellidoEditado;
                    fila.Cells[3].Value = editor.CorreoEditado;
                }
            }
            else
            {
                MessageBox.Show("Selecciona un empleado primero.");
            }
        }

        private void btnAccesos_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                DataGridViewRow fila = dgvEmpleados.Rows[filaSeleccionada];
                string id = fila.Cells[0].Value?.ToString();
                string nombre = fila.Cells[1].Value?.ToString();

                frmGestionAcceso ventana = new frmGestionAcceso(id, nombre);
                ventana.ShowDialog(); // o .Show() si quieres no modal
            }
            else
            {
                MessageBox.Show("Selecciona un empleado primero.");
            }
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filaSeleccionada = e.RowIndex;
                DataGridViewRow fila = dgvEmpleados.Rows[e.RowIndex];
                string nombre = fila.Cells[1].Value?.ToString();
                string apellido = fila.Cells[2].Value?.ToString();
                txtSeleccionado.Text = $"{nombre} {apellido}";
            }
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
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

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
