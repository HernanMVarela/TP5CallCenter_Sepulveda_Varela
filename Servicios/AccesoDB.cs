using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Servicio
{
    public class AccesoDB
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDB()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database = CallCenter; integrated security = true;");
            comando = new SqlCommand();
        }

        public void SetearComando(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void LecturaDB()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void EjecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            if (lector != null) lector.Close();
            conexion.Close();
        }

        public void setearParametros(string tipo, object valor)
        {
            comando.Parameters.AddWithValue(tipo, valor);
        }

    }
}
