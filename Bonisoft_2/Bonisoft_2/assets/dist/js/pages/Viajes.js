/**** Local variables ****/

var upAdd = '<%=upAdd.ClientID%>';
var upGridViajesEnCurso = '<%=upGridViajesEnCurso.ClientID%>';

var VIAJE_EN_CURSO_ID_SELECTED;
var VIAJE_ID_SELECTED;

/**** Extras variables ****/

$(document).ready(function () {

    $('.popbox').popbox();

    bindEvents();

    //loadClickRemoveButton_event();

    (function ($, window, document) {
        var panelSelector = '[data-perform="panel-collapse"]';

        $(panelSelector).each(function () {
            var $this = $(this),
            parent = $this.closest('.panel'),
            wrapper = parent.find('.panel-wrapper'),
            collapseOpts = { toggle: false };

            if (!wrapper.length) {
                wrapper =
                parent.children('.panel-heading').nextAll()
                .wrapAll('<div/>')
                .parent()
                .addClass('panel-wrapper');
                collapseOpts = {};
            }
            wrapper
            .collapse(collapseOpts)
            .on('hide.bs.collapse', function () {
                $this.children('i').removeClass('fa-minus').addClass('fa-plus');
            })
            .on('show.bs.collapse', function () {
                $this.children('i').removeClass('fa-plus').addClass('fa-minus');
            });
        });
        $(document).on('click', panelSelector, function (e) {
            e.preventDefault();
            var parent = $(this).closest('.panel');
            var wrapper = parent.find('.panel-wrapper');
            wrapper.collapse('toggle');

            if ($(this).children('i').hasClass('fa-minus')) {
                $(this).children('i').removeClass('fa-minus').addClass('fa-plus');
            } else {
                $(this).children('i').removeClass('fa-plus').addClass('fa-minus');
            }
        });
    }(jQuery, window, document));


    (function ($, window, document) {
        var panelSelector = '[data-perform="panel-dismiss"]';
        $(document).on('click', panelSelector, function (e) {
            e.preventDefault();
            var parent = $(this).closest('.panel');
            removeElement();

            function removeElement() {
                var col = parent.parent();
                parent.remove();
                col.filter(function () {
                    var el = $(this);
                    return (el.is('[class*="col-"]') && el.children('*').length === 0);
                }).remove();
            }
        });
    }(jQuery, window, document));
});

// attach the event binding function to every partial update
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
    bindEvents();
});

function bindEvents() {
    $(".datepicker").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#tabsViajes").tabs();
    $("#tabsNotificaciones").tabs();
    $("#gridViajesEnCurso").tablesorter();
    $("#gridViajes").tablesorter();

    $("#gridViajesEnCurso tr").click(function () {
        VIAJE_EN_CURSO_ID_SELECTED = $(this).find(".hiddencol").html();
    });

    $("#gridViajes tr").click(function () {
        VIAJE_ID_SELECTED = $(this).find(".hiddencol").html();
    });

    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridViajes = $("#gridViajes tbody tr");
    var gridViajesEnCurso = $("#gridViajesEnCurso tbody tr");
    $("#txbSearchViajesEnCurso").quicksearch(gridViajesEnCurso);
    $("#txbSearchViajes").quicksearch(gridViajes);

    $('#txbSearchViajesEnCurso').keydown(function () {
        var count = "Resultados: " + $('#gridViajesEnCurso tr:visible').length;
        $("#lblGridViajesEnCursoCount").text(count);
    });

    $('#txbSearchViajes').keydown(function () {
        var count = "Resultados: " + $('#gridViajes tr:visible').length;
        $("#lblGridViajesCount").text(count);
    });
}

function copiarPesadas(isOrigen) {
    if (isOrigen === 1) {
        var txb_pesada2Lugar = $("#txb_pesada2Lugar").val();
        var txb_pesada2Fecha = $("#txb_pesada2Fecha").val();
        var txb_pesada2Peso_bruto = $("#txb_pesada2Peso_bruto").val();
        var txb_pesada2Peso_neto = $("#txb_pesada2Peso_neto").val();
        var txb_pesada2Nombre = $("#txb_pesada2Nombre").val();

        $("#txb_pesada1Lugar").val(txb_pesada2Lugar);
        $("#txb_pesada1Fecha").val(txb_pesada2Fecha);
        $("#txb_pesada1Peso_bruto").val(txb_pesada2Peso_bruto);
        $("#txb_pesada1Peso_neto").val(txb_pesada2Peso_neto);
        $("#txb_pesada1Nombre").val(txb_pesada2Nombre);

    } else {
        var txb_pesada1Lugar = $("#txb_pesada1Lugar").val();
        var txb_pesada1Fecha = $("#txb_pesada1Fecha").val();
        var txb_pesada1Peso_bruto = $("#txb_pesada1Peso_bruto").val();
        var txb_pesada1Peso_neto = $("#txb_pesada1Peso_neto").val();
        var txb_pesada1Nombre = $("#txb_pesada1Nombre").val();

        $("#txb_pesada2Lugar").val(txb_pesada1Lugar);
        $("#txb_pesada2Fecha").val(txb_pesada1Fecha);
        $("#txb_pesada2Peso_bruto").val(txb_pesada1Peso_bruto);
        $("#txb_pesada2Peso_neto").val(txb_pesada1Peso_neto);
        $("#txb_pesada2Nombre").val(txb_pesada1Nombre);
    }
}

