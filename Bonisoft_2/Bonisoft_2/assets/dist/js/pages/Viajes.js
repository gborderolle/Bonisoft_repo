
$(document).ready(function () {
    $(".datepicker").datepicker();

    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridViajes = $("#gridViajes tbody tr").not(':first');
    var gridViajesEnCurso = $("#gridViajesEnCurso tbody tr").not(':first');
    $("#txbSearchViajesEnCurso").quicksearch(gridViajesEnCurso);
    $("#txbSearchViajes").quicksearch(gridViajes);
});
