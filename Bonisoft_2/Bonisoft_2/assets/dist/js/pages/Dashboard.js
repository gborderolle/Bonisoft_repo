
$(document).ready(function () {

    var clientes_count = $("#divContent #grdClientesCount").val();
    var proveedores_count = $("#divContent #grdProveedoresCount").val();
    var cuadrillas_count = $("#divContent #grdCuadrillasCount").val();
    var camiones_count = $("#divContent #grdCamionesCount").val();
    var choferes_count = $("#divContent #grdChoferesCount").val();
    var internos_count = $("#divContent #grdInternosCount").val();

    $("#divBoxClientes .info-box-number").text(clientes_count);
    $("#divBoxProveedores .info-box-number").text(proveedores_count);
    $("#divBoxCuadrillas .info-box-number").text(cuadrillas_count);
    $("#divBoxCamiones .info-box-number").text(camiones_count);
    $("#divBoxChoferes .info-box-number").text(choferes_count);
    $("#divBoxInternos .info-box-number").text(internos_count);

    ;

    $(".info-box").hover(function () {
        $(this).css("border-color", "#57c8da");
        //$(this).stop().animate({ marginTop: "-1px" }, 200);
        $(this).parent().find("span").css("color", "#57c8da");
    }, function () {
        $(this).css("border-color", "darkgray");
        //$(this).parent().find("*").stop().animate({ marginTop: "1px", opacity: 1 }, 300);
        $(this).parent().find("span").css("color", "black");
    });

    //#region Reflection effect
    // http://www.adrianpelletier.com/2009/05/31/create-a-realistic-hover-effect-with-jquery-ui/

    /*
    // Animate buttons, move reflection and fade
    $(".info-box").hover(function () {
        $(this).stop().animate({ marginTop: "-4px" }, 200);
        $(this).parent().find("*").stop().animate({ marginTop: "5px", opacity: 1 }, 200);
    }, function () {
        $(this).stop().animate({ marginTop: "0px" }, 300);
        $(this).parent().find("*").stop().animate({ marginTop: "1px", opacity: 1 }, 300);
    });

    /* =Shadow Nav
    -------------------------------------------------------------------------- */

    //#endregion 


});

$(".info-box").mouseover(function () {
    $(".info-box").css("background-color", "yellow");
});

$(document).on('click', ".info-box", function () {
    show_grid($(this));
});


function show_grid(element) {
    //Find the box parent
    var table_name = element.find(".info-box-text").text();
    if (table_name !== null) {
        $(".divTables").hide();
        switch (table_name.toLowerCase()) {
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
        }
    }

}

function setlblTableActive(name) {
    $("#lblTableActive").text(name);
}

function setTabActive(tabID) {
    $("div .tables").removeClass("box-active");
    $("div #" + tabID).addClass("box-active");

    var title = $("div #" + tabID + " .info-box-text").text();
    setlblTableActive(title);

    var count = $("div #" + tabID + " .info-box-number").text();
	$("#lblResultados").text(count);
}

function sidebar_action() {
	$("body").toggleClass('sidebar-collapse').toggleClass('sidebar-expanded-on-hover');
}

function box_collapse (element) {
      //Find the box parent
      var box = element.parents(".box").first();
      //Find the body and the footer
      var box_content = box.find("> .box-body, > .box-footer, > form  >.box-body, > form > .box-footer");
      if (!box.hasClass("collapsed-box")) {
        //Convert minus into plus
        element.children(":first")
            .removeClass("fa-minus")
            .addClass("fa-plus");
        //Hide the content
        box_content.slideUp(500, function () {
          box.addClass("collapsed-box");
        });
      } else {
        //Convert plus into minus
        element.children(":first")
            .removeClass("fa-plus")
            .addClass("fa-minus");
        //Show the content
        box_content.slideDown(500, function () {
          box.removeClass("collapsed-box");
        });
      }
}

$(document).on('click', ".btn-box-tool", function () {
	box_collapse($(this));
});



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

// http://www.itorian.com/2013/02/jquery-ajax-get-and-post-calls-to.html
$("#txbSearchTable").on('input', function() {

    var url = "/Camiones/Search";
    var search = $(this).val();
    $.post(url, { Search: search }, function (data) {
        $("#msg").html(data);
    });

    //alert($(this).val());

});

    // maybe check the value is more than n chars or whatever
    //$.ajax({
    //    url: <%= Url.Action("txbSearchTable", "Camiones") %> + '/' + this.val(), // path to ajax request
    //    dataType: "html", // probably
    //    success: updateContainerWithResults
    //});

function updateContainerWithResults(data) {
    $("#resultsContainerElement").html(data);
}