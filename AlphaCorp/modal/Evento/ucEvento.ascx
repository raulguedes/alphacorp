<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEvento.ascx.cs" Inherits="AlphaCorp.modal.Evento.ucEvento" %>
<style>

</style>
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
                        <span><strong>Evento criado!!</strong></span>
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
        <div class="modal-dialog modal" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background-color: darkred">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="text-center">
                        <span><strong>Nome do evento em branco</strong></span>
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
<div class="modal fade" id="mEvento" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog" role="document">
            <div class="modal-content ">
                <div class="modal-header" style="border-bottom: 0px;">
                    <button type="button" id="xfechar" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="text-center">
                        <h4 class="modal-title"><small>Eventos</small></h4>
                    </div>
                    <ul class="nav nav-tabs">
                        <li onclick="mEventoO()"><a data-toggle="tab" href="#mOrganizar">Organizar</a></li>
                    </ul>
                </div>
                <div class="tab-content">
                    <div class="modal-body">
                        <div id="mOrganizar" class="tab-pane fade">
                            <div class="form-group">
                                <label for="txtmNome">Nome</label>
                                <input class="form-control input-sm mreq evento" id="txtmNome" runat="server" type="text" required="required" clientidmode="static">
                            </div>
                            <div class="form-group">
                                <label for="txtmDescricao">Descrição</label>
                                <textarea class="form-control input-sm evento" id="txtmDescricao" runat="server"></textarea>
                            </div>
                            <div class="form-group">
                                <label for="txtmLocal">Local</label>
                                <input class="form-control input-sm evento" id="txtmLocal" runat="server" type="text">
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-1">
                                    <label for="txtmInicioD">Inicio</label>
                                </div>
                                <div class="col-sm-4">
                                    <div class="input-group datepicker">
                                        <div class="input-group-addon add-on ">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </div>
                                        <input class="form-control input-sm mb-2 mr-sm-2 mb-sm-0 evento" id="txtmInicioD" runat="server" clientidmode="Static" data-format="dd/MM/yyyy" placeholder="DD/MM/YYYY" maxlength="10" data-mask="00/00/0000">
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <span class="glyphicon glyphicon-dashboard"></span>
                                        </div>
                                        <input class="form-control input-sm evento" id="txtmInicioH" clientidmode="Static" runat="server" type="time" placeholder="hh:mm">
                                    </div>
                                </div>
                                <div class="col-sm-3  btn-link" onclick="divTermino()">
                                    <span>
                                        <asp:Label ID="hora" Text="+ Termino" runat="server" ClientIDMode="Static" />
                                    </span>
                                </div>
                            </div>
                            <div id="Termino" class="form-group row" style="display: none;">
                                <div class="col-sm-1">
                                    <label for="txtmTerminoD">Fim</label>
                                </div>
                                <div class="col-sm-4">
                                    <div class="input-group datepicker">
                                        <div class="input-group-addon add-on ">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </div>
                                        <input class="form-control input-sm mb-2 mr-sm-2 mb-sm-0  evento" id="txtmTerminoD" runat="server" clientidmode="Static" data-format="dd/MM/yyyy" placeholder="DD/MM/YYYY" maxlength="10" data-mask="00/00/0000">
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <span class="glyphicon glyphicon-dashboard"></span>
                                        </div>
                                        <input class="form-control input-sm evento" id="txtmTerminoH" runat="server" type="time" clientidmode="Static" placeholder="hh:mm">
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row ">
                                <div class="col-sm-2">
                                    <label for="ddlPrivacidade">Privacidade</label>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlPrivacidade" runat="server" CssClass="form-control input-sm org evento">
                                        <asp:ListItem Value="0" Text="Evento publico" />
                                        <asp:ListItem Selected="True" Value="1" Text="Evento privado" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="cancelar" type="reset" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button id="btnCriar" type="button" class="btn btn-primary" onclick="mEventoPost()">Criar</button>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function Retorno() {
        var url = window.location.href;
        location.href = url;
    };
    $(document).ready(function () {

        $("#cancelar").click(function (event) {
            $('#mEvento').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });

        $("#xfechar").click(function (event) {
            $('#mEvento').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });

        $(".close").click(function (event) {
            $('#mEvento').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });
        $(".fechar").click(function (event) {
            $('#mEvento').modal('hide');
            $('link[class="modal"]').remove();
            Retorno();
        });

    });
    function append() {
        $('head').append('<link href="../bootstrap/bootstrap.min.css"  rel="stylesheet" class="modal" />');
        $('head').append('<script scr="../Scripts/jquery.js"  class="modal" />');
        $('head').append('<script scr="../js/bootstrap.min.js"  class="modal" />');
        $('head').append('<link href="../bootstrap/outros.css"  rel="stylesheet" class="modal" />');
        $('head').append('<link href="../bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" class="modal" />');
        $('head').append('<script src="../bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js" class="modal" />');
        $('head').append('<script src="../../js/HtmlEvento.js" class="modal" />');
    }
    function Show() {

        append();
        $('#mEvento').modal({ backdrop: 'static', keyboard: false, show: true });
        $(function () {
            $('.datepicker').datetimepicker({
                format: 'dd/MM/yyyy'
            });
        });
        $.ajax({
            type: "POST",
            url: "../Evento.aspx/Explorar",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    };
    function ShowNotify() {
        $('#mEvento').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        append();
        $('#mNotify').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function ShowErro() {
        $('#mEvento').modal('hide');
        $('link[class="modal"]').remove();
        $('script[class="modal"]').remove();
        append();
        $('#mErro').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function divTermino() {

        if (Termino.style.display == "none") {
            Termino.style.display = "block";
            document.getElementById('hora').innerHTML = "- Termino";
            document.getElementById('txtmTerminoD').value = "";
            document.getElementById('txtmTerminoH').value = "";
        }
        else {
            Termino.style.display = "none";
            document.getElementById('hora').innerHTML = "+ Termino";
            document.getElementById('txtmTerminoD').value = "";
            document.getElementById('txtmTerminoH').value = "";
        }
    };
    function mEventoO() {
        $(".req").prop('required', false);
        $(".extra").prop('required', false);
        $(".mreq").prop('required', true);
    };
    function mEventoPost() {
        var nome = $('#<%=txtmNome.ClientID%>');
        if (nome.val() != "") {
            var inputs = new Array();

            $('.evento').each(function () {
                inputs.push($(this).val());
            });
            $.ajax({
                type: "POST",
                url: "Evento.aspx/CriarEvento",
                data: JSON.stringify({ mEvento: inputs }),
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
