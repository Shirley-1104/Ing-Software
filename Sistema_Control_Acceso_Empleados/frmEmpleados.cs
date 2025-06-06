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
            try
            {
                listaUsuarios = usuarioService.ObtenerUsuariosEmpleados();
                dgvEmpleados.DataSource = listaUsuarios;
            }catch(Exception ex)
            {
                MessageBox.Show($"Error al cargar los empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                int usuarioId = Convert.ToInt32(dgvEmpleados.Rows[filaSeleccionada].Cells[0].Value);
                string nombreCompleto = $"{dgvEmpleados.Rows[filaSeleccionada].Cells[1].Value} {dgvEmpleados.Rows[filaSeleccionada].Cells[2].Value}";

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea eliminar al empleado {nombreCompleto}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        if (usuarioService.EliminarUsuario(usuarioId))
                        {
                            MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarEmpleados();
                            txtSeleccionado.Text = "";
                            filaSeleccionada = -1;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                try
                {
                    Usuario usuarioSeleccionado = listaUsuarios[filaSeleccionada];

                    frmEditar editor = new frmEditar(
                        usuarioSeleccionado.Nombre,
                        usuarioSeleccionado.Apellido,
                        usuarioSeleccionado.Correo
                    );

                    if (editor.ShowDialog() == DialogResult.OK)
                    {
                        Usuario usuarioEditado = new Usuario
                        {
                            Id = usuarioSeleccionado.Id,
                            Nombre = editor.NombreEditado,
                            Apellido = editor.ApellidoEditado,
                            Correo = editor.CorreoEditado,
                            Rol = usuarioSeleccionado.Rol
                        };

                        if (editor.CambioContraseña)
                        {
                            usuarioEditado.Contraseña = editor.ContraseñaEditada;
                        }

                        if (usuarioService.EditarUsuario(usuarioEditado))
                        {
                            MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarEmpleados();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al editar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un empleado primero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAccesos_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                try
                {
                    Usuario usuarioSeleccionado = listaUsuarios[filaSeleccionada];
                    int usuarioId = usuarioSeleccionado.Id;
                    string nombreCompleto = $"{usuarioSeleccionado.Nombre} {usuarioSeleccionado.Apellido}";

                    // Abre el formulario de gestión de accesos y pasa el ID de usuario y nombre
                    frmGestionAcceso ventanaAccesos = new frmGestionAcceso(usuarioId, nombreCompleto);
                    ventanaAccesos.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir gestión de accesos: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un empleado primero.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
