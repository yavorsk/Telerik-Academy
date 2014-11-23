'use strict';

app.filter('isMine', function () {
    return function (input) {
        if (input) {
            return 'true';
        } else {
            return 'false';
        }
    };
});