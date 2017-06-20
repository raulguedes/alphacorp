<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProjeto.ascx.cs" Inherits="AlphaCorp.modal.Projeto.ucProjeto" %>
<script type="text/javascript">
    function Retorno() {
        var url = window.location.href;
        location.href = url;
    };
    function esconderModal() {
        $('#mCriar').modal('hide');
        $('#mEditar').modal('hide');
    };
    $(document).ready(function () {

        $("#btnCancelarC").click(function (event) {
            esconderModal();
            $('#mNotifyP').modal('hide');
            $('#mErroP').modal('hide');
            removeClass();
            Retorno();
        });

        $("#btnCancelarE").click(function (event) {
            esconderModal();
            $('#mNotifyP').modal('hide');
            $('#mErroP').modal('hide');
            removeClass();
            Retorno();
        });

        $("#xfechar").click(function (event) {
            esconderModal();
            $('#mNotifyP').modal('hide');
            $('#mErroP').modal('hide');
            removeClass();
            Retorno();
        });

        $(".close").click(function (event) {
            esconderModal();
            $('#mNotifyP').modal('hide');
            $('#mErroP').modal('hide');
            removeClass();
            Retorno();
        });
        $(".fechar").click(function (event) {
            esconderModal();
            $('#mNotifyP').modal('hide');
            $('#mErroP').modal('hide');
            removeClass();
            Retorno();
        });
    });
    function append() {
        $('head').append('<link href="../bootstrap/bootstrap.min.css"  rel="stylesheet" class="modal" />');
        $('head').append('<script scr="../Scripts/jquery.js"  class="modal" />');
        $('head').append('<script scr="../js/bootstrap.min.js"  class="modal" />');
        $('head').append('<link href="../bootstrap/outros.css"  rel="stylesheet" class="modal" />');
    }
    function ShowEditar(id, projeto, idDepartamento, idCliente, IdStatus) {
        append();
        $('#mCriar').modal('hide');
        $("#mEditar").modal({ backdrop: 'static', keyboard: false, show: true });
        $('.mreq').prop('required', true);
        $('.mreqR').prop('required', false);
        $('.req').prop('required', false);
        $('#<%=txtmId.ClientID%>').val(id);
        $('#<%=txtmNome2.ClientID%>').val(projeto);
        $('#<%=ddlmCliente2.ClientID%>').val(idCliente);
        $('#<%=ddlmStatus.ClientID%>').val(IdStatus);
        $('#<%=ddlmDepartamento2.ClientID%>').val(idDepartamento);
    };
    function ShowCriar() {
        append();
        $('#mEditar').modal('hide');
        $("#mCriar").modal({ backdrop: 'static', keyboard: false, show: true });
        $('.mreq').prop('required', false);
        $('.mreqR').prop('required', true);
        $('.req').prop('required', false);
    };
    function ShowNotify() {
        esconderModal();
        removeClass();
        append();
        $('#mNotifyP').modal({ backdrop: 'static', keyboard: false, show: true });
    };
    function ShowErro() {
        esconderModal();
        removeClass();
        append();
        $('#mErroP').modal({ backdrop: 'static', keyboard: false, show: true });
    };

    function removeClass() {
        $('link[class="modal"]').remove();
        $('.mreq').prop('required', false);
        $('.mreqR').prop('required', false);
        $('.req').prop('required', true);
    };

    function CriarProjeto() {
        var nome = $('#<%=txtmNome.ClientID%>').val();
        var IdDepartamento = $('#<%=ddlmDepartamento.ClientID%>').val();
        var IdCliente = $('#<%=ddlmCliente.ClientID%>').val();
        if (nome != "" && IdDepartamento != "") {
            $.ajax({
                type: "POST",
                url: "../Projeto.aspx/Criar",
                data: '{mNome:"' + nome + '",mDepartamento:"' + IdDepartamento + '",mCliente:"' + IdCliente + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d == "")
                        ShowNotify();
                },
                failure: function () {
                    ShowErro();
                }
            });
        } else {
            ShowErro();
        }
        $('.mreq').prop('required', false);
        $('.mreqR').prop('required', false);
        $('.req').prop('required', true);
    };
    function EditarProjeto() {
        var Id = $('#<%=txtmId.ClientID%>').val();
        var nome = $('#<%=txtmNome2.ClientID%>').val();
        var IdDepartamento = $('#<%=ddlmDepartamento2.ClientID%>').val();
        var IdCliente = $('#<%=ddlmCliente2.ClientID%>').val();
        var IdStatus = $('#<%=ddlmStatus.ClientID%>').val();
        if (nome != "" && IdDepartamento != "" && Id != "") {
            $.ajax({
                type: "POST",
                url: "../Projeto.aspx/Editar",
                data: '{mNome:"' + nome + '",mId:"' + Id + '",mDepartamento:"' + IdDepartamento + '",mCliente:"' + IdCliente + '",mStatus:"' + IdStatus + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d == "")
                        ShowNotify();
                    else
                        Retorno();
                },
                failure: function () {
                    ShowErro();
                }
            });
        } else {
            ShowErro();
        }
        $('.mreq').prop('required', false);
        $('.mreqR').prop('required', false);
        $('.req').prop('required', true);
    };
