<%@ Page Title="Panel principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-lg d-flex justify-content-around">
        <div class="contenedor" style="min-width:60%; height:">
            <div class="cuadro_uno">
                <h1>Tickets</h1>
                <asp:GridView ID="GridUser" class="d-sm-grid" OnRowDataBound="GridUser_RowDataBound" runat="server"></asp:GridView>
            </div>
        </div>
        <div class="contenedor d-flex align-items-start flex-column bd-highlight mb-3">    
            <div class="cuadro_uno">
                <h1>Usuarios</h1>

            </div>
        
            <div class="cuadro_uno">
                <h1>Tecnicos</h1>
            </div>

        </div>
    </div>


</asp:Content>
