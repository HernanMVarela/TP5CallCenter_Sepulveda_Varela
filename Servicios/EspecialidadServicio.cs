using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios
{
    public class EspecialidadServicio
    {
        public List<Especialidad> Listar()
        {
            List<Especialidad> Lista = new List<Especialidad>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT E.ID AS EID, E.NOMBRE AS ESPECIALIDAD FROM ESPECIALIDADES E");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Especialidad Aux = new Especialidad();
                    Aux.ID = (int)Datos.Lector["EID"];
                    Aux.Nombre = (string)Datos.Lector["ESPECIALIDAD"];
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