function BorrarViajeEnCurso(viaje_ID) {

    $("#txbClave").val("");
    $("#txbClave").show();

    $('#dialog_borrarViaje p').text(hashMessages['Confirmacion']);
    $("#dialog_borrarViaje").dialog({
        open: {},
        resizable: false,
        height: 230,
        modal: true,
        buttons: {
            "Confirmar": function () {

                var userID = globalUserID;
                if (viaje_ID > 0 && userID != null && userID != "") {
                    var viajeID_str = viaje_ID.toString();

                    var txbClave = $("#txbClave").val();
                    if (txbClave != null && txbClave.length > 0) {

                    // Ajax call parameters
                        console.log("Ajax call: Viajes.aspx/BorrarViajeEnCurso. Params:");
                        console.log("viajeID_str, type: " + type(viajeID_str) + ", value: " + viajeID_str);
                        console.log("userID, type: " + type(userID) + ", value: " + userID);
                        console.log("txbClave, type: " + type(txbClave) + ", value: " + txbClave);
                    
                    // Check existen mercaderías
                    $.ajax({
                        type: "POST",
                        url: "Viajes.aspx/BorrarViajeEnCurso",
                        data: '{viajeID_str: "' + viajeID_str + '", userID: "' + userID + '", clave_str: "' + txbClave + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var resultado = response.d;
                            switch (resultado) {
                                case 0: {
                                    // Error interno
                                    show_message_info('Error_Datos');
                                    break;
                                }
                                case 1: {
                                    // OK
                                    show_message_info('OK_BorrarViaje');

                                    $(this).dialog("close");

                                    // Actualizar tabla
                                    $("#btnUpdateViajesEnCurso").click();

                                    break;
                                }
                                case 2: {
                                    // Error de clave
                                    show_message_info('Error_clave');
                                    break;
                                }
                                case 3: {
                                    // Error de usuario
                                    show_message_info('Error_usuario');
                                    break;
                                }
                            }

                            $("#txbClave").val("");

                        }, // end success
                        failure: function (response) {
                            show_message_info('Error_Datos');
                            $("#txbClave").val("");
                        }
                    }); // Ajax

                    } else {
                        show_message_info('IngresarClave');
                    }
                }
            },
            "Cancelar": function () {
                $(this).dialog("close");
                $("#txbClave").val("");

                return false;
            }
        }
    }); 
}

function guardarPesadas(isOrigen) {

    var ok_continue = false;
    var hdn_notificaciones_viajeID = $("#hdn_notificaciones_viajeID");
    if (hdn_notificaciones_viajeID !== null && hdn_notificaciones_viajeID.val() !== null && hdn_notificaciones_viajeID.val().length > 0) {
        var viajeID_str = hdn_notificaciones_viajeID.val();

        // Ajax call parameters
        console.log("Ajax call: Viajes.aspx/Check_Mercaderias. Params:");
        console.log("viajeID_str, type: " + type(viajeID_str) + ", value: " + viajeID_str);

        // Check existen mercaderías
        $.ajax({
            type: "POST",
            url: "Viajes.aspx/Check_Mercaderias",
            data: '{viajeID_str: "' + viajeID_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var ok = response.d;
                if (ok) {
                    var txb_pesadaLugar = $("#txb_pesada1Lugar").val();
                    var txb_pesadaFecha = $("#txb_pesada1Fecha").val();
                    var txb_pesadaPeso_bruto = $("#txb_pesada1Peso_bruto").val();
                    var txb_pesadaPeso_neto = $("#txb_pesada1Peso_neto").val();
                    var txb_pesadaNombre = $("#txb_pesada1Nombre").val();
                    var txb_pesadaComentarios = $("#txb_pesada1Comentarios").val();

                    var hdn_notificacionesPesadaID = "";

                    if (isOrigen === 1) {
                        txb_pesadaLugar = $("#txb_pesada1Lugar").val();
                        txb_pesadaFecha = $("#txb_pesada1Fecha").val();
                        txb_pesadaPeso_bruto = $("#txb_pesada1Peso_bruto").val();
                        txb_pesadaPeso_neto = $("#txb_pesada1Peso_neto").val();
                        txb_pesadaNombre = $("#txb_pesada1Nombre").val();
                        txb_pesadaComentarios = $("#txb_pesada1Comentarios").val();

                        hdn_notificacionesPesadaID = $("#hdn_notificacionesPesadaID");

                    } else {
                        txb_pesadaLugar = $("#txb_pesada2Lugar").val();
                        txb_pesadaFecha = $("#txb_pesada2Fecha").val();
                        txb_pesadaPeso_bruto = $("#txb_pesada2Peso_bruto").val();
                        txb_pesadaPeso_neto = $("#txb_pesada2Peso_neto").val();
                        txb_pesadaNombre = $("#txb_pesada2Nombre").val();
                        txb_pesadaComentarios = $("#txb_pesada2Comentarios").val();

                        hdn_notificacionesPesadaID = $("#hdn_notificacionesPesadaDestinoID");
                    }

                    if (hdn_notificacionesPesadaID !== null) {

                        var pesadaID_str = hdn_notificacionesPesadaID.val();

                        // Ajax call parameters
                        console.log("Ajax call: Viajes.aspx/GuardarPesadas. Params:");
                        console.log("viajeID_str, type: " + type(viajeID_str) + ", value: " + viajeID_str);
                        console.log("isOrigen, type: " + type(isOrigen) + ", value: " + isOrigen);
                        console.log("pesadaID_str, type: " + type(pesadaID_str) + ", value: " + pesadaID_str);
                        console.log("txb_pesadaLugar, type: " + type(txb_pesadaLugar) + ", value: " + txb_pesadaLugar);
                        console.log("txb_pesadaFecha, type: " + type(txb_pesadaFecha) + ", value: " + txb_pesadaFecha);
                        console.log("txb_pesadaPeso_bruto, type: " + type(txb_pesadaPeso_bruto) + ", value: " + txb_pesadaPeso_bruto);
                        console.log("txb_pesadaPeso_neto, type: " + type(txb_pesadaPeso_neto) + ", value: " + txb_pesadaPeso_neto);
                        console.log("txb_pesadaNombre, type: " + type(txb_pesadaNombre) + ", value: " + txb_pesadaNombre);
                        console.log("txb_pesadaComentarios, type: " + type(txb_pesadaComentarios) + ", value: " + txb_pesadaComentarios);

                        $.ajax({
                            type: "POST",
                            url: "Viajes.aspx/GuardarPesadas",
                            data: '{viajeID_str: "' + viajeID_str + '",isOrigen: "' + isOrigen + '",pesadaID_str: "' + pesadaID_str + '",txb_pesadaLugar_str: "' + txb_pesadaLugar + '",txb_pesadaFecha_str: "' + txb_pesadaFecha + '", ' +
                                'txb_pesadaPeso_bruto_str: "' + txb_pesadaPeso_bruto + '",txb_pesadaPeso_neto_str: "' + txb_pesadaPeso_neto + '",txb_pesadaNombre_str: "' + txb_pesadaNombre + '", txb_pesadaComentarios_str: "' + txb_pesadaComentarios + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                var resultado_1 = response.d;
                                var resultado_2 = resultado_1.split("|");
                                var ok = resultado_2[0];
                                var precio_compra_str = resultado_2[1];

                                if (precio_compra_str !== null) {
                                    var precio_compra = TryParseFloat(precio_compra_str, 0);
                                    if (precio_compra > 0) {
                                        var notif_lblPrecioCompra = $("label[id*='notif_lblPrecioCompra']");
                                        if (notif_lblPrecioCompra !== null) {
                                            notif_lblPrecioCompra.text(precio_compra);
                                        }
                                    }
                                }

                                if (ok === "True") {
                                    show_message_info('OK_Datos');
                                } else {
                                    show_message_info('Error_Datos');
                                }

                            }, // end success
                            failure: function (response) {
                                show_message_info('Error_Datos');

                            }
                        }); // Ajax
                    }

                } else {
                    show_message_info('Error_DatosMercaderias');
                }

            }, // end success
            failure: function (response) {
                show_message_info('Error_Datos');

            }
        }); // Ajax

    }
}



