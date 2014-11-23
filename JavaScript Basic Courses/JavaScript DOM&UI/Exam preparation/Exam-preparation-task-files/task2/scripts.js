$.fn.tabs = function () {
    var $this = $(this);

    $this.addClass('tabs-container');

    $('.tab-item:first-of-type').addClass('current');
    $('.tab-item-content').attr('display', 'none');
    $('.tab-item.current .tab-item-content').attr('display', 'inline-block');

    $('.tab-item-title').on('click', function () {
        $('.current').removeClass('current');
        $(this).parent().addClass('current');
    })
};