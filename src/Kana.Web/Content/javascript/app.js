
$.fn.extend({
  confirm: function (text) {
    return this.each(function () {
      $(this).click(function(e) {
        return confirm(text);
      });
    });
  }
});

function Application() { }
Application.prototype = {
  queryString: {},
  init: function () {
    var self = this;

    $(document.body).addClass("js-enabled");

    $(window).resize(function () {
      self.windowResize();
    }).resize();

    $('a[data-confirm]').click(function() {
      var text = $(this).data('confirm');
      return confirm(text);
    });

    $('[data-insertto]').click(function (e) {
      e.preventDefault();
      var insertto = $(this).data('insertto');
      $('[data-insertto=' + insertto + ']').addClass('secondary');
      $(this).removeClass('secondary');
      $('#' + insertto).val($(this).data('value')).change();
    }).each(function () {
      if ($(this).data('value').toString() == $('#' + $(this).data('insertto')).val()) {
        $(this).removeClass('secondary');
      }
    });

    $('[data-selectall]').click(function(e) {
      e.preventDefault();
      var state = $(this).data('state');
      $($(this).data('selectall')).prop('checked', state);
      $(this).data('state', !state).html(state ? $(this).data('selectall-dename') : $(this).data('selectall-name'));
    }).each(function() {
      $(this).data('state', true).html($(this).data('selectall-name'));
    });

  },

  windowResize: function () {
    if ($(window).height() < $(document).height()) {
      $(document.body).addClass("scroll");
    } else {
      $(document.body).removeClass("scroll");
    }
  },

  initOnLoad: function () {
    $(document).foundation();

  }

};

var app = null;
$(document).ready(function () {
  app = new Application();
  app.init();
});

$(window).load(function () {
  app.initOnLoad();
});