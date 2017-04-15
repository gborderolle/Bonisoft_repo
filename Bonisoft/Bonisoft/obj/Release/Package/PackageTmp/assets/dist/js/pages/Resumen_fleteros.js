/**** Local variables ****/
var upFleteros = '<%=upFleteros.FleteroID%>';
var PAGO_ID_SELECTED;
var CLIENTE_ID_SELECTED;

$(document).ready(function () {
    bindEvents();

    // Seleccionar primer cliente
    var first = $("#gridClientes tbody tr").first();
    if (first != null) {
        first.click();
    }
});

// attach the event binding function to every partial update
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
    bindEvents();
    actualizarSaldos();
});

function loadDDLEvents() {
    $(".add_ddlFormas").val('').prop('disabled', true).trigger("liszt:updated");
    $("#addModal_rad_cliente").on('change', function () {
        if ($('input[name=add_rad_cliente]:checked').val() == "pago") {
            $(".add_ddlFormas").val('').prop('disabled', false).trigger("liszt:updated");
        } else {
            $(".add_ddlFormas").val('').prop('disabled', true).trigger("liszt:updated");
        }
    });

    $("#editModal_rad_cliente").on('change', function () {
        if ($('input[name=edit_rad_cliente]:checked').val() == "pago") {
            $(".edit_ddlFormas").val('').prop('disabled', false).trigger("liszt:updated");
        } else {
            $(".edit_ddlFormas").val('').prop('disabled', true).trigger("liszt:updated");
        }
    });
}

function loadInputDDL() {
    // Dropdownlist input
    $(".chzn-select").chosen();
    $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
}

function loadFilter_CurrentMonth() {
    var date = new Date();
    var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);

    $(".txbFiltro_saldos1").val(moment(firstDay).format("DD-MM-YYYY"));
    $(".txbFiltro_saldos2").val(moment(lastDay).format("DD-MM-YYYY"));
}

function newOpcionDDL(tipo) {
    var valor = prompt("Ingrese el valor a agregar", "");
    if (valor !== null && valor !== "") {

        // Ajax call parameters
        console.log("Ajax call: Resumen_fleteros.aspx/AgregarOpcionDDL. Params:");
        console.log("tipo, type: " + type(tipo) + ", value: " + tipo);
        console.log("cliente, type: " + type(valor) + ", value: " + valor);

        // Check existen mercaderías
        $.ajax({
            type: "POST",
            url: "Resumen_fleteros.aspx/AgregarOpcionDDL",
            data: '{tipo: "' + tipo + '",valor: "' + valor + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var resultado = response.d;

                if (resultado !== null && resultado !== "0") {
                    // Add option
                    var newOption = "<option value='" + resultado + "'>" + valor + " </option>";
                    switch (tipo) {
                        case "forma_pago": {
                            $("#add_ddlFormas").append(newOption);
                            $("#edit_ddlFormas").append(newOption);
                            break;
                        }
                    }
                    $(".chzn-select").trigger("liszt:updated");
                }

            }, // end success
            failure: function (response) {
            }
        }); // Ajax
    }
}

function addToday(tipo) {
    var date = moment(new Date()).format("DD-MM-YYYY");
    //var date = $.datepicker.formatDate('dd/mm/yy', new Date());
    switch (tipo) {
        case 1: {
            $("#add_txbFecha").val(date);
            break;
        }
        case 2: {
            $("#edit_txbFecha").val(date);
            break;
        }
    }
}

function actualizarSaldos() {

    var hdn_clientID = $("#hdn_clientID");
    if (hdn_clientID !== null && hdn_clientID.val() !== null && hdn_clientID.val().length > 0) {
        var clienteID_str = hdn_clientID.val();

        $.ajax({
            type: "POST",
            url: "Resumen_fleteros.aspx/Update_Saldos",
            data: '{clienteID_str: "' + clienteID_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var saldos = response.d;
                if (saldos !== null && saldos.length > 0) {

                    var saldos_array = saldos.split("|");
                    var saldo_inicial_str = saldos_array[0];
                    var saldo_final_str = saldos_array[1];

                    var lblSaldo_inicial = $("#lblSaldo_inicial");
                    if (lblSaldo_inicial !== null) {
                        lblSaldo_inicial.text(saldo_inicial_str);
                    }

                    var lblSaldo_final = $("#lblSaldo_final");
                    if (lblSaldo_final !== null) {
                        lblSaldo_final.text(saldo_final_str);

                        var saldo_final = TryParseFloat(saldo_final_str, 0);
                        if (saldo_final <= 0) {
                            lblSaldo_final.removeClass("label-success");
                            lblSaldo_final.addClass("label-danger");
                        } else {
                            lblSaldo_final.removeClass("label-danger");
                            lblSaldo_final.addClass("label-success");
                        }
                    }

                }
            }
        }); // Ajax
    }
}

