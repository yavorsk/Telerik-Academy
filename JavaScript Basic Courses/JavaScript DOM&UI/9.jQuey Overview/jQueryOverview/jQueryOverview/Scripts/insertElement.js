// Using jQuery implement functionality to insert a DOM element before or after another element

function insertBefore(element) {
    var $initial = $('#initial');

    $initial.before(element);
}

function insertAfter(element) {
    var $initial = $('#initial');

    $initial.after(element);
}

$('#beforeBtn').on('click', function () {
    var $newSpan = $('<span>new Span</span>');
    $newSpan.addClass('newElement');

    insertBefore($newSpan);
})

$('#afterBtn').on('click', function () {
    var $newSpan = $('<span>new Span</span>');
    $newSpan.addClass('newElement');

    insertAfter($newSpan);
})