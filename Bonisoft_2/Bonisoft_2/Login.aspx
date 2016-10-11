<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bonisoft_2.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->

    <!-- PAGE CSS -->
    <link rel="stylesheet" href="/assets/dist/css/Login_2.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->

    <!-- PAGE JS -->
    <script src="/assets/dist/js/Login_2.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box box-default">
        <div class="box-header with-border" style="padding-bottom: 0;">

            <div class="row">
                <div class="col-md-9">
                    <h2>Ingreso de usuarios al sistema</h2>
                </div>
            </div>

            <div class="sub-form">
            <div id="login">
                <h1>Introduzca sus datos</h1>
                  
                    <input type="text" id="txbUser1" runat="server" placeholder="Usuario" class="txbUser" />
                    <input type="password" id="txbPassword1" runat="server" placeholder="Contraseña" class="txbPassword" />

                    <button type="button" id="btnSubmit" class="submit" onclick="checkSubmit();">
                      <i class="fa fa-check"></i> Ingresar
                    </button>
                    <input type="submit" id="btnSubmit_candidato1" runat="server" onserverclick="btnSubmit_candidato1_ServerClick" 
                        style="display:none;" class="btnSubmit_candidato" />

                <div class="loginFormMessageContainer" style="box-sizing: inherit; width: 100%;">
				<div class="loginWaitingMessage" style="display:none">
					<div></div>
				</div>
				<div id="divMessages" class="alert alert-danger" role="alert" style="display:none;">
                    <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
                    <span class="sr-only">Error:</span>
                    <label id="lblMessages" style="font-weight: normal;"/>
                </div>
			</div>


            </div>
            </div>

        </div>
    </div>


</asp:Content>
