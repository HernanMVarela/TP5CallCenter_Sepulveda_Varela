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
        EspecialidadServicio Servicio = new EspecialidadServicio();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Session.Add("Error", "No hay un usuario logueado");
                    Response.Redirect("Error.aspx", false);
                }
                cargar_especialidad();

                if(!(Session["ModTecnico"] is null))
                {
                    nuevo=(Tecnico)Session["ModTecnico"];
                    txbNombre.Text = nuevo.Nombre;
                    txbApellido.Text = nuevo.Apellido;
                    txbEmail.Text = nuevo.Email;
                    txbTelefono.Text = nuevo.Telefono;
                    ddlEspecialidad.Items.FindByValue(nuevo.EspecialidadTecnico.ID.ToString()).Selected = true;
                }
            }
        }

        private void cargar_especialidad()
        {
            List<Especialidad> LEsp = Servicio.Listar();
            try
            {
                ddlEspecialidad.DataSource = LEsp;
                ddlEspecialidad.DataTextField = "Nombre";
                ddlEspecialidad.DataValueField = "ID";
                ddlEspecialidad.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoTicket.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

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

                nuevo.EspecialidadTecnico = new Especialidad();
                nuevo.EspecialidadTecnico.ID = int.Parse(ddlEspecialidad.SelectedItem.Value);
                nuevo.EspecialidadTecnico.Nombre = ddlEspecialidad.SelectedItem.Text;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

            TecnicoServicio TechService = new TecnicoServicio();
            
            if (!(Session["ModTecnico"] is null))
            {
                Tecnico Aux = new Tecnico();
                Aux = (Tecnico)Session["ModTecnico"];
                nuevo.ID = Aux.ID;
                TechService.ModificarDB(nuevo);
            }
            else
            {
                TechService.AgregarDB(nuevo);
            }
            Response.Redirect("NuevoTicket.aspx", false);
        }
    }
}