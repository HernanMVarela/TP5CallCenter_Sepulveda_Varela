<%@ Page Title="Panel principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid fondo_contenedor overflow-hidden d-flex w-auto ms-3 me-3" style="min-height:500px;">
        <div class="row m-2 w-100">
            <div class="col cuadro_uno mb-2 mt-2 h-auto w-auto">
                <div class="row mb-2 mt-2">
                    <div class="col-12 d-flex justify-content-center align-items-center">
                        <h1>Tickets</h1>
                    </div>
                </div>
                <div class="row mb-2 mt-2">
                    <div class="col-12" style="overflow-y: scroll;height: 400px;">    
                        <asp:GridView ID="gvTickets" class="table align-middle table-info table-striped table-hover" AutoGenerateColumns="false" OnSelectedIndexChanged="gvTickets_SelectedIndexChanged" OnRowDataBound="gvTickets_RowDataBound" runat="server">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                <asp:BoundField DataField="Titulo" HeaderText="Asunto" SortExpression="Titulo" />
                                <asp:BoundField DataField="PCliente.RazonSocial" HeaderText="Cliente" SortExpression="PCliente.RazonSocial" />
                                <asp:BoundField DataField="PCliente.Cuit" HeaderText="CUIT" SortExpression="PCliente.Cuit" />
                                <asp:BoundField DataField="PEstado.Nombre" HeaderText="Estado" SortExpression="PEstado.Nombre" />
                                <asp:BoundField DataField="Fecha_Creacion" HeaderText="Creacion" DataFormatString="{0:d}" SortExpression="Fecha_Creacion" />
                                <asp:BoundField DataField="Fecha_Cierre" HeaderText="Cierre" DataFormatString="{0:d}" SortExpression="Fecha_Cierre" />
                                <asp:ButtonField Text="Ver ticket" CommandName="Select" ItemStyle-Width="150" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row mb-3 mt-3 p-2">
                    <div class="col-4 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnNuevoTicket" class="btn btn-info w-75 fs-4 p-2" OnClick="btnNuevoTicket_Click" runat="server" Text="Nuevo Ticket"/>
                    </div>
                    <div class="col d-flex justify-content-center align-items-center">
                    </div>
                    <div class="col-4 d-flex justify-content-center align-items-center">
                    </div>
                </div>
            </div>
            <div class="col-3 mb-2 mt-2">    
                <div class="row h-auto cuadro_uno">
                    <div class="col d-flex justify-content-center align-items-center flex-column">
                        <asp:Label ID="lblTUsuario" CssClass="fs-2 fw-bold m-2" runat="server" Text="Usuario"></asp:Label>
                        <asp:Label ID="lblNombre" CssClass="fs-4 m-1" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblUsuario" CssClass="fs-5 m-1" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblTelefono" CssClass="fs-5 m-1" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblEmail" CssClass="fs-5 m-1" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row h-auto cuadro_uno">
                    <div class="col p-2 d-flex justify-content-center align-items-center flex-column">
                         <asp:Label ID="lblEstadisticas" CssClass="fs-2 fw-bold m-2" runat="server" Text="Estadísticas"></asp:Label>
                         <asp:Label ID="lblTotales" CssClass="fs-5" runat="server" Text="Tickets Totales"></asp:Label>
                         <asp:Label ID="lblAbiertos" CssClass="fs-5" runat="server" Text="Abiertos: "></asp:Label>
                         <asp:Label ID="lblCerrados" CssClass="fs-5" runat="server" Text="Cerrados: "></asp:Label>
                    </div>
                </div>
                <div class="row h-auto m-2">
                    <div class="col-12 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnPanelAdmin" CssClass="btn btn-warning fs-3 p-2" OnClick="btnPanelAdmin_Click" runat="server" Text="Panel de administración" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
