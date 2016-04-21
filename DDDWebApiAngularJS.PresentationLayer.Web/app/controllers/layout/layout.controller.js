(function () {
    'use strict';

    angular
        .module('ControllersModule')
        .controller('LayoutController', LayoutController);

    LayoutController.$inject = ['$location', 'LanguagesService', 'AuthenticationService'];
    function LayoutController($location, LanguagesService, AuthenticationService) {
        var layoutCtrl = this;

        layoutCtrl.date = new Date;
        //layoutCtrl.modalTitle = "Teste";
        //layoutCtrl.modalMessage = "TesteMessage";
        //layoutCtrl.modalShow = true;
        layoutCtrl.authentication = AuthenticationService.authentication;
        layoutCtrl.languages = LanguagesService;
        layoutCtrl.logout = logout;

        ////////////

        function logout() {
            AuthenticationService.logout();

            $location.path('/');
        }
    }
})();