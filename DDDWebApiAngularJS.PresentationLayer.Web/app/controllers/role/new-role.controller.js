(function () {
    'use strict';

    angular
        .module('ControllersModule')
        .controller('NewRoleController', NewRoleController);

    NewRoleController.$inject = ['$location', 'LanguagesService', 'RoleService'];
    function NewRoleController($location, LanguagesService, RoleService) {
        var newRoleCtrl = this;

        newRoleCtrl.roleViewModel = {
            name: "",
            roleGroup: ""
        };
        newRoleCtrl.isSuccessfully = false;
        newRoleCtrl.message = "";
        newRoleCtrl.languages = LanguagesService;
        newRoleCtrl.create = create;

        ////////////

        function create() {
            if (newRoleCtrl.form.$valid) {
                RoleService.create(newRoleCtrl.roleViewModel).then(function (response) {
                    newRoleCtrl.isSuccessfully = true;
                    newRoleCtrl.message = response;
                    $location.path('/roles');
                }, function (response) {
                    newRoleCtrl.message = response.data;
                });
            } else {
                newRoleCtrl.message = LanguagesService.getValue('InvalidInformations');
            }
        }
    }
})();