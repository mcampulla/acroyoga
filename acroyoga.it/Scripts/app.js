$('.carousel').carousel({
    interval: 30000 //changes the speed
})

$('#myCarousel').on('slid.bs.carousel', function (options) {
    // do something…
    $(".item:not(.active) .out").removeClass("in");
    $(".item.active .out").addClass("in");
    //$(".out").toggleClass("in");
    //console.log("slid");
})

$(function () {
    $(".item.active .out").addClass("in");

    $('.nav-scroll').bind('click', function () {
        $('html, body').stop().animate({
            scrollTop: $($(this).attr('href')).offset().top - 40
        }, 1500, 'easeInOutExpo');
        //console.log("click")
        event.preventDefault();
    });

    window.addEventListener('scroll', function (event) {
        if (!didScroll) {
            didScroll = true;
            setTimeout(scrollPage, 250)
        }
    }, false);

    /* This is basic - uses default settings */

    $("a.group").fancybox({
        'transitionIn': 'elastic',
        'transitionOut': 'elastic',
        'speedIn': 600,
        'speedOut': 200,
        'overlayShow': false
    });


    var $allVideos = $("iframe[src^='//www.youtube.com']"),

    // The element that is fluid width
    $fluidEl = $(".rwd-video1");

    // Figure out and save aspect ratio for each video
    $allVideos.each(function () {
        $(this)
          .data('aspectRatio', this.height / this.width)
          // and remove the hard coded width/height
          .removeAttr('height')
          .removeAttr('width');
    });


    // When the window is resized
    $(window).resize(function () {
        var newWidth = $fluidEl.width();

        // Resize all videos according to their own aspect ratio
        $allVideos.each(function () {

            var $el = $(this);
            $el
              .width(newWidth)
              .height(newWidth * 0.5625);

        });

        // Kick off one resize to fix all videos on page load
    }).resize();

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

// Find all YouTube videos
$(document).ready(function () {
    
});