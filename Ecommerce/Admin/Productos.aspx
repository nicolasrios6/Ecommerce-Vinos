<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Ecommerce.Admin.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Productos</h2>
    <a href="FormularioProducto.aspx" class="btn btn-primary">Agregar Producto</a>
    <asp:GridView ID="gvProductos" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre"/>
            <asp:BoundField HeaderText="Varietal" DataField="Varietal.Nombre"/>
            <asp:BoundField HeaderText="Bodega" DataField="Bodega.Nombre"/>
            <asp:BoundField HeaderText="Precio" DataField="Precio"/>
            <asp:BoundField HeaderText="Stock" DataField="Stock"/>
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo"/>
        </Columns>
    </asp:GridView>
</asp:Content>
