$(function () {

  $(document).on('click', '[href="#"]', function (e) { e.preventDefault(); })

  window.rippler = $.ripple('.btn:not(.no-bind), .area', {
    debug: true,
    duration: 5,
    multi: true
  });

  $.ripple('.no-bind.demo', {
    on: 'mouseleave',
    multi: true
  });

  $.ripple('.no-bind.jakiestfu', {
    on: 'mouseenter',
    multi: true
  });
});
