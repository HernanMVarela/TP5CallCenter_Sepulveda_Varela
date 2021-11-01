<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP5_CallCenter_Sepulveda_Varela.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="display:flex; flex-direction:column; text-align:center">
        <div  style="border:solid 5px blue; border-radius:15px" >
            <h2>Ingrese con su cuenta</h2>
        
            <div style="padding:10px">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario "></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </div>

            <div style="padding:10px">
                <asp:Label ID="lblClave" runat="server" Text="Contraseña "></asp:Label>
                <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
            </div>
            <div style="padding:10px">
                <asp:Button ID="btnIngresar" runat="server"  class="btn btn-default" OnClick="btnIngresar_Click" Text="Ingresar" />
            </div>
            <div style="padding:10px">
                <a href="#">Olvidaste tu contraseña?</a>
            </div>
        </div>
   </div>
</asp:Content>
