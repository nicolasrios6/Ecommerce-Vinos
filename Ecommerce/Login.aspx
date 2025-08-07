﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecommerce.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
    <div class="col-6">

        <h2>Iniciar Sesión</h2>

        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtContrasenia" class="form-label">Contraseña</label>
            <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <div class="mb-3">
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnLogin_Click"/>
        </div>
        <div class="d-flex flex-column">
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            <a href="Registro.aspx">¿No tenes cuenta? Registrate!</a>
        </div>
    </div>
</div>
</asp:Content>
