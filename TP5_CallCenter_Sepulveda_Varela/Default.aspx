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
                    <div class="col-12">   
                        <asp:GridView ID="gvTickets" class="table align-middle table-info table-hover" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                <asp:BoundField DataField="Titulo" HeaderText="Asunto" SortExpression="Titulo" />
                                <asp:BoundField DataField="PCliente.RazonSocial" HeaderText="Cliente" SortExpression="PCliente.RazonSocial" />
                                <asp:BoundField DataField="PIncidencia[0].PTecnico.NombreCompleto" HeaderText="Tecnico" SortExpression="PIncidencia[0].PTecnico.NombreCompleto" />
                                <asp:BoundField DataField="PCliente.Cuit" HeaderText="CUIT" SortExpression="PCliente.Cuit" />
                                <asp:BoundField DataField="PIncidencia[0].Categoria" HeaderText="Categoria" SortExpression="PIncidencia[0].Categoria" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                <asp:BoundField DataField="Fecha_Creacion" HeaderText="Creacion" DataFormatString="{0:d}" SortExpression="Fecha_Creacion" />
                                <asp:BoundField DataField="Fecha_Cierre" HeaderText="Cierre" DataFormatString="{0:d}" SortExpression="Fecha_Cierre" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row mb-2 mt-2">
                    <div class="col-2 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnNuevoTicket" class="btn btn-info" OnClick="btnNuevoTicket_Click" runat="server" Text="Nuevo Ticket"/>
                    </div>
                    <div class="col-2 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnAsignar" class="btn btn-info" runat="server" Text="Asignar"/>
                    </div>
                    <div class="col-2 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnModificar" class="btn btn-info" runat="server" Text="Modificar"/>
                    </div>
                    <div class="col-2 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnVerTicket" CssClass="btn btn-info" runat="server" OnClick="btnVerTicket_Click" Text="Ver ticket"/>
                    </div>
                    <div class="col-1 d-flex justify-content-center align-items-center">

                    </div>
                    <div class="col-3 d-flex justify-content-center align-items-center">
                        <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" />
                    </div>
                </div>
                
            </div>
            <div class="col-3 mb-2 mt-2">    
                <div class="row h-auto cuadro_uno">
                    <div class="col">
                        <div class="row mb-2 mt-2">
                            <div class="col d-flex justify-content-center align-items-center">
                                <h1>Usuario</h1>
                            </div>                            
                        </div>
                        <div class="row mb-2 mt-2">
                            <div class="col d-flex justify-content-center align-items-center">
                                <asp:Label ID="lblNombre" runat="server" style="font-size:25px;" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row mb-2 mt-2">
                            <div class="col d-flex justify-content-center align-items-center">
                                <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row mb-2 mt-2">
                            <div class="col d-flex justify-content-center align-items-center">
                                <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row m-2">
                            <div class="col d-flex justify-content-center align-items-center">
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
        
                <div class="row h-auto cuadro_uno">
                    <div class="col">
                        <div class="row m-1">
                            <h1>Técnico</h1>
                        </div>
                        <div class="row m-1">
                            <asp:Label ID="lblNombreTec" runat="server" Text="Nombre Completo"></asp:Label>
                        </div>
                        <div class="row m-1">
                            <asp:Label ID="lblEspecialidadTec" runat="server" Text="Especialidad"></asp:Label>
                        </div>
                        <div class="row m-1">
                            <asp:Label ID="lblTelefonoTec" runat="server" Text="Telefono"></asp:Label>
                        </div>
                        <div class="row m-1">
                            <asp:Label ID="lblEmailTec" runat="server" Text="Direccion de correo"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row h-auto cuadro_uno">
                    <div class="col">
                        <div class="row mb-2 mt-2">
                            <div class="col d-flex justify-content-center align-items-center">
                                <asp:Button ID="btnPanelAdmin" CssClass="btn btn-warning" style="height:70px; width:stretch;" OnClick="btnPanelAdmin_Click" runat="server" Text="Panel de administración" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
