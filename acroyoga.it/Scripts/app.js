$('.carousel').carousel({
    interval: 30000 //changes the speed
})

$('#myCarousel').on('slid.bs.carousel', function (options) {
    // do something…
    $(".item:not(.active) .out").removeClass("in");
    $(".item.active .out").addClass("in");
    //$(".out").toggleClass("in");
    console.log("slid");
})

$(function () {
    $(".item.active .out").addClass("in");

    $('nav a').bind('click', function () {
        $('html, body').stop().animate({
            scrollTop: $($(this).attr('href')).offset().top - 40
        }, 1500, 'easeInOutExpo');
        console.log("click")
        event.preventDefault();
    });

    window.addEventListener('scroll', function (event) {
        if (!didScroll) {
            didScroll = true;
            setTimeout(scrollPage, 250)
        }
    }, false);
});

didScroll = false;
changeOn = 50;

function scrollPage() {
    var y = scrollY;
    if (y > changeOn) {
        $('.navbar').addClass("navbar-shrink");;
    } else {
        $('.navbar').removeClass("navbar-shrink");
    }

    didScroll = false;
}