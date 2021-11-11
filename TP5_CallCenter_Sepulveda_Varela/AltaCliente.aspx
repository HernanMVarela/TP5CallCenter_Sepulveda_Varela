<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.AltaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class=" container-fluid cuadro_uno h-100">
        <div class="row mb-4">
            <div class="col-12 d-flex justify-content-evenly align-items-center">
                <asp:Label ID="lblCliente" runat="server" Font-Size="48px" Text="Nuevo cliente"></asp:Label>
            </div>
        </div>
        <div class="row mb-3 mt-3">
            <div class="col-3 d-flex justify-content-end">
                <h3>Razon Social: </h3>
            </div>
            <div class="col-3 d-flex justify-content-start">
                <asp:TextBox ID="txbRazonsocial" Width="250px" runat="server"></asp:TextBox>
            </div>
            <div class="col-2 d-flex justify-content-end">
                <h3>CUIT/CUIL: </h3>
            </div>
            <div class="col d-flex justify-content-start">
                <asp:TextBox ID="txbCuit" Width="250px" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3 mt-3">
            <div class="col-3 d-flex justify-content-end">
                <h3>Correo electrónico: </h3>
            </div>
            <div class="col d-flex justify-content-start">
                <asp:TextBox ID="txbEmail" Width="350px" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3 mt-3">
            <div class="col-3 d-flex justify-content-end">
                <h3>Teléfono: </h3>
            </div>
            <div class="col d-flex justify-content-start">
                <asp:TextBox ID="txbTelefono" Width="350px" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3 mt-3">
            <div class="col-3 d-flex justify-content-end">
                <h3>Tipo de cliente: </h3>
            </div>
            <div class="col d-flex justify-content-start">
                <asp:DropDownList class="btn btn-secondary" ID="ddlTipoCliente" Width="250px" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row mb-3 mt-3">
            <div class="col-6 d-flex justify-content-center">
                <asp:Button ID="btnAceptar" CssClass="btn btn-success" runat="server" Text="Aceptar" />
            </div>
            <div class="col-6 d-flex justify-content-center">
                <asp:Button ID="btnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
            </div>
        </div>
    </div>


</asp:Content>
