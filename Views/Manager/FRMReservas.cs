using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MC_Reservas_Hotel.Controllers;
using MC_Reservas_Hotel.Models;

namespace MC_Reservas_Hotel.Views.Manager
{
    public partial class FRMReservas : Form
    {
        private ReservasController controller = new ReservasController();
        private ClientesController clientesController = new ClientesController();
        private HabitacionesController habitacionesController = new HabitacionesController();

        private int idSeleccionado = -1;
        private bool haySeleccion = false;

        public FRMReservas()
        {
            InitializeComponent();
            dgvReservas.CellClick += dgvReservas_CellClick;
            txtNumeroHabitacion.TextChanged += txtNumeroHabitacion_TextChanged;
            cbEstado.SelectedIndexChanged += cbEstado_SelectedIndexChanged;
            cbNombreCliente.SelectedIndexChanged += cbNombreCliente_SelectedIndexChanged;
            dtpFechaEntrada.ValueChanged += (_, __) => ActualizarEstadoBotones();
            dtpFechaSalida.ValueChanged += (_, __) => ActualizarEstadoBotones();
        }

        private void FRMReservas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarEstados();
            CargarReservas();
        }

        private void CargarClientes()
        {
            var clientes = clientesController.ObtenerClientes();
            cbNombreCliente.DataSource = clientes;
            cbNombreCliente.DisplayMember = "Nombre";
            cbNombreCliente.ValueMember = "IdCliente";
            cbNombreCliente.SelectedIndex = -1;
        }

        private void CargarEstados()
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add("Activa");
            cbEstado.Items.Add("Finalizada");
            cbEstado.SelectedIndex = -1;
        }

        private void CargarReservas()
        {
            dgvReservas.DataSource = controller.ObtenerReservas();
            dgvReservas.Columns["IdReserva"].Visible = false;
            dgvReservas.Columns["IdCliente"].Visible = false;
            dgvReservas.Columns["IdHabitacion"].Visible = false;
        }

        private void cbNombreCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNombreCliente.SelectedIndex != -1)
            {
                var cliente = cbNombreCliente.SelectedItem as ClientesModel;

                if (cliente != null)
                {
                    int idCliente = cliente.IdCliente;
                    var habitacion = controller.ObtenerHabitacionPorCliente(idCliente);

                    if (habitacion != null)
                    {
                        txtNumeroHabitacion.Text = habitacion.NumeroHabitacion;
                        txtNumeroHabitacion.Tag = habitacion.IdHabitacion;
                    }
                    else
                    {
                        txtNumeroHabitacion.Clear();
                        txtNumeroHabitacion.Tag = null;
                    }
                }
            }

            ActualizarEstadoBotones();
        }

        private void txtNumeroHabitacion_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotones();
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotones();
        }

        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            if (cbNombreCliente.SelectedIndex == -1 || string.IsNullOrEmpty(txtNumeroHabitacion.Text) || cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idCliente = Convert.ToInt32(cbNombreCliente.SelectedValue);

            // Obtener el id real de la habitación a partir de su número
            int idHabitacion = habitacionesController.ObtenerIdPorNumero(txtNumeroHabitacion.Text);

            if (idHabitacion == 0)
            {
                MessageBox.Show("Número de habitación inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReservasModel reserva = new ReservasModel
            {
                IdCliente = idCliente,
                IdHabitacion = idHabitacion,
                FechaEntrada = dtpFechaEntrada.Value,
                FechaSalida = dtpFechaSalida.Value,
                Estado = cbEstado.SelectedItem.ToString()
            };

            bool insertado = controller.InsertarReserva(reserva);

            if (insertado)
            {
                MessageBox.Show("Reserva agregada con éxito.");
                CargarReservas();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar la reserva.");
            }
        }

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvReservas.Rows[e.RowIndex];

                idSeleccionado = Convert.ToInt32(fila.Cells["IdReserva"].Value);
                cbNombreCliente.SelectedValue = Convert.ToInt32(fila.Cells["IdCliente"].Value);
                txtNumeroHabitacion.Text = fila.Cells["NumeroHabitacion"].Value.ToString();
                txtNumeroHabitacion.Tag = fila.Cells["IdHabitacion"].Value;
                dtpFechaEntrada.Value = Convert.ToDateTime(fila.Cells["FechaEntrada"].Value);
                dtpFechaSalida.Value = Convert.ToDateTime(fila.Cells["FechaSalida"].Value);
                cbEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();

                haySeleccion = true;
                ActualizarEstadoBotones();
            }
        }

        private void btnEditarReserva_Click(object sender, EventArgs e)
        {
            if (!haySeleccion || idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione una reserva primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID de la habitación actualizada a partir del número escrito
            int idHabitacionActualizado = habitacionesController.ObtenerIdPorNumero(txtNumeroHabitacion.Text);

            if (idHabitacionActualizado == 0)
            {
                MessageBox.Show("Número de habitación inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReservasModel actualizada = new ReservasModel
            {
                IdReserva = idSeleccionado,
                IdCliente = Convert.ToInt32(cbNombreCliente.SelectedValue),
                IdHabitacion = idHabitacionActualizado, // Usar el nuevo ID
                FechaEntrada = dtpFechaEntrada.Value,
                FechaSalida = dtpFechaSalida.Value,
                Estado = cbEstado.SelectedItem?.ToString()
            };

            if (controller.ActualizarReserva(actualizada))
            {
                MessageBox.Show("Reserva actualizada correctamente.");
                CargarReservas();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar la reserva.");
            }
        }

        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            if (!haySeleccion || idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione una reserva para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar esta reserva?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                if (controller.EliminarReserva(idSeleccionado))
                {
                    MessageBox.Show("Reserva eliminada.");
                    CargarReservas();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la reserva.");
                }
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalirReserva_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimpiarCampos()
        {
            cbNombreCliente.SelectedIndex = -1;
            txtNumeroHabitacion.Clear();
            txtNumeroHabitacion.Tag = null;
            dtpFechaEntrada.Value = DateTime.Today;
            dtpFechaSalida.Value = DateTime.Today;
            cbEstado.SelectedIndex = -1;
            idSeleccionado = -1;
            haySeleccion = false;

            ActualizarEstadoBotones();
        }
        private void ActualizarEstadoBotones()
        {
            bool camposLlenos = cbNombreCliente.SelectedIndex != -1 &&
                                   !string.IsNullOrWhiteSpace(txtNumeroHabitacion.Text) &&
                                   cbEstado.SelectedIndex != -1 &&
                                   dtpFechaEntrada.Value.Date <= dtpFechaSalida.Value.Date;

            btnAgregarReserva.Enabled = camposLlenos && !haySeleccion;
            btnEditarReserva.Enabled = haySeleccion;
            btnEliminarReserva.Enabled = haySeleccion;
            btnCancelarReserva.Enabled = haySeleccion || camposLlenos;
        }


    }
}
