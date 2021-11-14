<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoTicket.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.NuevoTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid cuadro_uno overflow-hidden" style="min-height:600px;">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <asp:Label ID="lblNuevoTicket" style="font-size:40px;" runat="server" Text="Nuevo ticket"></asp:Label>
            </div>
        </div>
        <div class="row my-3 me-2">
            <div class="col-2 d-flex justify-content-center align-items-center">
                <asp:Label ID="lblDescripcion" style="font-size:30px;" runat="server" Text="Descripción"></asp:Label>
            </div>
            <div class="col d-flex justify-content-center align-items-center">
                <asp:TextBox ID="txbDescripcion" class="w-100" style="min-height:150px; max-height:250px" MaxLength="350" TextMode="MultiLine" Wrap="true" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row my-2 me-2">
            <div class="col-2 d-flex justify-content-center align-items-center">   
                <asp:Label ID="lblCliente" style="font-size:30px;" runat="server" Text="Cliente"></asp:Label>
            </div>
            <div class="col-4 d-flex justify-content-start align-items-center">
                <asp:DropDownList ID="ddlCliente" class="btn btn-secondary" style="width:100%" runat="server"></asp:DropDownList>
            </div>
            <div class="col-1 d-flex justify-content-center align-items-center">
                <asp:Button ID="btnAgregarCliente" class="btn btn-primary" OnClick="btnAgregarCliente_Click" runat="server" Text="Agregar"/>
            </div>
            <div class="col-1 d-flex justify-content-center align-items-center">
                <asp:Button ID="btnModificarCliente" class="btn btn-primary" OnClick="btnModificarCliente_Click" runat="server" Text="Modificar"/>
            </div>
            <div class="col-4 d-flex justify-content-center align-items-center">>   
                <%-- columna vacia --%>
            </div>
        </div>
        <div class="row my-2 me-2">
            <div class="col-2 d-flex justify-content-center align-items-center">   
                <asp:Label ID="lblTecnico" style="font-size:30px;" runat="server" Text="Técnico"></asp:Label>
            </div>
            <div class="col-4 d-flex justify-content-start align-items-center">
                <asp:DropDownList ID="ddlTecnico" class="btn btn-secondary" style="width:100%" runat="server"></asp:DropDownList>
            </div>
            <div class="col-1 d-flex justify-content-center align-items-center">
                <asp:Button ID="btnAgregarTecnico" class="btn btn-primary" OnClick="btnAgregarTecnico_Click" runat="server" Text="Agregar" />
            </div>
            <div class="col-1 d-flex justify-content-center align-items-center">
                <asp:Button ID="btnModificarTecnico" class="btn btn-primary" OnClick="btnModificarTecnico_Click" runat="server" Text="Modificar" />
            </div>
            <div class="col-4 d-flex justify-content-center align-items-center">>   
                <%-- columna vacia --%>
            </div>
        </div>
        <div class="row mb-2 mt-3 me-2">
            <div class="col-2 d-flex justify-content-center align-items-center">   
                <asp:Label ID="lblComentario" style="font-size:30px;" runat="server" Text="Comentario"></asp:Label>
            </div>
            <div class="col d-flex justify-content-center align-items-center">
                <asp:TextBox ID="txbComentario" class="w-100" style="min-height:75px; max-height:150px" MaxLength="150" TextMode="MultiLine" Wrap="true" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-2 mt-3 me-2">
            <div class="col-6 d-flex justify-content-center align-items-center">
                <asp:Button ID="btnAceptar" CssClass="btn btn-success" runat="server" OnClick="btnAceptar_Click" Text="Aceptar"/>
            </div>
            <div class="col-6 d-flex justify-content-center align-items-center">
                <asp:Button ID="btnCancelar" CssClass="btn btn-danger" runat="server" OnClick="btnCancelar_Click" Text="Cancelar"/>
            </div>

        </div>
        <div class="row mb-2 mt-3 me-2">
            <div class="col-12 d-flex justify-content-center align-self-end">
                <p style="font-size:20px"><%: DateTime.Now %></p>
            </div>
        </div>
        
    </div>

</asp:Content>
