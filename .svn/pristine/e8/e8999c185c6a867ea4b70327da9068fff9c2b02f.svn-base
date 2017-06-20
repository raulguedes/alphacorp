<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNotify.ascx.cs" Inherits="AlphaCorp.modal.Notify.ucNotify" %>

<script type="text/javascript">
    $(document).ready(function () {

        $("#cancelar").click(function (event) {
            $('#modalNotify').modal('hide');
            $('link[class="modal"]').remove();
            $('#lblConfirmHeader').text("false");
        });

        $("#xfecharmodalConfirm").click(function (event) {
            $('#modalNotify').modal('hide');
            $('link[class="modal"]').remove();
        });
    });

    function append() {
        $('head').append('<link href="../bootstrap/bootstrap.min.css"  rel="stylesheet" class="modal" />');
        $('head').append('<script scr="../Scripts/jquery.js"  class="modal" />');
        $('head').append('<script scr="../js/bootstrap.min.js"  class="modal" />');
        $('head').append('<link href="../bootstrap/outros.css"  rel="stylesheet" class="modal" />');            
    }

    function ShowErro(titulo, mensagem) {
        append();
        $('#mErro').modal({ backdrop: 'static', keyboard: false, show: true });
        //lbl para receber o titulo do confirm.
        $('#<%=lblmTituloErro.ClientID%>').text(titulo);
        //lbl para receber o corpo do confirm.
        $('#<%=lblmMensagemErro.ClientID%>').text(mensagem);
        setTimeout(function () {
            $('#mErro').modal('hide');
            $('link[class="modal"]').remove();
        }, 5000);
    }

    function ShowSucesso(titulo, mensagem) {
        append();
        $('#mNotify').modal({ backdrop: 'static', keyboard: false, show: true });
        //lbl para receber o titulo do confirm.
        $('#<%=lblmTitulo.ClientID%>').text(titulo);
        //lbl para receber o corpo do confirm.
        $('#<%=lblmMensagem.ClientID%>').text(mensagem);
        setTimeout(function () {
            $('#mNotify').modal('hide');
            $('link[class="modal"]').remove();
        }, 5000);
    }

</script>
<div class="modal fade" id="mNotify" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-sm" role="document">
        <div class="modal-content">
            <div class="modal-header" style="background-color: greenyellow">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
                <div class="text-center">
                    <h4 class="modal-title"><small>
                        <label id="lblmTitulo" runat="server" clientidmode="static" />
                    </small></h4>
                </div>
            </div>
            <div class="modal-body">
                <div class="text-center">
                    <span><strong>
                        <label id="lblmMensagem" runat="server" clientidmode="static"></label>
                    </strong></span>
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
                <div class="text-center">
                    <h4 class="modal-title"><small>
                        <label id="lblmTituloErro" runat="server" clientidmode="static" />
                    </small></h4>
                </div>
            </div>
            <div class="modal-body">
                <div class="text-center">
                    <span><strong>
                        <label id="lblmMensagemErro" runat="server" clientidmode="static"></label>
                    </strong></span>
                </div>
            </div>
        </div>
    </div>
</div>



