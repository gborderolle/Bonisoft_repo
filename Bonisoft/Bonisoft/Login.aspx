<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bonisoft.Login" MasterPageFile="~/Site.Master" %>

<asp:content id="ContentHeader" ContentPlaceHolderID="ContentHeader" runat="server">
    <link href="assets/css/login-styles.css" rel="stylesheet"/>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#wrapper").css("background-color", "#292929");

            // Initial focus
            $("input[id*='_txbUser']").focus();

        });


        function enterKey(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=btnLoginCandidate.UniqueID%>', "");
            }
        }

        function validateLength(oSrc, args) {
            args.IsValid = (args.Value.length > 0);
        }

        function ShowErrorMessage(type) {
            if (type == 1)
            {
                $('#lblMessages').text("Los campos son requeridos.");
            }
            else if (type == 2) {
                $('#lblMessages').text("Usuario y/o clave incorrecto.");
            }
            else if (type == 3) {
                $('#lblMessages').text("Error de conexión con la Base de Datos.");
            }
            $('#divMessages').show(); 
        }

        function checkEmptyValues() {
            var ok = false;
            var username = $("input[id*='txbUser']").val();
            var password = $("input[id*='txbPassword']").val();

            if (username == "" || password == "") {
                $('#lblMessages').text("Los campos son requeridos.");
                $('#divMessages').show();
            }
            else {
                // Loading spinner effect
                $("#btnIcon").removeClass("fa-check");
                $("#btnIcon").addClass("fa-spinner");

                $("#btnIcon").css("-webkit-animation", "fa-spin 2s infinite linear");
                $("#btnIcon").css("animation", "fa-spin 2s infinite linear");

                setTimeout(function () {
                    __doPostBack('<%=btnLoginCandidate.UniqueID%>', "");

                    ok = true;
                }, 2400);
                $('#divMessages').hide();
            }
            return ok;
        }

        function sleep(milliseconds) {
            var start = new Date().getTime();
            for (var i = 0; i < 1e7; i++) {
                if ((new Date().getTime() - start) > milliseconds) {
                    break;
                }
            }
        }

   </script>


    </asp:content>

<asp:content id="ContentBody" ContentPlaceHolderID="ContentBody" runat="server">
   <form id="form1" runat="server">

<div class="generalContainer col-md-12 col-xs-12">

<div class="loginTitleContainer" style=""></div>

	<div class="loginFormContainer">
		<div class="loginFormElements">

            <div class="loginTitleArea unselectable">
				<img class="loginTitleImage pull-left" src="assets/images/login_Titleimage.png"/>
				<div class="loginTitleBread">Bonisoft</div> 
				<div class="loginTitleText">Sistema de autenticación</div>
			</div>

			<div class="loginFormContent">

				<label class="loginFormLabel unselectable" style="float: left; width: auto; margin-left: 15px;">Usuario:</label>
                <asp:TextBox CssClass="form-control loginFormInput" placeholder="" runat="server" ID="txbUser" onkeypress="return enterKey(event)" CausesValidation="true"/>

				<label class="loginFormLabel unselectable" style="float: left; width: auto; margin-left: 15px;">Clave:</label>
                <asp:TextBox TextMode="password" CssClass="form-control loginFormInput" placeholder="" runat="server" ID="txbPassword" onkeypress="return enterKey(event)" CausesValidation="true"/>

			</div>
			<div class="loginFormButtonContainer" style="width: 100%;">
				<button id="submitButton" class="btn btn-default" type="button" runat="server" onclick="return checkEmptyValues();" onserverclick="submitButton_ServerClick" style="text-transform: none; letter-spacing: inherit;">
                     <span id="btnIcon" class="fa fa-check" aria-hidden="true"></span>
                    Iniciar sesión</button>
                <asp:Button ID="btnLoginCandidate" runat="server" style="display:none" Text="" OnClientClick="return checkEmptyValues();" OnClick="btnLoginCandidate_Click"/>
			</div>
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
       </form>
 </asp:content>