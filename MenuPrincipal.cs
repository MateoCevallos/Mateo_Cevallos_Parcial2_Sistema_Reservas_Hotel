using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_Reservas_Hotel
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide();

            var FRM_Clientes = new Views.Manager.FRMClientes();
            FRM_Clientes.FormClosed += (s, args) => this.Show();
            FRM_Clientes.Show();
        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            this.Hide();

            var FRM_Habitaciones = new Views.Manager.FRMHabitaciones();
            FRM_Habitaciones.FormClosed += (s, args) => this.Show();
            FRM_Habitaciones.Show();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            this.Hide();

            var FRM_Pagos = new Views.Manager.FRMPagos();
            FRM_Pagos.FormClosed += (s, args) => this.Show();
            FRM_Pagos.Show();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            this.Hide();

            var FRM_Reservas = new Views.Manager.FRMReservas();
            FRM_Reservas.FormClosed += (s, args) => this.Show();
            FRM_Reservas.Show();
        }
    }
}
