<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="Ecommerce.Admin.FormularioProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Formulario Producto</h2>

    <div class="row">
        <div class="col-6">
            <div class="form-group mb-3">
                <label class="form-label" for="txtNombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtDescripcion">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtNombre">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtStock">Stock</label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="ddlCategoria">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="ddlVarietal">Varietal</label>
                <asp:DropDownList ID="ddlVarietal" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:LinkButton ID="btnNuevoVarietal" runat="server" CssClass="btn btn-link p-0" OnClick="btnNuevoVarietal_Click">Agregar nuevo Varietal</asp:LinkButton>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="ddlBodega">Bodega</label>
                <asp:DropDownList ID="ddlBodega" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:LinkButton ID="btnNuevaBodega" runat="server" CssClass="btn btn-link p-0" OnClick="btnNuevaBodega_Click">Agregar nueva Bodega</asp:LinkButton>
            </div>
            <div class="form-group mb-3">
                <asp:CheckBox ID="chkActivo" runat="server" Checked="true" Text="Activo"/>
            </div>

            <asp:Label ID="lblError" runat="server" CssClass="text-danger" EnableViewState="false" />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
            <a href="Productos.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-group mb-3">
                        <label class="form-label" for="txtImagenUrl">Url de Imágen</label>
                        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Image ID="imgProducto" runat="server" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
