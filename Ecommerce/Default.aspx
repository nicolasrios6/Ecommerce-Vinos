<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container">
        <h2>Catalogo de productos</h2>
        <div class="row">
            <%-- Sidebar de filtros --%>
            <div class="col-3">
                <h5>Filtrar por Categoría</h5>
                <asp:RadioButtonList ID="rblCategorias" runat="server"
                    AutoPostBack="true" OnSelectedIndexChanged="rblCategorias_SelectedIndexChanged"
                    CssClass="list-group">
                </asp:RadioButtonList>
            </div>

            <%-- Seccion de productos --%>
            <div class="col-9">
                <div class="row">
                    <asp:Repeater ID="repCatalogo" runat="server" OnItemCommand="repCatalogo_ItemCommand">
                        <ItemTemplate>
                            <div class="col-4 mb-4 d-flex justify-content-center">
                                <div class="card d-flex flex-column align-items-center text-center p-2" style="width: 300px; height: 100%;">
                                    <img class="card-img-top" style="width: 200px" src='<%# Eval("ImagenUrl") %>' alt="Imagen del producto" />

                                    <!-- Contenido principal -->
                                    <div class="card-body d-flex flex-column justify-content-between flex-grow-1 w-100">
                                        <div>
                                            <h5 class="card-title"><%# Eval("Nombre") %></h5>

                                            <asp:Panel ID="Panel1" runat="server" Visible='<%# Eval("Categoria.Nombre").ToString() == "Vinos" %>'>
                                                <p class="card-text mb-1">
                                                    <small class="text-muted">Varietal: <%# Eval("Varietal.Nombre") %></small>
                                                </p>
                                                <p class="card-text mb-1">
                                                    <small class="text-muted">Bodega: <%# Eval("Bodega.Nombre") %></small>
                                                </p>
                                            </asp:Panel>
                                        </div>

                                        <!-- Precio siempre al final del card-body -->
                                        <p class="card-text fw-bold text-primary mb-0 mt-auto">
                                            $<%# string.Format("{0:N0}", Eval("Precio")) %>
                                        </p>
                                    </div>

                                    <!-- Botón al final de la tarjeta -->
                                    <a href='DetalleProducto.aspx?id=<%# Eval("Id") %>' class="btn btn-sm btn-secondary">Ver detalle</a>
                                    <asp:Button ID="btnAgregarCarrito" runat="server" 
                                        Text="Agregar al carrito" CssClass="btn btn-sm btn-primary mt-2" 
                                        CommandName="Agregar" CommandArgument='<%#Eval("Id") %>'
                                    />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

    </main>

</asp:Content>
