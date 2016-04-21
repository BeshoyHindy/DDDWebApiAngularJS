(function () {
    'use strict';

    angular
        .module('ServicesModule')
        .factory('AuthenticationService', AuthenticationService);

    AuthenticationService.$inject = ['$http', '$q', 'localStorageService', 'UserServiceBase', 'UserService'];
    function AuthenticationService($http, $q, localStorageService, UserServiceBase, UserService) {
        var authentication = {
            isAuthenticated: false,
            name: "",
            email: "",
            roles: []
        };
        var authenticationServiceFactory = {
            register: register,
            login: login,
            logout: logout,
            fillAuthData: fillAuthData,
            authentication: authentication
        };
        return authenticationServiceFactory;

        ////////////

        function register(registerViewModel) {
            logout();

            return $http.post(UserServiceBase + 'register', registerViewModel).then(function (response) {
                var loginViewModel = {};
                loginViewModel.email = registerViewModel.email;
                loginViewModel.password = registerViewModel.password;
                login(loginViewModel);

                return response.data;
            });
        };

        function login(loginViewModel) {
            var data = "grant_type=password&username=" + loginViewModel.email + "&password=" + loginViewModel.password;

            var deferred = $q.defer();

            $http.post(UserServiceBase + 'login', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                localStorageService.set('authorizationData', { token: response.access_token, email: loginViewModel.email });

                authentication.isAuthenticated = true;
                authentication.email = loginViewModel.email;

                deferred.resolve(response);

                UserService.getName(loginViewModel.email).then(function (name) {
                    authentication.name = name;
                });

                UserService.getRoles(loginViewModel.email).then(function (roles) {
                    if (roles != [])
                        for (var i = 0; i < roles.length; i++)
                            authentication.roles.push(roles[i]);
                });
            }).error(function (response, status) {
                logout();

                deferred.reject(response);
            });

            return deferred.promise;
        };

        function logout() {
            localStorageService.remove('authorizationData');

            authentication.isAuthenticated = false;
            authentication.name = "";
            authentication.email = "";
            authentication.roles = [];
        };

        function fillAuthData() {
            var authData = localStorageService.get('authorizationData');

            if (authData) {
                authentication.isAuthenticated = true;
                authentication.email = authData.email;
            }
        }
    }
})();