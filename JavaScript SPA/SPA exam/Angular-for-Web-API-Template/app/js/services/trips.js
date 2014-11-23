'use strict';

app.factory('trips', ['$http', '$q', 'authorization', 'baseServiceUrl', 'notifier', function GamesInfo($http, $q, authorization, baseServiceUrl, notifier) {

    var tripsUrl = baseServiceUrl + '/api/trips';

    return {
        getAvailableTrips: function getAvailableTrips() {
            var deferred = $q.defer();

            $http({ method: 'GET', url: tripsUrl }).
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