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
    public partial class NuevoTecnico : System.Web.UI.Page
    {
        public List<Especialidad> LEsp;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_especialidad();
        }

        private void cargar_especialidad()
        {
            EspecialidadServicio Servicio = new EspecialidadServicio();
            LEsp = Servicio.Listar();

            ddlEspecialidad.DataSource = LEsp;
            ddlEspecialidad.DataBind();
        }
    }
}