(function () {
    'use strict';

    angular
        .module('ControllersModule')
        .controller('RolesController', RolesController);

    RolesController.$inject = ['LanguagesService', 'RoleService'];
    function RolesController(LanguagesService, RoleService) {
        var rolesCtrl = this;

        rolesCtrl.roles = [];
        rolesCtrl.languages = LanguagesService;

        activate();

        ////////////

        function activate() {
            return RoleService.getRoles().then(function (results) {
                rolesCtrl.roles = results.data;
            }, function (error) {
                console.log(error.data);
            });
        }
    }
})();