'use strict';

app.factory('cities', ['$http', '$q', 'authorization', 'baseServiceUrl', 'notifier', function ($http, $q, authorization, baseServiceUrl, notifier) {

    var citiesUrl = baseServiceUrl + '/api/cities';

    return {
        getCities: function getCities() {
            var deferred = $q.defer();

            $http({ method: 'GET', url: citiesUrl }).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });

            return deferred.promise;
        }
    }
}]);