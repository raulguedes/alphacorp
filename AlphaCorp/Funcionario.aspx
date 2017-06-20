<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Funcionario.aspx.cs" Inherits="AlphaCorp.Funcionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Funcionário</title>
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
                <div class="col-sm-8">
                    <h3>Consultar funcionário</h3>
                </div>
                <div class="col-sm-3">
                    <h3>
                        <button id="btnCriar" type="button" class="form-control btn btn-success" onserverclick="btnCriar_ServerClick" runat="server">Criar</button></h3>
                </div>
            </div>
            <div class="row" style="padding: 20px;">
                <div class="form-group">

                    <div class="col-sm-4">
                        <label for="txtNome">Nome</label>
                        <input class="form-control req" id="txtNome" runat="server" placeholder="Nome">
                    </div>
                    <div class="col-sm-4">
                        <label for="ddlDepartamento">Departamento</label>
                        <asp:DropDownList ID="ddlDepartamento" AppendDataBoundItems="true" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                            <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-4">
                        <label for="ddlDepartamento">Cargo</label>
                        <asp:DropDownList ID="ddlCargo" AppendDataBoundItems="true" runat="server" class="form-control">
                            <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-4">
                        <label for="ddlStatus">Status</label>
                        <asp:DropDownList ID="ddlStatus" AppendDataBoundItems="true" runat="server" class="form-control ">
                            <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                            <asp:ListItem Text="Ativo" Value="1" />
                            <asp:ListItem Text="Desativado" Value="2" />
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
                    <asp:GridView ID="gvFuncionario" CssClass="table table-hover table-bordered table-condensed"
                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gvFuncionario_PageIndexChanging"
                        HeaderStyle-CssClass="heardGV" runat="server"
                        AutoGenerateColumns="False" Width="100%" Height="100%" DataKeyNames="Id"
                        OnRowCommand="gvFuncionario_RowCommand">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="0%" Visible="false" HeaderStyle-ForeColor="White" HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblId" Text='<%# Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White"></HeaderStyle>
                                <ItemStyle Width="0%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="0%" Visible="false">
                                <HeaderTemplate>
                                    <asp:Label runat="server" CssClass="col-sm-8 col-form-label" Text="ID"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIdTipoUser" CssClass="col-sm-8 col-form-label" Text='<%# Eval("IdTipoUser")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="40%">
                                <HeaderTemplate>
                                    <div class="col-sm-12">
                                        <asp:Label runat="server" Text="Cliente"></asp:Label>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblNome" CssClass="col-sm-12 col-form-label" Text='<%# Eval("Nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="20%">
                                <HeaderTemplate>
                                    <asp:Label runat="server" CssClass="col-sm-12 col-form-label" Text="Email"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblEmail" CssClass="col-sm-12 col-form-label" Text='<%# Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="25%">
                                <HeaderTemplate>
                                    <asp:Label runat="server" CssClass="col-sm-12 col-form-label" Text="Tel.Residencial"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblResidencial" CssClass="col-sm-12 col-form-label" Text='<%#(Eval("Residencial").ToString() == "0" ? string.Empty : string.Format("{0:(##)####-####}",Eval("Residencial")) )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="25%">
                                <HeaderTemplate>
                                    <asp:Label runat="server" CssClass="col-sm-12 col-form-label" Text="Tel.Residencial"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCelular" CssClass="col-sm-12 col-form-label" Text='<%#(Eval("Celular").ToString() == "0" ? string.Empty : string.Format("{0:(##)# ####-####}",Eval("Celular")) )%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="15%">
                                <HeaderTemplate>
                                    <asp:Label runat="server" CssClass="col-sm-12 col-form-label" Text="Tipo de usuário"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblTipoUser" CssClass="col-sm-12 col-form-label" Text='<%# Eval("vcTipoUser")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="10%">
                                <HeaderTemplate>
                                    <asp:Label runat="server" CssClass="col-sm-12 col-form-label" Text="Status"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblStatus" CssClass="col-sm-12 col-form-label" Text='<%# Eval("Status").ToString() == "0" ? "Desativado" : "Ativo"  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:LinkButton CommandName="Excluir" ToolTip="Exluir departamento" class="btn btn-default btn-sm" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="glyph
                                         glyphicon-remove"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:LinkButton CommandName="Editar" ToolTip="Editar departamento" class="btn btn-default btn-sm" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
