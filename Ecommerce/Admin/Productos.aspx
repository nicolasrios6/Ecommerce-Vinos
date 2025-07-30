<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Ecommerce.Admin.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Productos</h2>
    <div class="mb-3">
        <a href="FormularioProducto.aspx" class="btn btn-primary">Agregar Producto</a>
        <a href="Bodegas.aspx" class="btn btn-primary">Gestionar Bodegas</a>
        <a href="Varietales.aspx" class="btn btn-primary">Gestionar Varietales</a>
        <a href="Dashboard.aspx" class="btn btn-secondary">Volver</a>
    </div>
    <asp:GridView ID="gvProductos" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre"/>
            <asp:BoundField HeaderText="Varietal" DataField="Varietal.Nombre"/>
            <asp:BoundField HeaderText="Bodega" DataField="Bodega.Nombre"/>
            <asp:BoundField HeaderText="Precio" DataField="Precio"/>
            <asp:BoundField HeaderText="Stock" DataField="Stock"/>
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo"/>
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Modificar" />
        </Columns>
    </asp:GridView>
</asp:Content>
