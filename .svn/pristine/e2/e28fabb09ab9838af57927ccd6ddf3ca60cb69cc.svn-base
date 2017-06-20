<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="AlphaCorp.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="../bootstrap/sidenav.css" rel="stylesheet" />
    <link href="../bootstrap/outros.css" rel="stylesheet" />
    <script src="../Scripts/jquery-ui.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/validator.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="thumbnail col-sm-12">
        <div class="caption">
            <div class="page-header">
                <h3>Cliente</h3>
            </div>
            <div class="row" style="padding: 20px;">
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-4">
                            <label for="txtNome">Nome</label>
                            <input class="form-control req" id="txtNome" runat="server" placeholder="Nome">
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label for="txtEmail">E-mail</label>
                                <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                                    <div class="input-group-addon">@</div>
                                    <input type="email" class="form-control req " id="txtEmail" runat="server" placeholder="E-mail" data-error="Campo em branco ou em formato incorreto!!">
                                </div>
                                <div class="help-block with-errors"></div>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <label for="txtTelefone">Telefone</label>
                            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" TextMode="Number" MaxLength="14" placeholder="Telefone" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <button id="btnCriar" class=" btn btn-success form-control" runat="server" onserverclick="btnCriar_ServerClick">Criar</button>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12 col-md-12">
                    <div class="table-responsive">
                        <asp:GridView ID="gvCliente" CssClass="table table-hover table-bordered table-condensed" HeaderStyle-CssClass="heardGV" runat="server"
                            AutoGenerateColumns="False" Width="100%" Height="100%" DataKeyNames="Id"
                            AllowPaging="true" PageSize="10" OnPageIndexChanging="gvCliente_PageIndexChanging"
                            OnRowCommand="gvCliente_RowCommand">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblId" Text='<%# Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White"></HeaderStyle>
                                    <ItemStyle Width="0%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="40%">
                                    <HeaderTemplate>
                                        <div class="col-sm-4">
                                            <asp:Label runat="server" Text="Cliente"></asp:Label>
                                        </div>
                                        <div class="col-sm-7">
                                            <div class="form-group-sm input-group ">
                                                <asp:TextBox Text="" ID="lblBusca" CssClass="form-control input-sm" runat="server"  placeholder="Buscar por nome" />
                                                <div class="input-group-btn ">
                                                    <asp:LinkButton CommandName="Buscar" CssClass="btn btn-default btn-sm" runat="server" data-toggle="tooltip" data-placement="bottom" title="Ao buscar em branco trás todos os clientes."><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNome" CssClass="col-sm-8 col-form-label" Text='<%# Eval("Nome") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="20%">
                                    <HeaderTemplate>
                                        <asp:Label runat="server" CssClass="col-sm-8 col-form-label" Text="Email"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEmail" CssClass="col-sm-8 col-form-label" Text='<%# Eval("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="25%">
                                    <HeaderTemplate>
                                        <asp:Label runat="server" CssClass="col-sm-8 col-form-label" Text="Telefone"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTelefone" CssClass="col-sm-8 col-form-label" Text='<%#(Eval("Telefone").ToString() == "0" ? string.Empty : string.Format("{0:(##)####-####}",Eval("Telefone")) )%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="7%">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="Excluir" ToolTip="Exluir departamento" class="btn btn-default btn-sm" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="7%">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="Editar" ToolTip="Editar departamento" class="btn btn-default btn-sm" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--
                            <asp:ButtonField CommandName="Excluir" ItemStyle-Width="1%" ControlStyle-CssClass="btn btn-default btn-sm glyphicon glyphicon-remove" />
                            <asp:ButtonField CommandName="Editar" ItemStyle-Width="1%" ControlStyle-CssClass="btn btn-default btn-sm glyphicon glyphicon-edit" />
                                --%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

