using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MC_Reservas_Hotel.Config;
using MC_Reservas_Hotel.Models;
using MySql.Data.MySqlClient;

namespace MC_Reservas_Hotel.Controllers
{
    public class ClientesController
    {
        private Conexion conexion = new Conexion();

        public List<ClientesModel> ObtenerClientes()
        {
            List<ClientesModel> lista = new List<ClientesModel>();

            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM clientes";

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new ClientesModel
                    {
                        IdCliente = Convert.ToInt32(reader["id_cliente"]),
                        Nombre = reader["nombre"].ToString(),
                        Cedula = reader["cedula"].ToString(),
                        Telefono = reader["telefono"].ToString(),
                        Email = reader["email"].ToString()
                    });
                }
            }

            return lista;
        }

        public bool InsertarCliente(ClientesModel cliente)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = "INSERT INTO clientes (nombre, cedula, telefono, email) VALUES (@nombre, @cedula, @telefono, @correo)";

                var p1 = cmd.CreateParameter(); p1.ParameterName = "@nombre"; p1.Value = cliente.Nombre; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.ParameterName = "@cedula"; p2.Value = cliente.Cedula; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.ParameterName = "@telefono"; p3.Value = cliente.Telefono; cmd.Parameters.Add(p3);
                var p4 = cmd.CreateParameter(); p4.ParameterName = "@correo"; p4.Value = cliente.Email; cmd.Parameters.Add(p4);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarCliente(ClientesModel cliente)
        {
            using (IDbConnection cn = conexion.AbrirConexion(2))
            {
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"
            UPDATE clientes 
            SET nombre = @nombre, cedula = @cedula, telefono = @telefono, email = @correo 
            WHERE id_cliente = @id";

                var p0 = cmd.CreateParameter(); p0.ParameterName = "@id"; p0.Value = cliente.IdCliente; cmd.Parameters.Add(p0);
                var p1 = cmd.CreateParameter(); p1.ParameterName = "@nombre"; p1.Value = cliente.Nombre; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.ParameterName = "@cedula"; p2.Value = cliente.Cedula; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.ParameterName = "@telefono"; p3.Value = cliente.Telefono; cmd.Parameters.Add(p3);
                var p4 = cmd.CreateParameter(); p4.ParameterName = "@correo"; p4.Value = cliente.Email; cmd.Parameters.Add(p4);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarCliente(int id)
        {
            try
            {
                using (IDbConnection cn = conexion.AbrirConexion(2))
                {
                    IDbCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "DELETE FROM clientes WHERE id_cliente = @id";

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
                    MessageBox.Show("No se puede eliminar este cliente porque tiene reservas asociadas. Elimine primero las reservas.", "Eliminación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }
    }
}