
$(document).ready(function () {
    load_quicksearch();

    show_tabla();
    show_dato();
});

function load_quicksearch() {
    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridCamiones = $("#gridCamiones tbody tr").not(':first');
    var gridChoferes = $("#gridChoferes tbody tr").not(':first');
    var gridClientes = $("#gridClientes tbody tr").not(':first');
    var gridCuadrillas = $("#gridCuadrillas tbody tr").not(':first');
    var gridProveedores = $("#gridProveedores tbody tr").not(':first');
    var gridInternos = $("#gridInternos tbody tr").not(':first');
    var gridFleteros = $("#gridFleteros tbody tr").not(':first');
    var gridCargadores = $("#gridCargadores tbody tr").not(':first');
    var gridProcesadores = $("#gridProcesadores tbody tr").not(':first');
    var gridFormas = $("#gridFormas tbody tr").not(':first');
    var gridTipos = $("#gridTipos tbody tr").not(':first');
    var gridVariedades = $("#gridVariedades tbody tr").not(':first');
    var gridEjes = $("#gridEjes tbody tr").not(':first');

    $("#txbSearch").quicksearch(gridCamiones);
    $("#txbSearch").quicksearch(gridChoferes);
    $("#txbSearch").quicksearch(gridClientes);
    $("#txbSearch").quicksearch(gridCuadrillas);
    $("#txbSearch").quicksearch(gridProveedores);
    $("#txbSearch").quicksearch(gridInternos);
    $("#txbSearch").quicksearch(gridFleteros);
    $("#txbSearch").quicksearch(gridCargadores);
    $("#txbSearch").quicksearch(gridProcesadores);
    $("#txbSearch").quicksearch(gridFormas);
    $("#txbSearch").quicksearch(gridTipos);
    $("#txbSearch").quicksearch(gridVariedades);
    $("#txbSearch").quicksearch(gridEjes);
}

function show_tabla() {
    if (QueryString !== null) {

        if (QueryString['tabla'] !== null && QueryString['tabla'] !== "") {
            var tabla = QueryString['tabla'];
            switch (tabla) {
                case "clientes": {
                    $("#divClientes").show();
                    break;
                }
                case "proveedores": {
                    $("#divProveedores").show();
                    break;
                }
                case "cuadrillas": {
                    $("#divCuadrillas").show();
                    break;
                }
                case "camiones": {
                    $("#divCamiones").show();
                    break;
                }
                case "choferes": {
                    $("#divChoferes").show();
                    break;
                }
                case "internos": {
                    $("#divInternos").show();
                    break;
                }
                case "fleteros": {
                    $("#divFleteros").show();
                    break;
                }
                case "cargadores": {
                    $("#divCargadores").show();
                    break;
                }
                case "procesadores": {
                    $("#divProcesadores").show();
                    break;
                }

                case "tipos": {
                    $("#divTipos").show();
                    break;
                }
                case "variedades": {
                    $("#divVariedades").show();
                    break;
                }
                case "formas": {
                    $("#divFormas").show();
                    break;
                }
                case "ejes": {
                    $("#divEjes").show();
                    break;
                }
            }
        }
    }
}

function show_dato() {
    if (QueryString !== null) {

        if (QueryString['dato'] !== null && QueryString['dato'] !== "") {
            var dato = QueryString['dato'];
            $("#txbSearch").val(dato);
            $("#txbSearch").trigger("keyup");
        }
    }
}

var QueryString = function () {
    // This function is anonymous, is executed immediately and 
    // the return value is assigned to QueryString!
    var query_string = {};
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        // If first entry with this name
        if (typeof query_string[pair[0]] === "undefined") {
            query_string[pair[0]] = decodeURIComponent(pair[1]);
            // If second entry with this name
        } else if (typeof query_string[pair[0]] === "string") {
            var arr = [query_string[pair[0]], decodeURIComponent(pair[1])];
            query_string[pair[0]] = arr;
            // If third or later entry with this name
        } else {
            query_string[pair[0]].push(decodeURIComponent(pair[1]));
        }
    }
    return query_string;
}();


