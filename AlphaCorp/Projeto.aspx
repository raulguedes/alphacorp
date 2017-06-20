<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projeto.aspx.cs" Inherits="AlphaCorp.Projeto" %>

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
                <div class="row">
                    <div class="col-sm-8">
                        <h3>Consultar projeto</h3>
                    </div>
                    <div class="col-sm-4">
                        <h3>
                            <button id="btnCriar" runat="server" class="btn btn-success" onserverclick="btnCriar_ServerClick">Criar projeto</button>
                        </h3>
                    </div>
                </div>
            </div>
            <div class="row" style="padding: 20px;">
                <div class="form-group">

                    <div class="col-sm-4">
                        <label for="txtNome">Nome</label>
                        <input class="form-control" id="txtNome" runat="server" placeholder="Nome">
                    </div>
                    <div class="col-sm-4">
                        <label for="ddlDepartamento">Departamento</label>
                        <asp:DropDownList ID="ddlDepartamento" AppendDataBoundItems="true" runat="server" class="form-control">
                            <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-4">
                        <label for="ddlCliente">Cliente</label>
                        <asp:DropDownList ID="ddlCliente" AppendDataBoundItems="true" runat="server" class="form-control">
                            <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-4">
                        <label for="ddlStatus">Status</label>
                        <asp:DropDownList ID="ddlStatus" AppendDataBoundItems="true" runat="server" class="form-control">
                            <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                            <asp:ListItem Text="Em andamento" Value="1" />
                            <asp:ListItem Text="Concluído" Value="2" />
                            <asp:ListItem Text="Cancelado" Value="3" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3">
                        <br />
                        <button id="btnConsultar" class=" btn btn-primary form-control" runat="server" onserverclick="btnConsultar_ServerClick">Buscar</button>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvProjeto" CssClass="table table-hover table-bordered table-condensed" HeaderStyle-CssClass="heardGV" runat="server"
                        AutoGenerateColumns="False" Width="100%" Height="100%" DataKeyNames="Id"
                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gvProjeto_PageIndexChanging"
                        OnRowCommand="gvProjeto_RowCommand">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblId" Text='<%# Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIdDepartamento" Text='<%# Eval("IdDepartamento") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIdCliente" Text='<%# Eval("IdCliente") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIdResponsavel" Text='<%# Eval("IdResponsavel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIdStatus" Text='<%# Eval("IdStatus") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White"></HeaderStyle>
                                <ItemStyle Width="0%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Projeto">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblNome" CssClass="col-form-label" Text='<%# Eval("Nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="15%" HeaderText="Departamento">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDepartamento" CssClass="col-form-label" Text='<%# Eval("Departamento") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="15%" HeaderText="Cliente">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCliente" CssClass="col-form-label" Text='<%# Eval("Cliente") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="15%" HeaderText="Responsável">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblResponsavel" CssClass="col-form-label" Text='<%# Eval("Responsavel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblStatus" CssClass="col-form-label" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:LinkButton CommandName="Excluir" ToolTip="Exluir departamento" class="btn btn-default btn-sm" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="5%">
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
</asp:Content>
