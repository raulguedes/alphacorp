<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Conta.aspx.cs" Inherits="AlphaCorp.Conta" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" required="required">
    <link href="bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/sidenav.css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="bootstrap/outros.css" rel="stylesheet" />
    <script src="js/validator.min.js"></script>
    <link href="bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder1" runat="server">
    <div class="col-sm-12">
        <div class="jumbotron">
            <div class="container ">
                <div class="col-sm-9 ">
                    <div class=" row " style="margin: 0 auto !important">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-9">
                                    <h3><small>Dados da pessoais</small></h3>
                                    <hr />
                                </div>
                                <div class="col-sm-3  ">
                                    <button type="button" id="SenhaAlterar" class="btn btn-primary pull-right" runat="server" onserverclick="SenhaAlterar_ServerClick">
                                        Redefinir senha
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtNome">Nome</label>
                            <input class="form-control extra" id="txtNome" runat="server" required="required" placeholder="Nome">
                        </div>
                        <div id="ContaP" runat="server" visible="false">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label for="txtRG">RG</label>
                                        <input class="form-control" id="txtRG" runat="server" placeholder="RG">
                                    </div>
                                    <div class="col-sm-6">
                                        <label for="txtCPF">CPF</label>
                                        <input class="form-control" id="txtCPF" runat="server" placeholder="CPF">
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label for="txtDataNascimento">Nascimento</label>
                                        <div class="input-group datepicker">
                                            <div class="input-group-addon add-on">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </div>
                                            <input class="form-control" id="txtData" runat="server" data-format="dd/MM/yyyy" placeholder="DD/MM/YYYY">
                                        </div>
                                    </div>
                                    <div class="col-sm-5">
                                        <label for="ltsSexo">Sexo</label>
                                        <asp:DropDownList ID="ddlSexo" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0" Text="Feminino" />
                                            <asp:ListItem Value="1" Text="Masculino" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label for="txtResidencil">Tel. Residencil</label>
                                        <input class="form-control" id="txtResidencial" runat="server" placeholder="Tel. Residencial">
                                    </div>
                                    <div class="col-sm-6">
                                        <label for="txtCelular">Tel. Celular</label>
                                        <input class="form-control" id="txtCelular" runat="server" placeholder="Tel. Celular">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="ContaE" runat="server" visible="false">
                            <div class="form-group">
                                <label for="txtEmail">E-mail</label>
                                <div class="input-group mb-2 mr-sm-2 mb-sm-0">
                                    <div class="input-group-addon">@</div>
                                    <input type="email" class="form-control extra" id="txtEmail" runat="server" placeholder="E-mail" data-error="Campo em branco ou em formato incorreto!!" required>
                                </div>
                                <div class="help-block with-errors"></div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label for="txtCNPJ">CNPJ</label>
                                        <input class="form-control" id="txtCNPJ" runat="server" placeholder="CNPJ">
                                    </div>
                                    <div class="col-sm-6">
                                        <label for="txtContato">Contato</label>
                                        <input class="form-control" id="txtContato" runat="server" placeholder="Tel. Contato">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <h3><small>Endereço</small></h3>
                        <hr />
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-5">
                                    <label for="txtCEP">CEP</label>
                                    <div class="form-group input-group">
                                        <asp:TextBox CssClass="form-control " ID="txtCEP" runat="server" placeholder="CEP"> </asp:TextBox>
                                        <div class="input-group-btn">
                                            <button id="btnBuscarCep" type="button" class="btn btn-default glyphicon glyphicon-search" runat="server" onserverclick="btnBuscarCep_Click"></button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-9">
                                    <label for="txtEndereco">Endereço</label>
                                    <input class="form-control" id="txtEndereco" runat="server" placeholder="Endereço">
                                </div>
                                <div class="col-sm-3">
                                    <label for="txtNumeroEndereco">Nº</label>
                                    <input class="form-control" id="txtNumeroEndereco" runat="server" placeholder="Nº" tooltip="Nº de Endereco">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-9">
                                    <label for="txtComplementoEndereco">Complemento do Endereco</label>
                                    <input class="form-control" id="txtComplementoEndereco" runat="server" placeholder="Complemento">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-7">
                                    <label for="txtBairro">Bairro</label>
                                    <input class="form-control" id="txtBairro" runat="server" placeholder="Bairro">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-3">
                                    <label for="ddlUF">UF</label>
                                    <input class="form-control" id="txtUF" runat="server" placeholder="UF">
                                </div>
                                <div class="col-sm-6">
                                    <label for="ddlCidade">Cidade</label>
                                    <input class="form-control" id="txtCidade" runat="server" placeholder="Cidade">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-9">
                                    <asp:Button ID="btnSalvar" Text="Salvar" runat="server" OnClick="btnSalvar_Click" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
