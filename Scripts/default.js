//carousel
var t = n = 0,
    count;
$(document).ready(function () {
    count = $("#banner_list a").length;
    $("#banner_list a:not(:first-child)").hide();
    $("#banner .img-num a").click(function () {
        var i = $(this).text() - 1;
        n = i;
        if (i >= count) return;

        $("#banner_list a").filter(":visible").fadeOut(500)

            .parent().children().eq(i).fadeIn(1000);
        $(this).toggleClass("active");
        $(this).siblings().removeAttr("class");
    });
    t = setInterval("showAuto()", 3000);
    $("#banner").hover(function () { //mouse pause
        clearInterval(t)
    }, function () {
        t = setInterval("showAuto()", 3000);
    })
});
function showAuto() {
    n = n >= (count - 1) ? 0 : ++n;
    //trigger
    $("#banner .img-num a").eq(n).trigger("click");
}