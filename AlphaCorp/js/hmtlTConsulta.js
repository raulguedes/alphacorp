function FormatarData(data) {
    var date = new Date(parseInt(data.substr(6)));
    var dat = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
    return dat;
};

function htmlAprovar(data) {
    var dat = data;
    $.ajax({
        url: '../Timesheet_Aprovar.aspx/Find',
        datatype: 'json',
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
        data: '{wData:"' + dat + '"}',
        success: function (timesheet) {
            var html = '';
            if (timesheet.d.length == 0) {
                html += '<div class="col-sm-5 col-md-5">';
                html += '<div class="thumbnail default ">';
                html += '<div class="caption">';
                html += '<div class="row">';
                html += '<br />';
                html += '<div class="col-sm-12">';
                html += '<p>';
                html += 'Nenhum timesheet cadastrado nesse dia';
                html += '</p>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                $('#Timesheets').append(html);
            }
            else {
                $(timesheet.d).each(function () {
                    html = '';
                    html += '<div class="col-sm-6 col-md-4">';
                    html += '<div class="thumbnail" style="box-shadow: inset 1px 1px 10px #000;">';
                    html += '<div style="padding: 5px;">';
                    html += '<div class="caption">';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<div class="input-group">';
                    html += '<div class="input-group-btn">';
                    html += '<a href="../Timesheet_Aprovar.aspx?Rejeitar=' + this.Id + '">';
                    html += '<button class="btn btn-default btn-sm" type="button" id="btnRejeitar"  title="Rejeitar">';
                    html += '<span class="glyphicon glyphicon-remove"></span>';
                    html += '</button>';
                    html += '</a>';
                    html += '</div>';
                    html += '<div class="page-header page-header2">';
                    html += '<div class="text-center">';
                    html += '<h3>';
                    if (this.Duracao.Hours != "0" && this.Duracao.Minutes != "0") {
                        html += '<label id="lblBDuracao">' + " " + this.Duracao.Hours + "h" + " " + this.Duracao.Minutes + "min" + '</label></h3>';
                    } else if (this.Duracao.Hours != "0" && this.Duracao.Minutes == "0") {
                        html += '<label id="lblBDuracao">' + " " + this.Duracao.Hours + "h" + '</label></h3>';
                    } else if (this.Duracao.Hours == "0" && this.Duracao.Minutes != "0") {
                        html += '<label id="lblBDuracao">' + " " + this.Duracao.Minutes + "min" + '</label></h3>';
                    }
                    html += '</div>';
                    html += '<div class="text-center">';
                    html += '<label id="lblBData"><small>' + FormatarData(this.Data) == '1/1/1' ? '' : FormatarData(this.Data); + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="input-group-btn">';
                    html += '<a href="../Timesheet_Aprovar.aspx?Aprovar=' + this.Id + '">';
                    html += '<button class="btn btn-default btn-sm" type="button" id="btnAprovar"   title="Aprovar">';
                    html += '<span class="glyphicon glyphicon-check"></span>';
                    html += '</button>';
                    html += '</a>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblFuncionario" class="col-sm-5 col-form-label">Funcionário: </label>';
                    html += '<div class="col-sm-7">';
                    html += '<label id="lblFuncionario" class="col-form-label" runat="server"><small>' + this.NomeFuncionario + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblCargo" class="col-sm-3 col-form-label">Cargo: </label>';
                    html += '<div class="col-sm-8">';
                    html += '<label id="lblCargo" class="col-form-label" runat="server"><small>' + this.NomeCargo + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblProjeto" class="col-sm-3 col-form-label">Projeto: </label>';
                    html += '<div class="col-sm-8">';
                    html += '<label id="lblProjeto" class="col-form-label" runat="server"><small>' + this.NomeProjeto + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblCliente" class="col-sm-3 col-form-label">Cliente: </label>';
                    html += '<div class="col-sm-8">';
                    html += '<label id="lblCliente" class="col-form-label" runat="server"><small>' + this.NomeCliente + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblDescricao" class="col-sm-4 col-form-label">Descrição: </label>';
                    html += '<div class="col-sm-8">';
                    html += '<label id="lblDescricao" class="col-form-label" runat="server"><small>' + this.Descricao + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblStatus" class="col-sm-4 col-form-label">Status: </label>';
                    html += '<div class="col-sm-5">';
                    html += ' <label id="lblStatus" class="col-form-label" runat="server"><small>' + this.NomeStatus + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    $('#Timesheets').append(html);
                });
            }
        },
        error: function (error) {
        }
    })
};

