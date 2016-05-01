(function (app) {
	'use strict';

	app.factory('notificationService', notificationService);

	function notificationService() {

		var service = {
			displaySuccess: displaySuccess,
			displayError: displayError,
			displayWarning: displayWarning,
			displayInfo: displayInfo
		};

		return service;

		function displaySuccess(message) {
		    $.Notify({
		        type: 'success',
		        caption: 'Success',
		        content: message,
		        icon: "<span class='mif-checkmark'></span>"
		    });
		}

		function displayError(error) {
			if (Array.isArray(error)) {
				error.forEach(function (err) {
				    $.Notify({
				        type: 'alert',
				        caption: 'Error',
				        content: err,
				        icon: "<span class='mif-notification'></span>"
				    });
				});
			} else {
			    $.Notify({
			        type: 'alert',
			        caption: 'Error',
			        content: error,
			        icon: "<span class='mif-notification'></span>"
			    });
			}
		}

		function displayWarning(message) {
		    $.Notify({
		        type: 'warning',
		        caption: 'Warning',
		        content: message,
		        icon: "<span class='mif-warning'></span>"
		    });
		}

		function displayInfo(message) {
		    $.Notify({
		        type: 'info',
		        caption: 'Info',
		        content: message,
		        icon: "<span class='mif-notification'></span>"
		    });
		}

	}

})(angular.module('common.core'));