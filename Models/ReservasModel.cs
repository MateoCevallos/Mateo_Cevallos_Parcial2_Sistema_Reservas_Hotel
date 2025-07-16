using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_Reservas_Hotel.Models
{
    public class ReservasModel
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Estado { get; set; }

        // Relaciones 
        public string NombreCliente { get; set; }
        public string NumeroHabitacion { get; set; }
    }
}
