<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerenciamento.aspx.cs" Inherits="AlphaCorp.Gerenciamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="../bootstrap/sidenav.css" rel="stylesheet" />
    <script src="../Scripts/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../bootstrap/outros.css" rel="stylesheet" />
    <script src="../js/validator.min.js"></script>
    <link href="../bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="thumbnail col-sm-12">
        <div class="caption">
            <div class="page-header">
                <h3>Gerenciamento de supervisores</h3>
            </div>
            <div style="padding: 20px;">
                <div class="col-sm-12">
                    <div class="col-sm-6">
                        <fieldset class="form-group input-group">
                            <legend>Filtrar supervisor por</legend>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="ddlDepartamento">Departamento</label>
                                    <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                        <asp:ListItem Text="Selecione..." Selected="True" Value="0" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <label for="ddlCargo">Cargo</label>
                                    <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Selecione..." Selected="True" Value="0" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="col-sm-12">
                                <div class="text-center">
                                    <div class="col-sm-5">
                                        <button id="btnFiltrar" runat="server" class="btn btn-primary" onserverclick="btnFiltrar_ServerClick">Filtrar</button>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="col-sm-6">
                        <fieldset class="form-group input-group">
                            <legend>Filtrar funcionario por</legend>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="ddlDepartamento">Departamento</label>
                                    <asp:DropDownList ID="ddlFDepartamento" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlFDepartamento_SelectedIndexChanged">
                                        <asp:ListItem Text="Selecione..." Selected="True" Value="0" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <label for="ddlCargo">Cargo</label>
                                    <asp:DropDownList ID="ddlFCargo" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Selecione..." Selected="True" Value="0" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="col-sm-12">
                                <div class="text-center">
                                    <button id="btnFiltrarFuncionario" runat="server" class="btn btn-primary" onserverclick="btnFiltrarFuncionario_ServerClick">Filtrar funcionário</button>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="col-sm-12">
                        <fieldset class="form-group input-group">
                            <legend>Criar gerenciamento</legend>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label for="ddlSupervisor">Supervisor</label>
                                        <asp:DropDownList ID="ddlSupervisor" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Selecione..." Selected="True" Value="0" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-6">
                                        <label for="ddlFuncionario">Funcionário</label>
                                        <asp:DropDownList ID="ddlFuncionario" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Selecione..." Selected="True" Value="0" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="col-sm-12">
                                    <div class="text-right">
                                        <button id="btnSalvar" runat="server" class="btn btn-success" onserverclick="btnSalvar_ServerClick">Salvar</button>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="row">
                        <div class="table-responsive">
                            <asp:GridView ID="gvGerenciamento" CssClass="table table-hover table-bordered table-condensed" HeaderStyle-CssClass="heardGV" runat="server"
                                AutoGenerateColumns="False" Width="100%" Height="100%" DataKeyNames="Id"
                                AllowPaging="true" PageSize="10" OnPageIndexChanging="gvGerenciamento_PageIndexChanging"
                                OnRowCommand="gvGerenciamento_RowCommand">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblIdGerenciamento" Text='<%# Eval("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle ForeColor="White"></HeaderStyle>
                                        <ItemStyle Width="0%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblIdSupervisor" Text='<%# Eval("IdSupervisor") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle ForeColor="White"></HeaderStyle>
                                        <ItemStyle Width="0%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblIdFuncionario" Text='<%# Eval("IdFuncionario") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle ForeColor="White"></HeaderStyle>
                                        <ItemStyle Width="0%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="40%">
                                        <HeaderTemplate>
                                            <div class="col-sm-6">
                                                <asp:Label runat="server" Text="Supervisor"></asp:Label>
                                            </div>
                                            <div class="col-sm-6 pull-right">
                                                <asp:TextBox Text="" ID="txtBSupervisor" CssClass="form-control input-sm" runat="server" placeholder="Supervisor" />
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblSupervisor" CssClass="col-sm-8 col-form-label" Text='<%# Eval("Supervisor") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="40%">
                                        <HeaderTemplate>
                                            <div class="col-sm-7 pull-right">
                                                <asp:TextBox ID="txtBFuncionario" CssClass="form-control input-sm" runat="server" placeholder="Funcionário" />
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblFuncionario" CssClass="col-sm-8 col-form-label" Text='<%# Eval("Funcionario") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="15%">
                                        <HeaderTemplate>
                                            <asp:LinkButton CommandName="Buscar" CssClass="btn btn-default btn-sm" runat="server"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                                <div class="btn-group" role="group">
                                                    <asp:LinkButton CommandName="Excluir" ToolTip="Excluir" class="btn btn-default btn-sm" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
