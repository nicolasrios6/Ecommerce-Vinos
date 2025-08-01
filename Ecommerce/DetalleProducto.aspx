<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Ecommerce.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container mt-4">
        <div class="row">
            <div class="col-md-5">
                <asp:Image ID="imgProducto" runat="server" CssClass="img-fluid rounded shadow-sm"/>
            </div>
            <div class="col-md-7 mt-4">
                <h2><asp:Label ID="lblNombre" runat="server" /></h2>
                <h4 class="text-primary">$<asp:Label ID="lblPrecio" runat="server" /></h4>
                <p class="text-muted"><asp:Label ID="lblDescripcion" runat="server" /></p>

                <asp:Panel ID="pnlVino" runat="server" Visible="false">
                    <p><strong>Bodega:</strong> <asp:Label ID="lblBodega" runat="server" /></p>
                    <p><strong>Varietal:</strong> <asp:Label ID="lblVarietal" runat="server" /></p>
                </asp:Panel>

                <p><strong>Stock disponible:</strong> <asp:Label ID="lblStock" runat="server" /></p>

                <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="btn btn-primary" OnClick="btnAgregarCarrito_Click" Enabled="true" />
            </div>
        </div>
    </main>
</asp:Content>
