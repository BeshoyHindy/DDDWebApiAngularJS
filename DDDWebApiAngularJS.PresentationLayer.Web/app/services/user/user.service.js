(function () {
    'use strict';

    angular
        .module('ServicesModule')
        .factory('UserService', UserService);

    UserService.$inject = ['$http', 'UserServiceBase'];
    function UserService($http, UserServiceBase) {
        var usersServiceFactory = {
            getUsers: getUsers,
            getName: getName,
            getRoles: getRoles
        };
        return usersServiceFactory;

        ////////////

        function getUsers() {
            return $http.get(UserServiceBase).then(function (results) {
                return results;
            });
        };

        function getName(email) {
            return $http.get(UserServiceBase + 'name?email=' + email).then(function (result) {
                return result.data;
            });
        }

        function getRoles(email) {
            return $http.get(UserServiceBase + 'roles?email=' + email).then(function (result) {
                return result.data;
            });
        }
    }
})();