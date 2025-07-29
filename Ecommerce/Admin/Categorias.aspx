<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Ecommerce.Admin.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Categorías</h2>
    <a href="FormularioCategoria.aspx" class="btn btn-primary mb-3">Agregar Categoría</a>
    <a href="Dashboard.aspx" class="btn btn-secondary mb-3">Volver</a>

    <asp:GridView ID="gvCategorias" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="gvCategorias_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo"/>
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Modificar"/>
        </Columns>
    </asp:GridView>
</asp:Content>
