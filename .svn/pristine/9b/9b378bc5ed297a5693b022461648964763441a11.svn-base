<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDepartamento.ascx.cs" Inherits="AlphaCorp.modal.Departamento.ucDepartamento" %>
<script type="text/javascript">
    function Retorno() {
        var url = window.location.href;
        location.href = url;
    };
    $(document).ready(function () {

        $("#cancelar").click(function (event) {
            $('#mDepartamento').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });

        $("#xfechar").click(function (event) {
            $('#mDepartamento').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });

        $(".close").click(function (event) {
            $('#mDepartamento').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });
        $(".fechar").click(function (event) {
            $('#mDepartamento').modal('hide');
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
    function Show(id, departamento) {
        append();
        $("#mDepartamento").modal({ backdrop: 'static', keyboard: false, show: true });
        $('#<%=txtId.ClientID%>').val(id);
        $('#<%=txtmNome.ClientID%>').val(departamento);

    };
    function ShowNotify() {
        $('#mDepartamento').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        append();
        $('#mNotify').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function ShowErro() {
        $('#mDepartamento').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        append();
        $('#mErro').modal({ backdrop: 'static', keyboard: false, show: true });
    };


    function EditDepartamento() {
        debugger
        var nome = $('#<%=txtmNome.ClientID%>').val();
        var id = $('#<%=txtId.ClientID%>').val();
        if (nome != "" && id != "") {
            $.ajax({
                type: "POST",
                url: "../Departamento.aspx/Editar",
                data: '{mNome:"' + nome + '",mId:"' + id + '"}',
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
                        <span><strong>Departamento alterado!!</strong></span>
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
                        <span><strong>Nome do deparatmento em branco</strong></span>
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
<div class="modal fade" id="mDepartamento" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content ">
                <div class="modal-header">
                    <button type="button" id="xfechar" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="text-center">
                        <h4 class="modal-title"><small>Departamento</small></h4>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Departamento</label>
                        <input class="form-control input-sm mreq" id="txtmNome" runat="server" type="text" clientidmode="static">
                    </div>
                    <div style="display: none;">
                        <input class="form-control input-sm mreq" id="txtId" runat="server" type="text" clientidmode="static">
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="cancelar" type="reset" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button id="btnSalvar" type="submit" class="btn btn-primary" onclick="EditDepartamento()">Salvar</button>
                </div>
            </div>
        </div>
    </div>
</div>

