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
        public Cliente VCliente = new Cliente();
        public Usuario VUsuario = new Usuario();
        public List<Estado> VEstados = new List<Estado>();
        public List<Incidencia> LIncidencia = new List<Incidencia>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Session.Add("Error", "No hay un usuario logueado");
                    Response.Redirect("Error.aspx", false);
                }
                cargar_ticket();
                cargar_incidencias();
                cargar_cliente();
                cargar_usuario();
                cargar_estado();
                Session.Add("TID", VTicket.ID);
                ddlEstados.Items.FindByValue(VTicket.PEstado.ID.ToString()).Selected = true;
            }
        }

        public void cargar_ticket()
        {
            TicketServicio TServicio = new TicketServicio();
            try
            {
                VTicket.ID = (int)Session["TicketID"];
                VTicket = TServicio.Listar(Convert.ToInt32(Session["TicketID"]));
                lblTitulo.Text = VTicket.Titulo.ToString();
                txbComentario.Text = VTicket.Comentario.ToString();
                lblEstado.Text = "Estado: " + VTicket.PEstado.Nombre;
                lblCreacion.Text = "Fecha de creación: " + VTicket.Fecha_Creacion.ToString("dd/MM/yyyy");
                if (VTicket.Fecha_Cierre.Year < 2005)
                {
                    lblCierre.Text = "Fecha de cierre: Sin Fecha";
                }
                else
                {
                    lblCierre.Text = "Fecha de cierre: " + VTicket.Fecha_Cierre.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        public void cargar_incidencias()
        {
            IncidenciaServicio Service = new IncidenciaServicio();
            try
            {
                LIncidencia = Service.Listar(Convert.ToInt32(Session["TicketID"]));
                Session.Add("ListaInc", LIncidencia);
                gvIncidencias.DataSource = LIncidencia;
                gvIncidencias.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
        }

        public void cargar_cliente()
        {
            ClienteServicio Service = new ClienteServicio();
            VCliente = Service.Buscar(VTicket.PCliente.ID);
            try
            {
                lblCNombre.Text = "Nombre: " + VCliente.RazonSocial;
                lblCUIT.Text = "CUIT/CUIL: " + VCliente.Cuit;
                lblCTipo.Text = "Tipo: " + VCliente.Tipo.Nombre;
                lblCTelefono.Text = "Telefono: " + VCliente.Telefono;
                lblCMail.Text = "Correo: " + VCliente.Email;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargar_estado()
        {
            EstadoServicio EstadoService = new EstadoServicio();
            VEstados = EstadoService.Listar();
            try
            {
                ddlEstados.DataSource = VEstados;
                ddlEstados.DataTextField = "Nombre";
                ddlEstados.DataValueField = "ID";
                ddlEstados.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        public void cargar_usuario()
        {
            UsuarioServicio Service = new UsuarioServicio();
            VUsuario = Service.Buscar(VTicket.PResponsable.ID);

            try
            {
                lblRNombre.Text ="Nombre: " +  VUsuario.Nombre + " " + VUsuario.Apellido;
                lblRUser.Text ="User: " + VUsuario.NombreUsuario;
                lblRID.Text = "ID: " + VUsuario.ID.ToString();
                lblRTipo.Text = "Tipo: " + VUsuario.Tipo.Tipo.ToString();
                lblRTelefono.Text = "Telefono: " + VUsuario.Telefono;
                lblRMail.Text = "Correo: " + VUsuario.Email;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCargarIncidencia_Click(object sender, EventArgs e)
        {
            Incidencia aux = new Incidencia();
            LIncidencia = (List<Incidencia>)Session["ListaInc"];

            aux = LIncidencia.Last();
            Session.Add("Incidencia", aux);
            Response.Redirect("NuevaIncidencia.aspx",false);
        }

        protected void btnEstado_Click(object sender, EventArgs e)
        {
            TicketServicio TServicio = new TicketServicio();
            VTicket = TServicio.Listar(Convert.ToInt32(Session["TicketID"]));
            if (int.Parse(ddlEstados.SelectedItem.Value) != VTicket.PEstado.ID)
            {
                Session.Add("TEstado", ddlEstados.SelectedItem.Value);
                Response.Redirect("NuevaIncidencia.aspx", false);
            }
            else
            {
                lblEstado.CssClass = "btn-danger p-2 ps-3 pe-3";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
        
    }
}