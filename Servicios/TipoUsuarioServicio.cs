using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios
{
    public class TipoUsuarioServicio
    {
        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> Lista = new List<TipoUsuario>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("select TC.ID as TID, TC.Tipo AS TNOMBRE from TipoCuenta TC");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    TipoUsuario Aux = new TipoUsuario();
                    Aux.ID = Convert.ToInt32(Datos.Lector["TID"]);
                    Aux.Tipo = (string)Datos.Lector["TNOMBRE"];
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
