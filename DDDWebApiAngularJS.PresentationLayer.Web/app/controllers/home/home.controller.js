(function () {
    'use strict';

    angular
        .module('ControllersModule')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['LanguagesService'];
    function HomeController(LanguagesService) {
        var homeCtrl = this;

        homeCtrl.languages = LanguagesService;
    }
})();