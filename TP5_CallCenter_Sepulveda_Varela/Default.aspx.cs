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
    public partial class _Default : Page
    {
        private List<Usuario> Lusr;
              
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_usuario();
        }

        private void cargar_usuario()
        {
            UsuarioServicio Service = new UsuarioServicio();
            Lusr = Service.Listar();
            ListaUsuarios.DataSource = Lusr;
        }
    }
}