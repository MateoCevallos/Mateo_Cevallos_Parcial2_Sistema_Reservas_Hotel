using System;
using System.Collections.Generic;
using System.Data;
using MC_Reservas_Hotel.Config;
using MC_Reservas_Hotel.Models;
using MySql.Data.MySqlClient;

namespace MC_Reservas_Hotel.Controllers
{
    public class PagosController
    {
        private Conexion conexion = new Conexion();

        public List<PagosModel> ObtenerPagos()
        {
            List<PagosModel> lista = new List<PagosModel>();

            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"
                    SELECT p.id_pago, p.id_reserva, p.fecha_pago, p.monto_pagado, p.metodo_pago,
                           c.nombre AS nombre_cliente
                    FROM pagos p
                    JOIN reservas r ON p.id_reserva = r.id_reserva
                    JOIN clientes c ON r.id_cliente = c.id_cliente";

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new PagosModel
                    {
                        IdPago = Convert.ToInt32(reader["id_pago"]),
                        IdReserva = Convert.ToInt32(reader["id_reserva"]),
                        FechaPago = Convert.ToDateTime(reader["fecha_pago"]),
                        MontoPagado = Convert.ToDecimal(reader["monto_pagado"]),
                        MetodoPago = reader["metodo_pago"].ToString(),
                        NombreCliente = reader["nombre_cliente"].ToString()
                    });
                }
            }

            return lista;
        }

        public List<ClientesModel> ObtenerClientes()
        {
            List<ClientesModel> clientes = new List<ClientesModel>();

            using (MySqlConnection conn = conexion.AbrirConexion(2) as MySqlConnection)
            {
                string query = "SELECT id_cliente, nombre FROM clientes";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clientes.Add(new ClientesModel
                    {
                        IdCliente = reader.GetInt32("id_cliente"),
                        Nombre = reader.GetString("nombre")
                    });
                }
            }

            return clientes;
        }

        public int ObtenerUltimaReservaPorCliente(int idCliente)
        {
            using (var conn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
            SELECT id_reserva FROM reservas
            WHERE id_cliente = @cliente
            ORDER BY fecha_entrada DESC LIMIT 1";

                var p = cmd.CreateParameter();
                p.ParameterName = "@cliente";
                p.Value = idCliente;
                cmd.Parameters.Add(p);

                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        public bool InsertarPago(PagosModel pago)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO pagos 
                    (id_reserva, fecha_pago, monto_pagado, metodo_pago)
                    VALUES (@reserva, @fecha, @monto, @metodo)";

                var p1 = cmd.CreateParameter(); p1.ParameterName = "@reserva"; p1.Value = pago.IdReserva; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.ParameterName = "@fecha"; p2.Value = pago.FechaPago; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.ParameterName = "@monto"; p3.Value = pago.MontoPagado; cmd.Parameters.Add(p3);
                var p4 = cmd.CreateParameter(); p4.ParameterName = "@metodo"; p4.Value = pago.MetodoPago; cmd.Parameters.Add(p4);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarPago(PagosModel pago)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"
            UPDATE pagos
            SET id_reserva = @reserva,
                fecha_pago = @fecha,
                monto_pagado = @monto,
                metodo_pago = @metodo
            WHERE id_pago = @id";

                var p1 = cmd.CreateParameter(); p1.ParameterName = "@reserva"; p1.Value = pago.IdReserva; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.ParameterName = "@fecha"; p2.Value = pago.FechaPago; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.ParameterName = "@monto"; p3.Value = pago.MontoPagado; cmd.Parameters.Add(p3);
                var p4 = cmd.CreateParameter(); p4.ParameterName = "@metodo"; p4.Value = pago.MetodoPago; cmd.Parameters.Add(p4);
                var p5 = cmd.CreateParameter(); p5.ParameterName = "@id"; p5.Value = pago.IdPago; cmd.Parameters.Add(p5);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarPago(int id)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM pagos WHERE id_pago = @id";

                var p = cmd.CreateParameter(); p.ParameterName = "@id"; p.Value = id; cmd.Parameters.Add(p);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}