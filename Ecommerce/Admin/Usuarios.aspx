<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Ecommerce.Admin.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Usuarios</h2>
    <div class="mb-3">
        <a href="#" class="btn btn-primary">Agregar Usuario</a>
        <a href="Dashboard.aspx" class="btn btn-secondary">Volver</a>
    </div>

    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table" OnRowCommand="gvUsuarios_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:LinkButton ID="btnToggleActivo" runat="server" CommandName="ToggleActivo"
                        OnClientClick="return confirm('¿Estás seguro de cambiar el estado del usuario?');"
                        CommandArgument='<%#Eval("Id") %>' Text='<%#(bool)Eval("Activo") ? "Inactivar" : "Activar" %>'  
                        CssClass="btn btn-sm btn-warning"
                    >
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
