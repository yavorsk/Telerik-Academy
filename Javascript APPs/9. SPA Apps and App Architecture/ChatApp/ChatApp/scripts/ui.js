define(['jquery', 'mustache', 'Q'], function ($, mustache, Q) {
    var ui = (function () {

        var renderChat = function (data) {
            var timmedData = data.slice(data.length - 200);

            var view = {
                chatEntries: timmedData
            };

            var template = $('#chat-entries-template').html();

            var compiled = mustache.render(template, view);

            return compiled;
        }

        var sumTwoNumbers = function (a, b) {
            var result = a + b;
            return result;
        }

        return {
            renderChat: renderChat,
            sum: sumTwoNumbers
        };
    }());

    return ui;
})