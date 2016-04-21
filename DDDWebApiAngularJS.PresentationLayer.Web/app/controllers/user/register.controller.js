(function () {
    'use strict';

    angular
        .module('ControllersModule')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['$location', '$timeout', 'LanguagesService', 'AuthenticationService'];
    function RegisterController($location, $timeout, LanguagesService, AuthenticationService) {
        var registerCtrl = this;

        registerCtrl.registerViewModel = {
            name: "",
            email: "",
            password: "",
            confirmPassword: ""
        };
        registerCtrl.isSuccessfully = false;
        registerCtrl.message = "";
        registerCtrl.languages = LanguagesService;
        registerCtrl.register = register;

        ////////////

        function register() {
            if (registerCtrl.form.$valid && registerCtrl.registerViewModel.password == registerCtrl.registerViewModel.confirmPassword) {
                AuthenticationService.register(registerCtrl.registerViewModel).then(function (response) {
                    registerCtrl.isSuccessfully = true;
                    registerCtrl.message = response;
                    startTimer();
                }, function (response) {
                    registerCtrl.message = response.data;
                });
            } else {
                registerCtrl.message = LanguagesService.getValue('InvalidInformations');
            }
        };

        function startTimer() {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/login');
            }, 2000);
        }
    }
})();