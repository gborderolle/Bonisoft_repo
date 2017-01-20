(function(){

  $.fn.popbox = function(options){
    var settings = $.extend({
      selector      : this.selector,
      open          : '.open',
      box          : '.msg-box',
      arrow         : '.arrow',
      arrow_border  : '.arrow-border',
      close         : '.close'
    }, options);

    var methods = {
      open: function(event){
          event.preventDefault();

        var pop = $(this);
        var box = $('.msg-box');
        var btn = $('#btnConfirmRemoveElement');

        //box.find(settings['arrow']).css({'left': box.width()/2 - 10});
        //box.find(settings['arrow_border']).css({'left': box.width()/2 - 10});

        if (box.css('display') == 'block') {
            methods.close();
        } else {
            box.css('display', 'block');
            box.css('top', btn.offset().top);

            $('.msg-box').css('height', '270px');
            $('#popbox_footer').css('margin', '20px');

            $(".box.popbox").css('left', $(event.target).offset().left);
            $(".box.popbox").css('top', $(event.target).offset().top + 15);
        }
      },

      close: function () {          
          $("#txbConfirmRemoveElement").val("");
          $(settings['box']).fadeOut("fast");
          
          var btnBorrar = $("#btnBorrar");
          if (btnBorrar != null) {
              btnBorrar.removeClass("opened");
          }
      }
    };
      
    $(document).bind('keyup', function(event){
      if (event.keyCode == 27) { // Escape
          methods.close();
      }
    });

    $('.popbox').keypress(function(e){
        if (e.which == 13) { // Enter
            $("button[id*='btnConfirmRemoveElement").click();
        }
    });

    $(document).bind('click', function (event) {
        if (!$(event.target).closest(settings['selector']).length && !$(event.target).is('button') && !$(event.target).is('span') && !$(event.target).is('input')) {
            methods.close();
        }
    });

    return this.each(function(){
        //$(this).css({'width': $(settings['box']).width()}); // Width needs to be set otherwise popbox will not move when window resized.

        $(settings['open'], this).bind('click', methods.open);
        $(settings['open'], this).parent().find(settings['close']).bind('click', function(event){
        event.preventDefault();
        methods.close();
      });
    });
  }

}).call(this);
