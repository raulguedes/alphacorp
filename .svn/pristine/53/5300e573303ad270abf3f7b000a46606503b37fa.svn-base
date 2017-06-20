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
                </div>
            </div>
            <div id="Convites" class="tab-pane fade">
                <div id="ConvitesEventos" runat="server" clientidmode="static" class="row">
                </div>
            </div>
        </div>
    </div>

</asp:Content>