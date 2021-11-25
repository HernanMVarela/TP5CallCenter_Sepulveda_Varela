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
    public partial class NuevaIncidencia : System.Web.UI.Page
    {
        Ticket Vticket = new Ticket();
        Incidencia Nuevo = new Incidencia();
        List<Tecnico> VTecnico = new List<Tecnico>();
        List<Categoria> LCate = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Nuevo.IDTicket = (int)Session["TID"];
                lblIncidencia.Text = "Nueva incidencia - Ticket " + Nuevo.IDTicket.ToString();
                cargar_tecnico();
                cargar_categoria();
                Session.Add("TID", Nuevo.IDTicket);

                if (!(Session["Incidencia"] is null))
                {
                    Incidencia aux = new Incidencia();

                    aux = (Incidencia)Session["Incidencia"];

                    ddlTecnico.Items.FindByValue(aux.PTecnico.ID.ToString()).Selected = true;
                    ddlCategoria.Items.FindByValue(aux.PCategoria.ID.ToString()).Selected = true;
                }


                if (!(Session["TEstado"] is null))
                {
                    btnCancelar.Enabled = false;
                    Vticket.PEstado = new Estado();
                    Vticket.PEstado.ID = Convert.ToInt32(Session["TEstado"]);
                    Session.Add("TEstado", Vticket.PEstado.ID);
                }
                else
                {
                    btnCancelar.Enabled = true;
                }
            }
        }
        private void cargar_tecnico()
        {
            TecnicoServicio TechService = new TecnicoServicio();
            VTecnico = TechService.Listar();
            try
            {
                ddlTecnico.DataSource = VTecnico;
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

        private void cargar_categoria()
        {
            CategoriaServicio CateService = new CategoriaServicio();
            LCate = CateService.Listar();
            try
            {
                ddlCategoria.DataSource = LCate;
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataValueField = "ID";
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerTicket.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            IncidenciaServicio Servicio = new IncidenciaServicio();
            try
            {
                // Check por comentario vacio
                if (txbComentario.Text == "")
                {
                    txbComentario.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    //Nueva incidencia
                    txbComentario.BorderColor = System.Drawing.Color.White;
                    Nuevo.Descripcion = txbComentario.Text;
                    Nuevo.Modificacion = DateTime.Now;
                    Nuevo.PTecnico = new Tecnico();
                    Nuevo.PTecnico.ID = int.Parse(ddlTecnico.SelectedItem.Value);
                    Nuevo.PCategoria = new Categoria();
                    Nuevo.PCategoria.ID = int.Parse(ddlCategoria.SelectedItem.Value);
                    Nuevo.IDTicket = (int)Session["TID"];
                    Servicio.Agregar(Nuevo);

                    //Cambio de estado en ticket
                    if (!(Session["TEstado"] is null))
                    {
                        TicketServicio TService = new TicketServicio();

                        Vticket.ID = (int)Session["TID"];
                        Vticket.PEstado = new Estado();
                        Vticket.PEstado.ID = (int)Session["TEstado"];
                        TService.Cambiar_Estado(Vticket);
                    }
                    Response.Redirect("VerTicket.aspx",false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}