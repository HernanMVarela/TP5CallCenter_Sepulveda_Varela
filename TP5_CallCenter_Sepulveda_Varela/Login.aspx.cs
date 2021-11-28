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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txbUsuario.Text == "" || txbPass.Text == "")
            {
                txbUsuario.BorderColor = System.Drawing.Color.Red;
                txbPass.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                txbUsuario.BorderColor = System.Drawing.Color.White;
                txbPass.BorderColor = System.Drawing.Color.White;

                Usuario User;
                UsuarioServicio UService = new UsuarioServicio();
                try
                {
                    User = new Usuario(txbUsuario.Text, txbPass.Text);
                    UService.Login(User);
                    if (User.ID != 0)
                    {
                        Session.Add("UserID", (int)User.ID);
                        Session.Add("UNombre",User.Nombre + " " + User.Apellido);
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            } 
        }
    }
}