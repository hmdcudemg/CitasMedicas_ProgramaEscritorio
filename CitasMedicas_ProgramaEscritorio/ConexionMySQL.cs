﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitasMedicas_ProgramaEscritorio
{
    class ConexionMySQL
    {
        MySqlConnection connection = new MySqlConnection();
        string port = "3306", server = "localhost", user = "root", pass = "root", database = "citas_medicas";

        public ConexionMySQL()
        {
            //this.server = conection[0];
            //this.user = conection[1];
            //this.pass = conection[2];
        }

        public MySqlDataReader conexionSendData(String sqlCadena)
        {
            MySqlDataReader reader = null;
            try
            {
                connection.ConnectionString = "Server=" + server + "; Port=" + port + "; Database=" + database + "; Uid=" + user + "; Pwd=" + pass + ";";
                connection.Open();
                MySqlCommand instruccion = connection.CreateCommand();
                instruccion.CommandText = sqlCadena;
                reader = instruccion.ExecuteReader();
            }
            catch (MySqlException ex)
            {

            }
            return reader;
        }

        public MySqlDataAdapter conexionGetData(String sqlCadena)
        {
            MySqlDataAdapter reader = null;
            try
            {
                connection.ConnectionString = "Server=" + server + "; Port=" + port + "; Database=" + database + "; Uid=" + user + "; Pwd=" + pass + ";";
                connection.Open();
                MySqlCommand instruccion = connection.CreateCommand();
                instruccion.CommandText = sqlCadena;
                reader = new MySqlDataAdapter(instruccion);
            }
            catch (MySqlException ex)
            {

            }
            return reader;
        }

        public void conexionClose()
        {
            connection.Close();
        }
    }
}
