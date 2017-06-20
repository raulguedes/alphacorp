<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTimesheetFind.ascx.cs" Inherits="AlphaCorp.UserControl.ucTimesheetFind" %>
<script>
    $(function () {

        $('#btnFindTimesheet').click(function () {
            GerarHtml();
        });
    });

    function HtmlTimesheetConsulta(list) {

        var html = '';
        html += '<div class="col-sm-6 col-md-4">';
        html += '<div class="thumbnail" style="box-shadow: inset 1px 1px 10px #000;">';
        html += '<div style="padding: 5px;">';
        html += '<div class="caption">';
        html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
        html += '<div class="input-group">';
        html += '<div class="input-group-btn">';
        html += '<button class="btn btn-default btn-sm" type="button" id="btnExcluir" runat="server"  onserverclick="btnExcluir_ServerClick" title="Remover">';
        html += '<span class="glyphicon glyphicon-remove"></span>';
        html += '</button>';
        html += '</div>';
        html += '<div class="page-header page-header2">';
        html += '<div class="text-center">';
        html += '<h3>';
        html += '<label id="lblBDuracao">1h e 10 min</label></h3>';
        html += '</div>';
        html += '</div>';
        html += '<div class="input-group-btn">';
        html += '<button class="btn btn-default btn-sm" type="button" id="btnEditar" runat="server" onserverclick="Editar_Click" title="Editar">';
        html += '<span class="glyphicon glyphicon-edit"></span>';
        html += '</button>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
        html += '<label for="lblCliente" class="col-sm-3 col-form-label">Cliente: </label>';
        html += '<div class="col-sm-8">';
        html += '<label id="lblCliente" class="col-form-label" runat="server"><strong>Raul guedes</strong></label>';
        html += '</div>';
        html += '</div>';
        html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
        html += '<label for="lblProjeto" class="col-sm-3 col-form-label">Projeto: </label>';
        html += '<div class="col-sm-8">';
        html += '<label id="lblProjeto" class="col-form-label" runat="server"><strong>Timesheet versão1</strong></label>';
        html += '</div>';
        html += '</div>';
        html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
        html += '<label for="lblAtividade" class="col-sm-4 col-form-label">Atividade: </label>';
        html += '<div class="col-sm-8">';
        html += '<label id="lblAtividade" class="col-form-label" runat="server"><strong>Atividade executada</strong></label>';
        html += '</div>';
        html += '</div>';
        html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
        html += '<label for="lblDescricao" class="col-sm-4 col-form-label">Descrição: </label>';
        html += '<div class="col-sm-8">';
        html += '<label id="lblDescricao" class="col-form-label" runat="server"><strong>Apenas uma descrição do que ocorreu durante esse processo do caralho</strong></label>';
        html += '</div>';
        html += '</div>';
        html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
        html += '<label for="lblStatus" class="col-sm-3 col-form-label">Status: </label>';
        html += '<div class="col-sm-6">';
        html += '<label id="lblStatus" class="col-form-label" runat="server"><strong>Aprovado</strong></label>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        $('#Timesheets').append(html);
    }
</script>
