﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoUniversal.Framework.AccesoDatos
{
    public class Ejecuta
    {

        //-----------------------------------------------------------------------------------//
        public static SqlDataReader Texto(SqlConnection conexion, string nombreProcedimeinto)
        {
            var cmd = new SqlCommand(nombreProcedimeinto, conexion);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public static SqlDataReader ProcedimientoAlmacenado(SqlConnection conexion, string nombreProcedimiento, SqlParameter[] sqlParameter)
        {
            var sqlCommand = new SqlCommand(nombreProcedimiento, conexion);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            ParametroAcceso.AgregarParametros(sqlCommand, sqlParameter);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }

        public static SqlDataReader ProcedimientoAlmacenado(SqlConnection conexion, string nombreProcedimiento)
        {
            var sqlCommand = new SqlCommand(nombreProcedimiento, conexion);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }

        public static SqlDataReader ConsultaConRetorno(SqlConnection conexion, string sSql)
        {
            var sqlCommand = new SqlCommand(sSql, conexion);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }

        public static SqlDataReader ConsultaConRetorno(SqlConnection conexion, string sSql, SqlParameter[] sqlParameter)
        {
            var sqlCommand = new SqlCommand(sSql, conexion);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandTimeout = 0;

            ParametroAcceso.AgregarParametros(sqlCommand, sqlParameter);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }

        public static bool ConsultaSinRetorno(SqlConnection conexion, string sSql, SqlParameter[] sqlParameter)
        {
            var sqlCommand = new SqlCommand(sSql, conexion);
            sqlCommand.CommandType = CommandType.Text;

            ParametroAcceso.AgregarParametros(sqlCommand, sqlParameter);
            sqlCommand.ExecuteReader();
            return true;
        }

        public static bool ConsultaSinRetorno(SqlConnection conexion, string sSql)
        {
            var sqlCommand = new SqlCommand(sSql, conexion);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.ExecuteReader();
            return true;
        }

        //Metodo que ejecuta Consultas
        public static DataTable EjecutarConsulta(SqlConnection conexion, SqlParameter[] sqlParameter, string nombreProcedimiento)
        {
            try
            {
                var sqlCommand = new SqlCommand(nombreProcedimiento, conexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                ParametroAcceso.AgregarParametros(sqlCommand, sqlParameter);
                DataTable dt = new DataTable();
                dt.Load(sqlCommand.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable EjecutarConsultaSinparametros(SqlConnection conexion, string nombreProcedimiento)
        {
            try
            {
                var sqlCommand = new SqlCommand(nombreProcedimiento, conexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                dt.Load(sqlCommand.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Boolean EjecutarSpSinRetorno(SqlConnection conexion, SqlParameter[] sqlParameter, string nombreProcedimiento)
        {
            try
            {

                var sqlCommand = new SqlCommand(nombreProcedimiento, conexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                ParametroAcceso.AgregarParametros(sqlCommand, sqlParameter);
                DataTable dt = new DataTable();
                sqlCommand.ExecuteReader();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}