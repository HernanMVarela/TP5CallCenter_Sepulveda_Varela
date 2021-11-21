<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid m-2 cuadro_uno">
        <div class="row p-2">
            <div class="col-12 p-2 d-flex justify-content-center">
                <h2>Ingrese con su cuenta</h2>
            </div>
        </div>
        <div class="row p-2">
            <div class="col-6 p-2 d-flex justify-content-start align-items-center flex-column">
                <h1 class="fw-bold">Compumundo hiper mega red</h1>
                <h2>Service Desk</h2>
            </div>
            <div class="col-6 p-2 d-flex justify-content-center align-items-center flex-column">
                <asp:TextBox ID="txbUsuario" runat="server" CssClass="m-2 p-2 w-50" Text="Usuario"></asp:TextBox>
                <asp:TextBox ID="txbPass" runat="server" CssClass="m-2 p-2 w-50" Text="Contraseña" TextMode="Password" ></asp:TextBox>
                <asp:Button ID="btnIngresar" CssClass="btn btn-primary m-2 p-2 w-25" runat="server" OnClick="btnIngresar_Click1" Text="Ingresar" />
            </div>
        </div>
   </div>
</asp:Content>
