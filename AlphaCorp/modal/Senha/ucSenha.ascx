<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSenha.ascx.cs" Inherits="AlphaCorp.modal.Senha.ucSenha" %>
<script type="text/javascript">
    function Retorno() {
        var url = window.location.href;
        location.href = url;
    };
    $(document).ready(function () {

        $("#cancelar").click(function (event) {
            $('#mSenha').modal('hide');
            $('link[class="modal"]').remove();
            $('.mreq').prop('required', false);
            $('.extra').prop('required', true);
            Retorno();
        });

        $("#xfechar").click(function (event) {
            $('#mSenha').modal('hide');
            $('link[class="modal"]').remove();
            $('.mreq').prop('required', false);
            $('.extra').prop('required', true);
            Retorno();
        });
    });
    function ShowSenha() {
        $('.extra').prop('required', false);
        append();
        $("#mSenha").modal({ backdrop: 'static', keyboard: false, show: true });
        $('.mreq').prop('required', true);
    }
    function append() {
        $('head').append('<link href="../bootstrap/bootstrap.min.css"  rel="stylesheet" class="modal" />');
        $('head').append('<script scr="../Scripts/jquery.js"  class="modal" />');
        $('head').append('<script scr="../js/bootstrap.min.js"  class="modal" />');
        $('head').append('<link href="../bootstrap/outros.css"  rel="stylesheet" class="modal" />');
        $('head').append('<script src="js/validator.min.js" class="modal" />');
        $('head').append('<link href="bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" class="modal" />');
        $('head').append('<script src="bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js" class="modal" />');
    }
    function Gravar() {
        //var _data = JSON.stringify({ Texto: sortedIDs });
        var _atual = $("#txtSenha").val();
        var _nova = $("#txtNovaSenha").val();
        var _confirmar = $("#txtConfirmarSenha").val();
        if (_atual != "" || _nova != "" || _confirmar != "")
            $.ajax({
                type: "POST",
                url: "Conta.aspx/RefS",
                data: '{Atual:"' + _atual + '",Nova:"' + _nova + '",Confirmar:"' + _confirmar + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: ShowNotify(),
                failure: function (response) {
                    ShowErro(response.d);

                }
            });
        else
            ShowErro("Campo(s) vazio");
    }

    function ShowNotify() {
        $('#mSenha').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        $('.mreq').prop('required', false);
        $('.extra').prop('required', true);
        append();
        $('#mNotify').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function ShowErro(msg) {
        $('#mSenha').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        $('.mreq').prop('required', false);
        $('.extra').prop('required', true);
        append();
        $('#mErro').modal({ backdrop: 'static', keyboard: false, show: true });
        $('#<%=lblmsg.ClientID%>').text = msg;
    };

</script>

<div class="modal fade" id="mNotify" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background-color: greenyellow">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="text-center">
                        <span><strong>Senha alterada!!</strong></span>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="btn btn-default fechar">
                        Fechar
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" id="mErro" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background-color: darkred">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="text-center">
                        <span><strong>
                            <asp:Label Text="" ID="lblmsg" runat="server" ClientIDMode="Static" /></strong></span>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="btn btn-default fechar">
                        Fechar
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" id="mSenha" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content ">
                <div class="modal-header">
                    <button type="button" id="xfechar" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="text-center">
                        <h2 class="modal-title"><small>Redefinir senha</small></h2>
                    </div>
                    <div class="alert alert-error alert-danger" style="width: 100%; margin-left: 0%" id="AlertErro"
                        visible="false" runat="server">
                        <strong>
                            <asp:Label ID="lblAviso" runat="server" Text="" ClientIDMode="Static"></asp:Label>
                        </strong>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label for="txtSenha">Senha atual</label>
                                <input type="password" class="form-control mreq" id="txtSenha" clientidmode="Static" placeholder="Senha atual" runat="server">
                                <div class="help-block with-errors">Preencha esse campo!!</div>
                            </div>
                            <div class="form-group">
                                <label for="txtNovaSenha">Nova senha</label>
                                <input type="password" data-minlength="6" class="form-control mreq" id="txtNovaSenha" placeholder="Password" runat="server" clientidmode="Static">
                                <%--<asp:TextBox ID="txtNovaSenha" TextMode="Password" data-minlength="6" class="form-control req" runat="server" ClientIDMode="Static" />--%>
                                <div class="help-block">Minimum of 6 characters</div>
                            </div>
                            <div class="form-group">
                                <label for="txtConfirmarSenha">Confirmar senha</label>
                                <input type="password" class="form-control mreq" id="txtConfirmarSenha" clientidmode="Static" data-match="#txtNovaSenha" data-match-error="As senhas não são iguais!!!" placeholder="Confirmar senha" runat="server">
                                <div class="help-block with-errors">Preencha esse campo!!</div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="cancelar" type="reset" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button id="btnSalvarSenha" type="submit" class="btn btn-primary" onclick="Gravar()">Salvar</button>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

</script>
