<%@ Page Title="Panel principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid fondo_contenedor overflow-hidden" style="min-height:500px">
        <div class="row m-2">
            <div class="col cuadro_uno m-2 h-auto">
                <div class="row m-2">
                    <div class="col-12">
                        <h1>Tickets</h1>
                    </div>
                </div>
                <div class="row m-2">
                    <div class="col-12">   
                        <asp:GridView ID="gvTickets" AutoGenerateColumns="true" runat="server"></asp:GridView>
                    </div>
                </div>
                <div class="row m-4">
                    <div class="col-4 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnNuevoTicket" class="btn btn-outline-info" OnClick="btnNuevoTicket_Click" runat="server" Text="Nuevo Ticket" />
                    </div>
                    <div class="col-4 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnAsignar" class="btn btn-outline-info" runat="server" Text="Asignar" />
                    </div>
                    <div class="col-4 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnModificar" class="btn btn-outline-info" runat="server" Text="Modificar" />
                    </div>
                </div>
                
            </div>
            <div class="col-4 m-2">    
                <div class="row h-auto cuadro_uno">
                    <div class="col align-items-md-start">
                        <h1>Usuario</h1>
                        <asp:Label ID="lblNombre" runat="server" style="font-size:30px;" Text=""></asp:Label>
                        <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </div>
                </div>
        
                <div class="row h-auto cuadro_uno">
                    <div class="col ">
                        <div class="row m-1">
                            <h1>Técnico</h1>
                        </div>
                        <div class="row m-1">
                            <asp:Label ID="lblNombreTec" runat="server" Text="Nombre Completo"></asp:Label>
                        </div>
                        <div class="row m-1">
                            <asp:Label ID="lblEspecialidadTec" runat="server" Text="Especialidad"></asp:Label>
                        </div>
                        <div class="row m-1">
                            <asp:Label ID="lblTelefonoTec" runat="server" Text="Telefono"></asp:Label>
                        </div>
                        <div class="row m-1">
                            <asp:Label ID="lblEmailTec" runat="server" Text="Direccion de correo"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
