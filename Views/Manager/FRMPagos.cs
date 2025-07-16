using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MC_Reservas_Hotel.Controllers;
using MC_Reservas_Hotel.Models;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace MC_Reservas_Hotel.Views.Manager
{
    public partial class FRMPagos : Form
    {
        private PagosController controller = new PagosController();
        //private HabitacionesController habitacionesController = new HabitacionesController();
        //private ReservasController reservasController = new ReservasController();
        private int idSeleccionado = -1;
        private int idReservaSeleccionada = -1;

        public FRMPagos()
        {
            InitializeComponent();
            this.Load += FRMPagos_Load;

            // Eventos
            txtMontoPagado.TextChanged += (s, e) => ActualizarEstadoBotones();
            cbMetodoPago.SelectedIndexChanged += (s, e) => ActualizarEstadoBotones();
            cbCliente.SelectedIndexChanged += (s, e) => CargarReservaCliente();
            //this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbNombreCliente_SelectedIndexChanged);
            dgvPagos.CellClick += dgvPagos_CellClick;
        }

        private void FRMPagos_Load(object sender, EventArgs e)
        {
            cbMetodoPago.Items.Clear();
            cbMetodoPago.Items.AddRange(new[] { "Efectivo", "Tarjeta", "Transferencia" });
            cbMetodoPago.SelectedIndex = -1;

            cbCliente.DataSource = controller.ObtenerClientes();
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "IdCliente";
            cbCliente.SelectedIndex = -1;

            CargarClientes();
            CargarPagos();
            LimpiarCampos();
        }


        private void LimpiarCampos()
        {
            cbCliente.SelectedIndex = -1;
            dtpFechaPago.Value = DateTime.Now;
            txtMontoPagado.Clear();
            cbMetodoPago.SelectedIndex = -1;
            idSeleccionado = -1;
            idReservaSeleccionada = -1;
            dgvPagos.ClearSelection();
            ActualizarEstadoBotones();
        }

        private void ActualizarEstadoBotones()
        {
            bool haySeleccion = idSeleccionado != -1;
            bool hayDatos = cbCliente.SelectedIndex != -1 &&
                            !string.IsNullOrWhiteSpace(txtMontoPagado.Text) &&
                            cbMetodoPago.SelectedIndex != -1;

            btnAgregarPago.Enabled = !haySeleccion && hayDatos;
            btnEditarPago.Enabled = haySeleccion;
            btnEliminarPago.Enabled = haySeleccion;
            btnCancelarPago.Enabled = haySeleccion || hayDatos;
        }

        private void CargarPagos()
        {
            dgvPagos.DataSource = controller.ObtenerPagos();

            // Ocultar columnas no amigables
            dgvPagos.Columns["IdPago"].Visible = false;
            dgvPagos.Columns["IdReserva"].Visible = false;
            dgvPagos.Columns["NombreCliente"].DisplayIndex = 0;
            dgvPagos.Columns["MontoPagado"].DisplayIndex = 1;
            dgvPagos.Columns["MetodoPago"].DisplayIndex = 2;
            dgvPagos.Columns["FechaPago"].DisplayIndex = 3;

            dgvPagos.ClearSelection();
            ActualizarEstadoBotones();
        }
        private void CargarClientes()
        {
            List<ClientesModel> listaClientes = controller.ObtenerClientes();
            cbCliente.DataSource = listaClientes;
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "IdCliente";
        }
        private void CargarReservaCliente()
        {
            if (cbCliente.SelectedIndex != -1)
            {
                var clienteSeleccionado = cbCliente.SelectedItem as ClientesModel;
                if (clienteSeleccionado != null)
                {
                    int idCliente = clienteSeleccionado.IdCliente;
                    idReservaSeleccionada = controller.ObtenerUltimaReservaPorCliente(idCliente);

                    if (idReservaSeleccionada == -1)
                    {
                        MessageBox.Show("Este cliente no tiene una reserva asociada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    ActualizarEstadoBotones();
                }
            }
        }

        private void dgvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPagos.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdPago"].Value);
                idReservaSeleccionada = Convert.ToInt32(fila.Cells["IdReserva"].Value);

                string nombreCliente = fila.Cells["NombreCliente"].Value.ToString();
                cbCliente.SelectedIndex = cbCliente.FindStringExact(nombreCliente);

                dtpFechaPago.Value = Convert.ToDateTime(fila.Cells["FechaPago"].Value);
                txtMontoPagado.Text = fila.Cells["MontoPagado"].Value.ToString();
                cbMetodoPago.Text = fila.Cells["MetodoPago"].Value.ToString();

                ActualizarEstadoBotones();
            }
        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == -1)
            {
                MessageBox.Show("No se puede agregar el pago sin una reserva asociada.");
                return;
            }

            var pago = new PagosModel
            {
                IdReserva = idReservaSeleccionada,
                FechaPago = dtpFechaPago.Value,
                MontoPagado = decimal.Parse(txtMontoPagado.Text),
                MetodoPago = cbMetodoPago.Text
            };

            if (controller.InsertarPago(pago))
            {
                MessageBox.Show("Pago registrado correctamente.");
                CargarPagos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al registrar el pago.");
            }
        }

        private void btnEditarPago_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1 || idReservaSeleccionada == -1) return;

            var pago = new PagosModel
            {
                IdPago = idSeleccionado,
                IdReserva = idReservaSeleccionada,
                FechaPago = dtpFechaPago.Value,
                MontoPagado = decimal.Parse(txtMontoPagado.Text),
                MetodoPago = cbMetodoPago.Text
            };

            if (controller.ActualizarPago(pago))
            {
                MessageBox.Show("Pago actualizado.");
                CargarPagos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el pago.");
            }
        }

        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1) return;

            var confirmar = MessageBox.Show("¿Estás seguro de eliminar este pago?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                if (controller.EliminarPago(idSeleccionado))
                {
                    MessageBox.Show("Pago eliminado.");
                    CargarPagos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el pago.");
                }
            }
        }


        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalirPago_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
