
function setTabActive(tabID) {
    $("div .tables").removeClass("box-active");
    $("div #" + tabID).addClass("box-active");

    var title = $("div #" + tabID + " .info-box-text").text();
	$("#lblTableActive").text(title);

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