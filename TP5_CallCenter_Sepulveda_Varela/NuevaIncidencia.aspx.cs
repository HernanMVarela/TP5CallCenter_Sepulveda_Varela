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
    public partial class NuevaIncidencia : System.Web.UI.Page
    {
        Incidencia Nuevo = new Incidencia();
        List<Tecnico> VTecnico = new List<Tecnico>();
        List<Categoria> LCate = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Nuevo.IDTicket = (int)Session["TID"];
                lblIncidencia.Text = "Nueva incidencia - Ticket " + Nuevo.IDTicket.ToString();
                cargar_tecnico();
                cargar_categoria();
                Session.Add("TID", Nuevo.IDTicket);
            }
        }

        private void cargar_tecnico()
        {
            TecnicoServicio TechService = new TecnicoServicio();
            VTecnico = TechService.Listar();
            try
            {
                ddlTecnico.DataSource = VTecnico;
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerTicket.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}