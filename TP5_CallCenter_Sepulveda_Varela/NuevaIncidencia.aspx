<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaIncidencia.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.NuevaIncidencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid cuadro_uno">
        <div class="row w-auto m-2">  
            <div class="col-12 d-flex justify-content-center align-items-center p-3">
                <asp:Label ID="lblIncidencia" CssClass="fw-bold fs-1" runat="server" Text="Nueva incidencia"></asp:Label>
            </div>
        </div>
        <div class="row w-auto m-2">
            <div class="col-3 d-flex justify-content-center align-items-center d-flex flex-column">
                <asp:Label ID="lblTecnico" CssClass="fw-bold fs-3 mb-3" runat="server" Text="Tecnico"></asp:Label>
                <asp:DropDownList ID="ddlTecnico" CssClass="w-75 p-2 fs-3" runat="server"></asp:DropDownList>
            </div>
            <div class="col-3 d-flex justify-content-center align-items-center d-flex flex-column">
                <asp:Label ID="lblCategoria" CssClass="fw-bold fs-3 mb-3" runat="server" Text="Categoria"></asp:Label>
                <asp:DropDownList ID="ddlCategoria" CssClass="w-75 p-2 fs-3" runat="server"></asp:DropDownList>
            </div>
            <div class="col-6 d-flex justify-content-center align-items-center d-flex flex-column">
                <asp:Label ID="lblDescripcion" CssClass="fw-bold fs-3 mb-3" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="txbComentario" CssClass="bg-light text-dark" TextMode="MultiLine" Wrap="true" Font-Size="24px" style="min-width:90%; min-height:130px;" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row w-auto p-4">

        </div>
        <div class="row w-auto m-2">
            <div class="col-5 d-flex justify-content-center align-items-center d-flex flex-column">
                <asp:Button ID="btnAceptar" CssClass="btn btn-success p-2 w-25 fs-3" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
            </div>
            <div class="col-2 d-flex justify-content-center align-items-center d-flex flex-column">
                
            </div>
            <div class="col-5 d-flex justify-content-center align-items-center d-flex flex-column">
                <asp:Button ID="btnCancelar" CssClass="btn btn-danger p-2 w-25 fs-3" OnClick="btnCancelar_Click" runat="server" Text="Descartar" />
            </div>
        </div>
        <div class="row w-auto p-3">

        </div>
    </div>
</asp:Content>
