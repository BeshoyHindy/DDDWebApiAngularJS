(function () {
    'use strict';

    angular
        .module('ServicesModule')
        .factory('LanguagesService', LanguagesService);

    LanguagesService.$inject = ['$http', 'LanguagesServiceBase'];
    function LanguagesService($http, LanguagesServiceBase) {
        var languages = [];
        var languagesServiceFactory = {
            getValue: getValue
        };
        getLanguages();
        return languagesServiceFactory;

        ////////////

        function getValue(key) {
            for (var i = 0; i < languages.length; i++)
                if (languages[i].Key == key)
                    return languages[i].Value;
        };

        function getLanguages() {
            return $http.get(LanguagesServiceBase).success(function (result) {
                languages = result;
            });
        }
    }
})();