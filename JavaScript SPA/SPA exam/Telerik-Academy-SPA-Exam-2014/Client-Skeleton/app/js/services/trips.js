'use strict';

app.factory('trips', ['$http', '$q', 'authorization', 'baseServiceUrl', 'notifier', function ($http, $q, authorization, baseServiceUrl, notifier) {

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
        },
        getTrips: function getTrips(sort, order, fromCity, toCity, page, finished, onlyMine) {
            var deferred = $q.defer();

            var tripsUrlParams = tripsUrl + '?';

            if (page) {
                tripsUrlParams += 'page=' + page + '&';
            }

            if (sort) {
                tripsUrlParams += 'orderBy=' + sort + '&';
            }

            if (order) {
                tripsUrlParams += 'orderType=' + order + '&';
            }

            if (fromCity) {
                tripsUrlParams += 'from=' + fromCity + '&';
            }

            if (toCity) {
                tripsUrlParams += 'to=' + toCity + '&';
            }

            if (finished) {
                tripsUrlParams += 'finished=true&';
            }

            if (onlyMine) {
                tripsUrlParams += 'finished=onlyMine';
            }

            //console.log(tripsUrlParams);

            if (tripsUrlParams[tripsUrlParams - 1] == '&') {
                tripsUrlParams = tripsUrlParams.substring(0, tripsUrlParams.length - 1);
            };

            //console.log(tripsUrlParams);

            var header = authorization.getAuthorizationHeader();

            $http.get(tripsUrlParams, { headers: header }).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });

            //api/trips?page=1&orderBy=seats&orderType=asc&from=Sofia&finished=true&onlyMine=false
            return deferred.promise;
        },
        getTripById: function getTripById(id) {
            var deferred = $q.defer();

            var tripDetailsUrl = tripsUrl + '/' + id;
            var header = authorization.getAuthorizationHeader();

            //console.log(tripDetailsUrl);

            $http.get(tripDetailsUrl, { headers: header }).
                success(function (data, status, headers, config) {
                    deferred.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        joinTripPut: function joinTripPut(id) {
            var deferred = $q.defer();

            var tripDetailsUrl = tripsUrl + '/' + id;
            var header = authorization.getAuthorizationHeader();
            var body = {};

            $http.put(tripDetailsUrl, body, { headers: header }).
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