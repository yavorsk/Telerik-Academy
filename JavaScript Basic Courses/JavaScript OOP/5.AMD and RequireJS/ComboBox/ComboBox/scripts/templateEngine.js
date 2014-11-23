define(['handlebars'], function () {
    var TemplateEngine = function (templateIdSelector, data) {
        var templateHTML = document.querySelector(templateIdSelector).innerHTML;
        var template = Handlebars.compile(templateHTML);

        var container = document.createElement('DIV');
        container.id = 'dropDown-menu'

        for (var i = 0; i < data.length; i++) {
            container.innerHTML += template(data[i]);
        }

        return {
            getDropDown: function () {
                return container;
            }
        }
    }

    return TemplateEngine;
})