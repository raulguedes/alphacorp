<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCliente.ascx.cs" Inherits="AlphaCorp.modal.Cliente.ucCliente" %>

<script type="text/javascript">
    function Retorno() {
        var url = window.location.href;
        location.href = url;
    };
    $(document).ready(function () {

        $("#cancelar").click(function (event) {
            $('#mCliente').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });

        $("#xfechar").click(function (event) {
            $('#mCliente').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });

        $(".close").click(function (event) {
            $('#mCliente').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });
        $(".fechar").click(function (event) {
            $('#mCliente').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });
    });
    function append() {
        $('head').append('<link href="../bootstrap/bootstrap.min.css"  rel="stylesheet" class="modal" />');
        $('head').append('<script scr="../Scripts/jquery.js"  class="modal" />');
        $('head').append('<script scr="../js/bootstrap.min.js"  class="modal" />');
        $('head').append('<link href="../bootstrap/outros.css"  rel="stylesheet" class="modal" />');
    }
    function Show(id, nome, email, telefone) {
        append();
        $("#mCliente").modal({ backdrop: 'static', keyboard: false, show: true });
        $('#<%=txtId.ClientID%>').val(id);
        $('#<%=txtmNome.ClientID%>').val(nome);
        $('#<%=txtmEmail.ClientID%>').val(email);
        $('#<%=txtmTelefone.ClientID%>').val(telefone);
        $('.req').prop('required', false);
        $('.m').prop('required', true);
    };
    function ShowNotify() {
        $('#mCliente').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        $('.req').prop('required', true);
        $('.m').prop('required', false);
        append();
        $('#mNotify').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function ShowErro() {
        $('#mCliente').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        $('.req').prop('required', true);
        $('.m').prop('required', false);
        append();
        $('#mErro').modal({ backdrop: 'static', keyboard: false, show: true });
    };


    function EditCliente() {
        var nome = $('#<%=txtmNome.ClientID%>').val();
        var telefone = $('#<%=txtmTelefone.ClientID%>').val();
        var email = $('#<%=txtmEmail.ClientID%>').val();
        var id = $('#<%=txtId.ClientID%>').val();
        if (nome != "" && id != "") {
            $.ajax({
                type: "POST",
                url: "../Cliente.aspx/Editar",
                data: '{mNome:"' + nome + '",mId:"' + id + '",mEmail:"' + email + '",mTelefone:"' + telefone + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    ShowNotify();
                },
                failure: function () {
                    ShowErro();
                }
            });
        } else {
            ShowErro();
        }
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
                        <span><strong>Cliente alterado!!</strong></span>
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
                        <span><strong>Nome do cliente em branco</strong></span>
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
<div class="modal fade" id="mCliente" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content ">
                <div class="modal-header">
                    <button type="button" id="xfechar" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="text-center">
                        <h4 class="modal-title"><small>Cliente</small></h4>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtmNome">Nome</label>
                        <input class="form-control input-sm mreq" id="txtmNome" runat="server" type="text" clientidmode="static">
                    </div>
                    <div class="form-group">
                        <label for="txtmEmail">Email</label>
                        <input class="form-control input-sm mreq" id="txtmEmail" runat="server" type="text" clientidmode="static">
                    </div>
                    <div class="form-group">
                        <label for="txtmTelefone">Telefone</label>
                        <input class="form-control input-sm mreq" id="txtmTelefone" runat="server" type="text" clientidmode="static">
                    </div>
                    <div style="display: none;">
                        <input class="form-control input-sm mreq" id="txtId" runat="server" type="text" clientidmode="static">
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="cancelar" type="reset" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button id="btnSalvar" type="submit" class="btn btn-primary" onclick="EditCliente()">Salvar</button>
                </div>
            </div>
        </div>
    </div>
</div>

