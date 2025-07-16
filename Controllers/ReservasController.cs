using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MC_Reservas_Hotel.Config;
using MC_Reservas_Hotel.Models;

using MySql.Data.MySqlClient;


namespace MC_Reservas_Hotel.Controllers
{
    public class ReservasController
    {
        private Conexion conexion = new Conexion();

        public List<ReservasModel> ObtenerReservas()
        {
            List<ReservasModel> lista = new List<ReservasModel>();

            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"
                    SELECT r.id_reserva, r.id_cliente, r.id_habitacion, 
                           r.fecha_entrada, r.fecha_salida, r.estado,
                           c.nombre AS nombre_cliente, 
                           h.numero_habitacion
                    FROM reservas r
                    JOIN clientes c ON r.id_cliente = c.id_cliente
                    JOIN habitaciones h ON r.id_habitacion = h.id_habitacion";

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new ReservasModel
                    {
                        IdReserva = Convert.ToInt32(reader["id_reserva"]),
                        IdCliente = Convert.ToInt32(reader["id_cliente"]),
                        IdHabitacion = Convert.ToInt32(reader["id_habitacion"]),
                        FechaEntrada = Convert.ToDateTime(reader["fecha_entrada"]),
                        FechaSalida = Convert.ToDateTime(reader["fecha_salida"]),
                        Estado = reader["estado"].ToString(),
                        NombreCliente = reader["nombre_cliente"].ToString(),
                        NumeroHabitacion = reader["numero_habitacion"].ToString()
                    });
                }
            }

            return lista;
        }
        public HabitacionesModel ObtenerHabitacionPorCliente(int idCliente)
        {
            HabitacionesModel habitacion = null;

            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"
            SELECT h.id_habitacion, h.numero_habitacion 
            FROM reservas r
            JOIN habitaciones h ON r.id_habitacion = h.id_habitacion
            WHERE r.id_cliente = @idCliente
            ORDER BY r.id_reserva DESC LIMIT 1";

                var param = cmd.CreateParameter();
                param.ParameterName = "@idCliente";
                param.Value = idCliente;
                cmd.Parameters.Add(param);

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        habitacion = new HabitacionesModel
                        {
                            IdHabitacion = Convert.ToInt32(reader["id_habitacion"]),
                            NumeroHabitacion = reader["numero_habitacion"].ToString()
                        };
                    }
                }
            }

            return habitacion;
        }
        
        public bool InsertarReserva(ReservasModel reserva)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO reservas 
                    (id_cliente, id_habitacion, fecha_entrada, fecha_salida, estado)
                    VALUES (@cliente, @habitacion, @entrada, @salida, @estado)";

                var p1 = cmd.CreateParameter(); p1.ParameterName = "@cliente"; p1.Value = reserva.IdCliente; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.ParameterName = "@habitacion"; p2.Value = reserva.IdHabitacion; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.ParameterName = "@entrada"; p3.Value = reserva.FechaEntrada; cmd.Parameters.Add(p3);
                var p4 = cmd.CreateParameter(); p4.ParameterName = "@salida"; p4.Value = reserva.FechaSalida; cmd.Parameters.Add(p4);
                var p5 = cmd.CreateParameter(); p5.ParameterName = "@estado"; p5.Value = reserva.Estado; cmd.Parameters.Add(p5);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarReserva(ReservasModel reserva)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE reservas 
                    SET id_cliente = @cliente, 
                        id_habitacion = @habitacion, 
                        fecha_entrada = @entrada, 
                        fecha_salida = @salida, 
                        estado = @estado
                    WHERE id_reserva = @id";

                var p0 = cmd.CreateParameter(); p0.ParameterName = "@id"; p0.Value = reserva.IdReserva; cmd.Parameters.Add(p0);
                var p1 = cmd.CreateParameter(); p1.ParameterName = "@cliente"; p1.Value = reserva.IdCliente; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.ParameterName = "@habitacion"; p2.Value = reserva.IdHabitacion; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.ParameterName = "@entrada"; p3.Value = reserva.FechaEntrada; cmd.Parameters.Add(p3);
                var p4 = cmd.CreateParameter(); p4.ParameterName = "@salida"; p4.Value = reserva.FechaSalida; cmd.Parameters.Add(p4);
                var p5 = cmd.CreateParameter(); p5.ParameterName = "@estado"; p5.Value = reserva.Estado; cmd.Parameters.Add(p5);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarReserva(int id)
        {
            try
            {
                using (var conn = new Conexion().AbrirConexion(2)) // MySQL
                {
                    string query = "DELETE FROM reservas WHERE id_reserva = @id";
                    using (var cmd = new MySqlCommand(query, (MySqlConnection)conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Mensaje personalizado si hay clave foránea
                if (ex.Message.Contains("foreign key constraint fails"))
                {
                    MessageBox.Show("No se puede eliminar esta reserva porque está relacionada con otros datos (por ejemplo, pagos).", "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al eliminar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }
    }
}
