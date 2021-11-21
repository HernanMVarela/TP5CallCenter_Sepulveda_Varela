﻿using System;
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
                cargar_ticket();
                cargar_incidencias();
                cargar_cliente();
                cargar_usuario();
                cargar_tecnico();
                Session.Add("TID", VTicket.ID);
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
                lblCierre.Text = "Fecha de cierre: " + VTicket.Fecha_Cierre.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        public void cargar_incidencias()
        {
            IncidenciaServicio Service = new IncidenciaServicio();
            try
            {
                LIncidencia = Service.Listar(Convert.ToInt32(Session["TicketID"]));

                gvIncidencias.DataSource = LIncidencia;
                gvIncidencias.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
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
                Response.Redirect("Error.aspx");
            }
        }

        private void cargar_tecnico()
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
                Response.Redirect("Error.aspx");
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
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnCargarIncidencia_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("NuevaIncidencia.aspx");
        }

        protected void btnEstado_Click(object sender, EventArgs e)
        {
            TicketServicio TServicio = new TicketServicio();
            VTicket = TServicio.Listar(Convert.ToInt32(Session["TicketID"]));
            if (int.Parse(ddlEstados.SelectedItem.Value) != VTicket.PEstado.ID)
            {
                Session.Add("TEstado", ddlEstados.SelectedItem.Value);
                Response.Redirect("NuevaIncidencia.aspx");
            }
            else
            {
                lblEstado.CssClass = "btn-danger";
            }
        }
    }
}