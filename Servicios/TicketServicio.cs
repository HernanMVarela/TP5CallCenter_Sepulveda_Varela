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
                Datos.SetearComando("SELECT T.ID as TID, T.Titulo as TTitulo, T.Comentario as TComentario, T.FECHA_CREACION AS FCreacion, T.FECHA_CIERRE as FCierre, I.ID as IID, I.DESCRIPCION AS IDescripcion, I.MODIFICACION AS FModificacion, CI.NOMBRE AS ICategoria, U.Nombre AS UNombre, U.Apellido as UApellido, U.NombreUsuario as UUser, C.NOMBRE AS CNombre, TC.NOMBRE as CTipo, C.CUIT as CCuit, C.EMAIL as CMail, C.TELEFONO as CTelefono, TE.Nombre AS TENombre, TE.Apellido AS TEApellido, TE.Mail AS TEMail, TE.Telefono AS TETelefono, ES.NOMBRE AS TEEspecialidad, E.NOMBRE AS ENombre FROM TICKETS T INNER JOIN INCIDENCIAS I ON T.ID=I.IDTICKET INNER JOIN CATEGORIASINCIDENCIAS CI ON CI.ID=I.IDCATEGORIA INNER JOIN ESTADOS E ON E.ID=T.IDESTADO INNER JOIN Usuarios U ON U.ID=T.IDUSUARIO INNER JOIN CLIENTES C ON C.ID=T.IDCLIENTE INNER JOIN TIPOCLIENTES TC ON TC.ID=C.IDTIPO INNER JOIN TECNICOS TE ON TE.ID=I.IDTECNICO INNER JOIN ESPECIALIDADES ES ON ES.ID=TE.IDESP");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Ticket Aux = new Ticket();
                    if (!(Datos.Lector["TID"] is DBNull))
                    {
                        Aux.ID = Convert.ToInt32(Datos.Lector["TID"]);
                        Aux.Titulo = (string)Datos.Lector["TTitulo"];
                        Aux.Comentario = (string)Datos.Lector["TComentario"];
                        // INCIDENCIA
                        Aux.PIncidencia = new List<Incidencia>();
                        if (!(Datos.Lector["IID"] is DBNull))
                        {
                            Incidencia NewInc = new Incidencia();

                            NewInc.ID = (int)Datos.Lector["IID"];
                            NewInc.Descripcion = (string)Datos.Lector["IDescripcion"];
                            NewInc.Categoria = (string)Datos.Lector["ICategoria"];
                            NewInc.Modificacion = (DateTime)Datos.Lector["FModificacion"];
                            // TECNICO
                            if (!(Datos.Lector["TENombre"] is DBNull))
                            {
                                NewInc.PTecnico = new Tecnico();
                                NewInc.PTecnico.Nombre = (string)Datos.Lector["TENombre"];
                                NewInc.PTecnico.Apellido = (string)Datos.Lector["TEApellido"];
                                NewInc.PTecnico.NombreCompleto = (string)Datos.Lector["TENombre"] + " " + (string)Datos.Lector["TEApellido"];
                                NewInc.PTecnico.Email = (string)Datos.Lector["TEMail"];
                                NewInc.PTecnico.Telefono = (string)Datos.Lector["TETelefono"];
                                NewInc.PTecnico.EspecialidadTecnico = new Especialidad();
                                NewInc.PTecnico.EspecialidadTecnico.Nombre = (string)Datos.Lector["TEEspecialidad"];
                            }
                            
                            Aux.PIncidencia.Add(NewInc);
                        }
                        // ESTADO DEL TICKET
                        Aux.Estado = (string)Datos.Lector["ENombre"];

                        // USUARIO RESPONSABLE DEL TICKET
                        if (!(Datos.Lector["UNombre"] is DBNull))
                        {
                            Aux.PResponsable = new Usuario();
                            Aux.PResponsable.Nombre = (string)Datos.Lector["UNombre"];
                            Aux.PResponsable.Apellido = (string)Datos.Lector["UApellido"];
                            Aux.PResponsable.NombreUsuario = (string)Datos.Lector["UUser"];
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
                            Aux.PCliente.Telefono = (string)Datos.Lector["CTelefono"];
                        }
                        Aux.Fecha_Creacion = (DateTime)Datos.Lector["FCreacion"];
                        Aux.Fecha_Cierre = (DateTime)Datos.Lector["FCierre"];
                    }

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
