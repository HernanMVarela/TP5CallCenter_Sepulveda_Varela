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
                Datos.SetearComando("SELECT T.ID as TID, T.TITULO AS TTitulo, T.COMENTARIO as TComentario, T.FECHA_CREACION as FCreacion, T.FECHA_CIERRE as FCierre, E.ID as TEID, E.NOMBRE AS TEstado, T.IDCLIENTE as TIDCliente, T.IDUSUARIO AS TIDUsuario FROM TICKETS T INNER JOIN ESTADOS E ON T.IDESTADO=E.ID WHERE T.ID=@IDTicket");
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
                        Aux.PEstado = new Estado();
                        Aux.PEstado.ID = Convert.ToInt32(Datos.Lector["TEID"]);
                        Aux.PEstado.Nombre = (string)Datos.Lector["TEstado"];
                        Aux.Fecha_Creacion = (DateTime)Datos.Lector["FCreacion"];
                        Aux.Fecha_Cierre = (DateTime)Datos.Lector["FCierre"];
                        Aux.PResponsable = new Usuario();
                        Aux.PResponsable.ID = Convert.ToInt32(Datos.Lector["TIDUsuario"]); 
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
                Datos.SetearComando("SELECT T.ID as TID, T.TITULO as TTitulo, T.FECHA_CREACION as FCreacion, T.FECHA_CIERRE as FCierre, C.NOMBRE as CNombre, C.CUIT as CCuit, T.IDESTADO AS TEID, E.NOMBRE as Estado FROM TICKETS T INNER JOIN ESTADOS E ON T.IDESTADO=E.ID INNER JOIN CLIENTES C ON T.IDCLIENTE=C.ID");
                Datos.LecturaDB();

                while (Datos.Lector.Read())
                {
                    Ticket Aux = new Ticket();
                    if (!(Datos.Lector["TID"] is DBNull))
                    {
                        Aux.ID = Convert.ToInt32(Datos.Lector["TID"]);
                        Aux.Titulo = (string)Datos.Lector["TTitulo"];
                        Aux.PEstado = new Estado();
                        Aux.PEstado.ID = Convert.ToInt32(Datos.Lector["TEID"]);
                        Aux.PEstado.Nombre = (string)Datos.Lector["Estado"];
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
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cambiar_Estado(Ticket VEstado)
        {
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("UPDATE TICKETS SET IDESTADO=@IDEstado where ID=@ID");
                Datos.setearParametros("@ID", VEstado.ID);
                Datos.setearParametros("@IDEstado", VEstado.PEstado.ID);
                Datos.LecturaDB();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
