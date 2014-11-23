'use strict';

app.controller('DriversCtrl', ['$scope', 'notifier', 'trips', 'drivers', 'statistics', 'identity',
    function DriversCtrl($scope, notifier, trips, drivers, statistics, identity) {

        $scope.isAuthenticated = identity.isAuthenticated();
        //console.log($scope.isAuthenticated);
        $scope.currentUser = identity.getCurrentUser();
        //console.log($scope.currentUser);

        $scope.page = 1;

        $scope.getRegisteredDriversByPage = function getRegisteredDriversByPage(page) {
            console.log(page);
            drivers.getRegisteredDriversByPage(page).then(function (drivers) {
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
        };

        if ($scope.isAuthenticated) {
            $scope.getRegisteredDriversByPage($scope.page);
        } else {
            getLastRegisteredDrivers();
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
        };
        
    }]);