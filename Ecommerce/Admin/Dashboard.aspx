﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Ecommerce.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Panel de Administración</h2>

    <ul>
        <li><a href="Productos.aspx">Gestionar Productos</a></li>
        <li><a href="Categorias.aspx">Gestionar Categorías</a></li>
        <li><a href="Pedidos.aspx">Gestionar Pedidos</a></li>
        <li><a href="Usuarios.aspx">Gestionar Usuarios</a></li>
    </ul>
</asp:Content>