function guardarAmbasPesadas() {

    var ok_continue = false;
    var hdn_notificaciones_viajeID = $("#hdn_notificaciones_viajeID");
    if (hdn_notificaciones_viajeID !== null && hdn_notificaciones_viajeID.val() !== null && hdn_notificaciones_viajeID.val().length > 0) {
        var viajeID_str = hdn_notificaciones_viajeID.val();

        // Ajax call parameters
        console.log("Ajax call: Viajes.aspx/Check_Mercaderias. Params:");
        console.log("viajeID_str, type: " + type(viajeID_str) + ", value: " + viajeID_str);

        // Check existen mercaderías
        $.ajax({
            type: "POST",
            url: "Viajes.aspx/Check_Mercaderias",
            data: '{viajeID_str: "' + viajeID_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var ok = response.d;
                if (ok) {

                    // Origen
                    var txb_pesadaLugar1 = $("#txb_pesada1Lugar").val();
                    var txb_pesadaFecha1 = $("#txb_pesada1Fecha").val();
                    var txb_pesadaPeso_bruto1 = $("#txb_pesada1Peso_bruto").val();
                    var txb_pesadaPeso_neto1 = $("#txb_pesada1Peso_neto").val();
                    var txb_pesadaNombre1 = $("#txb_pesada1Nombre").val();

                    // Destino
                    var txb_pesadaLugar2 = $("#txb_pesada2Lugar").val();
                    var txb_pesadaFecha2 = $("#txb_pesada2Fecha").val();
                    var txb_pesadaPeso_bruto2 = $("#txb_pesada2Peso_bruto").val();
                    var txb_pesadaPeso_neto2 = $("#txb_pesada2Peso_neto").val();
                    var txb_pesadaNombre2 = $("#txb_pesada2Nombre").val();

                    var txb_pesadaComentarios = $("#txb_pesadaComentarios").val();

                        // Ajax call parameters
                        console.log("Ajax call: Viajes.aspx/GuardarPesadas. Params:");
                        console.log("viajeID_str, type: " + type(viajeID_str) + ", value: " + viajeID_str);
                        //console.log("isOrigen, type: " + type(isOrigen) + ", value: " + isOrigen);
                        //console.log("pesadaID_str, type: " + type(pesadaID_str) + ", value: " + pesadaID_str);

                        console.log("txb_pesadaLugar1, type: " + type(txb_pesadaLugar1) + ", value: " + txb_pesadaLugar1);
                        console.log("txb_pesadaFecha1, type: " + type(txb_pesadaFecha1) + ", value: " + txb_pesadaFecha1);
                        console.log("txb_pesadaPeso_bruto1, type: " + type(txb_pesadaPeso_bruto1) + ", value: " + txb_pesadaPeso_bruto1);
                        console.log("txb_pesadaPeso_neto1, type: " + type(txb_pesadaPeso_neto1) + ", value: " + txb_pesadaPeso_neto1);
                        console.log("txb_pesadaNombre1, type: " + type(txb_pesadaNombre1) + ", value: " + txb_pesadaNombre1);

                        console.log("txb_pesadaLugar2, type: " + type(txb_pesadaLugar2) + ", value: " + txb_pesadaLugar2);
                        console.log("txb_pesadaFecha2, type: " + type(txb_pesadaFecha2) + ", value: " + txb_pesadaFecha2);
                        console.log("txb_pesadaPeso_bruto2, type: " + type(txb_pesadaPeso_bruto2) + ", value: " + txb_pesadaPeso_bruto2);
                        console.log("txb_pesadaPeso_neto2, type: " + type(txb_pesadaPeso_neto2) + ", value: " + txb_pesadaPeso_neto2);
                        console.log("txb_pesadaNombre2, type: " + type(txb_pesadaNombre2) + ", value: " + txb_pesadaNombre2);

                        console.log("txb_pesadaComentarios, type: " + type(txb_pesadaComentarios) + ", value: " + txb_pesadaComentarios);

                        $.ajax({
                            type: "POST",
                            url: "Viajes.aspx/GuardarPesadas2",
                            data: '{viajeID_str: "' + viajeID_str + '",txb_pesadaLugar1: "' + txb_pesadaLugar1 + '",txb_pesadaFecha1: "' + txb_pesadaFecha1 + '", ' +
                                'txb_pesadaPeso_bruto1: "' + txb_pesadaPeso_bruto1 + '",txb_pesadaPeso_neto1: "' + txb_pesadaPeso_neto1 + '",txb_pesadaNombre1: "' + txb_pesadaNombre1 + '", ' +
                                'txb_pesadaLugar2: "' + txb_pesadaLugar2 + '",txb_pesadaFecha2: "' + txb_pesadaFecha2 + '", ' +
                                'txb_pesadaPeso_bruto2: "' + txb_pesadaPeso_bruto2 + '",txb_pesadaPeso_neto2: "' + txb_pesadaPeso_neto2 + '",txb_pesadaNombre2: "' + txb_pesadaNombre2 + '", txb_pesadaComentarios: "' + txb_pesadaComentarios + '"}',

                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                var resultado_1 = response.d;
                                var resultado_2 = resultado_1.split("|");
                                var ok = resultado_2[0];
                                var precio_compra_str = resultado_2[1];

                                if (precio_compra_str !== null) {
                                    var precio_compra = TryParseFloat(precio_compra_str, 0);
                                    if (precio_compra > 0) {
                                        var notif_lblPrecioCompra = $("label[id*='notif_lblPrecioCompra']");
                                        if (notif_lblPrecioCompra !== null) {
                                            notif_lblPrecioCompra.text(precio_compra);
                                        }
                                    }
                                }

                                if (ok === "True") {
                                    show_message_info('OK_Datos');
                                } else {
                                    show_message_info('Error_Datos');
                                }

                            }, // end success
                            failure: function (response) {
                                show_message_info('Error_Datos');

                            }
                        }); // Ajax

                } else {
                    show_message_info('Error_DatosMercaderias');
                }

            }, // end success
            failure: function (response) {
                show_message_info('Error_Datos');

            }
        }); // Ajax

    }
}


