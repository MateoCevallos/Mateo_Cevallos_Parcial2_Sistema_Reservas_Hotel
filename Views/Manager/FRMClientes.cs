using MC_Reservas_Hotel.Controllers;
using MC_Reservas_Hotel.Models;
using System;
using System.Windows.Forms;

namespace MC_Reservas_Hotel.Views.Manager
{
    public partial class FRMClientes : Form
    {
        private ClientesController controller = new ClientesController();
        private int idSeleccionado = -1;

        public FRMClientes()
        {
            InitializeComponent();
            CargarClientes();
            LimpiarCampos();

            txtNombre.TextChanged += (s, e) => ActualizarEstadoBotones();
            txtCedula.TextChanged += (s, e) => ActualizarEstadoBotones();
            txtTelefono.TextChanged += (s, e) => ActualizarEstadoBotones();
            txtEmail.TextChanged += (s, e) => ActualizarEstadoBotones();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = controller.ObtenerClientes();
            dgvClientes.ClearSelection();
            ActualizarEstadoBotones();
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            idSeleccionado = -1;
            dgvClientes.ClearSelection();
            ActualizarEstadoBotones();
        }

        private void ActualizarEstadoBotones()
        {
            bool haySeleccion = idSeleccionado != -1;

            bool todosCamposLlenos =
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtCedula.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text);

            bool hayDatos = !string.IsNullOrWhiteSpace(txtNombre.Text) ||
                            !string.IsNullOrWhiteSpace(txtCedula.Text) ||
                            !string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                            !string.IsNullOrWhiteSpace(txtEmail.Text);

            btnAgregarCliente.Enabled = !haySeleccion && todosCamposLlenos;
            btnEditarCliente.Enabled = haySeleccion && todosCamposLlenos;
            btnEliminarCliente.Enabled = haySeleccion;
            btnCancelarCliente.Enabled = haySeleccion || hayDatos;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            var cliente = new ClientesModel
            {
                Nombre = txtNombre.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            if (controller.InsertarCliente(cliente))
            {
                MessageBox.Show("Cliente agregado correctamente.");
                CargarClientes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar cliente.");
            }
        }
        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un cliente para editar.");
                return;
            }

            var cliente = new ClientesModel
            {
                IdCliente = idSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            if (controller.ActualizarCliente(cliente))
            {
                MessageBox.Show("Cliente actualizado correctamente.");
                CargarClientes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar cliente.");
            }
        }
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un cliente para eliminar.");
                return;
            }

            var confirmar = MessageBox.Show("¿Estás seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                if (controller.EliminarCliente(idSeleccionado))
                {
                    MessageBox.Show("Cliente eliminado.");
                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar cliente.");
                }
            }
        }

        private void btnSalirCliente_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value);
                txtNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtCedula.Text = dgvClientes.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                txtTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtEmail.Text = dgvClientes.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                ActualizarEstadoBotones();
            }
        }
        private void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}