
$(document).ready(function () {
    bindEvents();

});

function bindEvents() {
    $(".datepicker").datepicker();
    $("#tabsClientes").tabs();
    $("#gridClientes").tablesorter();

    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridClientes = $("#gridClientes tbody tr");
    $("#txbSearchClientes").quicksearch(gridClientes);

    var gridViajes = $("#gridViajes tbody tr");
    $("#txbSearchViajes").quicksearch(gridViajes);

    $('#txbSearchClientes').keydown(function () {
        var count = "Resultados: " + $('#gridClientes tr:visible').length;
        $("#lblGridClientesCount").text(count);
    });

    $('#txbSearchViajes').keydown(function () {
        var count = "Resultados: " + $('#gridViajes tr:visible').length;
        $("#lblGridViajesCount").text(count);
    });

    $('#gridClientes tbody tr').click(function () {
        
    });

}
