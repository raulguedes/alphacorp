<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Timesheet.aspx.cs" Inherits="AlphaCorp.Timesheet" MaintainScrollPositionOnPostback="true" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well well-sm">
        <ul class="nav nav-tabs">
            <li class="active">
                <a data-toggle="tab" href="../#Cadastrar" runat="server">
                    <div class="text-center">
                        <img src="../img/icon_timesheet.png" height="50" width="50" class="img-circle shadow" />
                        <br />
                        <p><span>Cadastrar</span></p>
                    </div>
                </a>
            </li>
            <li>
                <a href="../Timesheet_Consultar.aspx" runat="server">
                    <div class="text-center">
                        <img src="../img/LUPA-128.png" height="50" width="50" class="img-circle shadow" />
                        <br />
                        <p>Consultar</p>
                    </div>
                </a>
            </li>
            <li runat="server" id="LiTimesheet_Aprovar">
                <a href="../Timesheet_Aprovar.aspx" runat="server">
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
        <div id="Cadastrar" class="tab-pane fade in active" aria-expanded="true">
            <div class="col-lg-12">
                <div class="jumbotron">
                    <div id="time" class="row" style="display: block">
                        <div class="page-header">
                            <h3>Cadastrar timesheet</h3>
                        </div>
                        <div class="col-sm-5">
                            <div class="thumbnail" style="box-shadow: 1px 1px 10px #dadada;">
                                <div class="caption">
                                    <div class="form-group">
                                        <label for="txtData">Data</label>
                                        <div class="input-group datepicker">
                                            <div class="input-group-addon add-on">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </div>
                                            <input class="form-control input-sm  req" id="txtData" runat="server" required="required" data-format="dd/MM/yyyy" placeholder="DD/MM/YYYY" maxlength="10" data-mask="00/00/0000">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtDuracao">Duracao</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                <span class="glyphicon glyphicon-dashboard"></span>
                                            </div>
                                            <input class="form-control input-sm req" id="txtDuracao" runat="server" required="required" type="time" placeholder="hh:mm">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="ddlDepartamento">Departamento</label>
                                        <asp:DropDownList ID="ddlDepartamento" AutoPostBack="true" CssClass="form-control input-sm req" runat="server" required="required" ClientIDMode="Static" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                            <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="ddlProjeto">Projeto</label>
                                        <asp:DropDownList ID="ddlProjeto" CssClass="form-control input-sm req" runat="server" required="required" AppendDataBoundItems="true">
                                            <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="thumbnail left" style="box-shadow: inset 1px 1px 10px #dadada; max-height: 218px;">
                                <div class="caption">
                                    <div class="form-group">
                                        <label for="txtDescricao">Descrição</label>
                                        <asp:TextBox ID="txtDescricao" TextMode="MultiLine" CssClass="form-control req" Height="150px" runat="server" required="required" placeholder="Descrição"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="extra" class="row" style="display: none">
                        <div class="page-header">
                            <h3>Hora extra</h3>
                        </div>
                        <div class="col-sm-5">
                            <div class="thumbnail" style="box-shadow: 1px 1px 10px #dadada;">
                                <div class="caption">
                                    <div class="form-group">
                                        <label for="txtDuracao">Duracao</label>

                                        <div class="input-group ">
                                            <div class="input-group-addon">
                                                <span class="glyphicon glyphicon-dashboard"></span>
                                            </div>
                                            <input class="form-control input-sm extra" id="txtDuracaoExtra" runat="server" placeholder="HH/MM">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="thumbnail left" style="box-shadow: inset 1px 1px 10px #dadada; max-height: 218px;">
                                <div class="caption">
                                    <div class="form-group">
                                        <label for="txtDescricaoExtra">Descrição</label>
                                        <asp:TextBox ID="txtDescricaoExtra" TextMode="MultiLine" Height="150px" CssClass="form-control extra" runat="server" ClientIDMode="Static" placeholder="Descrição"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-footer">
                        <div class="form-group" style="margin-bottom: 0px">
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class=" col-sm-4 pull-left ">
                                            <div class="row">
                                                <ul class="pagination ">
                                                    <li onclick="P1()" id="1"><a>1</a></li>
                                                    <li onclick="P2()" id="2"><a>2</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class=" col-sm-8">
                                            <div class="row">
                                                <div class="btn-group pull-right " role="group">
                                                    <button type="reset" class="btn btn-danger ">Cancelar</button>
                                                    <asp:Button ID="btnSalvarTimesheet" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvarTimesheet_Click" CommandName="Salvar" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function P1() {
            time.style.display = "block";
            extra.style.display = "none";
            $(".extra").prop('required', false);
        }
        function P2() {
            extra.style.display = "block";
            time.style.display = "none";
            $(".extra").prop('required', true);
        }
        $(function () {
            $('.datepicker').datetimepicker({
                format: 'dd/MM/yyyy'
            });
        });
        $(document).ready(function () {
            $('.date').mask('dd/MM/yyyy');
        });
    </script>
    <script src="js/alphacorp.js"></script>
    <script src="js/hmtlTConsulta.js"></script>
</asp:Content>
