
$(function () {
    /*Side Menu Animation*/
    $("#menu-bar").click(function (event) {
        $('#side-bar').removeClass('fadeOutRight');
        $("#side-bar").addClass("open-bar");
        $('body').addClass('active-side-bar');
        event.stopPropagation();
    });

    $('html').click(function () {
        $('#side-bar').addClass('fadeOutRight');
        $('body').removeClass('active-side-bar');
    });

    $('#side-bar').click(function (event) {
        event.stopPropagation();
    });
});

/*Navigation Selection*/
$(window).load(function () {
    var pageName = $('div.render-body').attr('data-page');
    $('li[data-page="' + pageName + '"]').children('a').addClass("selected");
});

