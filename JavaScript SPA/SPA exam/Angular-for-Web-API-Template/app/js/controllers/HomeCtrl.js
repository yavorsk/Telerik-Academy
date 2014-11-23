'use strict';

app.controller('HomeCtrl', ['$scope', 'notifier', 'trips', 'identity', 'notifications',
    function homeCtrl($scope, notifier, trips, identity, notifications) {

        getAvailableTrips();
        //getLastRegisteredDrivers();
        //getStatistics();

        console.log($scope.trips);

        function getAvailableTrips() {
            trips.getAvailableTrips().then(function (trips) {
                $scope.trips = trips;
                //filterTrips(trips);
            }, function (error) {
                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! Could not load trpis!');
                }
            });
        }

    }]);