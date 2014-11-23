(function () {
    require.config({
        paths: {
            'handlebars': 'libs/handlebars-v1.3.0',
            'combobox': 'combobox',
            'templateEngine': 'templateEngine'
        }
    });

    require(['templateEngine', 'combobox'], function (TemplateEngine, combobox) {

        var cities = [{
            id: 1,
            name: 'Burgas',
            country: 'Bulgaria',
            cityUrl: 'images/burgas.jpg'
        },{
            id: 2,
            name: 'Dubai',
            country: 'UAE',
            cityUrl: 'images/dubai.jpg'
        },{
            id: 3,
            name: 'London',
            country: 'United Kingdom',
            cityUrl: 'images/london.jpg'
        },{
            id: 4,
            name: 'New York',
            country: 'USA',
            cityUrl: 'images/newyork.jpg'
        },{
            id: 5,
            name: 'Paris',
            country: 'France',
            cityUrl: 'images/paris.jpg'
        },{
            id: 6,
            name: 'Varna',
            country: 'Bulgaria',
            cityUrl: 'images/varna.jpg'
        }];

        var engine = new TemplateEngine('#city-template', cities);

        var dropDownMenu = engine.getDropDown();

        var container = document.getElementById('wrapper');
        container.appendChild(dropDownMenu);

        combobox();

    })
}());