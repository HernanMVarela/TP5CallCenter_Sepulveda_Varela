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
        List<Tecnico> LTec = new List<Tecnico>();
        List<Cliente> LClie = new List<Cliente>();
        List<Categoria> LCate = new List<Categoria>();
        Usuario LogUser = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // Valida si hay usuario logueado
                if (Session["UserID"] == null)
                {
                    //No hay usuario
                    Session.Add("Error", "No hay un usuario logueado");
                    Response.Redirect("Error.aspx", false);
                }
                cargar_cliente();   //Carga lista de clientes
                cargar_tecnico();   //Carga lista de tecnicos
                cargar_categoria(); //Carga lista de categorias
            }
        }

        private void cargar_tecnico()
        {
            TecnicoServicio TechService = new TecnicoServicio();
            LTec =TechService.Listar();
            try
            {
                ddlTecnico.DataSource = LTec;
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

        private void cargar_cliente()
        {
            ClienteServicio CliService = new ClienteServicio();
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

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            //Cliente nuevo
            Session.Add("ModCliente", null); 
            Response.Redirect("AltaCliente.aspx", false);
        }

        protected void btnAgregarTecnico_Click(object sender, EventArgs e)
        {
            //Tecnico nuevo
            Session.Add("ModTecnico", null);
            Response.Redirect("AltaTecnico.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            // NUEVO TICKET CON PRIMER INCIDENCIA
            Incidencia Inuevo = new Incidencia();
            Ticket Tnuevo = new Ticket();
            TicketServicio TService = new TicketServicio();
            IncidenciaServicio IService = new IncidenciaServicio();

            try
            {
                // VALIDA QUE LOS CAMPOS NO ESTEN VACIOS - SON OBLIGATORIOS
                if (txbAsunto.Text == "" || txbComentario.Text == "" || txbDescripcion.Text == "")
                {
                    txbAsunto.BorderColor = System.Drawing.Color.Red;
                    txbComentario.BorderColor = System.Drawing.Color.Red;
                    txbDescripcion.BorderColor = System.Drawing.Color.Red;
                }
                else
                {
                    txbAsunto.BorderColor = System.Drawing.Color.White;
                    txbComentario.BorderColor = System.Drawing.Color.White;
                    txbDescripcion.BorderColor = System.Drawing.Color.White;

                    // CARGA DATOS DEL TICKET DESDE TEXTBOXS Y PREDETERMINADOS
                    Tnuevo.Titulo = txbAsunto.Text;
                    Tnuevo.Comentario = txbDescripcion.Text;
                    Tnuevo.Fecha_Creacion = DateTime.Now;
                    Tnuevo.PResponsable = new Usuario();
                    Tnuevo.PResponsable.ID = (int)Session["UserID"];
                    Tnuevo.PCliente = new Cliente();
                    Tnuevo.PCliente.ID = int.Parse(ddlCliente.SelectedItem.Value);
                    Tnuevo.PEstado = new Estado();
                    Tnuevo.PEstado.ID = 1; // Se inicia con estado abierto

                    TService.Agregar(Tnuevo); // Agrega ticket a DB (IMPORTANTE *1 - VER NUEVA INCIDENCIA)

                    // CARGA DATOS DE NUEVA INCIDENCIA DESDE TEXTBOXS Y PREDETERMINADOS
                    Inuevo.PCategoria = new Categoria();
                    Inuevo.PCategoria.ID = int.Parse(ddlCategoria.SelectedItem.Value);
                    Inuevo.Modificacion = DateTime.Now;
                    Inuevo.Descripcion = txbComentario.Text;
                    Inuevo.PTecnico = new Tecnico();
                    Inuevo.PTecnico.ID = int.Parse(ddlTecnico.SelectedItem.Value);

                    // *1 - BUSCA ID DE ULTIMO TICKET GUARDADO EN DB (EL VALOR DE ARRIBA) Y LO ASIGNA
                    Inuevo.IDTicket = TService.BuscarUltimo();

                    // Agrega Incidencia a DB
                    IService.Agregar(Inuevo);
                    // REGRESA A HOME
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                // ERROR
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // CANCELAR - REGRESA A HOME
            Response.Redirect("Default.aspx", false);
        }

        protected void btnModificarTecnico_Click(object sender, EventArgs e)
        {
            // MODIFICAR TECNICO
            TecnicoServicio TechService = new TecnicoServicio();
            Tecnico modificar = new Tecnico();
            int id=0;
            id = int.Parse(ddlTecnico.SelectedItem.Value);  // BUSCA ID SELECCIONADO EN LISTA
            LTec = TechService.Listar();                    // CARGA LISTA DE TECNICOS
            modificar = LTec.Find(x => x.ID == id);         // SELECCIONA EL TECNICO DE LA LISTA 
            Session.Add("ModTecnico", modificar);           // Y LO GUARDA
            Response.Redirect("AltaTecnico.aspx",false);    // REDIRECCIONA
        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            ClienteServicio CliService = new ClienteServicio();
            Cliente modificar = new Cliente();
            int id = 0;
            id = int.Parse(ddlCliente.SelectedItem.Value);  // BUSCA ID SELECCIONADO EN LISTA
            LClie = CliService.Listar();                    // CARGA LISTA DE CLIENTES
            modificar = LClie.Find(x => x.ID == id);        // SELECCIONA EL TECNICO DE LA LISTA
            Session.Add("ModCliente", modificar);           // Y LO GUARDA
            Response.Redirect("AltaCliente.aspx",false);    // REDIRECCIONA
        }
    }
}