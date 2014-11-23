'use strict';

app.controller('DriverDetailsCtrl', ['$scope', '$routeParams', 'notifier', 'drivers', 'identity',
    function DriverDetailsCtrl($scope, $routeParams, notifier, drivers, identity) {

        getDriverDetails($routeParams.id);
        
        function getDriverDetails(id) {
            drivers.getDriverById(id).then(function (driver) {
                $scope.driver = driver;
                //filterDrivetrs(driver);
                console.log(driver);
            }, function (error) {
                if (error.data.Message) {
                    notifier.error(error.data.Message);
                }
                else {
                    notifier.error('Sorry! Could not load driver details!');
                }
            });
        };

        $scope.isMineChecked = false;

        $scope.isMinecheckedFunc = function () {
            console.log($scope.isMineChecked);
        }
    }]);