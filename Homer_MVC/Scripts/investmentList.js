$("tr").hover(function(){
    $(this).children("td").children().css("color", "white");
}, function(){
    $(this).children("td").children().css("color", "#34495e");
});

$("tr").click(function () {
   
})

$("span").click(function (e) {
    e.stopPropagation();
   
})