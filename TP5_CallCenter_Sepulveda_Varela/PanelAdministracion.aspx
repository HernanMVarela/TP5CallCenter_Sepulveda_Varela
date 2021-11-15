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
                 <div class="card" style="width: 18rem;">
                    <img class="card-img-top" src="https://www.pinclipart.com/picdir/big/545-5453529_printer-technician-logo-clipart.png" alt="Card image cap">
                    <div class="card-body">
                    <h5 class="card-title">Tecnicos</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <asp:Button ID="btnAgregarTecnico" CssClass="btn btn-info" runat="server" Text="Agregar"/>
                    </div>
                 </div>
             </div>
             <div class="col-3 m-2">
                 <div class="card" style="width: 18rem;">
                    <img class="card-img-top" src="https://image.pngaaa.com/93/4052093-middle.png" alt="Card image cap">
                    <div class="card-body">
                    <h5 class="card-title">Usuarios</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <asp:Button ID="btnAgregarUsuario" CssClass="btn btn-info" runat="server" Text="Agregar"/>
                    </div>
                 </div>
             </div>
             <div class="col-3 m-2">
                 <div class="card" style="width: 18rem;">
                    <img class="card-img-top" src="https://e7.pngegg.com/pngimages/561/480/png-clipart-customer-relationship-management-customer-service-people-icons-company-text.png" alt="Card image cap">
                    <div class="card-body">
                    <h5 class="card-title">Clientes</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <asp:Button ID="btnAgregarCliente" CssClass="btn btn-info" runat="server" Text="Agregar"/>
                    </div>
                 </div>
             </div>

         </div>


     </div>
</asp:Content>
