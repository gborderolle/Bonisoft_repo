$(document).ready(function () {
    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridInternos = $("#gridInternos tbody tr").not(':first');
    var gridFormas = $("#gridFormas tbody tr").not(':first');
    var gridTipos = $("#gridTipos tbody tr").not(':first');
    var gridVariedades = $("#gridVariedades tbody tr").not(':first');
    var gridEjes = $("#gridEjes tbody tr").not(':first');
    $("#txbSearch").quicksearch(gridInternos);
    $("#txbSearch").quicksearch(gridFormas);
    $("#txbSearch").quicksearch(gridTipos);
    $("#txbSearch").quicksearch(gridEjes);
});

