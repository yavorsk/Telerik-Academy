define(['jquery', 'mustache', 'Q'], function ($, mustache, Q) {
    var ui = (function () {

        var renderPosts = function (data) {
            var view = {
                postEntries: data
            };

            var template = $('#post-entries-template').html();

            var compiled = mustache.render(template, view);

            $('#posts').html(compiled);
        }

        return {
            renderPosts: renderPosts,
        };
    }());

    return ui;
})