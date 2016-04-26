$(function () {
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        $('li').removeClass('activeSection');
        $(this).parent().addClass('activeSection', 'slow')
    })

    $('.next').click(function () {
        var nextId = $(this).parents('.tab-pane').next().attr("id");
        $('[href=#' + nextId + ']').tab('show');
    })

    $('.prev').click(function () {
        var prevId = $(this).parents('.tab-pane').prev().attr("id");
        $('[href=#' + prevId + ']').tab('show');
    })
})