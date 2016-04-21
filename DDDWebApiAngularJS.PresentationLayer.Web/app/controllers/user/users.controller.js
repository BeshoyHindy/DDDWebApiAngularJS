(function () {
    'use strict';

    angular
        .module('ControllersModule')
        .controller('UsersController', UsersController);

    UsersController.$inject = ['LanguagesService', 'UserService'];
    function UsersController(LanguagesService, UserService) {
        var usersCtrl = this;

        usersCtrl.users = [];
        usersCtrl.languages = LanguagesService;

        activate();

        ////////////

        function activate() {
            return UserService.getUsers().then(function (results) {
                usersCtrl.users = results.data;
            }, function (error) {
                console.log(error.data.message);
            });
        }
    }
})();