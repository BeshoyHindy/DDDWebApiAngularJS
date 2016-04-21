(function () {
    'use strict';

    angular
        .module('AppModule')
        .config(AppConfig);

    AppConfig.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider', '$httpProvider'];
    function AppConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
        //push interceptor to the interceptors array
        $httpProvider.interceptors.push('AuthenticationInterceptorService');

        //default route
        $urlRouterProvider.otherwise('/');

        //home routes
        $stateProvider.state('/', {
            url: '/',
            templateUrl: 'views/home/home.html',
            controller: 'HomeController',
            controllerAs: 'homeCtrl'
        });

        //user routes
        $stateProvider.state('users', {
            url: '/users',
            templateUrl: 'views/user/list.html',
            controller: 'UsersController',
            controllerAs: 'usersCtrl'
        }).state('users/login', {
            url: '/users/login',
            templateUrl: 'views/user/login.html',
            controller: 'LoginController',
            controllerAs: 'loginCtrl'
        }).state('users/register', {
            url: '/users/register',
            templateUrl: 'views/user/register.html',
            controller: 'RegisterController',
            controllerAs: 'registerCtrl'
        }).state('users/profile', {
            url: '/users/profile',
            templateUrl: 'views/user/profile.html',
            controller: 'ProfileController',
            controllerAs: 'profileCtrl'
        });

        //role routes
        $stateProvider.state('roles', {
            url: '/roles',
            templateUrl: 'views/role/list.html',
            controller: 'RolesController',
            controllerAs: 'rolesCtrl'
        }).state('roles/new', {
            url: '/roles/new',
            templateUrl: 'views/role/new.html',
            controller: 'NewRoleController',
            controllerAs: 'newRoleCtrl'
        });

        //using HTML5 History API
        $locationProvider.html5Mode(true);
    }
})();