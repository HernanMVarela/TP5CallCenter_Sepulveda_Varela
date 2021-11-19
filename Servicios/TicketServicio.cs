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
        public Ticket Listar(int TicketID)
        {
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT T.ID as TID, T.TITULO AS TTitulo, T.COMENTARIO as TComentario, T.FECHA_CREACION as FCreacion, T.FECHA_CIERRE as FCierre, E.NOMBRE AS TEstado, T.IDCLIENTE as TIDCliente, T.IDUSUARIO AS TIDUsuario FROM TICKETS T INNER JOIN ESTADOS E ON T.IDESTADO=E.ID WHERE T.ID=@IDTicket");
                Datos.setearParametros("@IDTicket", TicketID);
                Datos.LecturaDB();
                Ticket Aux = new Ticket();
                while (Datos.Lector.Read())
                {
                    
                    if (!(Datos.Lector["TID"] is DBNull))
                    {
                        Aux.ID = TicketID;
                        Aux.Titulo = (string)Datos.Lector["TTitulo"];
                        Aux.Comentario = (string)Datos.Lector["TComentario"];
                        Aux.Estado = (string)Datos.Lector["TEstado"];
                        Aux.Fecha_Creacion = (DateTime)Datos.Lector["FCreacion"];
                        Aux.Fecha_Cierre = (DateTime)Datos.Lector["FCierre"];
                        if (!(Datos.Lector["TIDCliente"] is DBNull))
                        {
                            Aux.PCliente = new Cliente();
                            Aux.PCliente.ID = Convert.ToInt32(Datos.Lector["TIDCliente"]);
                        }
                    }
                    
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ticket> Listar()
        {
            List<Ticket> Lista = new List<Ticket>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT T.ID as TID, T.TITULO as TTitulo, T.FECHA_CREACION as FCreacion, T.FECHA_CIERRE as FCierre, C.NOMBRE as CNombre, C.CUIT as CCuit, E.NOMBRE as Estado FROM TICKETS T INNER JOIN ESTADOS E ON T.IDESTADO=E.ID INNER JOIN CLIENTES C ON T.IDCLIENTE=C.ID");
                Datos.LecturaDB();

                while (Datos.Lector.Read())
                {
                    Ticket Aux = new Ticket();
                    if (!(Datos.Lector["TID"] is DBNull))
                    {
                        Aux.ID = Convert.ToInt32(Datos.Lector["TID"]);
                        Aux.Titulo = (string)Datos.Lector["TTitulo"];
                        Aux.Estado = (string)Datos.Lector["Estado"];
                        Aux.Fecha_Creacion = (DateTime)Datos.Lector["FCreacion"];
                        Aux.Fecha_Cierre = (DateTime)Datos.Lector["FCierre"];
                        if (!(Datos.Lector["CNombre"] is DBNull))
                        {
                            Aux.PCliente = new Cliente();
                            Aux.PCliente.RazonSocial = (string)Datos.Lector["CNombre"];
                            Aux.PCliente.Cuit = (string)Datos.Lector["CCuit"];
                        }
                    }

                    Lista.Add(Aux);
                }



                //while (Datos.Lector.Read())
                //{
                //    Ticket Aux = new Ticket();
                //    if (!(Datos.Lector["TID"] is DBNull))
                //    {
                //        Aux.ID = Convert.ToInt32(Datos.Lector["TID"]);
                //        Aux.Titulo = (string)Datos.Lector["TTitulo"];
                //        Aux.Comentario = (string)Datos.Lector["TComentario"];
                //        // INCIDENCIA
                //        Aux.PIncidencia = new List<Incidencia>();
                //        if (!(Datos.Lector["IID"] is DBNull))
                //        {
                //            Incidencia NewInc = new Incidencia();

                //            NewInc.ID = (int)Datos.Lector["IID"];
                //            NewInc.Descripcion = (string)Datos.Lector["IDescripcion"];
                //            NewInc.Categoria = (string)Datos.Lector["ICategoria"];
                //            NewInc.Modificacion = (DateTime)Datos.Lector["FModificacion"];
                //            // TECNICO
                //            if (!(Datos.Lector["TENombre"] is DBNull))
                //            {
                //                NewInc.PTecnico = new Tecnico();
                //                NewInc.PTecnico.Nombre = (string)Datos.Lector["TENombre"];
                //                NewInc.PTecnico.Apellido = (string)Datos.Lector["TEApellido"];
                //                NewInc.PTecnico.NombreCompleto = (string)Datos.Lector["TENombre"] + " " + (string)Datos.Lector["TEApellido"];
                //                NewInc.PTecnico.Email = (string)Datos.Lector["TEMail"];
                //                NewInc.PTecnico.Telefono = (string)Datos.Lector["TETelefono"];
                //                NewInc.PTecnico.EspecialidadTecnico = new Especialidad();
                //                NewInc.PTecnico.EspecialidadTecnico.Nombre = (string)Datos.Lector["TEEspecialidad"];
                //            }
                            
                //            Aux.PIncidencia.Add(NewInc);
                //        }
                //        // ESTADO DEL TICKET
                //        Aux.Estado = (string)Datos.Lector["ENombre"];

                //        // USUARIO RESPONSABLE DEL TICKET
                //        if (!(Datos.Lector["UNombre"] is DBNull))
                //        {
                //            Aux.PResponsable = new Usuario();
                //            Aux.PResponsable.Nombre = (string)Datos.Lector["UNombre"];
                //            Aux.PResponsable.Apellido = (string)Datos.Lector["UApellido"];
                //            Aux.PResponsable.NombreUsuario = (string)Datos.Lector["UUser"];
                //        }
                //        // CLIENTE
                //        if (!(Datos.Lector["CNombre"] is DBNull))
                //        {
                //            Aux.PCliente = new Cliente();
                //            Aux.PCliente.RazonSocial = (string)Datos.Lector["CNombre"];
                //            Aux.PCliente.Tipo = new TipoCliente();
                //            Aux.PCliente.Tipo.Nombre = (string)Datos.Lector["CTipo"];
                //            Aux.PCliente.Cuit = (string)Datos.Lector["CCuit"];
                //            Aux.PCliente.Email = (string)Datos.Lector["CMail"];
                //            Aux.PCliente.Telefono = (string)Datos.Lector["CTelefono"];
                //        }
                //        Aux.Fecha_Creacion = (DateTime)Datos.Lector["FCreacion"];
                //        Aux.Fecha_Cierre = (DateTime)Datos.Lector["FCierre"];
                //    }

                //    Lista.Add(Aux);
                //}
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
