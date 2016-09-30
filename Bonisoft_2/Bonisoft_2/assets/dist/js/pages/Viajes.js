/**** Local variables ****/
var upAdd = '<%=upAdd.ClientID%>';

/**** Extras variables ****/

// Variable object types
var TYPES = {
    'undefined': 'undefined',
    'number': 'number',
    'boolean': 'boolean',
    'string': 'string',
    '[object Function]': 'function',
    '[object RegExp]': 'regexp',
    '[object Array]': 'array',
    '[object Date]': 'date',
    '[object Error]': 'error'
},
 TOSTRING = Object.prototype.toString;


$(document).ready(function () {
    bindEvents();

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
    $(".datepicker").datepicker();
    $("#tabsViajes").tabs();
    $("#tabsNotificaciones").tabs();
    $("#gridViajesEnCurso").tablesorter();
    $("#gridViajes").tablesorter();

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
    if (isOrigen == 1) {
        var txb_pesada2Lugar = $("#txb_pesada2Lugar").val();
        var txb_pesada2Fecha = $("#txb_pesada2Fecha").val();
        var txb_pesada2Peso_bruto = $("#txb_pesada2Peso_bruto").val();
        var txb_pesada2Peso_neto = $("#txb_pesada2Peso_neto").val();
        var txb_pesada2Nombre = $("#txb_pesada2Nombre").val();
        var txb_pesada2Comentarios = $("#txb_pesada2Comentarios").val();

        $("#txb_pesada1Lugar").val(txb_pesada2Lugar);
        $("#txb_pesada1Fecha").val(txb_pesada2Fecha);
        $("#txb_pesada1Peso_bruto").val(txb_pesada2Peso_bruto);
        $("#txb_pesada1Peso_neto").val(txb_pesada2Peso_neto);
        $("#txb_pesada1Nombre").val(txb_pesada2Nombre);
        $("#txb_pesada1Comentarios").val(txb_pesada2Comentarios);

    } else {
        var txb_pesada1Lugar = $("#txb_pesada1Lugar").val();
        var txb_pesada1Fecha = $("#txb_pesada1Fecha").val();
        var txb_pesada1Peso_bruto = $("#txb_pesada1Peso_bruto").val();
        var txb_pesada1Peso_neto = $("#txb_pesada1Peso_neto").val();
        var txb_pesada1Nombre = $("#txb_pesada1Nombre").val();
        var txb_pesada1Comentarios = $("#txb_pesada1Comentarios").val();

        $("#txb_pesada2Lugar").val(txb_pesada1Lugar);
        $("#txb_pesada2Fecha").val(txb_pesada1Fecha);
        $("#txb_pesada2Peso_bruto").val(txb_pesada1Peso_bruto);
        $("#txb_pesada2Peso_neto").val(txb_pesada1Peso_neto);
        $("#txb_pesada2Nombre").val(txb_pesada1Nombre);
        $("#txb_pesada2Comentarios").val(txb_pesada1Comentarios);
    }
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

function show_message_confirm(msg) {
    $('#dialog p').text(hashMessages[msg]);
    $("#dialog").dialog({
        open: {},
        resizable: false,
        height: 140,
        modal: true,
        buttons: {
            "Confirmar": function () {
                $(this).dialog("close");
                return true;

            },
            "Cancelar": function () {
                $(this).dialog("close");
                return false;
            }
        }
    });
}

function show_message_accept(msg) {
    $('#dialog p').text(hashMessages[msg]);
    $("#dialog").dialog({
        open: {},
        resizable: false,
        height: 140,
        modal: true,
        buttons: {
            "Aceptar": function () {
                $(this).dialog("close");
                return true;
            }
        }
    });
}

function finalizarViaje() {

    $('#dialog p').text(hashMessages['Confirmacion']);
    $("#dialog").dialog({
        open: {},
        resizable: false,
        height: 140,
        modal: true,
        buttons: {
            "Confirmar": function () {
                $("#lnkViajeDestinoCandidate").click();
                //__doPostBack('<%=lnkViajeDestinoCandidate.UniqueID%>', "");
                //$(this).dialog("close");

            },
            "Cancelar": function () {
                $(this).dialog("close");
                return false;
            }
        }
    });
}

function DoPost_Mercaderias() {

    // Hdn Fields - Pesada origen
    var mercaderias_txbNew4 = $("#mercaderias_txbNew4").val();
    var mercaderias_txbNew5 = $("#mercaderias_txbNew5").val();
    var mercaderias_txbNew6 = $("#mercaderias_txbNew6").val();
    var mercaderias_txbNew7 = $("#mercaderias_txbNew7").val();
    var mercaderias_ddlVariedad2 = $("#mercaderias_ddlVariedad2").val();
    var mercaderias_ddlProcesador2 = $("#mercaderias_ddlProcesador2").val();

    $("#hdn_modalMercaderia_txbNew4").val(mercaderias_txbNew4);
    $("#hdn_modalMercaderia_txbNew5").val(mercaderias_txbNew5);
    $("#hdn_modalMercaderia_txbNew6").val(mercaderias_txbNew6);
    $("#hdn_modalMercaderia_txbNew7").val(mercaderias_txbNew7);
    $("#hdn_modalMercaderia_ddlVariedad2").val(mercaderias_ddlVariedad2);
    $("#hdn_modalMercaderia_ddlProcesador2").val(mercaderias_ddlProcesador2);

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
    if (upAdd != null) {
        //__doPostBack(upAdd, '');

        __doPostBack("<%=upAdd.UniqueID %>", "");
        //document.getElementById("<%=btnSubmit_upAdd.ClientID %>").click();
    }
}

function calcularPrecioVenta() {
    var hdn_notificaciones_viajeID = $("#hdn_notificaciones_viajeID");
    var notif_lblPrecioCompra = $("label[id*='notif_lblPrecioCompra']");
    var notif_txbPrecioFlete = $("#notif_txbPrecioFlete");
    var notif_txbPrecioDescarga = $("#notif_txbPrecioDescarga");
    var notif_txbGananciaXTon = $("#notif_txbGananciaXTon");
    var notif_txbIVA = $("#notif_txbIVA");
    var txb_pesada2Peso_neto = $("#txb_pesada2Peso_neto");
    var notif_lblPrecioVenta = $("label[id*='notif_lblPrecioVenta']");

    if (hdn_notificaciones_viajeID != null && hdn_notificaciones_viajeID.val() != null && hdn_notificaciones_viajeID.val().length > 0 &&
        notif_lblPrecioCompra != null && notif_lblPrecioCompra.text() != null && notif_lblPrecioCompra.text().length > 0 &&
        notif_txbPrecioFlete != null && notif_txbPrecioFlete.val() != null && notif_txbPrecioFlete.val().length > 0 &&
        notif_txbPrecioDescarga != null && notif_txbPrecioDescarga.val() != null && notif_txbPrecioDescarga.val().length > 0 &&
        notif_txbGananciaXTon != null && notif_txbGananciaXTon.val() != null && notif_txbGananciaXTon.val().length > 0 &&
        notif_txbIVA != null && notif_txbGananciaXTon.val() != null && notif_txbIVA.val().length > 0 &&
        txb_pesada2Peso_neto != null && txb_pesada2Peso_neto.val() != null && txb_pesada2Peso_neto.val().length > 0 &&
        notif_lblPrecioVenta != null) {

        var viajeID = hdn_notificaciones_viajeID.val();
        var precioCompra = notif_lblPrecioCompra.text();
        var precioFlete = notif_txbPrecioFlete.val();
        var precioDescarga = notif_txbPrecioDescarga.val();
        var gananciaXTon = notif_txbGananciaXTon.val();
        var IVA = notif_txbIVA.val();
        var peso_neto_destino = txb_pesada2Peso_neto.val();
        
        // Ajax call parameters
        console.log("Ajax call: Viajes.aspx/CalcularPrecioVenta. Params:");
        console.log("viajeID, type: " + type(viajeID)); 
        console.log("precioCompra, type: " + type(precioCompra)); 
        console.log("precioFlete, type: " + type(precioFlete));
        console.log("precioDescarga, type: " + type(precioDescarga));
        console.log("gananciaXTon, type: " + type(gananciaXTon));
        console.log("IVA, type: " + type(IVA));
        console.log("peso_neto_destino, type: " + type(peso_neto_destino));
        console.log("End Ajax call");

        $.ajax({
            type: "POST",
            url: "Viajes.aspx/CalcularPrecioVenta",
            data: '{viajeID: "' + viajeID + '",precio_compra_str: "' + precioCompra + '",precio_flete_str: "' + precioFlete + '",precio_descarga_str: "' + precioDescarga + 
                '",gananciaXTon_str: "' + gananciaXTon + '",IVA_str: "' + IVA + '",peso_neto_destino_str: "' + peso_neto_destino + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var precio_venta = response.d;
                if (precio_venta != null) {
                    notif_lblPrecioVenta.text(precio_venta);

                    bindEvents();
                    $("#ui-id-14").click();
                }

            }, // end success
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    else {
        show_message_accept('Error_DatosPrecioVenta');
    }
}

function GuardarPrecioVenta() {

    var hdn_notificaciones_viajeID = $("#hdn_notificaciones_viajeID");
    var notif_lblPrecioVenta = $("#notif_lblPrecioVenta");

    if (hdn_notificaciones_viajeID != null && hdn_notificaciones_viajeID.val() != null && hdn_notificaciones_viajeID.val().length > 0 &&
        notif_lblPrecioVenta != null && notif_lblPrecioVenta.val() != null && notif_lblPrecioVenta.val().length > 0) {

        var viajeID = hdn_notificaciones_viajeID.val();
        var precio_venta_str = notif_lblPrecioVenta.val();

        // Ajax call parameters
        console.log("Ajax call: Viajes.aspx/GuardarPrecioVenta. Params:");
        console.log("viajeID, type: " + type(viajeID)); 
        console.log("precio_venta_str, type: " + type(precio_venta_str)); 

        $.ajax({
            type: "POST",
            url: "Viajes.aspx/GuardarPrecioVenta",
            data: '{viajeID: "' + viajeID + '",precio_venta_str: "' + precio_venta_str + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var precio_venta = response.d;
                if (precio_venta != null) {
                    notif_lblPrecioVenta.text(precio_venta);

                    bindEvents();
                    $("#ui-id-14").click();
                }

            }, // end success
            failure: function (response) {
                alert(response.d);
            }
        });
    }
}

/******** Auxiliar Functions ********/

// Get variable object type
function type(o) {
    return TYPES[typeof o] || TYPES[TOSTRING.call(o)] || (o ? 'object' : 'null');
};


