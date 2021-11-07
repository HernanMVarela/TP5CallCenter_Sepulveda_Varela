<%@ Page Title="Panel principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid fondo_contenedor">
        <div class="row" style="min-width:80%;">
            <div class="col cuadro_uno">
                <div class="align-self-center">
                    <h1>Tickets</h1>
                    <asp:Table ID="tblTickets" class="table-secondary" runat="server"></asp:Table>
                </div>
                <div class="d-flex " style="padding:10px 5px 10px 5px">
                    <asp:Button ID="btnNuevoTicket" class="btn btn-outline-info" OnClick="btnNuevoTicket_Click" runat="server" Text="Nuevo Ticket" />
                    <asp:Button ID="btnAsignar" class="btn btn-outline-info" runat="server" Text="Asignar" />
                    <asp:Button ID="btnModificar" class="btn btn-outline-info" runat="server" Text="Modificar" />
                </div>
            </div>
            <div class="col-4">    
                <div class="cuadro_uno w-100 h-50" style="display:flex; align-items:center; flex-direction:column;">
                    <h1>Usuario</h1>
                    <asp:Label ID="lblNombre" runat="server" style="font-size:30px;" Text=""></asp:Label>
                    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </div>
        
                <div class="cuadro_uno w-100 h-auto" style="display:flex; align-items:center; flex-direction:column;"">
                    <h1>Técnico</h1>
                    <asp:Label ID="lblNombreTec" runat="server" Text="Nombre Completo"></asp:Label>
                    <asp:Label ID="lblEspecialidadTec" runat="server" Text="Especialidad"></asp:Label>
                    <asp:Label ID="lblTelefonoTec" runat="server" Text="Telefono"></asp:Label>
                    <asp:Label ID="lblEmailTec" runat="server" Text="Direccion de correo"></asp:Label>

                </div>
            </div>
        </div>
    </div>



</asp:Content>
