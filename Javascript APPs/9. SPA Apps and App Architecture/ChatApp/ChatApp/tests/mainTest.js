(function () {
    require.config({
        paths: {
            "jquery": "../scripts/libs/jquery-2.1.1",
            "Q": "../scripts/libs/q.min",
            "mustache": "../scripts/libs/mustache",
            "sammy": "../scripts/libs/sammy-0.7.4",
            "httpRequester": "../scripts/httpRequestModule",
            "controller": "../scripts/controller",
            "ui": "../scripts/ui",
            "chai": "../scripts/libs/chai",
            "mocha": "../scripts/libs/mocha",
            "tests": "tests"
        }
    });

    require(['mocha', 'chai'], function () {
        mocha.setup('bdd');
        require(['tests'], function () {
            mocha.run();
        });
    })
}())