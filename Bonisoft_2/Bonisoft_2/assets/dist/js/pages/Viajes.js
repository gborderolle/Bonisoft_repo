
$(document).ready(function () {
    $(".datepicker").datepicker();

    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridViajes = $("#gridViajes tbody tr").not(':first');
    var gridViajesEnCurso = $("#gridViajesEnCurso tbody tr").not(':first');
    $("#txbSearchViajesEnCurso").quicksearch(gridViajesEnCurso);
    $("#txbSearchViajes").quicksearch(gridViajes);

});


function DoCustomPost() {

    var modalAdd_txbFecha1 = $("#modalAdd_txbFecha1").val();
    var modalAdd_txbFecha2 = $("#modalAdd_txbFecha2").val();
    var modalAdd_ddlProveedores = $("#modalAdd_ddlProveedores").val();
    var modalAdd_ddlClientes = $("#modalAdd_ddlClientes").val();
    var modalAdd_ddlEmpresaCarga = $("#modalAdd_ddlEmpresaCarga").val();
    var modalAdd_txbLugarCarga = $("#modalAdd_txbLugarCarga").val();
    var modalAdd_ddlFleteros = $("#modalAdd_ddlFleteros").val();
    var modalAdd_ddlCamiones = $("#modalAdd_ddlCamiones").val();
    var modalAdd_ddlChoferes = $("#modalAdd_ddlChoferes").val();
    var modalAdd_txbComentarios = $("#modalAdd_txbComentarios").val();

    $("#hdn_modalAdd_txbFecha1").val(modalAdd_txbFecha1);
    $("#hdn_modalAdd_txbFecha2").val(modalAdd_txbFecha2);
    $("#hdn_modalAdd_ddlProveedores").val(modalAdd_ddlProveedores);
    $("#hdn_modalAdd_ddlClientes").val(modalAdd_ddlClientes);
    $("#hdn_modalAdd_ddlEmpresaCarga").val(modalAdd_ddlEmpresaCarga);
    $("#hdn_modalAdd_txbLugarCarga").val(modalAdd_txbLugarCarga);
    $("#hdn_modalAdd_ddlFleteros").val(modalAdd_ddlFleteros);
    $("#hdn_modalAdd_ddlCamiones").val(modalAdd_ddlCamiones);
    $("#hdn_modalAdd_ddlChoferes").val(modalAdd_ddlChoferes);
    $("#hdn_modalAdd_txbComentarios").val(modalAdd_txbComentarios);
}

