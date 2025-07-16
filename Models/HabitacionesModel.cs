using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_Reservas_Hotel.Models
{
    public class HabitacionesModel
    {
        public int IdHabitacion { get; set; }
        public string NumeroHabitacion { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public string Estado { get; set; }
    }
}
