(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery-2.1.1",
            "Q": "libs/q.min",
            "mustache": "libs/mustache",
            "sammy": "libs/sammy-0.7.4",
            "httpRequester": "httpRequestModule",
            "controller": "controller",
            "ui": "ui"
        }
    });

    require(["jquery", "sammy", "controller"], function ($, sammy, controller) {
        controller.attachEventHandlers();

        var app = sammy('#main-content', function () {

            this.get('#/login', function () {
                controller.loadLogin();
            })

            this.get('#/chatroom', function () {
                controller.loadChatroom();
            })
        });

        if (sessionStorage.getItem('username')) {
            app.run("#/chatroom");
        } else {
            app.run("#/login");
        }
    })
}())