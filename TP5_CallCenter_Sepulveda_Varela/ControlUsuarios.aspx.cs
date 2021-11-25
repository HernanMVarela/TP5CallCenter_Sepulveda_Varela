﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Servicios;


namespace TP5_CallCenter_Sepulveda_Varela
{
    public partial class ControlUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { cargar_tipocuenta(); }
        }
        private void cargar_tipocuenta()
        {
            TipoUsuarioServicio uService = new TipoUsuarioServicio();

            List<TipoUsuario> LEsp = uService.Listar();
            try
            {
                ddlTipo.DataSource = LEsp;
                ddlTipo.DataTextField = "Tipo";
                ddlTipo.DataValueField = "ID";
                ddlTipo.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario nuevo = new Usuario();
            try
            {
                if (txbNombre.Text == "")
                {
                    txbNombre.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    txbNombre.BorderColor = System.Drawing.Color.White;
                    nuevo.Nombre = (string)txbNombre.Text;
                }
                if (txbApellido.Text == "")
                {
                    txbApellido.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    txbApellido.BorderColor = System.Drawing.Color.White;
                    nuevo.Apellido = (string)txbApellido.Text;
                }
                if (txbEmail.Text == "")
                {
                    txbEmail.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    txbEmail.BorderColor = System.Drawing.Color.White;
                    nuevo.Email = (string)txbEmail.Text;
                }
                if (txbTelefono.Text == "")
                {
                    txbTelefono.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    txbTelefono.BorderColor = System.Drawing.Color.White;
                    nuevo.Telefono = (string)txbTelefono.Text;
                }
                if (txbUsername.Text == "")
                {
                    txbUsername.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    txbUsername.BorderColor = System.Drawing.Color.White;
                    nuevo.NombreUsuario = (string)txbUsername.Text;
                }
                if (txbPass.Text == "" || txbPass2.Text == "")
                {
                    txbPass.BorderColor = System.Drawing.Color.Red;
                    txbPass2.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (txbPass.Text == txbPass2.Text)
                    {
                        nuevo.Clave = txbPass.Text;
                        txbPass.BorderColor = System.Drawing.Color.White;
                        txbPass2.BorderColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        txbPass.BorderColor = System.Drawing.Color.Red;
                        txbPass2.BorderColor = System.Drawing.Color.Red;
                    }
                }
                nuevo.Tipo = new TipoUsuario();
                nuevo.Tipo.ID = int.Parse(ddlTipo.SelectedItem.Value);
                nuevo.Tipo.Tipo = ddlTipo.SelectedItem.Text;

                UsuarioServicio uService = new UsuarioServicio();
                uService.AgregarDB(nuevo);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            Response.Redirect("PanelAdministracion.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelAdministracion.aspx", false);
        }
    }
}