$(function () {

    var $firstPoster = $('#poster img:first');
    $firstPoster.addClass('active');
    setInterval('imageCycles()', 20000);

    var firstPrice = $('#pricing ul:first');
    firstPrice.addClass('active');
    setInterval('priceCycles()', 8000);
});

function imageCycles() {
    var $active = $('#poster .active');
    var $next = ($active.next().length > 0) ? $active.next() : $('#poster img:first');
    $next.css('z-index', 2);
    $active.fadeOut(1500, function () {
        $active.css('z-index', 1).show().removeClass('active');
        $next.css('z-index', 3).addClass('active');
    });
}

function priceCycles() {
    var $active = $('#pricing .active');
    var $next = ($active.next().length > 0) ? $active.next() : $('#pricing ul:first');
    $next.css('z-index', 2);
    $active.fadeOut(1500, function () {
        $active.css('z-index', 1).show().removeClass('active');
        $next.css('z-index', 3).addClass('active');
    });
}