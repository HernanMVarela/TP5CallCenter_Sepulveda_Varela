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
        public ClienteServicio CliService = new ClienteServicio();
        public TecnicoServicio TechService = new TecnicoServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargar_cliente();
                cargar_tecnico();
            }
        }

        private void cargar_tecnico()
        {
            List<Tecnico> LEsp = TechService.Listar();
            try
            {
                ddlTecnico.DataSource = LEsp;
                ddlTecnico.DataTextField = "NombreCompleto";
                ddlTecnico.DataValueField = "ID";
                ddlTecnico.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cargar_cliente()
        {
            List<Cliente> LEsp = CliService.Listar();
            try
            {
                ddlCliente.DataSource = LEsp;
                ddlCliente.DataTextField = "RazonSocial";
                ddlCliente.DataValueField = "ID";
                ddlCliente.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaCliente.aspx");
        }

        protected void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaTecnico.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificarTecnico_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {

        }
    }
}