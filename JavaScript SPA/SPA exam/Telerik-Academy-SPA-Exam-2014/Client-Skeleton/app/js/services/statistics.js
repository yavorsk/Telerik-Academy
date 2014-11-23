'use strict';

app.factory('statistics', ['$http', '$q', 'authorization', 'baseServiceUrl', 'notifier', function ($http, $q, authorization, baseServiceUrl, notifier) {

    var statsUrl = baseServiceUrl + '/api/stats';

    return {
        getStats: function getStats() {
            var deferred = $q.defer();

            $http({ method: 'GET', url: statsUrl }).
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