$.fn.gallery = function (columns) {
    var $this = this;
    $this.addClass('gallery');

    columns = columns || 4;

    var $imgContainers = $this.find('.gallery-list').children();

    for (var i = 1; i < $imgContainers.length; i++) {
        if (i % columns == 0) {
            $($imgContainers[i]).css('clear', 'left');
        }
    }

    var $divSelected = $this.find('.selected');
    $divSelected.hide();

    var onShowSelectedClick = function () {
        $this.find('.gallery-list').addClass('blurred').addClass('disabled-background');

        var $selected = $(this).children().clone();
        $divSelected.find('.current-image').empty().append($selected);

        var $previousImgContainer = getPreviousSibling($(this));
        var $previous = $previousImgContainer.children().clone();
        $divSelected.find('.previous-image').empty().append($previous);

        var $nextImgContainer = getNextSibling($(this));
        var $next = $nextImgContainer.children().clone();
        $divSelected.find('.next-image').empty().append($next);

        $divSelected.show();
    }

    var onEnlargePrevOrNextClick = function () {
        var dataInfoAttr = $(this).children().attr('data-info');

        var $selectedFromGalleryList = $this.find('.gallery-list').find('img[data-info="' + dataInfoAttr + '"]').parent();
        var $selected = $selectedFromGalleryList.clone();
        $divSelected.find('.current-image').empty().append($selected);

        var $previousImgContainer = getPreviousSibling($selectedFromGalleryList);
        var $previous = $previousImgContainer.children().clone();
        $divSelected.find('.previous-image').empty().append($previous);

        var $nextImgContainer = getNextSibling($selectedFromGalleryList);
        var $next = $nextImgContainer.children().clone();
        $divSelected.find('.next-image').empty().append($next);
    }

    var onCloseSelectedClick = function () {
        $divSelected.hide();
        $this.find('.gallery-list').removeClass('blurred').removeClass('disabled-background');
    }

    $this.find('.image-container').on('click', onShowSelectedClick);
    $this.find('.current-image').on('click', onCloseSelectedClick);
    $this.find('.previous-image').on('click', onEnlargePrevOrNextClick);
    $this.find('.next-image').on('click', onEnlargePrevOrNextClick);

    function getPreviousSibling($element) {
        if ($element.prev().length !== 0) {
            return $element.prev()
        } else {
            return $element.parent().children().last();
        }
    }

    function getNextSibling($element) {
        if ($element.next().length !== 0) {
            return $element.next()
        } else {
            return $element.parent().children().first();
        }
    }
};