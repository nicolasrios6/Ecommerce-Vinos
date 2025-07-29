<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="Ecommerce.Admin.FormularioCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Formulario Categoría</h2>

    <div class="row">
        <div class="col-6">
            <div class="form-group mb-3">
                <label class="form-label" for="txtNombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger" EnableViewState="false" />
                <asp:RequiredFieldValidator
                    ID="rfvNombre"
                    runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="El Nombre es obligatorio."
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
            <div class="form-group mb-3">
                <%--<label class="form-label" for="chkActivo">Activo</label>--%>
                <asp:CheckBox ID="chkActivo" runat="server" Checked="true" Text="Activo" />
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>
