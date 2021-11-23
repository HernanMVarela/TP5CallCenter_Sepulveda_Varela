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
    public partial class _Default : Page
    {
        public List<Usuario> Lusr;
        public List<Ticket> Lticket;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_ticket();
                cargar_usuario();
            }
        }

        private void cargar_usuario()
        {
            UsuarioServicio Service = new UsuarioServicio();
            Lusr = Service.Listar();
            lblNombre.Text = Lusr[0].Nombre + " " + Lusr[0].Apellido;
            lblUsuario.Text =Lusr[0].NombreUsuario;
            lblTelefono.Text ="Telefono: " + Lusr[0].Telefono;
            lblEmail.Text = "Correo: " + Lusr[0].Email;
        }

        private void cargar_ticket()
        {
            TicketServicio Servicio = new TicketServicio();
            Lticket = Servicio.Listar();

            gvTickets.DataSource = Lticket;
            gvTickets.DataBind();
        }

        protected void btnNuevoTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoTicket.aspx");
        }

        protected void btnPanelAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelAdministracion.aspx");
        }

        protected void btnVerTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerTicket.aspx");
        }

        protected void gvTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvTickets.SelectedRow;
            Session.Add("TicketID", Convert.ToInt32(row.Cells[0].Text));
            Response.Redirect("VerTicket.aspx");
        }

        protected void gvTickets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime cierre = Convert.ToDateTime(e.Row.Cells[6].Text);
                if (cierre.ToShortDateString() == "01-Jan-01")
                {
                    e.Row.Cells[6].Text = "Sin Fecha";
                }
            }
        }
    }
}