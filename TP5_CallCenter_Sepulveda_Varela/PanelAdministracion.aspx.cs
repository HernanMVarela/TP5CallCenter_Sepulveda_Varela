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
    public partial class PanelAdministracion : System.Web.UI.Page
    {
        List<Tecnico> LTec = new List<Tecnico>();
        List<Cliente> LClie = new List<Cliente>();
        List<Usuario> LUser = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_cliente();
                cargar_tecnico();
                cargar_usuario();
            }

        }

        private void cargar_tecnico()
        {
            TecnicoServicio TechService = new TecnicoServicio();
            LTec = TechService.Listar();
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

        private void cargar_usuario()
        {
            UsuarioServicio UserService = new UsuarioServicio();
            LUser = UserService.Listar();
            try
            {
                ddlUsuario.DataSource = LUser;
                ddlUsuario.DataTextField = "NombreCompleto";
                ddlUsuario.DataValueField = "ID";
                ddlUsuario.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaTecnico.aspx", false);
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("ControlUsuarios.aspx", false);
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaCliente.aspx", false);
        }
    }
}