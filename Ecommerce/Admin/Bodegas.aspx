<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bodegas.aspx.cs" Inherits="Ecommerce.Admin.Bodegas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Bodegas</h2>
    <a href="FormularioBodega.aspx" class="btn btn-primary mb-3">Agregar Bodega</a>
    <a href="Productos.aspx" class="btn btn-secondary mb-3">Volver</a>

    <asp:GridView ID="gvBodegas" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table" OnSelectedIndexChanged="gvBodegas_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Modificar"/>
        </Columns>
    </asp:GridView>
</asp:Content>
