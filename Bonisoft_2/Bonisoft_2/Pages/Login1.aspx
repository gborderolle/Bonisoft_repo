<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="Bonisoft_2.Pages.Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html lang="es-Es" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <title>Bonisoft</title>

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css" />
    <link rel="stylesheet" href="/assets/dist/css/jquery-ui.css" />
    <link rel="stylesheet" href="/assets/dist/css/font-awesome.css" />

    <!-- PAGE CSS -->
    <link rel="stylesheet" href="/assets/dist/css/pages/Login.css" />

</head>
<body>

    <!-- PAGE SCRIPTS -->
    <script type="text/javascript" src="/assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/assets/bootstrap/js/bootstrap.js"></script>

    <!-- PAGE JS -->
    <script type="text/javascript" src="/assets/dist/js/pages/Login.js"></script>

    <div class="box box-default">
        <div class="box-header with-border dark in" style="padding-bottom: 0; overflow-y: hidden; display: block;">

            <div class="row">
                <div class="col-md-9 modal-header" style="background: #2d3032; border-bottom: 1px solid #2a2c2e;">
                    <h2 style="color: #ccc;">Bienvenido a Bonisoft software!</h2>
                </div>
            </div>

            <div class="bg-black" style="">


                <%--https://www.youtube.com/watch?v=On0Tl31p4xg&index=2&list=PLdnPhmxxRm5nTz_DtKMIr8E0_LczfVcJ2--%>
                <div class="form-box">
                    <div class="header">

                        <form id="form1" runat="server">

                            <div class="body">
                                <div class="form-group">

                                    <div id="login1" class="form-group">
                                        Usuario:
                <input type="text" id="txbUser1" runat="server" placeholder="Usuario" class="txbUser form-control" style="padding: 25px;" />
                                        Contraseña:
                <input type="password" id="txbPassword1" runat="server" placeholder="Contraseña" class="txbPassword form-control" style="padding: 25px;" />

                                        <button type="button" id="btnSubmit" class="btn btn-primary submit" style="font-size: 140%; line-height: 1.1;" onclick="checkSubmit();">
                                            <i class="fa fa-check"></i>Ingresar
                                        </button>
                                        <input type="submit" id="btnSubmit_candidato1" runat="server" onserverclick="btnSubmit_candidato1_ServerClick"
                                            style="display: none;" class="btnSubmit_candidato" />

                                        <div class="loginFormMessageContainer" style="box-sizing: inherit; width: 100%;">
                                            <div class="loginWaitingMessage" style="display: none">
                                                <div></div>
                                            </div>
                                            <div id="divMessages" class="alert alert-danger" role="alert" style="display: none;">
                                                <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
                                                <span class="sr-only">Error:</span>
                                                <label id="lblMessages" style="font-weight: normal;" />
                                            </div>
                                        </div>


                                    </div>

                                </div>
                            </div>

                        </form>
                    </div>
                </div>



            </div>

        </div>
    </div>


</body>
</html>
