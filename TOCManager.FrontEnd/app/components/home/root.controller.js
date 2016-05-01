(function (app) {
	'use strict';

	app.controller('RootController', RootController);

	RootController.$inject = ['$scope', '$location', 'membershipService', '$rootScope'];

	function RootController($scope, $location, membershipService, $rootScope) {

		$scope.userData = {};

		$scope.userData.displayUserInfo = displayUserInfo;
		$scope.logout = logout;


		function displayUserInfo() {
			$scope.userData.isUserLoggedIn = membershipService.isUserLoggedIn();

			if ($scope.userData.isUserLoggedIn) {
				$scope.username = $rootScope.repository.loggedUser.username;
			}
		}

		function logout() {
			membershipService.removeCredentials();
			$location.path('#/');
			$scope.userData.displayUserInfo();
		}

		$scope.userData.displayUserInfo();
	}

})(angular.module('tocManager'));