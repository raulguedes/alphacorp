function dataFormatada(data) {
    debugger
    var date = new Date(parseInt(data.substr(6)));
    var dat = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
    return dat;
};
function CreateEventoTudo() {
    var html = '';
    $.ajax({
        url: '../Historia.aspx/BuscarTudo',
        datatype: 'json',
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
        data: "",
        success: function (evento) {
            var convite = 0;
            if (evento.d.length == 0) {
                html += '<div class="col-sm-5 col-md-5">';
                html += '<div class="thumbnail default ">';
                html += '<div class="caption">';
                html += '<div class="row">';
                html += '<br />';
                html += '<div class="col-sm-12">';
                html += '<p>';
                html += 'Nenhum evento encontrado';
                html += '</p>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                $('.TudosEventos').append(html);
                $('#ConvitesEventos').append(html);
            }
            else {
                $(evento.d).each(function () {
                    html += '<div class="col-sm-8 col-md-8">';
                    html += '<div class="thumbnail default ">';
                    html += '<div class="caption">';
                    html += '<div class="page-header page-header2">';
                    html += '<a href="../Evento.aspx?Id=' + this.IdEvento + '">';
                    html += '<label id="lblNomeEventoT" style="cursor: pointer;">' + this.Nome + '</label>';
                    html += '</a>';
                    html += '</div>';
                    html += '<div class="row">';
                    html += '<br />';
                    if (dataFormatada(this.DataInicio) != "1/1/1") {
                        html += '<div class="col-sm-12">';
                        html += '<p>';
                        if (this.HoraInicio != null) {
                            if (this.HoraInicio.Hours != "0" && this.HoraInicio.Minutes != "0") {
                                html += '<label id="lblInicioT"> Inicio: ' + dataFormatada(this.DataInicio) + " ás " + this.HoraInicio.Hours + " :" + " " + this.HoraInicio.Minutes + '</label>';
                            } else if (this.HoraInicio.Hours != "0" && this.HoraInicio.Minutes == "0") {
                                html += '<label id="lblInicioT">Inicio: ' + dataFormatada(this.DataInicio) + " ás " + this.HoraInicio.Hours + " h" + '</label>';
                            }
                        }
                        html += '</p>';
                        html += '</div>';
                    }
                    html += '<div class="col-sm-10">';
                    html += '<label id="lblCriadorT">' + "<small>Criador - </small><b>" + this.NomeCriador + '</b></label>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    $('.TudosEventos').append(html);
                    if (this.Confirmar == "3") {
                        convite++;
                        $('#ConvitesEventos').append(html);
                    }
                    html = '';
                });
                if (convite == 0) {
                    html += '<div class="col-sm-5 col-md-5">';
                    html += '<div class="thumbnail default ">';
                    html += '<div class="caption">';
                    html += '<div class="row">';
                    html += '<br />';
                    html += '<div class="col-sm-12">';
                    html += '<p>';
                    html += 'Nenhum evento encontrado';
                    html += '</p>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    $('#ConvitesEventos').append(html);
                }
            }
        },
        error: function (error) {
        }
    })
};