<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCargo.ascx.cs" Inherits="AlphaCorp.modal.Cargo.ucCargo" %>
<script type="text/javascript" class="modal2">
    function Retorno() {
        var url = window.location.href;
        location.href = url;
    };
    function RemoveModal() {
        $('#mCargoC').modal('hide');
        $('#mNotifyC').modal('hide');
        $('#mErroC').modal('hide');

    };
    $(document).ready(function () {

        $("#cancelar").click(function (event) {
            RemoveModal();
            $('link[class="modal"]').remove();
            $('script[class="modal"]').remove();
            $('script[class="modal2"]').remove();
            Retorno();
        });

        $("#xfechar").click(function (event) {
            RemoveModal();
            $('link[class="modal"]').remove();
            $('script[class="modal"]').remove();            
            Retorno();
        });

        $(".close").click(function (event) {
            RemoveModal();
            $('link[class="modal"]').remove();
            $('script[class="modal"]').remove();            
            Retorno();
        });
        $(".fechar").click(function (event) {
            RemoveModal();
            $('link[class="modal"]').remove();
            $('script[class="modal"]').remove();
            Retorno();
        });

    });
    function append() {
        $('head').append('<link href="../bootstrap/bootstrap.min.css"  rel="stylesheet" class="modal" />');
        $('head').append('<script scr="../Scripts/jquery.js"  class="modal" />');
        $('head').append('<script scr="../js/bootstrap.min.js"  class="modal" />');
        $('head').append('<link href="../bootstrap/outros.css"  rel="stylesheet" class="modal" />');
    }
    function Show(id, cargo, idDepartamento) {
        append();
        $("#mCargoC").modal({ backdrop: 'static', keyboard: false, show: true });
        document.getElementById("ddlDepartamento").value = idDepartamento;
        $('#<%=txtId.ClientID%>').val(id);
        $('#<%=txtmNome.ClientID%>').val(cargo);
    };
    function ShowNotify() {
        debugger
        $('#mCargoC').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        append();
        $('#mNotifyC').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function ShowErro() {
        $('#mCargoC').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        append();
        $('#mErroC').modal({ backdrop: 'static', keyboard: false, show: true });
    };


    function EditCargo() {
        try {
            var id = $('#<%=txtId.ClientID%>').val();
            var nome = $('#<%=txtmNome.ClientID%>').val();
            var IdDepartamento = $('#<%=ddlDepartamento.ClientID%>').val();
            if (nome != "" && id != "") {
                $.ajax({
                    type: "POST",
                    url: "../Cargo.aspx/Editar",
                    data: '{mNome:"' + nome + '",mId:"' + id + '",mDepartamento:"' + IdDepartamento + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d == "")
                            ShowNotify();
                    },
                    failure: function (err) {
                        ShowErro();
                    },
                    error: function (err) {
                        ShowErro();
                    },
                });
            } else {
                ShowErro();
            }
        } catch (err) {
            ShowErro();
        };
    }

</script>


<div class="modal fade" id="mNotifyC" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background-color: greenyellow">
                    <button type="button" class="close"  aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="text-center">
                        <span><strong>Cargo alterado!!</strong></span>
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
<div class="modal fade" id="mErroC" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background-color: darkred">
                    <button type="button" class="close" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div id="IdErro" class="text-center" style="display: none;">
                        <span><strong>
                            <asp:Label ID="lblmErro" Text="Campo(s) em branco" runat="server" ClientIDMode="Static" />
                        </strong></span>
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
<div class="modal fade" id="mCargoC" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content ">
                <div class="modal-header">
                    <button type="button" id="xfechar" class="close" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="text-center">
                        <h4 class="modal-title">Cargo</h4>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Departamento</label>
                        <asp:DropDownList ID="ddlDepartamento" runat="server" ClientIDMode="Static" class="form-control input-sm mreq">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Cargo</label>
                        <input class="form-control input-sm mreq" id="txtmNome" runat="server" type="text" clientidmode="static">
                    </div>
                    <div style="display: none;">
                        <input class="form-control input-sm mreq" id="txtId" runat="server" type="text" clientidmode="static">
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="cancelar" type="reset" class="btn btn-secondary">Cancelar</button>
                    <button id="btnSalvar" type="submit" class="btn btn-primary" onclick="EditCargo()">Salvar</button>
                </div>
            </div>
        </div>
    </div>
</div>
