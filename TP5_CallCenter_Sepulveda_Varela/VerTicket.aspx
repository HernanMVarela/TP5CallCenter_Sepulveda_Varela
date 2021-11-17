<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerTicket.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.VerTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid fondo_contenedor" style="min-height:500px;">
        <div class="row cuadro_uno w-auto ms-2 me-2 mt-2">  
            <div class="col-12 d-flex justify-content-center align-items-center">
                <asp:Label ID="lblTitulo" runat="server" Font-Size="40px" Text="Titulo"></asp:Label>
            </div>
        </div>
        <div class="row cuadro_uno w-auto ms-2 me-2 mt-2">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <asp:GridView ID="gvIncidencias" runat="server"></asp:GridView>
            </div>
        </div>
        <div class="row cuadro_uno w-auto ms-2 me-2 mt-2">
            <div class="col-4 d-flex justify-content-center align-items-center">   
                <asp:Label ID="lblResponsable" runat="server" Font-Size="28px" Text="Responsable"></asp:Label>
            </div>
            <div class="col-4 d-flex justify-content-center align-items-center">
                <asp:Label ID="lblTecnico" runat="server" Font-Size="28px" Text="Tecnico"></asp:Label>
            </div>
            <div class="col-4 d-flex justify-content-center align-items-center">
                <asp:Label ID="lblCliente" runat="server" Font-Size="28px" Text="Cliente"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
