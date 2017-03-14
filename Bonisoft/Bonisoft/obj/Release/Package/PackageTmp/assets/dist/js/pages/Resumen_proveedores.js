/**** Local variables ****/
var upProveedores = '<%=upProveedores.ProveedorID%>';
var PAGO_ID_SELECTED;
var PROVEEDOR_ID_SELECTED;

$(document).ready(function () {

    bindEvents();

    // Seleccionar primer proveedor
    var first = $("#gridProveedores tbody tr").first();
    if (first != null) {
        first.click();
    }

    $("#gridProveedores tbody tr").css("cursor", "pointer");
});

// attach the event binding function to every partial update
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
    bindEvents();
    actualizarSaldos();
});

function loadInputDDL() {
    // Dropdownlist input
    $(".chzn-select").chosen();
    $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
}

function newOpcionDDL(tipo) {
    var valor = prompt("Ingrese el valor a agregar", "");
    if (valor !== null && valor !== "") {

        // Ajax call parameters
        console.log("Ajax call: Resumen_proveedores.aspx/AgregarOpcionDDL. Params:");
        console.log("tipo, type: " + type(tipo) + ", value: " + tipo);
        console.log("cliente, type: " + type(valor) + ", value: " + valor);

        // Check existen mercaderías
        $.ajax({
            type: "POST",
            url: "Resumen_proveedores.aspx/AgregarOpcionDDL",
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

    var hdn_proveedorID = $("#hdn_proveedorID");
    if (hdn_proveedorID !== null && hdn_proveedorID.val() !== null && hdn_proveedorID.val().length > 0) {
        var proveedorID_str = hdn_proveedorID.val();

        $.ajax({
            type: "POST",
            url: "Resumen_proveedores.aspx/Update_Saldos",
            data: '{proveedorID_str: "' + proveedorID_str + '"}',
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
                            lblSaldo_final.removeClass("label-danger");
                            lblSaldo_final.addClass("label-success");
                        } else {
                            lblSaldo_final.removeClass("label-success");
                            lblSaldo_final.addClass("label-danger");
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
        console.log("Ajax call: Resumen_proveedores.aspx/ModificarPago_1. Params:");
        console.log("pagoID_str, type: " + type(pagoID_str) + ", value: " + pagoID_str);

        $.ajax({
            type: "POST",
            url: "Resumen_proveedores.aspx/ModificarPago_1",
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

    var hdn_proveedorID = $("#hdn_proveedorID");
    if (hdn_proveedorID !== null && hdn_proveedorID.val() !== null && hdn_proveedorID.val().length > 0) {
        var proveedorID_str = hdn_proveedorID.val();

        if (PAGO_ID_SELECTED != null && PAGO_ID_SELECTED != "") {
            var pagoID_str = PAGO_ID_SELECTED;

            var txbFecha = $("#edit_txbFecha").val();
            var ddlFormas = $("#edit_ddlFormas").val();
            var txbMonto = $("#edit_txbMonto").val();
            var txbComentarios = $("#edit_txbComentarios").val();

            // Ajax call parameters
            console.log("Ajax call: Resumen_proveedores.aspx/ModificarPago_2. Params:");
            console.log("pagoID_str, type: " + type(pagoID_str) + ", value: " + pagoID_str);
            console.log("txbFecha, type: " + type(txbFecha) + ", value: " + txbFecha);
            console.log("ddlFormas, type: " + type(ddlFormas) + ", value: " + ddlFormas);
            console.log("txbMonto, type: " + type(txbMonto) + ", value: " + txbMonto);
            console.log("txbComentarios, type: " + type(txbComentarios) + ", value: " + txbComentarios);

            $.ajax({
                type: "POST",
                url: "Resumen_proveedores.aspx/ModificarPago_2",
                data: '{pagoID_str: "' + pagoID_str + '",fecha_str: "' + txbFecha + '",ddlFormas: "' + ddlFormas + '",monto_str: "' + txbMonto + '",comentarios_str: "' + txbComentarios + '"}',
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
                            var selected_row = $(".hiddencol").filter(':contains("' + proveedorID_str + '")');
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

    var hdn_proveedorID = $("#hdn_proveedorID");
    if (hdn_proveedorID !== null && hdn_proveedorID.val() !== null && hdn_proveedorID.val().length > 0) {
        var proveedorID_str = hdn_proveedorID.val();

        var txbFecha = $("#add_txbFecha").val();
        var ddlFormas = $("#add_ddlFormas").val();
        var txbMonto = $("#add_txbMonto").val();
        var txbComentarios = $("#add_txbComentarios").val();

        var monto = TryParseFloat(txbMonto, 0);
        if (monto > 0) {

            // Ajax call parameters
            console.log("Ajax call: Resumen_proveedores.aspx/IngresarPago. Params:");
            console.log("proveedorID_str, type: " + type(proveedorID_str) + ", value: " + proveedorID_str);
            console.log("txbFecha, type: " + type(txbFecha) + ", value: " + txbFecha);
            console.log("ddlFormas, type: " + type(ddlFormas) + ", value: " + ddlFormas);
            console.log("txbMonto, type: " + type(txbMonto) + ", value: " + txbMonto);
            console.log("txbComentarios, type: " + type(txbComentarios) + ", value: " + txbComentarios);

            $.ajax({
                type: "POST",
                url: "Resumen_proveedores.aspx/IngresarPago",
                data: '{proveedorID_str: "' + proveedorID_str + '",fecha_str: "' + txbFecha + '",ddlFormas: "' + ddlFormas + '",monto_str: "' + txbMonto + '",comentarios_str: "' + txbComentarios + '"}',
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
                            var selected_row = $(".hiddencol").filter(':contains("' + proveedorID_str + '")');
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
    $("#tabsProveedores").tabs();
    $("#gridProveedores").tablesorter();
    $("#gridViajes").tablesorter();
    $("#gridPagos").tablesorter();

    $("#gridPagos tr").click(function () {
        PAGO_ID_SELECTED = $(this).find(".hiddencol").html();
    });

    $("#gridProveedores tr").click(function () {
        PROVEEDOR_ID_SELECTED = $(this).find(".hiddencol").html();
        //$(this).css("background-color", "black");
        //$(this).find("td").css("background-color", "black");
    });


    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridProveedores = $("#gridProveedores tbody tr");
    $("#txbSearchProveedores").quicksearch(gridProveedores);

    var gridViajes = $("#gridViajes tbody tr");
    $("#txbSearchViajes").quicksearch(gridViajes);

    var gridPagos = $("#gridPagos tbody tr");
    $("#txbSearchPagos").quicksearch(gridPagos);

    $('#txbSearchProveedores').keydown(function () {
        var count = "# " + $('#gridProveedores tbody tr:visible').length;
        $("#lblgridProveedoresCount").text(count);
    });

    $('#txbSearchViajes').keydown(function () {
        var count = "# " + $('#gridViajes tbody tr:visible').length;
        $("#lblGridViajesCount").text(count);
    });

}

function BorrarPago(proveedorID) {

    if (proveedorID > 0) {
        var proveedorID_str = proveedorID.toString();

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
                            url: "Resumen_proveedores.aspx/BorrarPago",
                            data: '{pagoID_str: "' + pagoID_str + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                var ok = response.d;
                                if (ok) {
                                    show_message_info('OK_PagoBorrado');

                                    // Actualizar datos
                                    var selected_row = $(".hiddencol").filter(':contains("' + proveedorID_str + '")');
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

    var hdn_proveedorID = $("#hdn_proveedorID");
    if (hdn_proveedorID !== null && hdn_proveedorID.val() !== null && hdn_proveedorID.val().length > 0) {
        var proveedorID_str = hdn_proveedorID.val();

        // Ajax call parameters
        console.log("Ajax call: Resumen_proveedores.aspx/ViajeFicticio_1. Params:");
        console.log("proveedorID_str, type: " + type(proveedorID_str) + ", value: " + proveedorID_str);

        $.ajax({
            type: "POST",
            url: "Resumen_proveedores.aspx/ViajeFicticio_1",
            data: '{proveedorID_str: "' + proveedorID_str + '"}',
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

    var hdn_proveedorID = $("#hdn_proveedorID");
    if (hdn_proveedorID !== null && hdn_proveedorID.val() !== null && hdn_proveedorID.val().length > 0) {
        var proveedorID_str = hdn_proveedorID.val();

        var saldo = $("#modalAddFicticio_txbSaldo").val();
        var comentarios = $("#modalAddFicticio_txbComentarios").val();

        // Ajax call parameters
        console.log("Ajax call: Resumen_proveedores.aspx/ViajeFicticio_2. Params:");
        console.log("saldo, type: " + type(saldo) + ", value: " + saldo);
        console.log("comentarios, type: " + type(comentarios) + ", value: " + comentarios);
        console.log("proveedorID_str, type: " + type(proveedorID_str) + ", value: " + proveedorID_str);

        $.ajax({
            type: "POST",
            url: "Resumen_proveedores.aspx/ViajeFicticio_2",
            data: '{saldo_str: "' + saldo + '",comentarios: "' + comentarios + '",proveedorID_str: "' + proveedorID_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var ok = response.d;
                if (ok !== null && ok) {

                    show_message_info('OK_ViajeFicticio');
                    $.modal.close();

                    // Actualizar datos
                    var selected_row = $(".hiddencol").filter(':contains("' + proveedorID_str + '")');
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
