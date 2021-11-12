using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios
{
    public class TicketServicio
    {
        public List<Ticket> Listar()
        {
            List<Ticket> Lista = new List<Ticket>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT T.ID as TID, I.ID as IID, I.DESCRIPCION AS IDescripcion, CI.NOMBRE AS ICategoria, U.Nombre AS UNombre, U.Apellido as UApellido, U.NombreUsuario as UUser, C.NOMBRE AS CNombre, TC.NOMBRE as CTipo, C.CUIT as CCuit, C.EMAIL as CMail, C.TELEFONO as CTelefono, TE.Nombre AS TENombre, TE.Apellido AS TEApellido, TE.Mail AS TEMail, TE.Telefono AS TETelefono, ES.NOMBRE AS TEEspecialidad, E.NOMBRE AS ENombre, T.FECHA_CREACION AS FCreacion, T.FECHA_CIERRE as FCierre FROM TICKETS T INNER JOIN Usuarios U ON U.ID=T.IDUSUARIO INNER JOIN CLIENTES C ON C.ID=T.IDCLIENTE INNER JOIN TIPOCLIENTES TC ON TC.ID=C.IDTIPO INNER JOIN TECNICOS TE ON TE.ID=T.IDTECNICO INNER JOIN ESPECIALIDADES ES ON ES.ID=TE.IDESP INNER JOIN INCIDENCIAS I ON I.ID=T.IDINCIDENCIAS INNER JOIN CATEGORIASINCIDENCIAS CI ON CI.ID=I.IDCATEGORIA INNER JOIN ESTADOS E ON E.ID=T.IDESTADO");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Ticket Aux = new Ticket();
                    Aux.ID = (int)Datos.Lector[1];
                    // INCIDENCIA
                    if (!(Datos.Lector["IID"] is DBNull))
                    {
                        Aux.PIncidencia = new Incidencia();
                        Aux.PIncidencia.ID = (int)Datos.Lector["IID"];
                        Aux.PIncidencia.Descripcion= (string)Datos.Lector["IDescripcion"];
                        Aux.PIncidencia.Categoria = (string)Datos.Lector["ICategoria"];
                    }

                    // ESTADO DEL TICKET
                    Aux.Estado = (string)Datos.Lector["ENombre"];

                    // USUARIO RESPONSABLE DEL TICKET
                    if (!(Datos.Lector["UNombre"] is DBNull))
                    {
                        Aux.PResponsable = new Usuario();
                        Aux.PResponsable.Nombre = (string)Datos.Lector["UNombre"];
                        Aux.PResponsable.Apellido = (string)Datos.Lector["UApellido"];
                        Aux.PResponsable.NombreUsuario = (string)Datos.Lector["UUser"];;
                    }
                    // CLIENTE
                    if (!(Datos.Lector["CNombre"] is DBNull))
                    {
                        Aux.PCliente = new Cliente();
                        Aux.PCliente.RazonSocial = (string)Datos.Lector["CNombre"];
                        Aux.PCliente.Tipo = new TipoCliente();
                        Aux.PCliente.Tipo.Nombre = (string)Datos.Lector["CTipo"];
                        Aux.PCliente.Cuit = (string)Datos.Lector["CCuit"];
                        Aux.PCliente.Email = (string)Datos.Lector["CMail"];
                        Aux.PCliente.Telefono  = (string)Datos.Lector["CTelefono"];
                    }
                    // TECNICO
                    if (!(Datos.Lector["TENombre"] is DBNull))
                    {
                        Aux.PTecnico = new Tecnico();
                        Aux.PTecnico.Nombre = (string)Datos.Lector["TENombre"];
                        Aux.PTecnico.Apellido = (string)Datos.Lector["TEApellido"];
                        Aux.PTecnico.Email = (string)Datos.Lector["TEMail"];
                        Aux.PTecnico.Telefono = (string)Datos.Lector["TETelefono"];
                        Aux.PTecnico.EspecialidadTecnico = new Especialidad();
                        Aux.PTecnico.EspecialidadTecnico.Nombre = (string)Datos.Lector["TEEspecialidad"];
                    }
                    Aux.Fecha_Creacion = (DateTime)Datos.Lector["FCreacion"];
                    Aux.Fecha_Cierre = (DateTime)Datos.Lector["FCierre"];

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
