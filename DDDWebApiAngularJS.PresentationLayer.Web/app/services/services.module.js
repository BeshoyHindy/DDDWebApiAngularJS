(function () {
    'use strict';

    angular
        .module('ServicesModule', ['LocalStorageModule']);

    ////////////

    angular
        .module('ServicesModule')
        .factory('ServiceBase', ServiceBase);

    function ServiceBase() {
        return 'http://localhost:51228/api/';
    }

    ////////////

    angular
        .module('ServicesModule')
        .factory('LanguagesServiceBase', LanguagesServiceBase);

    LanguagesServiceBase.$inject = ['ServiceBase'];
    function LanguagesServiceBase(ServiceBase) {
        return ServiceBase + 'languages/';
    }

    ////////////

    angular
        .module('ServicesModule')
        .factory('UserServiceBase', UserServiceBase);

    UserServiceBase.$inject = ['ServiceBase'];
    function UserServiceBase(ServiceBase) {
        return ServiceBase + 'users/';
    }

    ////////////

    angular
        .module('ServicesModule')
        .factory('RoleServiceBase', RoleServiceBase);

    RoleServiceBase.$inject = ['ServiceBase'];
    function RoleServiceBase(ServiceBase) {
        return ServiceBase + 'roles/';
    }
})();