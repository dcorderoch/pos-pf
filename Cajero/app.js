(function () {
    'use strict';
 //El modulo principal del proyecto
    angular
        .module('app', ['ngRoute', 'ngCookies'])//se llama a ngRoute routeo entre paginas, ngCookies para cookies)
        .config(config)   //funcion de config se llama de primero, no hay que cambiarlo
        .run(run);
      //la funcion run se llama de primero tambien, no hay que cambiarlo
    config.$inject = ['$routeProvider', '$locationProvider'];
    function config($routeProvider, $locationProvider) {  //Inyectar dependencias de routeProvider y locationProvider 
        $routeProvider
                                      //un alias del controlador, vm significa view model

            .when('/', {
                controller: 'PosController',//esta es la extension de url que sucede cuando se esta en el HomeController
                templateUrl: 'pos/pos.view.html',  //El controlador de este when home.controller.js
                controllerAs: 'vm'     //Vista es el archivo home/home.view.html
            })     
            .when('/purchase', {
                controller: 'PurchaseController',
                templateUrl: 'purchase/purchase.view.html',
                controllerAs: 'vm'
            })
           .when('/login', {
                controller: 'LoginController',
                templateUrl: 'login/login.view.html',
                controllerAs: 'vm'
            })
            .otherwise({ redirectTo: '/login' });//Esta es la url por defecto
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];  //cosas que se corren al comienzo del proyecto
    function run($rootScope, $location, $cookieStore, $http) {      //no hay que modificar esto
        // Mantener al usuario logeado cuando se refresca la pagina
        $rootScope.url="http://mdphischel-dev.azurewebsites.net/";
        $rootScope.globals = $cookieStore.get('globals') || {}; // Se mantiene el usuario
        if ($rootScope.globals.currentUser) {                            // se crean las cookies
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
        //     Redirige a la pagina de login cuando se intenta hacer trampa (Watch out evil-doers)
//            var restrictedPage = $.inArray($location.path(), ['/login']) === -1;
//            var loggedIn = $rootScope.globals.currentUser;
//            if (restrictedPage && !loggedIn) {
//                $location.path('/login');
//            }//Si intenta meterse en una pagina restringida
            // redirect to login page if not logged in and trying to access a restrictedPage page
        });
    }

})();