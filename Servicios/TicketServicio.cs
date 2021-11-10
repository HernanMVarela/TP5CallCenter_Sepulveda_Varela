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
                Datos.SetearComando("SELECT TK.ID, TK.IDEstado, TK.IDTecnico, TK.IDCliente, TK.IDIncidencia, TK.Fecha_Creacion, TK.Fecha_Cierre from Tickets TK");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Ticket Aux = new Ticket();
                    Aux.ID = (int)Datos.Lector["ID"];
                    Aux.IDEstado = (int)Datos.Lector["IDEstado"];
                    Aux.IDTecnico = (int)Datos.Lector["IDTecnico"];
                    Aux.IDCliente = (int)Datos.Lector["IDCliente"];
                    Aux.IDIncidencia = (int)Datos.Lector["IDIncidencia"];
                    Aux.Fecha_Creacion = (DateTime)Datos.Lector["Fecha_Creacion"];
                    Aux.Fecha_Cierre = (DateTime)Datos.Lector["Fecha_Cierre"];

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
