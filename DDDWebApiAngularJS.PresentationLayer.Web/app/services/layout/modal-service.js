(function () {
    'use strict';

    angular
        .module('ServicesModule')
        .factory('ModalService', ModalService);

    ModalService.$inject = ['LanguagesService'];
    function ModalService(LanguagesService) {
        var modalServiceFactory = {
            title: '',
            message: '',
            show: false
        };
        return modalServiceFactory;
    }
})();