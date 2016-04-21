(function () {
    'use strict';

    angular
        .module('ServicesModule')
        .factory('AuthenticationInterceptorService', AuthenticationInterceptorService);

    AuthenticationInterceptorService.$inject = ['$q', '$location', 'localStorageService'];
    function AuthenticationInterceptorService($q, $location, localStorageService) {
        var authenticationInterceptorServiceFactory = {
            request: request,
            responseError: responseError
        };
        return authenticationInterceptorServiceFactory;

        ////////////

        function request(config) {
            config.headers = config.headers || {};

            var authorizationData = localStorageService.get('authorizationData');

            if (authorizationData)
                config.headers.Authorization = 'Bearer ' + authorizationData.token;

            return config;
        }

        function responseError(rejection) {
            if (rejection.status === 401)
                $location.path('users/login');

            return $q.reject(rejection);
        }
    }
})();