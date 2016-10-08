/**** Local variables ****/
var upClientes = '<%=upClientes.ClientID%>';
var PAGO_ID_SELECTED;

$(document).ready(function () {
    bindEvents();
});

// attach the event binding function to every partial update
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
    bindEvents();
    actualizarSaldos();
});

function actualizarSaldos() {

    var hdn_clientID = $("#hdn_clientID");
    if (hdn_clientID !== null && hdn_clientID.val() !== null && hdn_clientID.val().length > 0) {
        var clienteID_str = hdn_clientID.val();

        $.ajax({
            type: "POST",
            url: "Resumen_clientes.aspx/Update_Saldos",
            data: '{clienteID_str: "' + clienteID_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var saldos = response.d;
                if (saldos !== null && saldos.length > 0) {

                    var saldos_array = saldos.split("|");
                    var saldo_inicial = saldos_array[0];
                    var saldo_final = saldos_array[1];

                    var lblSaldo_inicial = $("#lblSaldo_inicial");
                    if (lblSaldo_inicial !== null) {
                        lblSaldo_inicial.text(saldo_inicial);
                    }

                    var lblSaldo_final = $("#lblSaldo_final");
                    if (lblSaldo_final !== null) {
                        lblSaldo_final.text(saldo_final);
                    }

                }
            }
        }); // Ajax
    }
}

function IngresarPago() {

    var hdn_clientID = $("#hdn_clientID");
    if (hdn_clientID !== null && hdn_clientID.val() !== null && hdn_clientID.val().length > 0) {
        var clienteID_str = hdn_clientID.val();

        var txbFecha = $("#txbFecha").val();
        var ddlFormas = $("#ddlFormas").val();
        var txbMonto = $("#txbMonto").val();
        var txbComentarios = $("#txbComentarios").val();
        
        var monto = TryParseFloat(txbMonto, 0);
        if (monto > 0) {

            // Ajax call parameters
            console.log("Ajax call: Viajes.aspx/GuardarPesadas. Params:");
            console.log("clienteID_str, type: " + type(clienteID_str) + ", value: " + clienteID_str);
            console.log("txbFecha, type: " + type(txbFecha) + ", value: " + txbFecha);
            console.log("ddlFormas, type: " + type(ddlFormas) + ", value: " + ddlFormas);
            console.log("txbMonto, type: " + type(txbMonto) + ", value: " + txbMonto);
            console.log("txbComentarios, type: " + type(txbComentarios) + ", value: " + txbComentarios);

            $.ajax({
                type: "POST",
                url: "Resumen_clientes.aspx/IngresarPago",
                data: '{clienteID_str: "' + clienteID_str + '",fecha_str: "' + txbFecha + '",ddlFormas: "' + ddlFormas + '",monto_str: "' + txbMonto + '",comentarios_str: "' + txbComentarios + '"}',
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

                            lblSaldo_final.text(saldo_final);

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
    $(".datepicker").datepicker();
    $("#tabsClientes").tabs();
    $("#gridClientes").tablesorter();
    $("#gridViajes").tablesorter();
    $("#gridPagos").tablesorter();

    $("#gridPagos tr").click(function () {
        PAGO_ID_SELECTED = $(this).find(".hiddencol").html();
    });

    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridClientes = $("#gridClientes tbody tr");
    $("#txbSearchClientes").quicksearch(gridClientes);

    var gridViajes = $("#gridViajes tbody tr");
    $("#txbSearchViajes").quicksearch(gridViajes);

    var gridPagos = $("#gridPagos tbody tr");
    $("#txbSearchPagos").quicksearch(gridPagos);

    $('#txbSearchClientes').keydown(function () {
        var count = "Resultados: " + $('#gridClientes tr:visible').length;
        $("#lblGridClientesCount").text(count);
    });

    $('#txbSearchViajes').keydown(function () {
        var count = "Resultados: " + $('#gridViajes tr:visible').length;
        $("#lblGridViajesCount").text(count);
    });

    $('#txbSearchPagos').keydown(function () {
        var count = "Resultados: " + $('#gridPagos tr:visible').length;
        $("#lblGridPagosCount").text(count);
    });


}


function BorrarPago() {

    var hdn_clientID = $("#hdn_clientID");
    if (hdn_clientID !== null && hdn_clientID.val() !== null && hdn_clientID.val().length > 0) {
        var clienteID_str = hdn_clientID.val();

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
                            url: "Resumen_clientes.aspx/BorrarPago",
                            data: '{pagoID_str: "' + pagoID_str + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                var ok = response.d;
                                if (ok) {
                                    show_message_info('OK_PagoBorrado');

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


