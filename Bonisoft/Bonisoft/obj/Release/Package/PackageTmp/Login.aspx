<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bonisoft.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css" />

    <!-- PAGE CSS -->
    <link rel="stylesheet" href="/assets/dist/css/pages/Login.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->

    <!-- PAGE JS -->
    <script type="text/javascript" src="/assets/dist/js/pages/Login.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box box-default">
        <div class="box-header with-border dark in" style="padding-bottom: 0; overflow-y: hidden; display: block;">

            <div class="row">
                <div class="col-md-9 modal-header" style="background: #2d3032; border-bottom: 1px solid #2a2c2e;">
                    <h2 style="color: #ccc;">Bienvenido a Bonisoft software!</h2>
                </div>
            </div>

            <div class="login-container sub-form panel panel-default">
                <div id="login">

                    <div class="form-group">
                        Usuario:
                <input type="text" id="txbUser1" runat="server" placeholder="Usuario" class="txbUser form-control" style="padding: 25px;" />
                    </div>
                    <div class="form-group">
                        Contraseña:
                <input type="password" id="txbPassword1" runat="server" placeholder="Contraseña" class="txbPassword form-control" style="padding: 25px;" />
                    </div>

                    <button type="button" id="btnSubmit" class="btn btn-primary submit" style="font-size: 140%; line-height: 1.1;" onclick="checkSubmit();">
                        <i class="fa fa-check"></i>&nbsp;Ingresar
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
    </div>

</asp:Content>
