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
        public List<Usuario> Lusr;


        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_usuario();
        }

        private void cargar_usuario()
        {
            
            UsuarioServicio Service = new UsuarioServicio();
            Lusr = Service.Listar();
            lblNombre.Text = Lusr[0].Nombre + " " + Lusr[0].Apellido;
            lblUsuario.Text =Lusr[0].NombreUsuario;
            lblTelefono.Text ="Telefono: " + Lusr[0].Telefono;
            lblEmail.Text = "Correo: " + Lusr[0].Email;

        }

        protected void btnNuevoTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect("/NuevoTicket.aspx");
        }
    }
}