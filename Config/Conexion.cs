﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_Reservas_Hotel.Config
{
    public class Conexion
    {
        private readonly string _csSqlServer =
            "server=(local);database=hotel_reservas;uid=cuarto;pwd=123;";

        private readonly string _csMySql =
            "server=localhost;database=hotel_reservas;uid=root;pwd=;";

        /// <param name="tipobase">1 = SQL Server (default) · 2 = MySQL</param>
        public IDbConnection AbrirConexion(int tipobase = 1)
        {
            IDbConnection cn = tipobase == 1
                ? (IDbConnection)new SqlConnection(_csSqlServer)
                : new MySqlConnection(_csMySql);

            cn.Open();     // conexión abierta
            return cn;     // quien llama la cerrará con using/Dispose
        }
    }
}
