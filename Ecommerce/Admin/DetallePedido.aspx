﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="Ecommerce.Admin.DetallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pedido N° <asp:Label ID="lblNumeroPedidoTitulo" runat="server" /></h2>
    <a href="Pedidos.aspx" class="btn btn-secondary mb-3">Volver</a>

    <asp:Panel ID="pnlInfoPedido" CssClass="mb-4 border p-3 rounded bg-light" runat="server">
        <h3>Información del Pedido</h3>
        <p><strong>Número:</strong>
            <asp:Label ID="lblNumeroPedido" runat="server" />
        </p>
        <p><strong>Cliente:</strong>
            <asp:Label ID="lblCliente" runat="server" />
        </p>
        <p><strong>Fecha:</strong>
            <asp:Label ID="lblFecha" runat="server" />
        </p>
        <p><strong>Método de Envío:</strong>
            <asp:Label ID="lblMetodoEnvio" runat="server" />
        </p>
        <p><strong>Dirección de Envío:</strong>
            <asp:Label ID="lblDireccion" runat="server" />
        </p>
        <p><strong>Método de Pago:</strong>
            <asp:Label ID="lblMetodoPago" runat="server" />
        </p>
        <p><strong>Observaciones:</strong>
            <asp:Label ID="lblObservaciones" runat="server" />
        </p>
    </asp:Panel>

    <asp:Panel ID="pnlDetalles" runat="server" CssClass="mb-4 p-3">
        <h4>Productos</h4>
        <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField HeaderText="Producto" DataField="NombreProducto" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnitario" DataFormatString="${0:N0}" HtmlEncode="false" />
                <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" DataFormatString="${0:N0}" HtmlEncode="false" />
            </Columns>
        </asp:GridView>

        <!-- Totales -->
        <div class="mt-3">
            <strong>Subtotal:</strong>
            <asp:Label ID="lblSubtotal" runat="server" />
            <br />
            <strong>Envío:</strong>
            <asp:Label ID="lblEnvio" runat="server" />
            <br />
            <strong>Total:</strong>
            <asp:Label ID="lblTotal" runat="server" />
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlEstado" runat="server" CssClass="border p-3 bg-white rounded">
        <h4>Estado del Pedido</h4>
        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control w-25 mb-3">
            <asp:ListItem Text="Pendiente" Value="Pendiente" />
            <asp:ListItem Text="Procesando" Value="Procesando" />
            <asp:ListItem Text="Enviado" Value="Enviado" />
            <asp:ListItem Text="Entregado" Value="Entregado" />
            <asp:ListItem Text="Cancelado" Value="Cancelado" />
        </asp:DropDownList>

        <asp:Button ID="btnActualizarEstado" runat="server" Text="Actualizar Estado" CssClass="btn btn-primary" OnClick="btnActualizarEstado_Click" />
    </asp:Panel>
</asp:Content>
