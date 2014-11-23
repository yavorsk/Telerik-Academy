define(['jquery', 'Q'], function ($, Q) {
    var httpRequester = (function () {

        var execRequest = function (options) {
            var requestUrl, type, data, deferred;

            deferred = Q.defer();

            options = options || {};
            requestUrl = options.url;
            type = options.type || 'GET';
            data = options.data || null;

            $.ajax({
                url: requestUrl,
                type: type,
                data: data,
                contentType: 'application/json',
                dataType: 'json',
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (err) {
                    deferred.reject(err);

                }
            })

            return deferred.promise;
        };

        var getJSONreq = function (url) {
            var options = {
                url: url,
                type: 'GET'
            };

            return execRequest(options);
        };

        var postJSONreq = function (url, data) {
            var options = {
                url: url,
                type: 'POST',
                data: JSON.stringify(data)
            };

            return execRequest(options);
        };

        return {
            getJSON: getJSONreq,
            postJSON: postJSONreq
        };
    }());

    return httpRequester;
})