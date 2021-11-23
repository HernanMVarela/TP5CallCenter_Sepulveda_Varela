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
    public partial class NuevoTicket : System.Web.UI.Page
    {
        List<Tecnico> LTec = new List<Tecnico>();
        List<Cliente> LClie = new List<Cliente>();
        List<Categoria> LCate = new List<Categoria>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargar_cliente();
                cargar_tecnico();
                cargar_categoria();
            }
        }

        private void cargar_tecnico()
        {
            TecnicoServicio TechService = new TecnicoServicio();
            LTec =TechService.Listar();
            try
            {
                ddlTecnico.DataSource = LTec;
                ddlTecnico.DataTextField = "NombreCompleto";
                ddlTecnico.DataValueField = "ID";
                ddlTecnico.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargar_cliente()
        {
            ClienteServicio CliService = new ClienteServicio();
            LClie = CliService.Listar();
            try
            {
                ddlCliente.DataSource = LClie;
                ddlCliente.DataTextField = "RazonSocial";
                ddlCliente.DataValueField = "ID";
                ddlCliente.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargar_categoria()
        {
            CategoriaServicio CateService = new CategoriaServicio();
            LCate = CateService.Listar();
            try
            {
                ddlCategoria.DataSource = LCate;
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataValueField = "ID";
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Session.Add("ModCliente", null); 
            Response.Redirect("AltaCliente.aspx", false);
        }

        protected void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            Session.Add("ModTecnico", null);
            Response.Redirect("AltaTecnico.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Incidencia Inuevo = new Incidencia();
            Ticket Tnuevo = new Ticket();
            TicketServicio TService = new TicketServicio();
            IncidenciaServicio IService = new IncidenciaServicio();

            try
            {
                Tnuevo.Titulo = txbAsunto.Text;
                Tnuevo.Comentario = txbDescripcion.Text;
                Tnuevo.Fecha_Creacion = DateTime.Now;
                Tnuevo.PResponsable = new Usuario();
                Tnuevo.PResponsable.ID = 1;                // Pendiente a modificar con usuario logueado
                Tnuevo.PCliente = new Cliente();
                Tnuevo.PCliente.ID = int.Parse(ddlCliente.SelectedItem.Value);
                Tnuevo.PEstado = new Estado();
                Tnuevo.PEstado.ID = 1; // Se inicia con estado abierto

                TService.Agregar(Tnuevo);

                Inuevo.PCategoria = new Categoria();
                Inuevo.PCategoria.ID = int.Parse(ddlCategoria.SelectedItem.Value);
                Inuevo.Modificacion = DateTime.Now;
                Inuevo.Descripcion = txbComentario.Text;
                Inuevo.PTecnico = new Tecnico();
                Inuevo.PTecnico.ID = int.Parse(ddlTecnico.SelectedItem.Value);
                Inuevo.IDTicket = TService.BuscarUltimo();

                IService.Agregar(Inuevo);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

            Response.Redirect("Default.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnModificarTecnico_Click(object sender, EventArgs e)
        {
            TecnicoServicio TechService = new TecnicoServicio();
            Tecnico modificar = new Tecnico();
            int id=0;
            id = int.Parse(ddlTecnico.SelectedItem.Value);
            LTec = TechService.Listar();
            modificar = LTec.Find(x => x.ID == id);
            Session.Add("ModTecnico", modificar);
            Response.Redirect("AltaTecnico.aspx",false);
        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            ClienteServicio CliService = new ClienteServicio();
            Cliente modificar = new Cliente();
            int id = 0;
            id = int.Parse(ddlCliente.SelectedItem.Value);
            LClie = CliService.Listar();
            modificar = LClie.Find(x => x.ID == id);
            Session.Add("ModCliente", modificar);
            Response.Redirect("AltaCliente.aspx",false);
        }
    }
}