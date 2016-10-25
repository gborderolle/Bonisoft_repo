$(document).ready(function () {
    load_quicksearch();
    check_admin();
});

function load_quicksearch() {
    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridInternos = $("#gridInternos tbody tr");
    var gridFormas = $("#gridFormas tbody tr");
    var gridTipos = $("#gridTipos tbody tr");
    var gridVariedades = $("#gridVariedades tbody tr");
    var gridEjes = $("#gridEjes tbody tr");
    var gridUsuarios = $("#gridUsuarios tbody tr");

    $("#txbSearch").quicksearch(gridInternos);
    $("#txbSearch").quicksearch(gridFormas);
    $("#txbSearch").quicksearch(gridTipos);
    $("#txbSearch").quicksearch(gridVariedades);
    $("#txbSearch").quicksearch(gridEjes);
    $("#txbSearch").quicksearch(gridUsuarios);
}

function check_admin() {

    var userID = globalUserID;
    if (userID != null && userID != "") {

        // Ajax call parameters
        console.log("Ajax call: Datos_configuracion.aspx/CheckUserAdmin. Params:");
        console.log("userID, type: " + type(userID) + ", value: " + userID);

        // Check user is Admin
        $.ajax({
            type: "POST",
            url: "Datos_configuracion.aspx/CheckUserAdmin",
            data: '{userID_str: "' + userID + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var ok = response.d;
                if (ok) {
                    $("#row_admin").show();
                }

            }, // end success
            failure: function (response) {
                show_message_info('Error_Datos');

            }
        }); // Ajax
    }
}
