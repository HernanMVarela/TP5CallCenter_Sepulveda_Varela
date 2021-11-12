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
    public partial class NuevoTecnico : Page
    {
        public Tecnico nuevo = new Tecnico();
        public List<Especialidad> LEsp;
        public string dato = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_especialidad();
            }
        }

        private void cargar_especialidad()
        {
            try
            {
                EspecialidadServicio Servicio = new EspecialidadServicio();
                LEsp = Servicio.Listar();

                ddlEspecialidad.DataSource = LEsp;
                ddlEspecialidad.DataTextField = "Nombre";
                ddlEspecialidad.DataValueField = "ID";
                ddlEspecialidad.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private void AgregarTecnico()
        {
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoTicket.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            dato = txbNombre.Text;
            //Response.Redirect("NuevoTicket.aspx", false);
        }

    
    }
}