function NuevoViaje() {

    var fecha1 = $("#modalAdd_txbFecha1").val();
    var fecha2 = $("#modalAdd_txbFecha2").val();
    var proveedor = $("#modalAdd_ddlProveedores").val();
    var cliente = $("#modalAdd_ddlClientes").val();
    var cargador = $("#modalAdd_ddlCargadores").val();
    var lugar_carga = $("#modalAdd_txbLugarCarga").val();
    var fletero = $("#modalAdd_ddlFleteros").val();
    var camion = $("#modalAdd_ddlCamiones").val();
    var chofer = $("#modalAdd_ddlChoferes").val();
    var comentarios = $("#modalAdd_txbComentarios").val();

    // Ajax call parameters
    console.log("Ajax call: Viajes.aspx/NuevoViaje. Params:");
    console.log("fecha1, type: " + type(fecha1) + ", value: " + fecha1);
    console.log("fecha2, type: " + type(fecha2) + ", value: " + fecha2);
    console.log("proveedor, type: " + type(proveedor) + ", value: " + proveedor);
    console.log("cliente, type: " + type(cliente) + ", value: " + cliente);
    console.log("cargador, type: " + type(cargador) + ", value: " + cargador);
    console.log("lugar_carga, type: " + type(lugar_carga) + ", value: " + lugar_carga);
    console.log("fletero, type: " + type(fletero) + ", value: " + fletero);
    console.log("camion, type: " + type(camion) + ", value: " + camion);
    console.log("chofer, type: " + type(chofer) + ", value: " + chofer);
    console.log("comentarios, type: " + type(comentarios) + ", value: " + comentarios);

    $.ajax({
        type: "POST",
        url: "Viajes.aspx/NuevoViaje",
        data: '{fecha1: "' + fecha1 + '",fecha2: "' + fecha2 + '",proveedor: "' + proveedor +
            '",cliente: "' + cliente + '",cargador: "' + cargador + '",lugar_carga: "' + lugar_carga + '",fletero: "' + fletero +
            '",camion: "' + camion + '",chofer: "' + chofer + '",comentarios: "' + comentarios + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var ok = response.d;
            if (ok !== null && ok) {

                $('#dialog p').text(hashMessages['OK_ViajeNuevo']);
                $("#dialog").dialog({
                    open: {},
                    resizable: false,
                    height: 150,
                    modal: true,
                    buttons: {
                        "Aceptar": function () {
                            $("#btnUpdateViajesEnCurso").click();
                            $(this).dialog("close");
                            $.modal.close();
                            return true;
                        }
                    }
                });

            } else {
                show_message_info('Error_Datos');
            }

        }, // end success
        failure: function (response) {
            show_message_info('Error_Datos');

        }
    }); // Ajax

}

