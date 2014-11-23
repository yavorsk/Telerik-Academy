define(function () {
    var combobox = function () {
        var container = document.querySelector('#dropDown-menu');
        var entries = container.querySelectorAll('.city-item');
        var hidden = true;

        var selectedDiv = document.querySelector('.selected');
        selectedDiv.innerHTML = entries[0].innerHTML;

        hideDivs(entries);

        selectedDiv.addEventListener('click', function () {
            if (hidden) {
                showDivs(entries);
                hidden = false;
            } else {
                hideDivs(entries);
                hidden = true;
            }
        })

        var handleSelected = function () {
            selectedDiv.innerHTML = this.innerHTML;
            hideDivs(entries);
        }

        for (var i = 0; i < entries.length; i++) {
            entries[i].addEventListener('click', handleSelected);
        }

        function hideDivs(collection) {
            for (var i = 0; i < collection.length; i++) {
                collection[i].style.display = 'none';
            }
        }

        function showDivs(collection) {
            for (var i = 0; i < collection.length; i++) {
                collection[i].style.display = '';
            }
        }
    }

    return combobox;
})