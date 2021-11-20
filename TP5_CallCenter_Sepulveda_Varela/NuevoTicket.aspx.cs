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
                Response.Redirect("Error.aspx");
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
                Response.Redirect("Error.aspx");
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
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Session.Add("ModCliente", null); 
            Response.Redirect("AltaCliente.aspx");
        }

        protected void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            Session.Add("ModTecnico", null);
            Response.Redirect("AltaTecnico.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
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