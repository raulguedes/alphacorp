<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFuncionario.ascx.cs" Inherits="AlphaCorp.modal.Funcionario.ucFuncionario" %>

<script type="text/javascript">
    function Retorno() {
        var url = window.location.href;
        location.href = url;
    };
    $(document).ready(function () {
        $("#cancelar").click(function (event) {
            $('#mFuncionario').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });
        $("#xfechar").click(function (event) {
            $('#mFuncionario').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });
        $(".close").click(function (event) {
            $('#mFuncionario').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });
        $(".fechar").click(function (event) {
            $('#mFuncionario').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });
    });
    function append() {
        $('head').append('<link href="../bootstrap/bootstrap.min.css"  rel="stylesheet" class="modal" />');
        $('head').append('<script scr="../Scripts/jquery.js"  class="modal" />');
        $('head').append('<script scr="../js/bootstrap.min.js"  class="modal" />');
        $('head').append('<link href="../bootstrap/outros.css"  rel="stylesheet" class="modal" />');
        $('head').append('<script src="js/validator.min.js" class="modal" />');
    }
    function ShowFuncionario() {
        append();
        $('#mFuncionario').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function RemoveModalFuncionario() {
        $('#mFuncionario').modal('hide');
        $('link[class="modal"]').remove();
    };
    function RemoveModalNotify() {
        $('#mNotify').modal('hide');
        $('link[class="modal"]').remove();
    };
    function RemoveModalErro() {
        $('#mErro').modal('hide');
        $('link[class="modal"]').remove();
    };
    function ShowNotify() {
        RemoveModalFuncionario();
        append();
        $('#mNotify').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function ShowErro() {
        RemoveModalFuncionario();
        append();
        $('#mErro').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function CarregarCargo() {
        var Departamento = $('#<%=ddlmDepartamento.ClientID%>').val();
        var str = "";
        $.ajax({
            url: '../Funcionario.aspx/CarregarCargo',
            datatype: 'json',
            contentType: 'application/json; charset=utf-8',
            type: 'POST',
            data: JSON.stringify({ mId: Departamento }),
            success: function (data) {
                str += '<option value="0">Selecione..</option>';
                $(data.d).each(function () {
                    str += '<option value=' + this.Id + '>' + this.Nome + '</option>';
                })
                $('#<%=ddlmCargo.ClientID%>').html(str);
                str = "";
            },
            error: function (error) {
            }
        })
    };
</script>


<div class="modal fade" id="mNotify" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-sm" role="document">
        <div class="modal-content">
            <div class="modal-header" style="background-color: greenyellow">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="text-center">
                    <span><strong>Funcinário cadastrado!!</strong></span>
                </div>
            </div>
            <div class="modal-footer">
                <div class="btn btn-default fechar">
                    OK
                </div>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" id="mErro" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-sm" role="document">
        <div class="modal-content">
            <div class="modal-header" style="background-color: darkred">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="text-center">
                    <asp:Label ID="lblmErro" Text="Dados do funcionário em branco" ClientIDMode="Static" runat="server" />
                </div>
            </div>
            <div class="modal-footer">
                <div class="btn btn-default fechar">
                    OK
                </div>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" id="mFuncionario" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog" role="document">
            <div class="modal-content ">
                <div class="modal-header">
                    <button type="button" id="xfechar" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="text-center">
                        <h4 class="modal-title"><small>Cadastrar funcionário</small></h4>
                    </div>

                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtmNome">Nome</label>
                        <input type="text" class="form-control mreq funcionario" id="txtmNome" tabindex="1" placeholder="Nome" runat="server" clientidmode="Static">
                        <div class="help-block with-errors">Preencha esse campo!!</div>
                    </div>
                    <div class="form-group">
                        <label for="txtmEmail">E-mail</label>
                        <input type="email" class="form-control mreq funcionario" id="txtmEmail" tabindex="2" placeholder="E-mail" runat="server" clientidmode="Static">
                        <div class="help-block with-errors">Preencha esse campo!!</div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-5">
                                <label for="txtmSenha">Senha</label>
                                <input type="password" data-minlength="6" class="form-control mreq funcionario" tabindex="3" id="txtmSenha" placeholder="Password" runat="server" clientidmode="Static">
                                <div class="help-block">Minimo 6 caracteres</div>
                            </div>
                            <div class="col-sm-5">
                                <label for="txtmConfirmar">Confirmar senha</label>
                                <input type="password" class="form-control mreq funcionario" id="txtmConfirmar" tabindex="4" clientidmode="Static" data-match="#txtmSenha" data-match-error="As senhas não são iguais!!!" placeholder="Confirmar senha" runat="server">
                                <div class="help-block with-errors">Preencha esse campo!!</div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <h4>
                        <span>Configurações</span>
                    </h4>
                    <hr />

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-5">
                                <label for="txtmHoraDiaria">Hora diária</label>
                                <input type="time" class="form-control mreq funcionario" id="txtmHoraDiaria" tabindex="5" clientidmode="Static" placeholder="Hora diária" runat="server">
                                <div class="help-block with-errors">Preencha esse campo!!</div>
                            </div>
                            <div class="col-sm-5">
                                <label for="ddmSexo">Sexo</label>
                                <asp:DropDownList CssClass="form-control input-sm mreq funcionario" ID="ddlmSexo" TabIndex="6" ClientIDMode="Static" runat="server">
                                    <asp:ListItem Value="1" Text="Masculino" Selected="True" />
                                    <asp:ListItem Value="2" Text="Feminino" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-5">
                                <label for="ddlmDepartamento">Departamento</label>
                                <asp:DropDownList CssClass="form-control input-sm mreq funcionario" ID="ddlmDepartamento" TabIndex="6" ClientIDMode="Static" runat="server" onchange="CarregarCargo()">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-5">
                                <label for="ddmCargo">Cargo</label>
                                <asp:DropDownList CssClass="form-control input-sm mreq funcionario" ID="ddlmCargo" TabIndex="7" AppendDataBoundItems="true" ClientIDMode="Static" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-5">
                                <label for="ddlmTipoUser">Tipo de usuario</label>
                                <asp:DropDownList CssClass="form-control input-sm mreq funcionario" ID="ddlmTipoUser" TabIndex="8" ClientIDMode="Static" runat="server">
                                    <asp:ListItem Value="1" Text="Administrador" Selected="True" />
                                    <asp:ListItem Value="2" Text="Supervisor" />
                                    <asp:ListItem Value="3" Text="Comum" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-5">
                                <label for="ddlmPermitir">Permitir hora extra</label>
                                <asp:DropDownList CssClass="form-control input-sm mreq funcionario" ID="ddlmPermitir" TabIndex="9" AppendDataBoundItems="true" ClientIDMode="Static" runat="server">
                                    <asp:ListItem Value="0" Text="Não" />
                                    <asp:ListItem Value="1" Text="Sim" Selected="True" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="cancelar" type="reset" class="btn btn-secondary">Cancelar</button>
                    <asp:Button ID="btnCriar" Text="Registrar" runat="server" OnClientClick="Registrar()" CssClass="btn btn-login" />
                </div>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function Registrar() {
        var Nome = $('#<%=txtmNome.ClientID%>').val(), Email = $('#<%=txtmEmail.ClientID%>').val(), Senha = $('#<%=txtmSenha.ClientID%>').val(), Confirmar = $('#<%=txtmConfirmar.ClientID%>').val();
        if (Nome != "" && Email != "" && Senha != "" && Confirmar != "") {
            var inputs = new Array();
            $('.funcionario').each(function () {
                inputs.push($(this).val());
            });
            debugger
            $.ajax({
                type: "POST",
                url: "../Funcionario.aspx/Register",
                data: JSON.stringify({ mFuncionario: inputs }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {                    
                    if (msg.d == "")
                        ShowNotify();
                    else {
                        $('#<%=lblmErro.ClientID%>').text(msg.d);
                        ShowErro();
                    }
                },
                failure: function () {
                    ShowErro();
                },
                error: function () {
                    ShowErro();
                }
            });
        }
        else {
            ShowErro();
        }
    }
</script>
