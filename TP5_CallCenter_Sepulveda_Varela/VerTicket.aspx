﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerTicket.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.VerTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid cuadro_uno" style="min-height:500px;">
        <div class="row w-auto ms-2 me-2 mt-2">  
            <div class="col-12 d-flex justify-content-center align-items-center">
                <asp:Label ID="lblTitulo" runat="server" Font-Size="40px" Text="Titulo"></asp:Label>
            </div>
        </div>
        <div class="row w-auto m-2">  
            <div class="col-12 d-flex justify-content-center align-items-center">
                <asp:TextBox ID="txbComentario" ReadOnly="true" TextMode="MultiLine" Wrap="true" Font-Size="24px" style="min-width:90%; min-height:130px;" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row w-auto m-2">
            <div class="col-4 d-flex justify-content-center align-items-center p-3">
                <asp:Label ID="lblEstado" CssClass="btn-info p-2 ps-3 pe-3" Font-Size="24px" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-4 d-flex justify-content-center align-items-center p-3">
                <asp:Label ID="lblCreacion" Font-Size="24px" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-4 d-flex justify-content-center align-items-center p-3">
                <asp:Label ID="lblCierre" Font-Size="24px" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row w-auto m-3 mb-4">
            <div class="col-12 d-flex justify-content-center align-items-center">
                <asp:GridView ID="gvIncidencias" class="table align-middle table-info table-hover" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="PCategoria.Nombre" HeaderText="Categoria" ItemStyle-Font-Size="20px" SortExpression="PCategoria.Nombre"/>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Font-Size="20px" SortExpression="Descripcion"/>
                        <asp:BoundField DataField="PTecnico.NombreCompleto" HeaderText="Tecnico" ItemStyle-Font-Size="20px" SortExpression="PTecnico.NombreCompleto"/>
                        <asp:BoundField DataField="PTecnico.Telefono" HeaderText="Contacto" ItemStyle-Font-Size="20px" SortExpression="PTecnico.Telefono"/>
                        <asp:BoundField DataField="PTecnico.EspecialidadTecnico.Nombre" HeaderText="Especialidad" ItemStyle-Font-Size="20px" SortExpression="PTecnico.EspecialidadTecnico.Nombre"/>
                        <asp:BoundField DataField="Modificacion" HeaderText="Modificacion" DataFormatString="{0:d}" ItemStyle-Font-Size="20px" SortExpression="Modificacion"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row w-auto ms-2 me-2 mt-2">
            <div class="col-4 cuadro_uno btn-outline-dark d-flex flex-column justify-content-center align-items-center p-2">   
                <asp:Label ID="lblResponsable" runat="server" Font-Size="28px" Text="Responsable"></asp:Label>
                <asp:Label ID="lblRNombre" runat="server" Font-Size="26px" Text="Cliente"></asp:Label>
                <asp:Label ID="lblRUser" runat="server" Font-Size="22px" Text="Usuario"></asp:Label>
                <asp:Label ID="lblRID" runat="server" Font-Size="22px" Text="Mail"></asp:Label>
                <asp:Label ID="lblRTipo" runat="server" Font-Size="22px" Text="Nombre"></asp:Label>
                <asp:Label ID="lblRMail" runat="server" Font-Size="22px" Text="CUIT"></asp:Label>
                <asp:Label ID="lblRTelefono" runat="server" Font-Size="22px" Text="TIPO"></asp:Label>
            </div>
            <div class="col-4 cuadro_uno d-flex flex-column justify-content-center align-items-center p-2">
                <asp:DropDownList ID="ddlReasignar" CssClass="btn-info p-2 m-3 w-50" Font-Size="24px"  runat="server"></asp:DropDownList>
                <asp:Button ID="btnReasignar" CssClass="btn-info p-2 m-3 w-75" Font-Bold="true" Font-Size="28px" runat="server" Text="Reasignar" />
            </div>
            <div class="col-4 cuadro_uno btn-outline-dark d-flex flex-column justify-content-center align-items-center p-2">
                <asp:Label ID="lblCliente" runat="server" Font-Size="28px" Text="Cliente"></asp:Label>
                <asp:Label ID="lblCNombre" runat="server" Font-Size="26px" Text="Nombre"></asp:Label>
                <asp:Label ID="lblCUIT" runat="server" Font-Size="22px" Text="CUIT"></asp:Label>
                <asp:Label ID="lblCTipo" runat="server" Font-Size="22px" Text="TIPO"></asp:Label>
                <asp:Label ID="lblCMail" runat="server" Font-Size="22px" Text="Mail"></asp:Label>
                <asp:Label ID="lblCTelefono" runat="server" Font-Size="22px" Text="Telefono"></asp:Label>     
            </div>
        </div>
        <div class="row w-auto m-3">
            <div class="col-12 d-flex justify-content-evenly align-items-center">
                <asp:Button ID="btnAceptar" CssClass="btn btn-success p-2 w-25" runat="server" Text="Guardar cambios y salir" />
                <asp:Button ID="btnCargarIncidencia" CssClass="btn btn-warning p-2 w-25" OnClick="btnCargarIncidencia_Click" runat="server" Text="Nueva Incidencia" />
                <asp:Button ID="btnSalir" CssClass="btn btn-danger p-2 w-25" OnClick="btnSalir_Click" runat="server" Text="Salir sin guardar" />
                </div>
        </div>
    </div>

</asp:Content>
