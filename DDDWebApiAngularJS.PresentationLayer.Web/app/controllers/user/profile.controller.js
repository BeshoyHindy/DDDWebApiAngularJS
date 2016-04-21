(function () {
    'use strict';

    angular
        .module('ControllersModule')
        .controller('ProfileController', ProfileController);

    ProfileController.$inject = ['LanguagesService', 'UserService'];
    function ProfileController(LanguagesService, UserService) {
        var profileCtrl = this;

        profileCtrl.user = {};
        profileCtrl.message = "";
        profileCtrl.languages = LanguagesService;

        //activate();

        ////////////

        //function activate() {
        //    return userService.getUser().then(function (result) {
        //        profileCtrl.user = result.data;
        //    }, function (error) {
        //        console.log(error.data.message);
        //    });
        //}
    }
})();