function ModificarPago_1(pagoID) {

    if (pagoID > 0) {
        var pagoID_str = pagoID.toString();

        // Ajax call parameters
        console.log("Ajax call: Resumen_fleteros.aspx/ModificarPago_1. Params:");
        console.log("pagoID_str, type: " + type(pagoID_str) + ", value: " + pagoID_str);

        $.ajax({
            type: "POST",
            url: "Resumen_fleteros.aspx/ModificarPago_1",
            data: '{pagoID_str: "' + pagoID_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var datos = response.d;
                if (datos) {

                    var datos_array = datos.split("|");
                    var fecha_pago = datos_array[0];
                    var forma = datos_array[1];
                    var monto = datos_array[2];
                    var comentarios = datos_array[3];

                    //$("#edit_txbFecha").val(moment(fecha_pago, "DD-MM-YYYY").format("DD-MM-YYYY"));
                    $("#edit_txbFecha").val(fecha_pago);
                    $("#edit_ddlFormas").val(forma);
                    $("#edit_txbMonto").val(monto);
                    $("#edit_txbComentarios").val(comentarios);

                    $('#editPagoModal').modal('show');

                } else {
                    show_message_info('Error_Datos');
                }

            }, // end success
            failure: function (response) {
                show_message_info('Error_Datos');
            }
        }); // Ajax

    }
}

function ModificarPago_2() {

    var hdn_clientID = $("#hdn_clientID");
    if (hdn_clientID !== null && hdn_clientID.val() !== null && hdn_clientID.val().length > 0) {
        var clienteID_str = hdn_clientID.val();

        if (PAGO_ID_SELECTED != null && PAGO_ID_SELECTED != "") {
            var pagoID_str = PAGO_ID_SELECTED;

            var txbFecha = $("#edit_txbFecha").val();
            var ddlFormas = $("#edit_ddlFormas").val();
            var txbMonto = $("#edit_txbMonto").val();
            var txbComentarios = $("#edit_txbComentarios").val();

            var esPago = false;
            if ($('input[name=edit_rad_cliente]:checked').val() == "pago") {
                esPago = true;
            }

            // Ajax call parameters
            console.log("Ajax call: Resumen_fleteros.aspx/ModificarPago_2. Params:");
            console.log("pagoID_str, type: " + type(pagoID_str) + ", value: " + pagoID_str);
            console.log("txbFecha, type: " + type(txbFecha) + ", value: " + txbFecha);
            console.log("ddlFormas, type: " + type(ddlFormas) + ", value: " + ddlFormas);
            console.log("txbMonto, type: " + type(txbMonto) + ", value: " + txbMonto);
            console.log("txbComentarios, type: " + type(txbComentarios) + ", value: " + txbComentarios);
            console.log("esPago, type: " + type(esPago) + ", value: " + esPago);

            $.ajax({
                type: "POST",
                url: "Resumen_fleteros.aspx/ModificarPago_2",
                data: '{pagoID_str: "' + pagoID_str + '",fecha_str: "' + txbFecha + '",ddlFormas: "' + ddlFormas + '",monto_str: "' + txbMonto + '",comentarios_str: "' + txbComentarios + '",esPago: "' + esPago + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var ok = response.d;
                    if (ok !== null && ok) {

                        var lblSaldo_final = $("#lblSaldo_final");
                        if (lblSaldo_final !== null) {

                            var saldo_final_str = lblSaldo_final.text();
                            var saldo_final = TryParseFloat(saldo_final_str, 0);

                            var monto = TryParseFloat(txbMonto, 0);
                            saldo_final -= monto;

                            lblSaldo_final.text(saldo_final_str);

                            if (saldo_final <= 0) {
                                lblSaldo_final.removeClass("label-danger");
                                lblSaldo_final.addClass("label-success");
                            } else {
                                lblSaldo_final.removeClass("label-success");
                                lblSaldo_final.addClass("label-danger");
                            }

                            show_message_info('OK_Datos');
                            $.modal.close();

                            // Actualizar datos
                            var selected_row = $(".hiddencol").filter(':contains("' + clienteID_str + '")');
                            if (selected_row !== null) {
                                selected_row.click();
                            }
                        }

                    } else {
                        show_message_info('Error_Datos');
                    }

                }, // end success
                failure: function (response) {
                    show_message_info('Error_Datos');

                }
            }); // Ajax

        }
    }
}

