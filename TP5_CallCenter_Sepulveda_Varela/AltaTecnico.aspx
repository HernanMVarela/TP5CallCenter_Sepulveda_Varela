<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaTecnico.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.NuevoTecnico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid cuadro_uno h-auto">
        <div class="row mb-4">
            <div class="col-12 d-flex justify-content-evenly align-items-center">
                <asp:Label ID="lblTitutlo" runat="server" Font-Size="48px" Text="Nuevo técnico"></asp:Label> 
            </div>
        </div>
        <div class="row mb-3 mt-3">
            <div class="col-3 d-flex justify-content-end">
                <h3>Nombre: </h3>
            </div>
            <div class="col-3 d-flex justify-content-start">
                <asp:TextBox ID="txbNombre" Width="250px" runat="server"></asp:TextBox>
            </div>
            <div class="col-2 d-flex justify-content-end">
                <h3>Apellido: </h3>
            </div>
            <div class="col d-flex justify-content-start">
                <asp:TextBox ID="txbApellido" Width="250px" runat="server"></asp:TextBox>
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
                <h3>Especialidad: </h3>
            </div>
            <div class="col d-flex justify-content-start">
                <asp:DropDownList class="btn btn-secondary" ID="ddlEspecialidad" Width="250px" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row mb-3 mt-3">
            <div class="col-6 d-flex justify-content-center">
                <asp:Button ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" UseSubmitBehavior="false"/>
            </div>
            <div class="col-6 d-flex justify-content-center">
                <asp:Button ID="btnCancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" UseSubmitBehavior="false" />
            </div>
        </div>
    </div>

</asp:Content>
