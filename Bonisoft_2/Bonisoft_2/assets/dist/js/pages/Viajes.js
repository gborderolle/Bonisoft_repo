
$(document).ready(function () {
    $(".datepicker").datepicker();

    // Source: https://www.youtube.com/watch?v=Sy2J7cUv0QM
    var gridViajes = $("#gridViajes tbody tr").not(':first');
    var gridViajesEnCurso = $("#gridViajesEnCurso tbody tr").not(':first');
    $("#txbSearchViajesEnCurso").quicksearch(gridViajesEnCurso);
    $("#txbSearchViajes").quicksearch(gridViajes);

});

$(function () {
    $("#tabsViajes").tabs();
});

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
            Cancel: function () {
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


$(document).ready(function () {

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