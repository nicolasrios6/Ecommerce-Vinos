<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Varietales.aspx.cs" Inherits="Ecommerce.Admin.Varietales1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Varietales</h2>
    <a href="FormularioVarietal.aspx" class="btn btn-primary mb-3">Agregar Varietal</a>
    <a href="Productos.aspx" class="btn btn-secondary mb-3">Volver</a>

    <asp:GridView ID="gvVarietales" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table" OnSelectedIndexChanged="gvVarietales_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Modificar" />
        </Columns>
    </asp:GridView>
</asp:Content>
