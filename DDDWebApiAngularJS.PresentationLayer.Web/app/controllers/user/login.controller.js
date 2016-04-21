(function () {
    'use strict';

    angular
        .module('ControllersModule')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', 'LanguagesService', 'AuthenticationService'];
    function LoginController($location, LanguagesService, AuthenticationService) {
        var loginCtrl = this;

        loginCtrl.loginViewModel = {
            email: "",
            password: ""
        };
        loginCtrl.message = "";
        loginCtrl.languages = LanguagesService;
        loginCtrl.login = login;

        ////////////

        function login() {
            if (loginCtrl.form.$valid) {
                AuthenticationService.login(loginCtrl.loginViewModel).then(function (response) {
                    $location.path('/');
                }, function (error) {
                    loginCtrl.message = error.error_description;
                });
            } else {
                loginCtrl.message = LanguagesService.getValue('InvalidInformations');
            }
        }
    }
})();