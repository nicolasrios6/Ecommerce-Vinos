﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="Ecommerce.Admin.FormularioProducto" %>

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
                <label class="form-label" for="txtImagenUrl">Url de Imágen</label>
                <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control"></asp:TextBox>
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
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="ddlBodega">Bodega</label>
                <asp:DropDownList ID="ddlBodega" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="form-group mb-3">
                <%--<label class="form-label" for="chkActivo">Activo</label>--%>
                <asp:CheckBox ID="chkActivo" runat="server" Checked="true" Text="Activo"/>
            </div>
        </div>
    </div>
</asp:Content>
