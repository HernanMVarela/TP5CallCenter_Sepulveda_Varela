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
        List<Tecnico> LTec;
        List<Cliente> LClie;

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
            LTec=TechService.Listar();
            try
            {
                ddlTecnico.DataSource = LTec;
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

                throw ex;
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
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
            Tecnico modificar = new Tecnico();
            int id=0;
            id = int.Parse(ddlTecnico.SelectedItem.Value);
            LTec = TechService.Listar();
            modificar = LTec.Find(x => x.ID == id);

            Session.Add("ModTecnico", modificar);
            Response.Redirect("AltaTecnico.aspx");
        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {

        }
    }
}