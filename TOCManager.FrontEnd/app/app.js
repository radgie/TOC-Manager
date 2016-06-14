﻿(function () {
    'use strict';

    angular.module('tocManager', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "app/components/home/index.html",
                controller: "IndexController",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/login", {
                templateUrl: "app/components/account/login.html",
                controller: "LoginController"
            })
            .when("/register", {
                templateUrl: "app/components/account/register.html",
                controller: "RegisterController"
            }).otherwise({ redirectTo: "/" });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        //$(document).ready(function () {
        //    $(".fancybox").fancybox({
        //        openEffect: 'none',
        //        closeEffect: 'none'
        //    });

        //    $('.fancybox-media').fancybox({
        //        openEffect: 'none',
        //        closeEffect: 'none',
        //        helpers: {
        //            media: {}
        //        }
        //    });

        //    $('[data-toggle=offcanvas]').click(function () {
        //        $('.row-offcanvas').toggleClass('active');
        //    });
        //});
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();


//(function () {
//    'use strict';

//    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

//    function run($rootScope, $location, $cookieStore, $http) {
//        // handle page refreshes
//        $rootScope.repository = $cookieStore.get('repository') || {};
//        if ($rootScope.repository.loggedUser) {
//            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
//        }

//        $(document).ready(function () {
//            $(".fancybox").fancybox({
//                openEffect: 'none',
//                closeEffect: 'none'
//            });

//            $('.fancybox-media').fancybox({
//                openEffect: 'none',
//                closeEffect: 'none',
//                helpers: {
//                    media: {}
//                }
//            });

//            $('[data-toggle=offcanvas]').click(function () {
//                $('.row-offcanvas').toggleClass('active');
//            });
//        });
//    }

//    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

//    function isAuthenticated(membershipService, $rootScope, $location) {
//        if (!membershipService.isUserLoggedIn()) {
//            $rootScope.previousState = $location.path();
//            $location.path('/login');
//        }
//    }
//})();