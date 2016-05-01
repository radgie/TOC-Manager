(function () {
    'use strict';

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "index.html",
                controller: "indexCtrl"
            })
            .when("/login", {
                templateUrl: "app/components/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "app/components/account/register.html",
                controller: "registerCtrl"
            }).otherwise({ redirectTo: "/" });
    }

})();