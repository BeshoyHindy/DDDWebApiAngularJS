(function () {
    'use strict';

    angular
        .module('DirectivesModule')
        .directive('modal', modal);

    function modal() {
        var directive = {
            restrict: 'E',
            templateUrl: 'templates/modal.directive.html',
            controller: LayoutController,
            controllerAs: 'layoutCtrl'
        };

        return directive;
    }
})();