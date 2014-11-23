'use strict';

app.controller('TripsCtrl', ['$scope', 'notifier', 'trips', 'drivers', 'statistics', 'identity', 'cities',
    function TripsCtrl($scope, notifier, trips, drivers, statistics, identity, cities) {

        $scope.isAuthenticated = identity.isAuthenticated();
        //console.log($scope.isAuthenticated);
        $scope.currentUser = identity.getCurrentUser();
        //console.log($scope.currentUser);

        getCities();

        if ($scope.isAuthenticated) {
            getAvailableTrips();
        } else {
            getAvailableTrips();
        }

        function getAvailableTrips() {
            trips.getAvailableTrips().then(function (trips) {
                $scope.trips = trips;
                //filterTrips(trips);
                console.log(trips);
            }, function (error) {

                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! Could not load trpis!');
                }
            });
        }

        $scope.getTripsParams = function () {
            //debugger;
            getTrips($scope.sort, $scope.order, $scope.fromCity, $scope.toCity, $scope.page, $scope.finished, $scope.onlyMine);

        };

        function getTrips(sort, order, fromCity, toCity, page, finished, onlyMine) {
            //console.log(page);
            trips.getTrips(sort, order, fromCity, toCity, page, finished, onlyMine).then(function (trips) {
                $scope.trips = trips;
                //filterDrivetrs(drivers);
                console.log(trips);
            }, function (error) {
                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! Could not load drivers!');
                }
            });
        };

        function getCities() {
            cities.getCities().then(function (cities) {
                $scope.cities = cities;
                //console.log(cities);
            }, function (error) {
                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! Could not load cities!');
                }
            });
        };
    }]);