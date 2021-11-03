<%@ Page Title="Panel principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contenedor">
        <div class="cuadro_uno">
            <h1>Tickets</h1>
        </div>
        
        <div class="cuadro_uno">
            <h1>Usuarios</h1>
            <asp:GridView ID="GridUser" OnRowDataBound="GridUser_RowDataBound" style="width:100%;" runat="server"></asp:GridView>
           
        </div>
        
        <div class="cuadro_uno">
            <h1>Tecnicos</h1>
        </div>
    </div>

    


</asp:Content>
