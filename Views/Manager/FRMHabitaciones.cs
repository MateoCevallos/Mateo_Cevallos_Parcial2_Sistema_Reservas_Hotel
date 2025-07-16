using MC_Reservas_Hotel.Controllers;
using MC_Reservas_Hotel.Models;
using System;
using System.Windows.Forms;

namespace MC_Reservas_Hotel.Views.Manager
{
    public partial class FRMHabitaciones : Form
    {
        private HabitacionesController controller = new HabitacionesController();
        private int idSeleccionado = -1;

        public FRMHabitaciones()
        {
            InitializeComponent();

            // Asignar eventos a botones
            btnAgregarHabitacion.Click += btnAgregarHabitacion_Click;
            btnEditarHabitacion.Click += btnEditarHabitacion_Click;
            btnEliminarHabitacion.Click += btnEliminarHabitacion_Click;
            btnCancelarHabitacion.Click += btnCancelarHabitacion_Click;
            btnSalirHabitacion.Click += btnSalirHabitacion_Click;

            // Evento de carga del formulario
            this.Load += FRMHabitaciones_Load;

            // Eventos para habilitar y deshabilitar botones automáticamente
            txtNumHabitacion.TextChanged += (s, e) => ActualizarEstadoBotones();
            txtPrecioNoche.TextChanged += (s, e) => ActualizarEstadoBotones();
            cbTipo.SelectedIndexChanged += (s, e) => ActualizarEstadoBotones();
            cbEstado.SelectedIndexChanged += (s, e) => ActualizarEstadoBotones();

            // Inicializar datos
            CargarHabitaciones();
            LimpiarCampos();
        }

        private void CargarHabitaciones()
        {
            dgvHabitaciones.DataSource = controller.ObtenerHabitaciones();

            if (dgvHabitaciones.Columns.Contains("IdHabitacion"))
            {
                dgvHabitaciones.Columns["IdHabitacion"].Visible = false;
            }

            dgvHabitaciones.ClearSelection();
            ActualizarEstadoBotones();
        }

        private void LimpiarCampos()
        {
            txtNumHabitacion.Clear();
            txtPrecioNoche.Clear();
            cbTipo.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            idSeleccionado = -1;
            dgvHabitaciones.ClearSelection();
            ActualizarEstadoBotones();
        }

        private void ActualizarEstadoBotones()
        {
            bool haySeleccion = idSeleccionado != -1;

            bool todosCamposLlenos =
                !string.IsNullOrWhiteSpace(txtNumHabitacion.Text) &&
                !string.IsNullOrWhiteSpace(txtPrecioNoche.Text) &&
                cbTipo.SelectedIndex != -1 &&
                cbEstado.SelectedIndex != -1;

            bool hayDatos = !string.IsNullOrWhiteSpace(txtNumHabitacion.Text) ||
                            !string.IsNullOrWhiteSpace(txtPrecioNoche.Text) ||
                            cbTipo.SelectedIndex != -1 ||
                            cbEstado.SelectedIndex != -1;

            btnAgregarHabitacion.Enabled = !haySeleccion && todosCamposLlenos;
            btnEditarHabitacion.Enabled = haySeleccion && todosCamposLlenos;
            btnEliminarHabitacion.Enabled = haySeleccion;
            btnCancelarHabitacion.Enabled = haySeleccion || hayDatos;
        }

        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvHabitaciones.Rows[e.RowIndex].Cells["IdHabitacion"].Value);
                txtNumHabitacion.Text = dgvHabitaciones.Rows[e.RowIndex].Cells["NumeroHabitacion"].Value.ToString();
                cbTipo.Text = dgvHabitaciones.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
                txtPrecioNoche.Text = dgvHabitaciones.Rows[e.RowIndex].Cells["PrecioPorNoche"].Value.ToString();
                cbEstado.Text = dgvHabitaciones.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                ActualizarEstadoBotones();
            }
        }
        private void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumHabitacion.Text) ||
        string.IsNullOrWhiteSpace(txtPrecioNoche.Text) ||
        cbTipo.SelectedIndex == -1 ||
        cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa todos los campos antes de agregar la habitación.");
                return;
            }

            if (!decimal.TryParse(txtPrecioNoche.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            var habitacion = new HabitacionesModel
            {
                NumeroHabitacion = txtNumHabitacion.Text.Trim(),
                Tipo = cbTipo.Text,
                PrecioPorNoche = precio,
                Estado = cbEstado.Text
            };

            if (controller.InsertarHabitacion(habitacion))
            {
                MessageBox.Show("Habitación agregada correctamente.");
                CargarHabitaciones();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar habitación. Verifica que no exista ya el número o revisa relaciones con reservas.");
            }
        }

        private void btnEditarHabitacion_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Selecciona una habitación para editar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumHabitacion.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioNoche.Text) ||
                cbTipo.SelectedIndex == -1 ||
                cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa todos los campos antes de editar la habitación.");
                return;
            }

            if (!decimal.TryParse(txtPrecioNoche.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            var habitacion = new HabitacionesModel
            {
                IdHabitacion = idSeleccionado,
                NumeroHabitacion = txtNumHabitacion.Text.Trim(),
                Tipo = cbTipo.Text,
                PrecioPorNoche = precio,
                Estado = cbEstado.Text
            };

            if (controller.ActualizarHabitacion(habitacion))
            {
                MessageBox.Show("Habitación actualizada correctamente.");
                CargarHabitaciones();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar habitación.");
            }
        }

        private void btnCancelarHabitacion_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminarHabitacion_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Selecciona una habitación para eliminar.");
                return;
            }

            var confirmar = MessageBox.Show("¿Estás seguro de eliminar esta habitación?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                if (controller.EliminarHabitacion(idSeleccionado))
                {
                    MessageBox.Show("Habitación eliminada.");
                    CargarHabitaciones();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar habitación.");
                }
            }
        }

        private void FRMHabitaciones_Load(object sender, EventArgs e)
        {
            cbTipo.Items.Clear();
            cbTipo.Items.Add("Simple");
            cbTipo.Items.Add("Doble");
            cbTipo.Items.Add("Suite");

            cbEstado.Items.Clear();
            cbEstado.Items.Add("Disponible");
            cbEstado.Items.Add("Ocupada");
            cbEstado.Items.Add("Mantenimiento");

            cbTipo.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
        }

        private void btnSalirHabitacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarHabitacion_Click_1(object sender, EventArgs e)
        {

        }
    }
}