function IngresarPago() {

    var hdn_clientID = $("#hdn_clientID");
    if (hdn_clientID !== null && hdn_clientID.val() !== null && hdn_clientID.val().length > 0) {
        var clienteID_str = hdn_clientID.val();

        var txbFecha = $("#add_txbFecha").val();
        var ddlFormas = $("#add_ddlFormas").val();
        var txbMonto = $("#add_txbMonto").val();
        var txbComentarios = $("#add_txbComentarios").val();

        var esPago = false;
        if ($('input[name=add_rad_cliente]:checked').val() == "pago") {
            esPago = true;
        }

        var monto = TryParseFloat(txbMonto, 0);
        if (monto > 0) {

            // Ajax call parameters
            console.log("Ajax call: Resumen_fleteros.aspx/IngresarPago. Params:");
            console.log("clienteID_str, type: " + type(clienteID_str) + ", value: " + clienteID_str);
            console.log("txbFecha, type: " + type(txbFecha) + ", value: " + txbFecha);
            console.log("ddlFormas, type: " + type(ddlFormas) + ", value: " + ddlFormas);
            console.log("txbMonto, type: " + type(txbMonto) + ", value: " + txbMonto);
            console.log("txbComentarios, type: " + type(txbComentarios) + ", value: " + txbComentarios);
            console.log("esPago, type: " + type(esPago) + ", value: " + esPago);

            $.ajax({
                type: "POST",
                url: "Resumen_fleteros.aspx/IngresarPago",
                data: '{clienteID_str: "' + clienteID_str + '",fecha_str: "' + txbFecha + '",ddlFormas: "' + ddlFormas + '",monto_str: "' + txbMonto + '",comentarios_str: "' + txbComentarios + '",esPago: "' + esPago + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var ok = response.d;
                    if (ok !== null && ok) {

                        var lblSaldo_final = $("#lblSaldo_final");
                        if (lblSaldo_final !== null) {

                            var saldo_final_str = lblSaldo_final.text();
                            var saldo_final = TryParseFloat(saldo_final_str, 0);

                            saldo_final -= monto;

                            lblSaldo_final.text(saldo_final_str);

                            if (saldo_final <= 0) {
                                lblSaldo_final.removeClass("label-danger");
                                lblSaldo_final.addClass("label-success");
                            } else {
                                lblSaldo_final.removeClass("label-success");
                                lblSaldo_final.addClass("label-danger");
                            }

                            show_message_info('OK_Datos');
                            $.modal.close();

                            // Actualizar datos
                            var selected_row = $(".hiddencol").filter(':contains("' + clienteID_str + '")');
                            if (selected_row !== null) {
                                selected_row.click();
                            }
                        }

                    } else {
                        show_message_info('Error_Datos');
                    }

                }, // end success
                failure: function (response) {
                    show_message_info('Error_Datos');

                }
            }); // Ajax

        } else {
            show_message_info('Error_DatosPagos');
        }

    }
}


function bindEvents() {
    $(".datepicker").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#tabsClientes").tabs();
    $("#gridClientes").tablesorter();
    $("#gridViajes").tablesorter();
    $("#gridViajesImprimir").tablesorter();
    $("#gridPagos").tablesorter();

    $("#gridPagos tr").click(function () {
        PAGO_ID_SELECTED = $(this).find(".hiddencol").html();
    });

    $("#gridClientes tr").click(function () {
        CLIENTE_ID_SELECTED = $(this).find(".hiddencol").html();
        //$(this).css("background-color", "black");
        //$(this).find("td").css("background-color", "black");
    });


    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridClientes = $("#gridClientes tbody tr");
    $("#txbSearchClientes").quicksearch(gridClientes);

    var gridViajes = $("#gridViajes tbody tr");
    $("#txbSearchViajes").quicksearch(gridViajes);

    var gridPagos = $("#gridPagos tbody tr");
    $("#txbSearchPagos").quicksearch(gridPagos);

    $('#txbSearchClientes').keydown(function () {
        var count = "# " + $('#gridClientes tbody tr:visible').length;
        $("#lblGridClientesCount").text(count);
    });

    $('#txbSearchViajes').keydown(function () {
        var count = "# " + $('#gridViajes tbody tr:visible').length;
        $("#lblGridViajesCount").text(count);
    });

}

