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

        private int filaSeleccionada = -1;
        public frmEmpleados()
        {
            InitializeComponent();
            cargarDGV();
        }
        private void cargarDGV()
        {
            dgvEmpleados.ColumnCount = 4;

            dgvEmpleados.Columns[0].Name = "Id";
            dgvEmpleados.Columns[1].Name = "Nombre";
            dgvEmpleados.Columns[2].Name = "Apellido";
            dgvEmpleados.Columns[3].Name = "Correo";

            dgvEmpleados.Rows.Add(1,"Juan Manuel", "Zapata Olaya", "juan@gmail.com");
            dgvEmpleados.Rows.Add(2,"Camilo", "Rodriguez Beltran", "camilo@gmail.com");
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                dgvEmpleados.Rows.RemoveAt(filaSeleccionada);
                filaSeleccionada = -1;
                txtSeleccionado.Clear();
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
    }
}
