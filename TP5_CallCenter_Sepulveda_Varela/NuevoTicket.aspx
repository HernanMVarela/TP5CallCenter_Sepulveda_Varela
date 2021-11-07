<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoTicket.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.NuevoTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid cuadro_uno">
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
        <asp:TextBox ID="txbDescripcion" Height="300px" TextMode="MultiLine" Wrap="true" runat="server"></asp:TextBox>


    </div>

</asp:Content>
