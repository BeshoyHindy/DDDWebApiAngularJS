(function () {
    'use strict';

    angular
        .module('ServicesModule')
        .factory('RoleService', RoleService);

    RoleService.$inject = ['$http', 'RoleServiceBase'];
    function RoleService($http, RoleServiceBase) {
        var rolesServiceFactory = {
            getRoles : getRoles,
            create: create
        };
        return rolesServiceFactory;

        ////////////

        function getRoles() {
            return $http.get(RoleServiceBase).then(function (results) {
                return results;
            });
        };

        function create(roleViewModel) {
            return $http.post(RoleServiceBase + 'new', roleViewModel).then(function (response) {
                return response.data;
            });
        };
    }
})();