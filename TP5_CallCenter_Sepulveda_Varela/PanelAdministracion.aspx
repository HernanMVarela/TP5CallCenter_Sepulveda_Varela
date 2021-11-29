<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdministracion.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.PanelAdministracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <div class="container-fluid cuadro_uno h-auto">
         <div class="row m-2">
             <div class="col-12 m-2 d-flex justify-content-evenly">
                 <asp:Label Text="Panel de administrador" Font-Size="40px" runat="server" />
             </div>
         </div>
         <div class="row m-2 d-flex justify-content-evenly">
             <div class="col-3 m-2">
                 <div class="card" style="width: 22rem;">
                    <img class="card-img-top" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqUZ-Jx_ikjA2_woc7TlHlZ67-MT30uHQEXHidXzv2n2fcWJDQZTe7i5obXt7fUmuFdSs&usqp=CAU" alt="Card image cap">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">Tecnicos</h5>
                        <p class="card-text">Control de Técnicos</p>
                        <asp:Button ID="btnAgregarTecnico" CssClass="btn btn-info m-2 mb-3" OnClick="btnAgregarTecnico_Click" runat="server" Text="Agregar"/>
                        <asp:DropDownList ID="ddlTecnico" CssClass="m-2 pb-2 pt-2" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnModificarTecnico" CssClass="btn btn-info m-2" OnClick="btnModificarTecnico_Click" runat="server" Text="Modificar"/>
                        <div class="col-12 m-2 d-flex justify-content-evenly">
                        <asp:CheckBox ID="chbBajaTecnico" runat="server" />
                        <asp:Button ID="btnBajaTecnico" CssClass="btn btn-outline-danger text-black fw-bold m-2 w-75" runat="server" Text="Eliminar"/>
                        </div>
                        <asp:Label ID="lblConfTecnico" runat="server" Text="Tilde para confirmar eliminación"></asp:Label>
                    </div>
                 </div>
             </div>
             <div class="col-3 m-2">
                 <div class="card" style="width: 22rem;">
                    <img class="card-img-top" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSPtjfIUP2hGthek-WhMKIEbslwmiHIfWHkFcMdfKlEoIarAf_ZNdWHCO-nggfTU6WcyE&usqp=CAU" alt="Card image cap">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">Usuarios</h5>
                        <p class="card-text">Control de Usuarios</p>
                        <asp:Button ID="btnAgregarUsuario" CssClass="btn btn-info m-2 mb-3" OnClick="btnAgregarUsuario_Click" runat="server" Text="Agregar"/>
                        <asp:DropDownList ID="ddlUsuario" CssClass="m-2 pb-2 pt-2" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnModificarUsuario" CssClass="btn btn-info m-2" OnClick="btnModificarUsuario_Click" runat="server" Text="Modificar"/>
                        <div class="col-12 m-2 d-flex justify-content-evenly">
                        <asp:CheckBox ID="chbBajaUsuario" OnCheckedChanged="chbBajaUsuario_CheckedChanged" AutoPostBack="true" runat="server" />
                        <asp:Button ID="btnBajaUsuario" CssClass="btn btn-outline-danger text-black fw-bold m-2 w-75" runat="server" Text="Eliminar"/>  
                        </div>
                        <asp:Label ID="lblConfUsuario" runat="server" Text="Tilde para confirmar eliminación"></asp:Label>
                    </div>
                 </div>
             </div>
             <div class="col-3 m-2">
                 <div class="card" style="width: 22rem;">
                    <img class="card-img-top" src="https://cdn1.iconfinder.com/data/icons/shopping-e-commerce-colored-outline-version/33/maintenance_support-512.png" alt="Card image cap">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">Clientes</h5>
                        <p class="card-text">Control de Clientes</p>
                        <asp:Button ID="btnAgregarCliente" CssClass="btn btn-info m-2 mb-3" OnClick="btnAgregarCliente_Click" runat="server" Text="Agregar"/>
                        <asp:DropDownList ID="ddlCliente" CssClass="m-2 pb-2 pt-2" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnModificarCliente" CssClass="btn btn-info m-2" OnClick="btnModificarCliente_Click" runat="server" Text="Modificar"/>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>    
                        <div class="col-12 m-2 d-flex justify-content-evenly">
                            <asp:CheckBox ID="chbBajaCliente" AutoPostBack="true" OnCheckedChanged="chbBajaCliente_CheckedChanged" runat="server" />
                            <asp:Button ID="btnBajaCliente" CssClass="btn btn-outline-danger text-black fw-bold m-2 w-75" OnClick="btnBajaCliente_Click" runat="server" Text="Eliminar"/>
                        </div>
                        </ContentTemplate>  
                        </asp:UpdatePanel>
                        <asp:Label ID="lblConfCliente" runat="server" Text="Tilde para confirmar eliminación"></asp:Label>
                    </div>
                 </div>
             </div>
         </div>
     </div>
</asp:Content>