function DoCustomPost() {

    // Add Hdn Fields 
    var modalAdd_txbFecha1 = $("#modalAdd_txbFecha1").val();
    var modalAdd_txbFecha2 = $("#modalAdd_txbFecha2").val();
    var modalAdd_ddlProveedores = $("#modalAdd_ddlProveedores").val();
    var modalAdd_ddlClientes = $("#modalAdd_ddlClientes").val();
    var modalAdd_ddlCargadores = $("#modalAdd_ddlCargadores").val();
    var modalAdd_txbLugarCarga = $("#modalAdd_txbLugarCarga").val();
    var modalAdd_ddlFleteros = $("#modalAdd_ddlFleteros").val();
    var modalAdd_ddlCamiones = $("#modalAdd_ddlCamiones").val();
    var modalAdd_ddlChoferes = $("#modalAdd_ddlChoferes").val();
    var modalAdd_txbComentarios = $("#modalAdd_txbComentarios").val();

    $("#hdn_modalAdd_txbFecha1").val(modalAdd_txbFecha1);
    $("#hdn_modalAdd_txbFecha2").val(modalAdd_txbFecha2);
    $("#hdn_modalAdd_ddlProveedores").val(modalAdd_ddlProveedores);
    $("#hdn_modalAdd_ddlClientes").val(modalAdd_ddlClientes);
    $("#hdn_modalAdd_ddlCargadores").val(modalAdd_ddlCargadores);
    $("#hdn_modalAdd_txbLugarCarga").val(modalAdd_txbLugarCarga);
    $("#hdn_modalAdd_ddlFleteros").val(modalAdd_ddlFleteros);
    $("#hdn_modalAdd_ddlCamiones").val(modalAdd_ddlCamiones);
    $("#hdn_modalAdd_ddlChoferes").val(modalAdd_ddlChoferes);
    $("#hdn_modalAdd_txbComentarios").val(modalAdd_txbComentarios);

    // Edit Hdn Fields 
    var modalEdit_txbFecha1 = $("#modalEdit_txbFecha1").val();
    var modalEdit_txbFecha2 = $("#modalEdit_txbFecha2").val();
    var modalEdit_ddlProveedores = $("#modalEdit_ddlProveedores").val();
    var modalEdit_ddlClientes = $("#modalEdit_ddlClientes").val();
    var modalEdit_ddlCargadores = $("#modalEdit_ddlCargadores").val();
    var modalEdit_txbLugarCarga = $("#modalEdit_txbLugarCarga").val();
    var modalEdit_ddlFleteros = $("#modalEdit_ddlFleteros").val();
    var modalEdit_ddlCamiones = $("#modalEdit_ddlCamiones").val();
    var modalEdit_ddlChoferes = $("#modalEdit_ddlChoferes").val();
    var modalEdit_txbComentarios = $("#modalEdit_txbComentarios").val();

    $("#hdn_modalEdit_txbFecha1").val(modalEdit_txbFecha1);
    $("#hdn_modalEdit_txbFecha2").val(modalEdit_txbFecha2);
    $("#hdn_modalEdit_ddlProveedores").val(modalEdit_ddlProveedores);
    $("#hdn_modalEdit_ddlClientes").val(modalEdit_ddlClientes);
    $("#hdn_modalEdit_ddlCargadores").val(modalEdit_ddlCargadores);
    $("#hdn_modalEdit_txbLugarCarga").val(modalEdit_txbLugarCarga);
    $("#hdn_modalEdit_ddlFleteros").val(modalEdit_ddlFleteros);
    $("#hdn_modalEdit_ddlCamiones").val(modalEdit_ddlCamiones);
    $("#hdn_modalEdit_ddlChoferes").val(modalEdit_ddlChoferes);
    $("#hdn_modalEdit_txbComentarios").val(modalEdit_txbComentarios);
    
}

function DoPost_Pesadas() {

    // Hdn Fields - Pesada origen
    var txb_pesada1Lugar = $("#txb_pesada1Lugar").val();
    var txb_pesada1Fecha = $("#txb_pesada1Fecha").val();
    var txb_pesada1Peso_bruto = $("#txb_pesada1Peso_bruto").val();
    var txb_pesada1Peso_neto = $("#txb_pesada1Peso_neto").val();
    var txb_pesada1Nombre = $("#txb_pesada1Nombre").val();
    var txb_pesada1Comentarios = $("#txb_pesada1Comentarios").val();

    $("#hdn_modalNotificaciones_pesadas1_txbLugar").val(txb_pesada1Lugar);
    $("#hdn_modalNotificaciones_pesadas1_txbFecha").val(txb_pesada1Fecha);
    $("#hdn_modalNotificaciones_pesadas1_txbPesoBruto").val(txb_pesada1Peso_bruto);
    $("#hdn_modalNotificaciones_pesadas1_txbPesoNeto").val(txb_pesada1Peso_neto);
    $("#hdn_modalNotificaciones_pesadas1_txbNombre").val(txb_pesada1Nombre);
    $("#hdn_modalNotificaciones_pesadas1_txbComentarios").val(txb_pesada1Comentarios);

    // Hdn Fields - Pesada destino
    var txb_pesada2Lugar = $("#txb_pesada2Lugar").val();
    var txb_pesada2Fecha = $("#txb_pesada2Fecha").val();
    var txb_pesada2Peso_bruto = $("#txb_pesada2Peso_bruto").val();
    var txb_pesada2Peso_neto = $("#txb_pesada2Peso_neto").val();
    var txb_pesada2Nombre = $("#txb_pesada2Nombre").val();
    var txb_pesada2Comentarios = $("#txb_pesada2Comentarios").val();

    $("#hdn_modalNotificaciones_pesadas2_txbLugar").val(txb_pesada2Lugar);
    $("#hdn_modalNotificaciones_pesadas2_txbFecha").val(txb_pesada2Fecha);
    $("#hdn_modalNotificaciones_pesadas2_txbPesoBruto").val(txb_pesada2Peso_bruto);
    $("#hdn_modalNotificaciones_pesadas2_txbPesoNeto").val(txb_pesada2Peso_neto);
    $("#hdn_modalNotificaciones_pesadas2_txbNombre").val(txb_pesada2Nombre);
    $("#hdn_modalNotificaciones_pesadas2_txbComentarios").val(txb_pesada2Comentarios);

}

function guardarMercaderias() {

    // Hdn Fields - Pesada origen
    var mercaderias_txbNew4 = $("#mercaderias_txbNew4").val();
    var mercaderias_txbNew5 = $("#mercaderias_txbNew5").val();
    var mercaderias_txbNew7 = $("#mercaderias_txbNew7").val();
    var mercaderias_ddlVariedad2 = $("#mercaderias_ddlVariedad2").val();

    $("#hdn_modalMercaderia_txbNew4").val(mercaderias_txbNew4);
    $("#hdn_modalMercaderia_txbNew5").val(mercaderias_txbNew5);
    $("#hdn_modalMercaderia_txbNew7").val(mercaderias_txbNew7);
    $("#hdn_modalMercaderia_ddlVariedad2").val(mercaderias_ddlVariedad2);

}

