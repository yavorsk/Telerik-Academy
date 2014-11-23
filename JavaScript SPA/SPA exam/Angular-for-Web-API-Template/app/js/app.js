'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function ($routeProvider) {

        function validateAuthentication(identity, notifier) {
            if (!identity.isAuthenticated()) {
                window.location = '#/unauthorized';
                notifier.error('You need to log in first!')
            }
        }

        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'HomeCtrl'
            })
            .when('/unauthorized', {
                templateUrl: 'views/partials/unauthorized.html'
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/drivers', {
                templateUrl: 'views/partials/drivers.html',
                controller: 'DriversCtrl'
            })
            .when('/drivers/:id', {
                templateUrl: 'views/partials/drivers.html',
                controller: 'DriversCtrl',
                resolve: { authentication: validateAuthentication }
            })
            .when('/trips', {
                templateUrl: 'views/partials/trips.html',
                controller: 'TripsCtrl'
            })
            .when('/trips/create', {
                templateUrl: 'views/partials/tripsCreate.html',
                controller: 'TripsCtrl',
                resolve: { authentication: validateAuthentication }
            })
            .when('/trips:id', {
                templateUrl: 'views/partials/trips.html',
                controller: 'TripsCtrl',
                resolve: { authentication: validateAuthentication }
            })
            .otherwise({ redirectTo: '/' });
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com');

//'http://spa2014.bgcoder.com'