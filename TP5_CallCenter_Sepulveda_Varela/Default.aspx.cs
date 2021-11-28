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
        public List<Ticket> Lticket;
        Usuario Lusr = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Valida si hay usuario logueado
                if (Session["UserID"] == null)
                {
                    //No hay usuario
                    Session.Add("Error", "No hay un usuario logueado");
                    Response.Redirect("Error.aspx", false);
                } 
                else
                {
                    //Hay usuario
                    cargar_usuario((int)Session["UserID"]);  // Carga datos del usuario
                    cargar_ticket();                         // Carga lista de tickets
                    if(Lusr.Tipo.Tipo != "Administrador")    // Valida si usuario es admin
                    {
                        btnPanelAdmin.Enabled = false;       // Deshabilita boton de panel admin   
                    }
                }
            }
        }

        private void cargar_usuario(int id)
        {
            UsuarioServicio Service = new UsuarioServicio();
            try
            {
                // Carga usuario por ID
                Lusr = Service.Buscar(id);
                lblNombre.Text = Lusr.Nombre + " " + Lusr.Apellido;
                lblUsuario.Text = Lusr.NombreUsuario;
                lblTelefono.Text = "Telefono: " + Lusr.Telefono;
                lblEmail.Text = "Correo: " + Lusr.Email;
            }
            catch (Exception ex)
            {
                // ERROR
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargar_ticket()
        {
            // Carga lista de Tickets
            TicketServicio Servicio = new TicketServicio();
            Lticket = Servicio.Listar();

            // Verifica tipo de usuario
            if(Lusr.Tipo.Tipo == "Telefonista")
            {
                // Filtra Lista de ticket si usuario es Telefonista 
                gvTickets.DataSource = Lticket.FindAll(x => x.PResponsable.ID == Lusr.ID);
            }
            else
            {
                // Muestra lista de tickets completa
                gvTickets.DataSource = Lticket;
            }
            gvTickets.DataBind();
        }

        protected void btnNuevoTicket_Click(object sender, EventArgs e)
        {
            // NUEVO TICKET
            Response.Redirect("NuevoTicket.aspx");
        }

        protected void btnPanelAdmin_Click(object sender, EventArgs e)
        {
            // PANEL DE ADMINISTRACION
            Response.Redirect("PanelAdministracion.aspx");
        }

        protected void gvTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Direccion a Ver Ticket con ID del ticket seleccionado en la grilla
            GridViewRow row = gvTickets.SelectedRow;
            Session.Add("TicketID", Convert.ToInt32(row.Cells[0].Text));
            Response.Redirect("VerTicket.aspx");
        }

        protected void gvTickets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Verifica fechas y filtra menores de 2002
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime cierre = Convert.ToDateTime(e.Row.Cells[6].Text);
                if (cierre.Year < 2002)
                {
                    e.Row.Cells[6].Text = "Sin Fecha";
                }
            }
        }
    }
}