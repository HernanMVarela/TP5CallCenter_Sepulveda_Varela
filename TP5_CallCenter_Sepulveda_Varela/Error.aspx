<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid fondo_contenedor">
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <asp:Label ID="lblNuevoTicket" style="font-size:40px;" runat="server" Text="Ha ocurrido un error inesperado"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <asp:TextBox ID="txbError" ReadOnly="true" TextMode="MultiLine" Wrap="true" style="min-width:90%; min-height:400px;" runat="server"></asp:TextBox>
            </div>
        </div>

    </div>

</asp:Content>
