'use strict';

app.controller('HomeCtrl', ['$scope', 'notifier', 'trips', 'drivers', 'statistics', 'identity',
    function homeCtrl($scope, notifier, trips, drivers, statistics, identity) {

        getAvailableTrips();
        getLastRegisteredDrivers();
        getStatistics();

        function getAvailableTrips() {
            trips.getAvailableTrips().then(function (trips) {
                $scope.trips = trips;
                //filterTrips(trips);
                //console.log(trips);
            }, function (error) {
                
                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! Could not load trpis!');
                }
            });
        }

        function getLastRegisteredDrivers() {
            drivers.getRegisteredDrivers().then(function (drivers) {
                $scope.drivers = drivers;
                //filterDrivetrs(drivers);
                //console.log(drivers);
            }, function (error) {
                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! Could not load drivers!');
                }
            });
        }

        function getStatistics() {
            statistics.getStats().then(function (stats) {
                $scope.stats = stats;
                //filterStats(stats);
                //console.log(stats);
            }, function (error) {

                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! Could not load stats!');
                }
            });
        }
    }]);