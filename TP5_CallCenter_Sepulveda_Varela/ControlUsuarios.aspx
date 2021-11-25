<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlUsuarios.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.ControlUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class ="container-fluid cuadro_uno">     
        <div class="row col-12 p-3 ">   
            <div class="col-12 d-flex justify-content-evenly align-items-center">   
                <asp:Label ID="lblTitulo" CssClass="fs-2 fw-bold" runat="server" Text="Panel de Control de Usuarios"></asp:Label>
            </div>
            
        </div>
        <div class="row m-2 p-2 ">
            <div class="col-2 d-flex justify-content-end align-items-center">   
                <asp:Label ID="lblNombre" CssClass="fs-4 fw-bold" runat="server" Text="Nombre "></asp:Label>

            </div>
            <div class="col-4 d-flex justify-content-start align-items-center">   
                <asp:TextBox ID="txbNombre" Width="280px" runat="server"></asp:TextBox>

            </div>
            <div class="col-2 d-flex justify-content-end align-items-center">   
                <asp:Label ID="lblApellido" CssClass="fs-4 fw-bold" runat="server" Text="Apellido "></asp:Label>

            </div>
            <div class="col-4 d-flex justify-content-start align-items-center">   
                <asp:TextBox ID="txbApellido" Width="280px" runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="row m-2 p-2">
            <div class="col-2 d-flex justify-content-end align-items-center">  
                <asp:Label ID="lblEmail" CssClass="fs-4 fw-bold" runat="server" Text="Email "></asp:Label>  

            </div>
             <div class="col-4 d-flex justify-content-start align-items-center">  
                 <asp:TextBox ID="txbEmail" Width="280px" runat="server"></asp:TextBox> 

            </div>
             <div class="col-2 d-flex justify-content-end align-items-center">  
                 <asp:Label ID="lblTelefono" CssClass="fs-4 fw-bold" runat="server" Text="Teléfono "></asp:Label> 

            </div>
             <div class="col-4 d-flex justify-content-start align-items-center">  
                 <asp:TextBox ID="txbTelefono" Width="280px" runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="row m-2 p-2">
            <div class="col-2 d-flex justify-content-end align-items-center">  
                <asp:Label ID="lblUsername" CssClass="fs-4 fw-bold" runat="server" Text="Usuario "></asp:Label>

            </div>
             <div class="col-4 d-flex justify-content-start align-items-center">  
                 <asp:TextBox ID="txbUsername" Width="280px" runat="server"></asp:TextBox>

            </div>
             <div class="col-2 d-flex flex-column justify-content-center align-items-end">  
                 <asp:Label ID="lblPass" CssClass="fs-4 fw-bold" runat="server" Text="Contraseña "></asp:Label>
                 <asp:Label ID="lblPass2" CssClass="fs-4 fw-bold" runat="server" Text="Validar"></asp:Label>
            </div>
             <div class="col-4 d-flex flex-column justify-content-center align-items-start">  
                 <asp:TextBox ID="txbPass" CssClass="mb-2" Width="280px" TextMode="Password" runat="server"></asp:TextBox>
                 <asp:TextBox ID="txbPass2" CssClass="mt-2" Width="280px" TextMode="Password" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row m-2 p-2">
            <div class="col-2 d-flex justify-content-end align-items-center">  
                <asp:Label ID="lblTipo" CssClass="fs-4 fw-bold" runat="server" Text="Tipo"></asp:Label>

            </div>
             <div class="col-4 d-flex justify-content-start align-items-center">  
                 <asp:DropDownList ID="ddlTipo" Width="280px"  runat="server"></asp:DropDownList>

            </div>
             <div class="col-2 d-flex justify-content-end align-items-center">  
            
            </div>
             <div class="col-4 d-flex justify-content-start align-items-center">  
            
            </div>
        </div>
        <div class="row m-2 p-2">
            <div class="col-6 d-flex justify-content-evenly align-items-center">  
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" />   

            </div>
             <div class="col-6 d-flex justify-content-evenly align-items-center">  
                 <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />

            </div>
        </div>
     </div>

</asp:Content>
