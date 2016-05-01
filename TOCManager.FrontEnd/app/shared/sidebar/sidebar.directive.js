(function (app) {
    'use strict';

    app.directive('sidebar', sidebar);

    function sidebar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/app/shared/sidebar/sidebar.html'
        }
    }

})(angular.module('common.ui'));