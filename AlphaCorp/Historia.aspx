<%@ Page Title="" Language="C#" MasterPageFile="~/Evento.Master" AutoEventWireup="true" CodeBehind="Historia.aspx.cs" Inherits="AlphaCorp.Historia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="../bootstrap/sidenav.css" rel="stylesheet" />
    <script src="../Scripts/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../bootstrap/outros.css" rel="stylesheet" />
    <script src="../js/validator.min.js"></script>
    <link href="../bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../js/HtmlEvento.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-5">
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#Tudo">Tudo</a></li>
            <li><a data-toggle="tab" href="#Convites">Convites</a></li>
        </ul>
    </div>
    <div class="col-sm-9">
        <div class="tab-content">
            <div id="Tudo" class="tab-pane fade in active">
                <div  runat="server" clientidmode="static" class="row TudosEventos">
                    <%--<div class="col-sm-6">
                        <div class="thumbnail default ">
                            <div class="caption">
                                <div class="page-header page-header2">
                                    <a href="#">
                                        <label id="lblNomeEventoT">Nome do evento</label>
                                    </a>
                                </div>
                                <div class="row">
                                    <br />
                                    <div class="col-sm-10">
                                        <p>
                                            <label id="lblInicioT">16/10/2017 às 19:00</label>
                                        </p>
                                    </div>
                                    <div class="col-sm-10">
                                        <p>
                                            <label id="lblCriadorT">Criador do evento</label>
                                        </p>
                                    </div>
                                </div>
                                <p><a href="#" class="btn btn-primary" role="button">Button</a> <a href="#" class="btn btn-default" role="button">Button</a></p>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
            <div id="Convites" class="tab-pane fade">
                <div id="ConvitesEventos" runat="server" clientidmode="static" class="row">
                    <%--<div class="col-sm-6">
                        <div class="thumbnail">
                            <div class="caption">
                                <div class="page-header page-header2">
                                    <a href="#">
                                        <label id="lblNomeEventoC">Nome do evento</label>
                                    </a>
                                </div>
                                <div class="row">
                                    <br />
                                    <div class="col-sm-10">
                                        <p>
                                            <label id="lblInicioC">16/10/2017 às 19:00</label>
                                        </p>
                                    </div>
                                    <div class="col-sm-10">
                                        <p>
                                            <label id="lblCriadorC">Criador do evento</label>
                                        </p>
                                    </div>
                                </div>
                                <p><a href="#" class="btn btn-primary" role="button">Button</a> <a href="#" class="btn btn-default" role="button">Button</a></p>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>

</asp:Content>