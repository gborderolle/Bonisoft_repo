$(document).ready(function () {
    bindEvents();

    // Seleccionar primer cliente
    var first = $("#gridClientes tbody tr").first();
    if (first != null) {
        first.click();
    }
});


function bindEvents() {
    $("#gridLogs").tablesorter();
}