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
                if (Session["UserID"] == null)
                {
                    Session.Add("Error", "No hay un usuario logueado");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    UsuarioServicio UserService = new UsuarioServicio();
                    Usuario LogUser = UserService.Buscar((int)Session["UserID"]);
                    if(LogUser.Tipo.Tipo != "Administrador")
                    {
                        Session.Add("Error", "No tiene permisos para ingresar a esta página");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                cargar_cliente();
                cargar_tecnico();
                cargar_usuario();
                btnBajaCliente.Enabled = false;
                btnBajaTecnico.Enabled = false;
                btnBajaUsuario.Enabled = false;
            }
        }

        private void cargar_tecnico()
        {
            TecnicoServicio TechService = new TecnicoServicio();
            LTec = TechService.Listar();
            try
            {
                ddlTecnico.DataSource = LTec.FindAll(x => x.Estado == true);
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
                ddlCliente.DataSource = LClie.FindAll(x => x.Estado == true);
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
                ddlUsuario.DataSource = LUser.FindAll(x => x.Estado == true);
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
            Session["ModTecnico"] = null;
            Response.Redirect("AltaTecnico.aspx", false);
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Session["ModUsuario"] = null;
            Response.Redirect("ControlUsuarios.aspx", false);
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Session["ModCliente"] = null;
            Response.Redirect("AltaCliente.aspx", false);
        }

        protected void btnModificarTecnico_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
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

        protected void btnBajaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteServicio CliService = new ClienteServicio();
                CliService.BorrarDB(int.Parse(ddlCliente.SelectedItem.Value));
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void chbBajaUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (btnBajaUsuario.Enabled == false)
            {
                btnBajaUsuario.Enabled = true;
                btnBajaUsuario.CssClass = "btn btn-danger text-black fw-bold m-2 w-75";
            }
            else
            {
                btnBajaUsuario.Enabled = false;
                btnBajaUsuario.CssClass = "btn btn-outline-danger text-black fw-bold m-2 w-75";
            }
        }
        protected void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioServicio UserService = new UsuarioServicio();
                UserService.BorrarDB(int.Parse(ddlUsuario.SelectedItem.Value));
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void chbBajaCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (btnBajaCliente.Enabled == false)
            {
                btnBajaCliente.Enabled = true;
                btnBajaCliente.CssClass = "btn btn-danger text-black fw-bold m-2 w-75";
            }
            else
            {
                btnBajaCliente.Enabled = false;
                btnBajaCliente.CssClass = "btn btn-outline-danger text-black fw-bold m-2 w-75";
            }
        }

        protected void chbBajaTecnico_CheckedChanged(object sender, EventArgs e)
        {
            if (btnBajaTecnico.Enabled == false)
            {
                btnBajaTecnico.Enabled = true;
                btnBajaTecnico.CssClass = "btn btn-danger text-black fw-bold m-2 w-75";
            }
            else
            {
                btnBajaTecnico.Enabled = false;
                btnBajaTecnico.CssClass = "btn btn-outline-danger text-black fw-bold m-2 w-75";
            }
        }

        protected void btnBajaTecnico_Click(object sender, EventArgs e)
        {
            try
            {
                TecnicoServicio TecService = new TecnicoServicio();
                TecService.BorrarDB(int.Parse(ddlTecnico.SelectedItem.Value));
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        
    }
}