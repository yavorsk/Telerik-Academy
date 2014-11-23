var httpRequester = (function () {
    var getHttpRequest, httpRequester;

    getHttpRequest = (function () {
        var xmlHttpFactories;
        xmlHttpFactories = [
          function () {
              return new XMLHttpRequest();
          }, function () {
              return new ActiveXObject("Msxml3.XMLHTTP");
          }, function () {
              return new ActiveXObject("Msxml2.XMLHTTP.6.0");
          }, function () {
              return new ActiveXObject("Msxml2.XMLHTTP.3.0");
          }, function () {
              return new ActiveXObject("Msxml2.XMLHTTP");
          }, function () {
              return new ActiveXObject("Microsoft.XMLHTTP");
          }
        ];
        return function () {
            var xmlFactory, _i, _len;
            for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                xmlFactory = xmlHttpFactories[_i];
                try {
                    return xmlFactory();
                } catch (_error) {

                }
            }
            return null;
        };
    })();

    httpRequester = (function () {
        var execRequest = function (options) {
            var httpRequest, requestUrl, type, contentType, accept, data, deferred;

            deferred = Q.defer();

            httpRequest = getHttpRequest();

            options = options || {};
            requestUrl = options.url;
            type = options.type || 'GET';
            contentType = options.contentType || '';
            accept = options.accept || '';
            data = options.data || null;

            httpRequest.onreadystatechange = function () {
                if (httpRequest.readyState === 4) {
                    switch (Math.floor(httpRequest.status / 100)) {
                        case 2:
                            deferred.resolve(httpRequest.responseText);
                            break;
                        default:
                            deferred.reject(httpRequest.responseText);
                            break;
                    }
                }
            };

            httpRequest.open(type, requestUrl, true);
            httpRequest.setRequestHeader('Content-Type', contentType);
            httpRequest.setRequestHeader('Accept', accept);
            httpRequest.send(data);

            return deferred.promise;
        };

        var getJSONreq = function (url, headers) {
            var options = {
                url: url,
                type: 'GET',
                contentType: headers.contentType,
                accept: headers.accept
            };

            return execRequest(options);
        };

        var postJSONreq = function (url, headers, data) {
            var options = {
                url: url,
                type: 'POST',
                contentType: headers.contentType,
                accept: headers.accept,
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
}());