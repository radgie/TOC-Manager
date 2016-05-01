(function (app) {
    'use strict';

    app.controller('IndexController', IndexController);

    IndexController.$inject = ['$scope', 'apiService', 'notificationService'];

    function IndexController($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home';
        $scope.loadingMovies = true;
        $scope.loadingGenres = true;
        $scope.isReadOnly = true;
    }

})(angular.module('tocManager'));