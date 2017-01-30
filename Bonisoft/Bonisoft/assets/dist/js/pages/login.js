$(document).ready(function () {
    $(".txbUser").focus();
});

function enterKey(e) {
    if (e.keyCode === 13) {
        $("#btnSubmit").click();
        
        //__doPostBack('<%=btnLoginCandidate.UniqueID%>', "");
    }
}

function validateLength(oSrc, args) {
    args.IsValid = (args.Value.length > 0);
}

function ShowErrorMessage(type, exception_message) {
    if (type === "1") {
        $('#lblMessages').text("Los campos son requeridos.");
    }
    else if (type === "2") {
        $('#lblMessages').text("Usuario y/o clave incorrecto.");
    }
    else if (type === "3") {
        $('#lblMessages').text("Error de conexi\u00F3n con la Base de Datos. \r\n" + exception_message);
    }
    $('#divMessages').show();
}

function checkSubmit() {
    var ok = false;
    var username = $(".txbUser").val();
    var password = $(".txbPassword").val();

    if (username === "" || password === "") {
        $('#lblMessages').text("Los campos son requeridos.");
        $('#divMessages').show();
    }
    else {
        // Loading spinner effect
        $("#btnSubmit i").removeClass("fa-check");
        $("#btnSubmit i").addClass("fa-spinner");

        $("#btnSubmit i").css("-webkit-animation", "fa-spin 2s infinite linear");
        $("#btnSubmit i").css("animation", "fa-spin 2s infinite linear");

        setTimeout(function () {
            //__doPostBack('<%=btnLoginCandidate.UniqueID%>', "");
            $(".btnSubmit_candidato").click();

            ok = true;
        }, 1800);
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

function doSubmit(){



}

