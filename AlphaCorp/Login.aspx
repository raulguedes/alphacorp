<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlphaCorp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TimeSheet</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="../bootstrap-switch/css/bootstrap-switch.css" rel="stylesheet" />
    <link href="../bootstrap/sidenav.css" rel="stylesheet" />
    <script src="../Scripts/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../bootstrap/outros.css" rel="stylesheet" />
    <script src="../js/validator.min.js"></script>
    <link href="../bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../bootstrap-switch/js/bootstrap-switch.js"></script>
    <link href="../bootstrap/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-login">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div id="login" style="display: block;">
                                        <h2>Acessar</h2>
                                        <div class="alert alert-error alert-danger" style="width: 100%; margin-left: 0%" id="AlertErro"
                                            visible="false" runat="server">
                                            <strong>
                                                <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
                                            </strong>
                                        </div>
                                        <div class="form-group">
                                            <input type="text" name="username" id="txtEmail" runat="server" tabindex="1" class="form-control L" placeholder="E-mail" value="" />
                                        </div>
                                        <div class="form-group">
                                            <input type="password" name="password" id="txtSenha" runat="server" tabindex="2" class="form-control L" placeholder="Senha" />
                                        </div>
                                        <div class="col-xs-6 form-group pull-right">
                                            <asp:Button ID="btnAcessar" runat="server" TabIndex="4" CssClass="form-control btn btn-login" OnClick="btnAcessar_Click" Text="Entrar" />
                                        </div>
                                    </div>
                                    <div id="register" style="display: none;">
                                        <h2>REGISTRAR</h2>
                                        <div class="form-group">
                                            <input type="text" name="Nome" id="txtrNome" tabindex="1" class="form-control R" placeholder="Nome da empresa" value="" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <input type="email" name="Email" id="txtrEmail" tabindex="1" class="form-control R" placeholder="Email coorporativo" value="" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <input type="password" name="Senha" id="txtrSenha" tabindex="2" class="form-control R" placeholder="Senha" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <input type="password" name="Confirmar senha" id="txtrConfirmar" tabindex="2" class="form-control R" placeholder="Confirmar senha" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-6 col-sm-offset-3">
                                                    <asp:Button ID="btnRegistrar" runat="server" TabIndex="4" CssClass="form-control btn btn-login" OnClick="btnRegistrar_Click" Text="Registrar agora" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-6 tabs">
                                    <a onclick="L()" href="#" class="active" id="login-form-link">
                                        <div class="login">Acessar</div>
                                    </a>
                                </div>
                                <div class="col-xs-6 tabs">
                                    <a onclick="R()" href="#" id="register-form-link">
                                        <div class="register">Registrar</div>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        function L() {
            register.style.display = "none";
            login.style.display = "block";
            $(".L").prop('required', true);
            $(".R").prop('required', false);
        }
        function R() {
            register.style.display = "block";
            login.style.display = "none";
            $(".L").prop('required', false);
            $(".R").prop('required', true);
        }
        $(function () {

            $('#login-form-link').click(function (e) {
                $("#login").delay(100).fadeIn(100);
                $("#register").fadeOut(100);
                $('#register-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });
            $('#register-form-link').click(function (e) {
                $("#register").delay(100).fadeIn(100);
                $("#login").fadeOut(100);
                $('#login-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });

        });

    </script>
</body>
</html>
