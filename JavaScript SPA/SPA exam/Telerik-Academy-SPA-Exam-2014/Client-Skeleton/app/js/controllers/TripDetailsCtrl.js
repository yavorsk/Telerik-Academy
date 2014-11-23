'use strict';

app.controller('TripDetailsCtrl', ['$scope', '$routeParams', 'notifier', 'trips', 'identity',
    function TripDetailsCtrl($scope, $routeParams, notifier, trips, identity) {

        getTripDetails($routeParams.id);

        console.log($scope.trip);

        $scope.joinTrip = function () {
            if ($scope.trip.numberOfFreeSeats > 0) {
                joinTheTrip($routeParams.id);
            } else {
                notifier.error('No Free seats available!')
            }
        };

        function getTripDetails(id) {
            trips.getTripById(id).then(function (trip) {
                $scope.trip = trip;
                //filterDrivetrs(driver);
                //console.log(trip);
            }, function (error) {
                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! Could not load trip details!');
                }
            });
        };

        function joinTheTrip(id) {
            //debugger;
            trips.joinTripPut(id).then(function (response) {
                console.log('response' + response);
                notifier.success("Trip successfully joined!")
            }, function (error) {
                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! There waas an error!');
                }
            });
        }
    }]);