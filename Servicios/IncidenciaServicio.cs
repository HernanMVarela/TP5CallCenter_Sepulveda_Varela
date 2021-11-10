using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios
{
    public class IncidenciaServicio
    {
        public List<Incidencia> Listar()
        {
            List<Incidencia> Lista = new List<Incidencia>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT I.ID, I.IDCategoria, I.Descripcion FROM Incidencias I");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Incidencia Aux = new Incidencia();
                    Aux.ID = (int)Datos.Lector["ID"];
                    Aux.IDCategoria = (int)Datos.Lector["IDCategoria"];
                    Aux.Descripcion = (string)Datos.Lector["Descripcion"];
                   
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
