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
    public partial class AltaCliente : System.Web.UI.Page
    {
        TipoClienteServicio Servicio = new TipoClienteServicio();
        Cliente Nuevo = new Cliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTCliente();
                
                if (!(Session["ModCliente"] is null))
                {
                    Nuevo = (Cliente)Session["ModCliente"];
                    txbRazonsocial.Text = Nuevo.RazonSocial;
                    txbCuit.Text = Nuevo.Cuit;
                    txbEmail.Text = Nuevo.Email;
                    txbTelefono.Text = Nuevo.Telefono;
                }
            }
        }

        private void CargarTCliente()
        {
            List<TipoCliente> ListaTClientes = Servicio.Listar();
            try
            {
                ddlTipoCliente.DataSource = ListaTClientes;
                ddlTipoCliente.DataTextField = "Nombre";
                ddlTipoCliente.DataValueField = "ID";
                ddlTipoCliente.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
              

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoTicket.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbRazonsocial.Text == "")
                {
                    txbRazonsocial.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    txbRazonsocial.BorderColor = System.Drawing.Color.White;
                    Nuevo.RazonSocial = txbRazonsocial.Text;
                }
                if (txbCuit.Text == "")
                {
                    txbCuit.BorderColor = System.Drawing.Color.Red;

                }
                else
                {
                    txbCuit.BorderColor = System.Drawing.Color.White;
                    Nuevo.Cuit = txbCuit.Text;
                }
                if (txbEmail.Text == "")
                {
                    txbEmail.BorderColor = System.Drawing.Color.Red;

                }
                else
                {
                    txbEmail.BorderColor = System.Drawing.Color.White;
                    Nuevo.Email = txbEmail.Text;
                }
                if (txbTelefono.Text == "")
                {
                    txbTelefono.BorderColor = System.Drawing.Color.Red;

                }
                else
                {
                    txbTelefono.BorderColor = System.Drawing.Color.White;
                    Nuevo.Telefono = txbTelefono.Text;
                }
                Nuevo.Tipo = new TipoCliente();
                Nuevo.Tipo.ID = int.Parse(ddlTipoCliente.SelectedItem.Value);
                Nuevo.Tipo.Nombre = ddlTipoCliente.SelectedItem.Text;



                ClienteServicio ClServicio = new ClienteServicio();
                
                if (!(Session["ModCliente"] is null))
                {
                    Cliente aux = new Cliente();
                    aux = (Cliente)Session["ModCliente"];
                    Nuevo.ID = aux.ID;
                    ClServicio.ModificarDB(Nuevo);
                }
                else
                {
                    ClServicio.AgregarDB(Nuevo);
                }
                
                

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            Response.Redirect("NuevoTicket.aspx", false);
        }
    }
}