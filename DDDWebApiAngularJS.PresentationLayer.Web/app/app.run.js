(function () {
    'use strict';

    angular
        .module('AppModule')
        .run(AppRun);

    AppRun.$inject = ['AuthenticationService'];
    function AppRun(AuthenticationService) {
        AuthenticationService.fillAuthData();
    }
})();