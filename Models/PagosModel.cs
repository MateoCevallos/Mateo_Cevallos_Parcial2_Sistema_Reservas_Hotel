using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_Reservas_Hotel.Models
{
    public class PagosModel
    {
        public int IdPago { get; set; }
        public int IdReserva { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoPagado { get; set; }
        public string MetodoPago { get; set; }

        // Relaciones
        public string NombreCliente { get; set; }
    }
}
