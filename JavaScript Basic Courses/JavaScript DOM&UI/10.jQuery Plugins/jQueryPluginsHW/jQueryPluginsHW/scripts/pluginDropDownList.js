//Create a jQuery plugin for creating dropdown list
//<select id="dropdown">
//    <option value="1">One</option>
//    <option value="2">Two</option>
//</select>
//Produces the following HTML:
//<select id="dropdown" style="display: none">…</select>
//<div class="dropdown-list-container">
//    <ul class="dropdown-list-options">
//        <li class="dropdown-list-option" data-value="0">One</li>
//        …
//    </ul>
//</div>

//And make it work as SELECT node
//Selecting an one of the generated LI nodes, selects the corresponding OPTION node
//So $('#dropdown:selected') works

(function ($) {
    $.fn.transformDropDown = function () {
        var $this = $(this);
        $this.css('display', 'none');

        var $container = $('<div>').addClass('dropdown-list-container').appendTo('#wrapper');
        var $transformedList = $('<ul>').addClass('dropdown-list-options').appendTo($container);

        var $options = $this.children();

        for (var i = 0; i < $options.length; i++) {
            var str = $($options[i]).text();
            var $liItem = $('<li>' + str + '</li>');

            if ($($options[i]).is(':selected')) {
                $liItem.addClass('selected');
            }

            $liItem.addClass('dropdown-list-options').attr('data-value', $($options[i]).val()).appendTo($transformedList);
        }

        $('.dropdown-list-options li').on('click', function () {
            $('.selected').removeClass('selected');
            $(this).addClass('selected');
        })

        return $this;
    };
}(jQuery));

$('#dropdown').transformDropDown();