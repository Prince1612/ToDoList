(function () {
    'use strict';

    angular
        .module('app', ['ngRoute'])
        .config(configMethod);

    function configMethod($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'templates/notesView.html',
                controller: 'notesController as vm'
            })
            .when('/register', {
                //register page goes here...
                templateUrl: 'templates/register.html',
                controller: 'registerController as vm'
            })
            .when('/login', {
                //login page goes here...
                templateUrl: 'templates/loginHome.html',
                controller: 'loginController as vm'
            })
            .when('/addNotes', {
                templateUrl: 'templates/addNotes.html',
                controller: 'addNotesController as vm'
            })
            .when('/editNotes/:note', {
                templateUrl: 'templates/editNotes.html',
                controller: 'editNotesController as vm'
            })
            .otherwise('/');
    }

})();