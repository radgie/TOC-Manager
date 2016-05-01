(function (app) {
    'use strict';

    app.directive('navbar', navbar);

    function navbar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/app/shared/navbar/navbar.html'
        }
    }

})(angular.module('common.ui'));