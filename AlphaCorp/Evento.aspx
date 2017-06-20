<%@ Page Title="" Language="C#" MasterPageFile="~/Evento.Master" AutoEventWireup="true" CodeBehind="Evento.aspx.cs" Inherits="AlphaCorp.Evento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/sidenav.css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="bootstrap/outros.css" rel="stylesheet" />
    <script src="js/validator.min.js"></script>
    <link href="bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divEvento" runat="server" visible="true">
        <div class="thumbnail col-sm-9">
            <div class="caption">
                <div class="page-header">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="text-center">
                                <h1>
                                    <label id="lblNomeEvento" runat="server"><strong>Nome do evento</strong></label>
                                </h1>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <small id="lblDetalhesDoEvento" runat="server">Evento privado - Evento criado por</small><b id="lblCriador" runat="server">Raul Guedes</b>
                        </div>
                    </div>
                </div>
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                    <div id="idEventoStatus" class="btn-group" role="group" runat="server" visible="false">
                        <div class="text-center">
                            <asp:DropDownList ID="ddlConvite" CssClass="form-control dropdown-toggle" runat="server">
                                <asp:ListItem Value="1" Text="Vou" />
                                <asp:ListItem Value="2" Text="Não vou" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div id="idEventoStatusVou" class="btn-group" role="group" runat="server" visible="false">
                        <button type="button" class="btn btn-primary">Vou</button>
                    </div>
                    <div id="idEventoStatusNaoVou" class="btn-group" role="group" runat="server" visible="false">
                        <button type="button" class="btn btn-danger">Não vou</button>
                    </div>
                    <div id="idEventoConvidar" runat="server" class="btn-group" role="group">
                        <button type="button" class="btn btn-default">Convidar</button>
                    </div>
                    <div id="idEventoMembros" runat="server" class="btn-group" role="group" visible="false">
                        <button type="button" class="btn btn-default">Membros</button>
                    </div>
                </div>
                <br />
                <div id="idEventoMembros2" runat="server" class="btn-group btn-group-justified" role="group" aria-label="...">
                    <div class="btn-group" role="group">
                        <button type="button" class="btn btn-default">Membros</button>
                    </div>
                </div>
                <hr />
                <div class="col-sm-8">
                    <div class="row">
                        <span>
                            <label id="lblHorario" runat="server"><strong>16 de outubro ás 16:00 - 00:00</strong></label>
                        </span>
                    </div>
                    <span>
                        <small id="lblSubHorario" runat="server">16/10 ás 16:00 até 11/10 00:00</small>
                    </span>
                </div>
            </div>
        </div>
        <div class="thumbnail col-sm-9">
            <div class="caption">
                <div class="col-sm-12">
                    <div class="row">
                        <div class="btn-group btn-group-justified" role="group" aria-label="...">
                            <div class="btn-group" role="group">
                                <button type="button" class="btn btn-primary"><span id="lblTodalVai" runat="server" class="badge">0</span> Vai</button>

                            </div>
                            <div class="btn-group" role="group">
                                <button type="button" class="btn btn-danger"><span id="lblTodalNaoVai" runat="server" class="badge">0</span> Não vai</button>
                            </div>
                            <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span id="lblTodalConvidados" runat="server" class="badge">0</span> Convidados</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="thumbnail col-sm-9">
            <div class="caption">
                <div class="page-header page-header2">
                    Local
                </div>
            </div>
            <div class="col-sm-8">
                <span>
                    <label id="lblLocal" runat="server" aria-multiline="true">Sem Detalhes</label>
                </span>
            </div>
        </div>
        <div class="thumbnail col-sm-9">
            <div class="caption">
                <div class="page-header page-header2">
                    Detalhes
                </div>
            </div>
            <div class="col-sm-12">
                <p>
                    <label id="lblDescricao" runat="server" aria-multiline="true">Sem Detalhes</label>
                </p>
            </div>
        </div>
    </div>
    <div id="divErro" runat="server" visible="true">
        <div class="thumbnail col-sm-9">
            <div class="caption">
                <div class="page-header">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="text-center">
                                <h1>
                                    <label id="lblErro" runat="server"><strong>Erro ao encontrar a pagina desse evento</strong></label>
                                </h1>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