function GetSelectedRow(lnk) {
    var mercaderias_txb4 = $("#mercaderias_txb4").val();
    var mercaderias_txb5 = $("#mercaderias_txb5").val();
    var mercaderias_txb6 = $("#mercaderias_txb6").val();
    var mercaderias_txb7 = $("#mercaderias_txb7").val();
    var mercaderias_ddlVariedad1 = $("#mercaderias_ddlVariedad1").val();
    var mercaderias_ddlProcesador1 = $("#mercaderias_ddlProcesador1").val();
    
    $("#hdn_modalMercaderia_txb4").val(mercaderias_txb4);
    $("#hdn_modalMercaderia_txb5").val(mercaderias_txb5);
    $("#hdn_modalMercaderia_txb6").val(mercaderias_txb6);
    $("#hdn_modalMercaderia_txb7").val(mercaderias_txb7);
    $("#hdn_modalMercaderia_ddlVariedad1").val(mercaderias_ddlVariedad1);
    $("#hdn_modalMercaderia_ddlProcesador1").val(mercaderias_ddlProcesador1);
}

function openNewWindows() {
    window.open("http://localhost:8083/Pages/Datos");
}

function showItems() {
    if (upAdd !== null) {
        //__doPostBack(upAdd, '');

        __doPostBack("<%=upAdd.UniqueID %>", "");
        //document.getElementById("<%=btnSubmit_upAdd.ClientID %>").click();
    }
}

function calcularPrecioVenta() {

    var ok_continue = false;

    var hdn_notificaciones_viajeID = $("#hdn_notificaciones_viajeID");
    if (hdn_notificaciones_viajeID !== null && hdn_notificaciones_viajeID.val() !== null && hdn_notificaciones_viajeID.val().length > 0) {

        var viajeID_str = hdn_notificaciones_viajeID.val();

        // Ajax call parameters
        console.log("Ajax call: Viajes.aspx/Check_Pesadas. Params:");
        console.log("viajeID_str, type: " + type(viajeID_str) + ", value: " + viajeID_str);
        
        // Check existen pesadas
        $.ajax({
            type: "POST",
            url: "Viajes.aspx/Check_Pesadas",
            data: '{viajeID_str: "' + viajeID_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var ok = response.d;
                if (ok) {

                    var notif_lblPrecioCompra = $("label[id*='notif_lblPrecioCompra']");
                    var notif_txbPrecioFlete = $("#notif_txbPrecioFlete");
                    var notif_txbPrecioDescarga = $("#notif_txbPrecioDescarga");
                    var notif_txbGananciaXTon = $("#notif_txbGananciaXTon");
                    var notif_txbIVA = $("#notif_txbIVA");
                    var notif_lblPrecioVenta = $("label[id*='notif_lblPrecioVenta']");

                    var txb_pesada1Peso_neto = $("#txb_pesada1Peso_neto");
                    var txb_pesada2Peso_neto = $("#txb_pesada2Peso_neto");

                    if (notif_lblPrecioCompra !== null && notif_lblPrecioCompra.text() !== null && notif_lblPrecioCompra.text().length > 0 &&
                    notif_txbPrecioFlete !== null && notif_txbPrecioFlete.val() !== null && notif_txbPrecioFlete.val().length > 0 &&
                    notif_txbPrecioDescarga !== null && notif_txbPrecioDescarga.val() !== null && notif_txbPrecioDescarga.val().length > 0 &&
                    notif_txbGananciaXTon !== null && notif_txbGananciaXTon.val() !== null && notif_txbGananciaXTon.val().length > 0 &&
                    notif_txbIVA !== null && notif_txbGananciaXTon.val() !== null && notif_txbIVA.val().length > 0 &&
                    txb_pesada1Peso_neto !== null && txb_pesada2Peso_neto !== null && 
                    notif_lblPrecioVenta !== null) {

                        var precioCompra_str = notif_lblPrecioCompra.text();
                        var precioFlete_str = notif_txbPrecioFlete.val();
                        var precioDescarga_str = notif_txbPrecioDescarga.val();
                        var gananciaXTon_str = notif_txbGananciaXTon.val();
                        var IVA_str = notif_txbIVA.val();

                        var peso_neto_origen_str = txb_pesada1Peso_neto.val();
                        var peso_neto_destino_str = txb_pesada2Peso_neto.val();

                        var precioCompra = TryParseFloat(precioCompra_str, 0);
                        var precioFlete = TryParseFloat(precioFlete_str, 0);
                        var precioDescarga = TryParseFloat(precioDescarga_str, 0);
                        var gananciaXTon = TryParseFloat(gananciaXTon_str, 0);
                        var IVA = TryParseInt(IVA_str, 0);

                        var peso_neto_origen = TryParseFloat(peso_neto_origen_str, 0);
                        var peso_neto_destino = TryParseFloat(peso_neto_destino_str, 0);

                        if (peso_neto_destino === 0) {
                            peso_neto_destino = peso_neto_origen;
                        }
                        if (peso_neto_destino !== 0) {
                            var ganancia_final = gananciaXTon * peso_neto_destino;
                            var precio_venta = precioCompra + precioFlete + precioDescarga + ganancia_final;

                            if (IVA > 0) {
                                var IVA_solo = precio_venta * IVA / 100;
                                precio_venta = precio_venta + IVA_solo;
                            }

                            if (precio_venta > 0) {
                                notif_lblPrecioVenta.text(precio_venta);
                            }
                        } else {
                            show_message_info('Error_DatosPesadas');
                        }
                        
                    }
                    else {
                        show_message_info('Error_DatosPrecioVenta');
                    }

                } else {
                    show_message_info('Error_DatosPesadas');
                }

            }, // end success
            failure: function (response) {
                show_message_info('Error_Datos');

            }
        });

    }
}

