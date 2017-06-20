$(document).ready(function () {
    var divPai = $('#centro');
    var btnCriar = $('#criarLinha');

    btnCriar.click(function () {
        
        divPai.append(
            "<div class='row'> <div class='col-sm-12'><div class='panel panel-default text-left'><div class='panel-body'><p contenteditable='true'>CREATE</p><button type='button' id='criarLinha' class='btn btn-default btn-sm'><span class='glyphicon glyphicon-thumbs-up'></span>Criar linha</button></div></div></div></div>"
            );
    });

});