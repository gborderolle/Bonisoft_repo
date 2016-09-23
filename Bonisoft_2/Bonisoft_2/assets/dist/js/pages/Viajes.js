
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

function show_message(msg) {
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


                //$.ajax({
                //    type: "POST",
                //    url: "Dashboard.aspx/RemoveElementSelected",
                //    data: '{list_elements: "' + list_elements + '"}',
                //    contentType: "application/json; charset=utf-8",
                //    dataType: "json",
                //    success: function (response) {

                //        $("#dialog p").text(hashMessages["ElementosBorrados"]);
                //        $("#dialog").dialog({
                //            open: {},
                //            buttons: {
                //                "Confirmar": function () {
                //                    $(this).dialog("close");
                //                    $(this).dialog("destroy");
                //                }
                //            }
                //        });

                //        // Hide elements from search panel
                //        $('tr:visible td input:checked').parent().parent().hide();

                //        // Disable element in memory elements 
                //        var _hdnIsUpdateNeeded = $("#_hdnIsUpdateNeeded");
                //        if (
                //            _hdnIsUpdateNeeded != null) {
                //            _hdnIsUpdateNeeded.val("true");
                //        }

                //        // Clear player image
                //        $("#imgPlayer").attr("src", "");

                //        if (list_elements.length > 0) {

                //            //
                //            $("#timeframe").empty(); // Clean div content
                //            var new_timeline_data = jQuery.extend(true, {}, _TL_DATA); // It clones the object, does not references it
                //            for (var i = 0; i < list_elements.length; i++) {
                //                if (list_elements[i] != null) {
                //                    var attrs_array = list_elements[i].split("#"); // Element attributes
                //                    if (attrs_array.length > 1) {
                //                        var tapeID = attrs_array[0];
                //                        if (tapeID != null && tapeID.length) {
                //                            if (new_timeline_data.spans != null && new_timeline_data.spans.length > 0) {
                //                                new_timeline_data.spans = $
                //                                    .grep(
                //                                        new_timeline_data.spans,
                //                                        function (item, index) {
                //                                            return item.id != tapeID;
                //                                        }
                //                                    );
                //                            }
                //                        }
                //                    }
                //                }
                //            } // for
                //            _TL_DATA = new_timeline_data;
                //            prepareTimelineReload(_TL_DATA);
                //        }

                //        // Update elements count
                //        $("#divPanel_Busqueda span[id*='lblResultsCount']").text($("#tblLeftGridElements tr[id*='tape_']:visible").length.toString());

                //    }, // end success
                //    failure: function (response) {
                //        alert(response.d);
                //    }
                //});

            },
            Cancel: function () {
                $(this).dialog("close");
                return false;
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