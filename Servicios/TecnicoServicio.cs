using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios
{
    public class TecnicoServicio
    {
        public List<Tecnico> Listar()
        {
            List<Tecnico> Lista = new List<Tecnico>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT T.ID, T.EspecialidadTecnico, T.Nombre, T.Apellido, T.Telefono, T.Mail FROM Tecnicos T");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Tecnico Aux = new Tecnico();
                    Aux.ID = (int)Datos.Lector["ID"];
                    Aux.EspecialidadTecnico = (string)Datos.Lector["EspecialidadTecnico"];
                    Aux.Nombre = (string)Datos.Lector["Nombre"];
                    Aux.Apellido = (string)Datos.Lector["Apellido"];
                    Aux.Telefono = (string)Datos.Lector["Telefono"];
                    Aux.Email = (string)Datos.Lector["Mail"];

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