</script>


<div class="modal fade" id="mNotifyP" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background-color: greenyellow; color: white;">
                    <button type="button" class="close" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="text-center">
                        <span><strong>Procedimento concluído.</strong></span>
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
<div class="modal fade" id="mErroP" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background-color: darkred; color: white;">
                    <button type="button" class="close" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="text-center">
                        <span><strong>
                            <asp:Label ID="lblmErro" ClientIDMode="Static" Text="Campo(s) em branco" runat="server" /></strong></span>
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


<div class="modal fade" id="mCriar" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content ">
                <div class="modal-header">
                    <button type="button" class="close" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="text-center">
                        <h4 class="modal-title">Projeto</h4>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Nome</label>
                        <input class="form-control input-sm mreqR" id="txtmNome" runat="server" type="text" clientidmode="static">
                    </div>
                    <div class="form-group">
                        <label>Departamento</label>
                        <asp:DropDownList ID="ddlmDepartamento" runat="server" ClientIDMode="Static" AppendDataBoundItems="true" class="form-control input-sm mreqR">
                            <asp:ListItem Text="Selecione.." Selected="True" Value="0" />
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Cliente</label>
                        <asp:DropDownList ID="ddlmCliente" runat="server" ClientIDMode="Static" AppendDataBoundItems="true" class="form-control input-sm ">
                            <asp:ListItem Text="Selecione.." Selected="True" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnCancelarC" type="reset" class="btn btn-secondary">Cancelar</button>
                    <button type="submit" class="btn btn-primary" onclick="CriarProjeto()">Criar</button>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" id="mEditar" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="container">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content ">
                <div class="modal-header">
                    <button type="button" id="xfechar" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="text-center">
                        <h4 class="modal-title">Editar projeto</h4>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Nome</label>
                        <input class="form-control input-sm mreq" id="txtmNome2" runat="server" type="text" clientidmode="static">
                    </div>
                    <div class="form-group">
                        <label>Departamento</label>
                        <asp:DropDownList ID="ddlmDepartamento2" runat="server" ClientIDMode="Static" AppendDataBoundItems="true" class="form-control input-sm mreq">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Cliente</label>
                        <asp:DropDownList ID="ddlmCliente2" runat="server" ClientIDMode="Static" AppendDataBoundItems="true" class="form-control input-sm mreq">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlmStatus" runat="server" ClientIDMode="Static" AppendDataBoundItems="true" class="form-control input-sm mreq">
                            <asp:ListItem Text="Em andamento" Value="1" />
                            <asp:ListItem Text="Concluído" Value="2" />
                            <asp:ListItem Text="Cancelado" Value="3" />
                        </asp:DropDownList>
                    </div>
                    <div style="display: none;">
                        <input class="form-control input-sm m" id="txtmId" runat="server" type="text" clientidmode="static">
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnCancelarE" type="reset" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button id="btnSalvar" type="submit" class="btn btn-primary" onclick="EditarProjeto()">Editar</button>
                </div>
            </div>
        </div>
    </div>
</div>
