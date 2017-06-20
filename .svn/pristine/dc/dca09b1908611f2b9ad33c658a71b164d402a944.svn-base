<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Timesheet_Aprovar.aspx.cs" Inherits="AlphaCorp.Timesheet_Aprovar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="../bootstrap/sidenav.css" rel="stylesheet" />
    <link href="../bootstrap/outros.css" rel="stylesheet" />
    <script src="../Scripts/jquery-ui.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/validator.min.js"></script>
    <link href="../bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../js/jquery.maskedinput.js"></script>
    <script src="../js/hmtlTConsulta.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well well-sm">
        <ul class="nav nav-tabs">
            <li>
                <a href="../Timesheet.aspx" runat="server">
                    <div class="text-center">
                        <img src="../img/icon_timesheet.png" height="50" width="50" class="img-circle shadow " />
                        <br />
                        <p><span>Cadastrar</span></p>
                    </div>
                </a>
            </li>
            <li>
                <a href="../Timesheet_Consultar.aspx" runat="server">
                    <div class="text-center">
                        <img src="../img/LUPA-128.png" height="50" width="50" class="img-circle shadow " />
                        <br />
                        <p>Consultar</p>
                    </div>
                </a>
            </li>
            <li class="active" id="LiTimesheet_Aprovar" runat="server">
                <a data-toggle="tab" href="..#Aprovar" runat="server">
                    <div class="text-center">
                        <img src="../img/aprovar.png" height="50" width="50" class="img-circle shadow " />
                        <br />
                        <p>Aprovar</p>
                    </div>
                </a>
            </li>
        </ul>
    </div>
    <div class="tab-content">
        <div id="Aprovar" class="tab-pane fade in active" aria-expanded="true">
            <div class="thumbnail col-sm-12">
                <div class="caption">
                    <div class="page-header">
                        <h3>Aprovar timesheet</h3>
                    </div>
                    <div class="row">
                        <div class="col-sm-8">
                            <div class="form-group">
                                <div class="row">

                                    <div class="col-sm-7">
                                        <div class="input-group date">
                                            <input type="text" class="form-control " id="txtFindDataAprovar" clientidmode="Static" runat="server" placeholder="Data do timesheet">
                                            <div class="input-group-addon add-on btn btn-default" title="Mostrar calendário">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <button id="btnFindTimesheet" type="button" runat="server" onserverclick="btnFindTimesheet_ServerClick" class="form-control btn btn-primary btn-sm">Buscar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="Timesheets" class="row" runat="server" clientidmode="static">
                <%--  <div class="col-sm-6 col-md-4">
                    <div class="thumbnail" style="box-shadow: inset 1px 1px 10px #000;">
                        <div style="padding: 5px;">
                            <div class="caption">
                                <div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">
                                    <div class="input-group">
                                        <div class="input-group-btn">
                                            <button class="btn btn-default btn-sm" type="button" id="btnExcluir" runat="server" onserverclick="btnExcluir_ServerClick" title="Remover">
                                                <span class="glyphicon glyphicon-remove"></span>
                                            </button>
                                        </div>
                                        <div class="page-header page-header2">
                                            <div class="text-center">
                                                <h3>
                                                    <label id="lblBDuracao">1h e 10 min</label></h3>
                                            </div>
                                        </div>
                                        <div class="input-group-btn">
                                            <button class="btn btn-default btn-sm" type="button" id="btnEditar" runat="server" onserverclick="Editar_Click" title="Editar">
                                                <span class="glyphicon glyphicon-edit"></span>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">
                                    <label for="lblFuncionario" class="col-sm-5 col-form-label">Funcionário: </label>
                                    <div class="col-sm-7">
                                        <label id="lblFuncionario" class="col-form-label" runat="server"><strong>Raul guedes</strong></label>
                                    </div>
                                </div>
                                <div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">
                                    <label for="lblCargo" class="col-sm-3 col-form-label">Cargo: </label>
                                    <div class="col-sm-8">
                                        <label id="lblCargo" class="col-form-label" runat="server"><strong>Junior</strong></label>
                                    </div>
                                </div>
                                <div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">
                                    <label for="lblProjeto" class="col-sm-3 col-form-label">Projeto: </label>
                                    <div class="col-sm-8">
                                        <label id="lblProjeto" class="col-form-label" runat="server"><strong>Timesheet versão1</strong></label>
                                    </div>
                                </div>
                                <div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">
                                    <label for="lblCliente" class="col-sm-3 col-form-label">Cliente: </label>
                                    <div class="col-sm-8">
                                        <label id="lblCliente" class="col-form-label" runat="server"><strong>Raul guedes</strong></label>
                                    </div>
                                </div>
                                <div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">
                                    <label for="lblDescricao" class="col-sm-4 col-form-label">Descrição: </label>
                                    <div class="col-sm-8">
                                        <label id="lblDescricao" class="col-form-label" runat="server"><strong>Apenas uma descrição do que ocorreu durante esse processo do caralho</strong></label>
                                    </div>
                                </div>
                                <div class="form-group row" style="box-shadow: 1px 1px 10px #808080;">
                                    <div class="text-center">
                                        <label for="lblStatus" class="col-sm-5 col-form-label">Status: </label>
                                        <div class="col-sm-5">
                                            <label id="lblStatus" class="col-form-label" runat="server"><strong>Aprovado</strong></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            $('.date').datetimepicker({
                format: 'dd/MM/yyyy'
            });
        });
        $(document).ready(function () {
            $('.date').mask('dd/MM/yyyy');
        });
    </script>
</asp:Content>
