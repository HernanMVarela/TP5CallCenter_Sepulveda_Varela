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

        protected void btnModificarTecnico_Click(object sender, EventArgs e)
        {
            TecnicoServicio TechService = new TecnicoServicio();
            Tecnico modificar = new Tecnico();
            int id = 0;
            id = int.Parse(ddlTecnico.SelectedItem.Value);
            LTec = TechService.Listar();
            modificar = LTec.Find(x => x.ID == id);
            Session.Add("ModTecnico", modificar);
            Response.Redirect("AltaTecnico.aspx", false);
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioServicio UsrService = new UsuarioServicio();
            Usuario modificar = new Usuario();
            int id = 0;
            id = int.Parse(ddlUsuario.SelectedItem.Value);
            LUser = UsrService.Listar();
            modificar = LUser.Find(x => x.ID == id);
            Session.Add("ModUsuario", modificar);
            Response.Redirect("ControlUsuarios.aspx", false);
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
            Response.Redirect("AltaCliente.aspx", false);
        }
    }
}