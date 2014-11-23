'use strict';

app.factory('drivers', ['$http', '$q', 'authorization', 'baseServiceUrl', 'notifier', function ($http, $q, authorization, baseServiceUrl, notifier) {

    var driversUrl = baseServiceUrl + '/api/drivers';

    return {
        getRegisteredDrivers: function getRegisteredDrivers() {
            var deferred = $q.defer();

            $http({ method: 'GET', url: driversUrl }).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        getRegisteredDriversByPage: function getRegisteredDriversByPage(page) {
            var deferred = $q.defer();

            var driversPageUrl = driversUrl + '?page=' + page;
            var header = authorization.getAuthorizationHeader();

            console.log(driversPageUrl);

            $http.get(driversPageUrl, { headers: header }).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        getDriverById: function getDriverById(id) {
            var deferred = $q.defer();

            var driverDetailsUrl = driversUrl + '/' + id;
            var header = authorization.getAuthorizationHeader();

            console.log(driverDetailsUrl);

            $http.get(driverDetailsUrl, {headers: header}).
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