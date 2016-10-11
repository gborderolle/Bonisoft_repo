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