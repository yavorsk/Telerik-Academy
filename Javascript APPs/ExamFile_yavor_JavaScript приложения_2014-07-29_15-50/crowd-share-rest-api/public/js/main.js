(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery-2.1.1",
            "Q": "libs/q.min",
            "mustache": "libs/mustache",
            "sammy": "libs/sammy-0.7.4",
            "httpRequester": "httpRequestModule",
            "underscore": "libs/underscore",
            "controller": "controller",
            "ui": "ui"
        }
    });

    require(["jquery", "sammy", "controller"], function ($, sammy, controller) {
        controller.attachEventHandlers();
        controller.renderPosts();

        var app = sammy('#wrapper', function () {

            this.get('#/main', function () {
                controller.loadMain();
            })

            this.get('#/register', function () {
                controller.loadRegister();
            })

            this.get('#/login', function () {
                controller.loadLogin();
            })

            this.get('#/session', function () {
                controller.loadSession();
            })
        });

        //if (sessionStorage.getItem('username')) {
        //    app.run("#/chatroom");
        //} else {
            app.run("#/main");
        //}
    })
}())