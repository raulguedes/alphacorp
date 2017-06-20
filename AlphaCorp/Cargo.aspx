<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cargo.aspx.cs" Inherits="AlphaCorp.Cargo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/sidenav.css" rel="stylesheet" />
    <link href="bootstrap/outros.css" rel="stylesheet" />
    <script src="Scripts/jquery-ui.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="thumbnail col-sm-12">
        <div class="caption">
            <div class="page-header">
                <h3>Cargo</h3>
            </div>
            <div class="row" style="padding-bottom: 20px; padding-top: 20px;">
                <div class="col-sm-7">
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Text="Selecione departamento..." Selected="True" Value="0" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group input-group">
                            <input class="form-control req" id="txtCadastar" runat="server" placeholder="Cargo">
                            <span class="input-group-btn">
                                <button id="btnCriar" type="button" class="form-control btn btn-success" onserverclick="btnCriar_ServerClick" runat="server">Criar</button>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col-sm-11">
                    <div class="table-responsive">
                        <asp:GridView ID="gvCargo" CssClass="table table-hover table-bordered table-condensed" HeaderStyle-CssClass="heardGV" runat="server"
                            AutoGenerateColumns="False" Width="100%" Height="100%" DataKeyNames="Id" OnRowDataBound="gvCargo_RowDataBound"
                             AllowPaging="true" PageSize="10" OnPageIndexChanging="gvCargo_PageIndexChanging"
                            OnRowCommand="gvDepartamento_RowCommand">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblIdDepartamento" Text='<%# Eval("IdDepartamento") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White"></HeaderStyle>
                                    <ItemStyle Width="0%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblId" Text='<%# Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White"></HeaderStyle>
                                    <ItemStyle Width="0%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="40%">
                                    <HeaderTemplate>
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Departamento"></asp:Label>
                                        </div>
                                        <div class="col-sm-6 pull-right">
                                            <%--<asp:TextBox Text="text" ID="lblBusca" CssClass="form-control input-sm" runat="server" placeholder="Buscar" />--%>
                                            <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-control input-sm" AppendDataBoundItems="true" placeholder="Buscar">
                                                <asp:ListItem Text="Selecione..." Selected="True" Value="0" />
                                            </asp:DropDownList>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDepartamento" CssClass="col-sm-8 col-form-label" Text='<%# Eval("Departamento") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="40%">
                                    <HeaderTemplate>
                                        <div class="col-sm-7 pull-right">
                                            <asp:TextBox ID="lblBuscaCargo" CssClass="form-control input-sm" runat="server" placeholder="Buscar por cargo" />
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCargo" CssClass="col-sm-8 col-form-label" Text='<%# Eval("Nome") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="15%">
                                    <HeaderTemplate>
                                        <asp:LinkButton CommandName="Buscar" CssClass="btn btn-default btn-sm" runat="server"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                            <div class="btn-group" role="group">
                                                <asp:LinkButton CommandName="Excluir" class="btn btn-default btn-sm" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="glyphicon glyphicon-remove-circle"></span></asp:LinkButton>
                                            </div>
                                            <div class="btn-group" role="group">
                                                <asp:LinkButton CommandName="Editar" class="btn btn-default btn-sm" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                            </div>
                                        </div>
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
