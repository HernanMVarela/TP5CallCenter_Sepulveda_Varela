<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlUsuarios.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.ControlUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class ="container-fluid cuadro_uno">     
        <div class="row m-2 p-2">
            <div class="col-2 d-flex justify-content-evenly align-items-center">   
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>

            </div>
            <div class="col-4 d-flex justify-content-evenly align-items-center">   
                <asp:TextBox ID="txbNombre" runat="server"></asp:TextBox>

            </div>
            <div class="col-2 d-flex justify-content-evenly align-items-center">   
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>

            </div>
            <div class="col-4 d-flex justify-content-evenly align-items-center">   
                <asp:TextBox ID="txbApellido" runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="row m-2 p-2">
            <div class="col-2 d-flex justify-content-evenly align-items-center">  
                <asp:Label ID="lblEmail" runat="server" Text="email"></asp:Label>  

            </div>
             <div class="col-4 d-flex justify-content-evenly align-items-center">  
                 <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox> 

            </div>
             <div class="col-2 d-flex justify-content-evenly align-items-center">  
                 <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label> 

            </div>
             <div class="col-4 d-flex justify-content-evenly align-items-center">  
                 <asp:TextBox ID="txbTelefono" runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="row m-2 p-2">
            <div class="col-2 d-flex justify-content-evenly align-items-center">  
                <asp:Label ID="lblUsername" runat="server" Text="Nombre de Usuario"></asp:Label>

            </div>
             <div class="col-4 d-flex justify-content-evenly align-items-center">  
                 <asp:TextBox ID="txbUsername" runat="server"></asp:TextBox>

            </div>
             <div class="col-2 d-flex justify-content-evenly align-items-center">  
                 <asp:Label ID="lblPass" runat="server" Text="Contraseña"></asp:Label>

            </div>
             <div class="col-4 d-flex justify-content-evenly align-items-center">  
                 <asp:TextBox ID="txbPass" runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="row m-2 p-2">
            <div class="col-2 d-flex justify-content-evenly align-items-center">  
                

            </div>
             <div class="col-4 d-flex justify-content-evenly align-items-center">  
                

            </div>
             <div class="col-2 d-flex justify-content-evenly align-items-center">  
                

            </div>
             <div class="col-4 d-flex justify-content-evenly align-items-center">  
                

            </div>
        </div>
    </div>

</asp:Content>