function BorrarPago(clienteID) {

    if (clienteID > 0) {
        var clienteID_str = clienteID.toString();

        $('#dialog p').text(hashMessages['Confirmacion']);
        $("#dialog").dialog({
            open: {},
            resizable: false,
            height: 140,
            modal: true,
            buttons: {
                "Confirmar": function () {

                    if (PAGO_ID_SELECTED != null && PAGO_ID_SELECTED != "") {
                        var pagoID_str = PAGO_ID_SELECTED;

                        // Check existen mercaderías
                        $.ajax({
                            type: "POST",
                            url: "Resumen_fleteros.aspx/BorrarPago",
                            data: '{pagoID_str: "' + pagoID_str + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                var ok = response.d;
                                if (ok) {
                                    show_message_info('OK_PagoBorrado');

                                    // Actualizar datos
                                    var selected_row = $(".hiddencol").filter(':contains("' + clienteID_str + '")');
                                    if (selected_row !== null) {
                                        selected_row.click();
                                    }

                                } else {
                                    show_message_info('Error_Datos');
                                }

                            }, // end success
                            failure: function (response) {
                                show_message_info('Error_Datos');
                            }
                        }); // Ajax

                    }
                },
                "Cancelar": function () {
                    $(this).dialog("close");
                    return false;
                }
            }
        });
    }
}


function ViajeFicticio_1() {

    var hdn_clientID = $("#hdn_clientID");
    if (hdn_clientID !== null && hdn_clientID.val() !== null && hdn_clientID.val().length > 0) {
        var clienteID_str = hdn_clientID.val();

        // Ajax call parameters
        console.log("Ajax call: Resumen_fleteros.aspx/ViajeFicticio_1. Params:");
        console.log("clienteID_str, type: " + type(clienteID_str) + ", value: " + clienteID_str);

        $.ajax({
            type: "POST",
            url: "Resumen_fleteros.aspx/ViajeFicticio_1",
            data: '{clienteID_str: "' + clienteID_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var datos = response.d;
                if (datos) {

                    datos = datos.replace(/,/g, '.');

                    var datos_array = datos.split("|");
                    var saldo = datos_array[0];
                    var comentarios = datos_array[1];

                    $("#modalAddFicticio_txbSaldo").val(saldo);
                    $("#modalAddFicticio_txbComentarios").val(comentarios);

                    $('#addFicticioModal').modal('show');

                } else {
                    show_message_info('Error_Datos');
                }

            }, // end success
            failure: function (response) {
                show_message_info('Error_Datos');
            }
        }); // Ajax

    }
}

function ViajeFicticio_2() {

    var hdn_clientID = $("#hdn_clientID");
    if (hdn_clientID !== null && hdn_clientID.val() !== null && hdn_clientID.val().length > 0) {
        var clienteID_str = hdn_clientID.val();

        var saldo = $("#modalAddFicticio_txbSaldo").val();
        var comentarios = $("#modalAddFicticio_txbComentarios").val();

        // Ajax call parameters
        console.log("Ajax call: Resumen_fleteros.aspx/ViajeFicticio_2. Params:");
        console.log("saldo, type: " + type(saldo) + ", value: " + saldo);
        console.log("comentarios, type: " + type(comentarios) + ", value: " + comentarios);
        console.log("clienteID_str, type: " + type(clienteID_str) + ", value: " + clienteID_str);

        $.ajax({
            type: "POST",
            url: "Resumen_fleteros.aspx/ViajeFicticio_2",
            data: '{saldo_str: "' + saldo + '",comentarios: "' + comentarios + '",clienteID_str: "' + clienteID_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var ok = response.d;
                if (ok !== null && ok) {

                    show_message_info('OK_ViajeFicticio');
                    $.modal.close();

                    // Actualizar datos
                    var selected_row = $(".hiddencol").filter(':contains("' + clienteID_str + '")');
                    if (selected_row !== null) {
                        selected_row.click();
                    }

                } else {
                    show_message_info('Error_Datos');
                }

            }, // end success
            failure: function (response) {
                show_message_info('Error_Datos');

            }
        }); // Ajax
    }
}
