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
                    <img class="card-img-top" src="https://www.pinclipart.com/picdir/big/545-5453529_printer-technician-logo-clipart.png" alt="Card image cap">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">Tecnicos</h5>
                        <p class="card-text">Control de Técnicos</p>
                        <asp:Button ID="btnAgregarTecnico" CssClass="btn btn-info m-2 mb-3" OnClick="btnAgregarTecnico_Click" runat="server" Text="Agregar"/>
                        <asp:DropDownList ID="ddlTecnico" CssClass="m-2 pb-2 pt-2" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnModificarTecnico" CssClass="btn btn-info m-2" runat="server" Text="Modificar"/>
                        <div class="col-12 m-2 d-flex justify-content-evenly">
                        <asp:CheckBox ID="chbBajaTecnico" runat="server" />
                        <asp:Button ID="btnBajaTecnico" CssClass="btn btn-outline-danger text-black fw-bold m-2 w-75" runat="server" Text="Eliminar"/>
                        </div>
                    </div>
                 </div>
             </div>
             <div class="col-3 m-2">
                 <div class="card" style="width: 22rem;">
                    <img class="card-img-top" src="https://image.pngaaa.com/93/4052093-middle.png" alt="Card image cap">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">Usuarios</h5>
                        <p class="card-text">Control de Usuarios</p>
                        <asp:Button ID="btnAgregarUsuario" CssClass="btn btn-info m-2 mb-3" OnClick="btnAgregarUsuario_Click" runat="server" Text="Agregar"/>
                        <asp:DropDownList ID="ddlUsuario" CssClass="m-2 pb-2 pt-2" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnModificarUsuario" CssClass="btn btn-info m-2" runat="server" Text="Modificar"/>
                        <div class="col-12 m-2 d-flex justify-content-evenly">
                        <asp:CheckBox ID="chbBajaUsuario" runat="server" />
                        <asp:Button ID="btnBajaUsuario" CssClass="btn btn-outline-danger text-black fw-bold m-2 w-75" runat="server" Text="Eliminar"/>
                        </div>
                    </div>
                 </div>
             </div>
             <div class="col-3 m-2">
                 <div class="card" style="width: 22rem;">
                    <img class="card-img-top" src="https://e7.pngegg.com/pngimages/561/480/png-clipart-customer-relationship-management-customer-service-people-icons-company-text.png" alt="Card image cap">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">Clientes</h5>
                        <p class="card-text">Control de Clientes</p>
                        <asp:Button ID="btnAgregarCliente" CssClass="btn btn-info m-2 mb-3" OnClick="btnAgregarCliente_Click" runat="server" Text="Agregar"/>
                        <asp:DropDownList ID="ddlCliente" CssClass="m-2 pb-2 pt-2" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnModificarCliente" CssClass="btn btn-info m-2" runat="server" Text="Modificar"/>
                        <div class="col-12 m-2 d-flex justify-content-evenly">
                        <asp:CheckBox ID="chbBajaCliente" runat="server" />
                        <asp:Button ID="btnBajaCliente" CssClass="btn btn-outline-danger text-black fw-bold m-2 w-75" runat="server" Text="Eliminar"/>
                        </div>
                    </div>
                 </div>
             </div>

         </div>


     </div>
</asp:Content>
