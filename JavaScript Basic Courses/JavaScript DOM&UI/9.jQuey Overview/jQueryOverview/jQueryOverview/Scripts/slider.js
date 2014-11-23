//Create a slider control using jQuery
//      The slider can have many slides
//      Only one slide is visible at a time
//      Each slide contains HTML code
//      i.e. it can contain images, forms, divs, headers, links, etc…
//      Implement functionality for changing the visible slide after 5 seconds
//      Create buttons for next and previous slide

function getNextSlide() {
    var activeSlide = $('#slider .active');
    var nextSlide = activeSlide.next();

    if (nextSlide.length == 0) {
        nextSlide = $('#slider .slide:first');
    }

    activeSlide.fadeToggle(1000).removeClass('active');
    nextSlide.fadeToggle(1000).addClass('active');
}

function getPreviousSlide() {
    var activeSlide = $('#slider .active');
    var previousSlide = activeSlide.prev();

    if (previousSlide.length == 0) {
        previousSlide = $('#slider .slide:last');
    }

    activeSlide.fadeToggle(1000).removeClass('active');
    previousSlide.fadeToggle(1000).addClass('active');
}


var activeSlide = $('#slider .active');
activeSlide.css('display', 'block');

var nextBtn = $('#next');
var prevBtn = $('#previous');

var timeout = 5000;

var timer = setInterval(getNextSlide, timeout);

nextBtn.on("click", function () {
    clearInterval(timer);
    getNextSlide();
    timer = setInterval(getNextSlide, timeout);
});

prevBtn.on('click', function () {
    clearInterval(timer);
    getPreviousSlide();
    timer = setInterval(getNextSlide, timeout);
})