
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

$(document).ready(function () {
    if (QueryString !== null) {
        if (QueryString.table !== null) {
            var table = QueryString.table;
            if (table !== "") {
                switch (table) {
                    case "proveedores":
                        {
                            setlblTableActive("Proveedores");
                            break;
                        }
                    case "clientes":
                        {
                            setlblTableActive("Clientes");
                            break;
                        }
                    case "viajes":
                        {
                            setlblTableActive("Viajes");
                            break;
                        }
                    case "choferes":
                        {
                            setlblTableActive("Choferes");
                            break;
                        }
                    case "cuadrillas":
                        {
                            setlblTableActive("Cuadrillas");
                            break;
                        }
                    case "internos":
                        {
                            setlblTableActive("Internos");
                            break;
                        }
                    case "pesadas":
                        {
                            setlblTableActive("Pesadas");
                            break;
                        }
                    case "camiones":
                        {
                            setlblTableActive("Camiones");
                            break;
                        }
                    case "personas":
                        {
                            setlblTableActive("Personas");
                            break;
                        }
                    case "contacto_medio":
                        {
                            setlblTableActive("Medios de contacto");
                            break;
                        }
                }
            }
        }
    }
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