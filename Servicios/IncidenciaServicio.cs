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
        public List<Incidencia> Listar(int TicketID)
        {
            List<Incidencia> Lista = new List<Incidencia>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT I.ID AS IID, I.DESCRIPCION AS IDescripcion, MODIFICACION AS FModificacion, C.ID AS CID, C.NOMBRE AS ICategoria, T.ID AS TID, T.Nombre AS TNombre, T.Apellido AS TApellido, T.Mail AS TMail, T.Telefono AS TTelefono, E.ID AS EID, E.NOMBRE AS Especialidad FROM INCIDENCIAS I INNER JOIN CATEGORIASINCIDENCIAS C ON I.IDCATEGORIA=C.ID INNER JOIN TECNICOS T ON I.IDTECNICO=T.ID INNER JOIN ESPECIALIDADES E ON E.ID=T.IDESP WHERE IDTICKET=@IDTicket");
                Datos.setearParametros("@IDTicket", TicketID);
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Incidencia Aux = new Incidencia();
                    Aux.ID = Convert.ToInt32(Datos.Lector["IID"]);
                    Aux.IDTicket = TicketID;
                    Aux.Descripcion = (string)Datos.Lector["IDescripcion"];
                    Aux.Modificacion = (DateTime)Datos.Lector["FModificacion"];
                    Aux.PCategoria = new Categoria();
                    Aux.PCategoria.ID = (int)Datos.Lector["CID"];
                    Aux.PCategoria.Nombre = (string)Datos.Lector["ICategoria"];
                    Aux.PTecnico = new Tecnico();
                    Aux.PTecnico.ID = Convert.ToInt32(Datos.Lector["TID"]);
                    Aux.PTecnico.Nombre = (string)Datos.Lector["TNombre"];
                    Aux.PTecnico.Apellido = (string)Datos.Lector["TApellido"];
                    Aux.PTecnico.NombreCompleto = Aux.PTecnico.Nombre + " " + Aux.PTecnico.Apellido;
                    Aux.PTecnico.Email = (string)Datos.Lector["TMail"];
                    Aux.PTecnico.Telefono = (string)Datos.Lector["TTelefono"];
                    Aux.PTecnico.EspecialidadTecnico = new Especialidad();
                    Aux.PTecnico.EspecialidadTecnico.ID = Convert.ToInt32(Datos.Lector["EID"]);
                    Aux.PTecnico.EspecialidadTecnico.Nombre = (string)Datos.Lector["Especialidad"];

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