function ModificarViaje_1(viajeID) {

    if (viajeID > 0) {
        var viajeID_str = viajeID.toString();

        var hdn_editViaje_viajeID = $("#hdn_editViaje_viajeID");
        if (hdn_editViaje_viajeID !== null) {
            hdn_editViaje_viajeID.val(viajeID_str);

            // Ajax call parameters
            console.log("Ajax call: Viajes.aspx/ModificarViaje_1. Params:");
            console.log("viajeID_str, type: " + type(viajeID_str) + ", value: " + viajeID_str);

            $.ajax({
                type: "POST",
                url: "Viajes.aspx/ModificarViaje_1",
                data: '{viajeID_str: "' + viajeID_str + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var datos = response.d;
                    if (datos) {

                        var datos_array = datos.split("|");
                        var fecha1 = datos_array[0];
                        var fecha2 = datos_array[1];
                        var proveedor = datos_array[2];
                        var cliente = datos_array[3];
                        var cargador = datos_array[4];
                        var lugar_carga = datos_array[5];
                        var fletero = datos_array[6];
                        var camion = datos_array[7];
                        var chofer = datos_array[8];
                        var comentarios = datos_array[9];

                        //$("#modalEdit_txbFecha1").val(moment(fecha1, "DD-MM-YYYY").format("DD-MM-YYYY"));
                        //$("#modalEdit_txbFecha2").val(moment(fecha2, "DD-MM-YYYY").format("DD-MM-YYYY"));

                        $("#modalEdit_txbFecha1").val(fecha1);
                        $("#modalEdit_txbFecha2").val(fecha2);
                        $("#modalEdit_ddlProveedores").val(proveedor);
                        $("#modalEdit_ddlClientes").val(cliente);
                        $("#modalEdit_ddlCargadores").val(cargador);
                        $("#modalEdit_txbLugarCarga").val(lugar_carga);
                        $("#modalEdit_ddlFleteros").val(fletero);
                        $("#modalEdit_ddlCamiones").val(camion);
                        $("#modalEdit_ddlChoferes").val(chofer);
                        $("#modalEdit_txbComentarios").val(comentarios);

                        $('#editModal').modal('show');

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

function ModificarViaje_2() {

    var hdn_editViaje_viajeID = $("#hdn_editViaje_viajeID");
    if (hdn_editViaje_viajeID !== null && hdn_editViaje_viajeID.val() !== null && hdn_editViaje_viajeID.val().length > 0) {
        var viajeID_str = hdn_editViaje_viajeID.val();

        var fecha1 = $("#modalEdit_txbFecha1").val();
        var fecha2 = $("#modalEdit_txbFecha2").val();
        var proveedor = $("#modalEdit_ddlProveedores").val();
        var cliente = $("#modalEdit_ddlClientes").val();
        var cargador = $("#modalEdit_ddlCargadores").val();
        var lugar_carga = $("#modalEdit_txbLugarCarga").val();
        var fletero = $("#modalEdit_ddlFleteros").val();
        var camion = $("#modalEdit_ddlCamiones").val();
        var chofer = $("#modalEdit_ddlChoferes").val();
        var comentarios = $("#modalEdit_txbComentarios").val();

        // Ajax call parameters
        console.log("Ajax call: Viajes.aspx/ModificarViaje_2. Params:");
        console.log("viajeID_str, type: " + type(viajeID_str) + ", value: " + viajeID_str);
        console.log("fecha1, type: " + type(fecha1) + ", value: " + fecha1);
        console.log("fecha2, type: " + type(fecha2) + ", value: " + fecha2);
        console.log("proveedor, type: " + type(proveedor) + ", value: " + proveedor);
        console.log("cliente, type: " + type(cliente) + ", value: " + cliente);
        console.log("cargador, type: " + type(cargador) + ", value: " + cargador);
        console.log("lugar_carga, type: " + type(lugar_carga) + ", value: " + lugar_carga);
        console.log("fletero, type: " + type(fletero) + ", value: " + fletero);
        console.log("camion, type: " + type(camion) + ", value: " + camion);
        console.log("chofer, type: " + type(chofer) + ", value: " + chofer);
        console.log("comentarios, type: " + type(comentarios) + ", value: " + comentarios);

        $.ajax({
            type: "POST",
            url: "Viajes.aspx/ModificarViaje_2",
            data: '{viajeID_str: "' + viajeID_str + '",fecha1: "' + fecha1 + '",fecha2: "' + fecha2 + '",proveedor: "' + proveedor +
                '",cliente: "' + cliente + '",cargador: "' + cargador + '",lugar_carga: "' + lugar_carga + '",fletero: "' + fletero +
                '",camion: "' + camion + '",chofer: "' + chofer + '",comentarios: "' + comentarios + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var ok = response.d;
                if (ok !== null && ok) {

                    $('#dialog p').text(hashMessages['OK_Datos']);
                    $("#dialog").dialog({
                        open: {},
                        resizable: false,
                        height: 150,
                        modal: true,
                        buttons: {
                            "Aceptar": function () {
                                $("#btnUpdateViajesEnCurso").click();
                                $(this).dialog("close");
                                $.modal.close();
                                return true;
                            }
                        }
                    });

                    //// Actualizar datos
                    //var selected_row = $(".hiddencol").filter(':contains("' + clienteID_str + '")');
                    //if (selected_row !== null) {
                    //    selected_row.click();
                    //}

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


function FinDelViaje() {

    $('#dialog p').text(hashMessages['Confirmacion']);
    $("#dialog").dialog({
        open: {},
        resizable: false,
        height: 150,
        modal: true,
        buttons: {
            "Confirmar": function () {

                var hdn_notificaciones_viajeID = $("#hdn_notificaciones_viajeID");
                if (hdn_notificaciones_viajeID !== null && hdn_notificaciones_viajeID.val() !== null && hdn_notificaciones_viajeID.val().length > 0) {
                    var viajeID_str = hdn_notificaciones_viajeID.val();

                    // Ajax call parameters
                    console.log("Ajax call: Viajes.aspx/FinDelViaje. Params:");
                    console.log("viajeID_str, type: " + type(viajeID_str) + ", value: " + viajeID_str);

                    $.ajax({
                        type: "POST",
                        url: "Viajes.aspx/FinDelViaje",
                        data: '{viajeID_str: "' + viajeID_str + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var result = response.d;
                            switch (result) {
                                case 0: {
                                    show_message_info('Error_Datos');
                                    break;
                                }

                                case 1: {
                                    show_message_info('OK_FINViaje');
                                    location.reload();
                                    break;
                                }

                                case 2: {
                                    show_message_info('Error_DatosMercaderias');
                                    break;
                                }

                                case 3: {
                                    show_message_info('Error_DatosPesadas');
                                    break;
                                }

                                case 4: {
                                    show_message_info('Error_DatosPrecioVenta');
                                    break;
                                }
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
    }); // Ajax
}


function GuardarPrecioVenta() {

    var hdn_notificaciones_viajeID = $("#hdn_notificaciones_viajeID").val();
    var notif_txbPrecioFlete = $("#notif_txbPrecioFlete").val();
    var notif_txbPrecioDescarga = $("#notif_txbPrecioDescarga").val();
    var notif_txbGananciaXTon = $("#notif_txbGananciaXTon").val();
    var notif_txbIVA = $("#notif_txbIVA").val();
    var txb_pesada2Peso_neto = $("#txb_pesada2Peso_neto").val();

    // Check viaje
    if (hdn_notificaciones_viajeID !== null && hdn_notificaciones_viajeID.length > 0) {

        // Check datos pesadas
        if (txb_pesada2Peso_neto !== null && txb_pesada2Peso_neto.length > 0) {

            // Check existe cálculo
            var notif_lblPrecioVenta = $("#notif_lblPrecioVenta");
            if (notif_lblPrecioVenta !== null) {
                var precio_venta_str = notif_lblPrecioVenta.text();
                if (precio_venta_str !== null && precio_venta_str !== "" && precio_venta_str !== "0") {

                    // Check datos venta
                    if (notif_txbPrecioFlete !== null && notif_txbPrecioFlete.length > 0 &&
                    notif_txbPrecioDescarga !== null && notif_txbPrecioDescarga.length > 0 &&
                    notif_txbGananciaXTon !== null && notif_txbGananciaXTon.length > 0 &&
                    notif_txbIVA !== null && notif_txbIVA.length > 0) {

                        var viajeID = hdn_notificaciones_viajeID;

                        var precioFlete_str = notif_txbPrecioFlete;
                        var precioDescarga_str = notif_txbPrecioDescarga;
                        var gananciaXTon_str = notif_txbGananciaXTon;
                        var IVA_str = notif_txbIVA;

                        if (precio_venta_str !== "" && precio_venta_str !== "0") {

                            // Ajax call parameters
                            console.log("Ajax call: Viajes.aspx/GuardarPrecioVenta. Params:");
                            console.log("viajeID, type: " + type(viajeID) + ", value: " + viajeID);
                            console.log("precioFlete_str, type: " + type(precioFlete_str) + ", value: " + precioFlete_str);
                            console.log("precioDescarga_str, type: " + type(precioDescarga_str) + ", value: " + precioDescarga_str);
                            console.log("gananciaXTon_str, type: " + type(gananciaXTon_str) + ", value: " + gananciaXTon_str);
                            console.log("IVA_str, type: " + type(IVA_str) + ", value: " + IVA_str);
                            console.log("precio_venta_str, type: " + type(precio_venta_str) + ", value: " + precio_venta_str);

                            $.ajax({
                                type: "POST",
                                url: "Viajes.aspx/GuardarPrecioVenta",
                                data: '{viajeID: "' + viajeID + '",precioFlete_str: "' + precioFlete_str + '",precioDescarga_str: "' + precioDescarga_str + '",gananciaXTon_str: "' + gananciaXTon_str + '", ' +
                                    'IVA_str: "' + IVA_str + '", precio_venta_str: "' + precio_venta_str + '"}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (response) {
                                    var precio_venta = response.d;
                                    if (precio_venta !== null) {
                                        show_message_info('OK_Datos');
                                    }

                                }, // end success
                                failure: function (response) {
                                    alert(response.d);
                                }
                            });
                        }
                        else {
                            show_message_info('Error_DatosPrecioVenta');
                        }
                    } // venta
                    else {
                        show_message_info('Error_DatosPrecioVenta');
                    }

                }
                else {
                    show_message_info('Error_DatosPrecioVenta');
                }

            } // pesadas
            else {
                show_message_info('Error_DatosPesadas');
            }
        } // viaje
        else {
            show_message_info('Error_DatosPrecioVenta');
        }

    }
}

/**** Event: OnClick Load on click event remove button (btnRemoveElement) ****/
//function loadClickRemoveButton_event() {
//    var btnRemoveElement = $("#btnBorrar");
//    btnRemoveElement.bind("click", function () {
//        if (!$('#btnBorrar').hasClass("opened")) {

//            $('.popbox3').popbox3();
//            $(".box3.popbox3").show("highlight", 700);
//            $('#txbConfirmRemoveElement').focus();
//            $('#btnBorrar').addClass("opened");

//            // Popup re-location
//            $(".popbox3").position({
//                my: "left top",
//                at: "left bottom",
//                of: "#btnBorrar"
//            });

//            var btn_width = (parseInt(btnBorrar.css("width"), 10) / 2) + 2;

//            // X and Y Axis
//            $("#divPopbox3").offset({ left: $("#divPopbox3").offset().left + btn_width });
//            $("#divPopbox3").offset({ top: $("#divPopbox3").offset().top + 5 });

//        } else {
//            $(".box3.popbox3").hide(200);
//            $('#btnBorrar').removeClass("opened");
//        }
//    });
//}

function confirmar_borrarViajeEnCurso() {

    var btnBorrar = $("#btnBorrar");
    if (btnBorrar != null) {
        if (!btnBorrar.hasClass("opened")) {
            $(".msg-box.popbox").show("highlight", 700);
            $('#txbConfirmRemoveElement').focus();
            btnBorrar.addClass("opened");

            // Popup re-location
            $(".popbox").position({
                my: "left top",
                at: "left bottom",
                of: "#btnBorrar"
            });

            var btn_width = (parseInt(btnBorrar.css("width"), 10) / 2) + 2;

            // X and Y Axis
            $("#divPopbox").offset({ left: $("#divPopbox").offset().left + btn_width });
            $("#divPopbox").offset({ top: $("#divPopbox").offset().top + 5 });

        } else {
            //$(".msg-box.popbox").hide(200);
            btnBorrar.removeClass("opened");
        }
    }

}
