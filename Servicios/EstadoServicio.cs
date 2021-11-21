using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios
{
    public class EstadoServicio
    {
        public List<Estado> Listar()
        {
            List<Estado> Lista = new List<Estado>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT E.ID AS EID, E.NOMBRE AS ESTADOS FROM ESTADOS E");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Estado Aux = new Estado();
                    Aux.ID = (int)Datos.Lector["EID"];
                    Aux.Nombre = (string)Datos.Lector["ESTADOS"];
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
