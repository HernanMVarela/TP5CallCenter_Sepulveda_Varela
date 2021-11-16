using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios
{
    public class TipoClienteServicio
    {
        public List<TipoCliente> Listar()
        {
            List<TipoCliente> Lista = new List<TipoCliente>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("select TC.ID as TID, TC.NOMBRE AS TNOMBRE from TipoClientes TC");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    TipoCliente Aux = new TipoCliente();
                    Aux.ID = Convert.ToInt32(Datos.Lector["TID"]);
                    Aux.Nombre = (string)Datos.Lector["TNOMBRE"];
                    Lista.Add(Aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