function htmlConsultar(data) {
    $.ajax({
        url: '../Timesheet_Consultar.aspx/Find',
        datatype: 'json',
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
        data: '{wData:"' + data + '"}',
        success: function (timesheet) {
            debugger
            var html = '';
            if (timesheet.d.length == 0) {
                html += '<div class="col-sm-5 col-md-5">';
                html += '<div class="thumbnail default ">';
                html += '<div class="caption">';
                html += '<div class="row">';
                html += '<br />';
                html += '<div class="col-sm-12">';
                html += '<p>';
                html += 'Nenhum timesheet cadastrado nesse dia';
                html += '</p>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                $('#Timesheets').append(html);
            } else {
                $(timesheet.d).each(function () {
                    debugger
                    html = '';
                    html += '<div class="col-sm-6 col-md-4">';
                    if (this.IdStatus == "1") {
                        html += '<div class="thumbnail" style="box-shadow: inset 1px 1px 10px #000;">';
                    }
                    else if (this.IdStatus == "2") {
                        html += '<div class="thumbnail" style="box-shadow: inset 1px 1px 10px #fefefe;background-color: #3c763d;">';
                    }
                    else if (this.IdStatus == "3") {
                        html += '<div class="thumbnail" style="box-shadow: inset 1px 1px 10px #fefefe;background-color: #6d0200;">';
                    }

                    html += '<div style="padding: 5px;">';
                    html += '<div class="caption" style="background-color:#fff;">';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<div class="input-group">';
                    html += '<div class="input-group-btn">';
                    html += '<a href="../Timesheet_Consultar.aspx?Excluir=' + this.Id + '&Status=' + this.IdStatus + '">';
                    html += '<button class="btn btn-default btn-sm" type="button" id="btnExcluir"  title="Excluir">';
                    html += '<span class="glyphicon glyphicon-remove"></span>';
                    html += '</button>';
                    html += '</a>'
                    html += '</div>';
                    html += '<div class="page-header page-header2">';
                    html += '<div class="text-center">';
                    html += '<h3>';
                    if (this.Duracao.Hours != "0" && this.Duracao.Minutes != "0") {
                        html += '<label id="lblBDuracao">' + " " + this.Duracao.Hours + "h" + " " + this.Duracao.Minutes + "min" + '</label></h3>';
                    } else if (this.Duracao.Hours != "0" && this.Duracao.Minutes == "0") {
                        html += '<label id="lblBDuracao">' + " " + this.Duracao.Hours + "h" + '</label></h3>';
                    } else if (this.Duracao.Hours == "0" && this.Duracao.Minutes != "0") {
                        html += '<label id="lblBDuracao">' + " " + this.Duracao.Minutes + "min" + '</label></h3>';
                    }
                    html += '</div>';
                    html += '<div class="text-center">';
                    html += '<label id="lblBData"><small>' + FormatarData(this.Data) == '1/1/1' ? '' : FormatarData(this.Data); + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="input-group-btn">';
                    html += '<a href="../Timesheet_Consultar.aspx?Editar=' + this.Id + '&Status=' + this.IdStatus + '">';
                    html += '<button class="btn btn-default btn-sm" type="button" id="btnEditar"   title="Editar">';
                    html += '<span class="glyphicon glyphicon-edit"></span>';
                    html += '</button>';
                    html += '</a>'
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblFuncionario" class="col-sm-5 col-form-label">Funcionário: </label>';
                    html += '<div class="col-sm-7">';
                    html += '<label id="lblFuncionario" class="col-form-label" runat="server"><small>' + this.NomeFuncionario + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    //html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    //html += '<label for="lblCargo" class="col-sm-3 col-form-label">Cargo: </label>';
                    //html += '<div class="col-sm-8">';
                    //html += '<label id="lblCargo" class="col-form-label" runat="server"><small>' + this.NomeCargo + '</small></label>';
                    //html += '</div>';
                    //html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblProjeto" class="col-sm-3 col-form-label">Projeto: </label>';
                    html += '<div class="col-sm-8">';
                    html += '<label id="lblProjeto" class="col-form-label" runat="server"><small>' + this.NomeProjeto + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblCliente" class="col-sm-3 col-form-label">Cliente: </label>';
                    html += '<div class="col-sm-8">';
                    html += '<label id="lblCliente" class="col-form-label" runat="server"><small>' + this.NomeCliente + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblDescricao" class="col-sm-4 col-form-label">Descrição: </label>';
                    html += '<div class="col-sm-8">';
                    html += '<label id="lblDescricao" class="col-form-label" runat="server"><small>' + this.Descricao + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">';
                    html += '<label for="lblStatus" class="col-sm-4 col-form-label">Status: </label>';
                    html += '<div class="col-sm-5">';
                    html += ' <label id="lblStatus" class="col-form-label" runat="server"><small>' + this.NomeStatus + '</small></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    $('#Timesheets').append(html);
                });
            }
        },
        error: function (error) {
        }
    })
};



