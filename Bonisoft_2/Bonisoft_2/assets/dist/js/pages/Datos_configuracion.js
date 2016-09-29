$(document).ready(function () {
    load_quicksearch();
});

function load_quicksearch() {
    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridInternos = $("#gridInternos tbody tr");
    var gridFormas = $("#gridFormas tbody tr");
    var gridTipos = $("#gridTipos tbody tr");
    var gridVariedades = $("#gridVariedades tbody tr");
    var gridEjes = $("#gridEjes tbody tr");
    $("#txbSearch").quicksearch(gridInternos);
    $("#txbSearch").quicksearch(gridFormas);
    $("#txbSearch").quicksearch(gridTipos);
    $("#txbSearch").quicksearch(gridEjes);
}
