<%@ Page Title="" Language="C#" MasterPageFile="~/Evento.Master" AutoEventWireup="true" CodeBehind="Erro.aspx.cs" Inherits="AlphaCorp.Erro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/sidenav.css" rel="stylesheet" />
    <script src="Scripts/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="bootstrap/outros.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="thumbnail col-sm-9">
        <div class="caption">
            <div class="page-header">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="text-center">
                            <h1>
                                <label id="lblNomeEvento" runat="server"><strong>Evento não encontrado</strong></label>
                            </h1>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
