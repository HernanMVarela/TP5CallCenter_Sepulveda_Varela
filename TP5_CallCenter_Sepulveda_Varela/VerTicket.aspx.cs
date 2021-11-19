using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Servicios;

namespace TP5_CallCenter_Sepulveda_Varela
{    
    public partial class VerTicket : System.Web.UI.Page
    {
        public Ticket VTicket = new Ticket();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargar_ticket();
            }    
        }

        public void cargar_ticket()
        {
            TicketServicio TServicio = new TicketServicio();
            
            VTicket = TServicio.Listar(Convert.ToInt32(Session["TicketID"]));
            lblTitulo.Text = VTicket.Titulo.ToString();
            txbComentario.Text = VTicket.Comentario.ToString();
            lblEstado.Text = VTicket.Estado;
            lblCreacion.Text = VTicket.Fecha_Creacion.Date.ToString();
            lblCierre.Text = VTicket.Fecha_Cierre.Date.ToString();
        }
    }
}