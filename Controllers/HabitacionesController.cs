using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MC_Reservas_Hotel.Config;
using MC_Reservas_Hotel.Models;
using MySql.Data.MySqlClient;

namespace MC_Reservas_Hotel.Controllers
{
    public class HabitacionesController
    {
        private Conexion conexion = new Conexion();

        public List<HabitacionesModel> ObtenerHabitaciones()
        {
            List<HabitacionesModel> lista = new List<HabitacionesModel>();

            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM habitaciones";

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new HabitacionesModel
                    {
                        IdHabitacion = Convert.ToInt32(reader["id_habitacion"]),
                        NumeroHabitacion = reader["numero_habitacion"].ToString(),
                        Tipo = reader["tipo"].ToString(),
                        PrecioPorNoche = Convert.ToDecimal(reader["precio_por_noche"]),
                        Estado = reader["estado"].ToString()
                    });
                }
            }

            return lista;
        }

        public int ObtenerIdPorNumero(string numeroHabitacion)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT id_habitacion FROM habitaciones WHERE numero_habitacion = @numero";

                var param = cmd.CreateParameter();
                param.ParameterName = "@numero";
                param.Value = numeroHabitacion;
                cmd.Parameters.Add(param);

                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public bool InsertarHabitacion(HabitacionesModel habitacion)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO habitaciones 
                    (numero_habitacion, tipo, precio_por_noche, estado) 
                    VALUES (@numero, @tipo, @precio, @estado)";

                var p1 = cmd.CreateParameter(); p1.ParameterName = "@numero"; p1.Value = habitacion.NumeroHabitacion; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.ParameterName = "@tipo"; p2.Value = habitacion.Tipo; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.ParameterName = "@precio"; p3.Value = habitacion.PrecioPorNoche; cmd.Parameters.Add(p3);
                var p4 = cmd.CreateParameter(); p4.ParameterName = "@estado"; p4.Value = habitacion.Estado; cmd.Parameters.Add(p4);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarHabitacion(HabitacionesModel habitacion)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"
            UPDATE habitaciones 
            SET numero_habitacion = @numero, 
                tipo = @tipo, 
                precio_por_noche = @precio, 
                estado = @estado
            WHERE id_habitacion = @id";

                var p0 = cmd.CreateParameter(); p0.ParameterName = "@id"; p0.Value = habitacion.IdHabitacion; cmd.Parameters.Add(p0);
                var p1 = cmd.CreateParameter(); p1.ParameterName = "@numero"; p1.Value = habitacion.NumeroHabitacion; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.ParameterName = "@tipo"; p2.Value = habitacion.Tipo; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.ParameterName = "@precio"; p3.Value = habitacion.PrecioPorNoche; cmd.Parameters.Add(p3);
                var p4 = cmd.CreateParameter(); p4.ParameterName = "@estado"; p4.Value = habitacion.Estado; cmd.Parameters.Add(p4);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarHabitacion(int id)
        {
            try
            {
                using (IDbConnection cn = conexion.AbrirConexion(2)) // 2 = MySQL
                {
                    IDbCommand cmd = cn.CreateCommand();

                    cmd.CommandText = "DELETE FROM habitaciones WHERE id_habitacion = @id";
                    var p = cmd.CreateParameter();
                    p.ParameterName = "@id";
                    p.Value = id;
                    cmd.Parameters.Add(p);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("foreign key constraint fails"))
                {
                    MessageBox.Show("Esta habitación está asociada a una o más reservas. Por favor, elimine primero esas reservas antes de continuar.",
                                    "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al intentar eliminar la habitación: " + ex.Message,
                                    "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }


    }
}