(function () {
    'use strict';

    angular
        .module('app')   //Pertenece al modulo app de app.js
        .controller('LoginController', LoginController);//Nombre del controlador, se debe poner 2 veces.


//Injeccion de dependencias: Location: para URL, AuthenServ.. $scope se utiliza para variables locales que se pueden 
//usar en la vista tambien. http es lo de rest. 
    LoginController.$inject = ['$location', 'AuthenticationService', 'FlashService','$scope','$http', '$rootScope'];
    function LoginController($location, AuthenticationService, FlashService, $scope, $http, $rootScope) {

        var vm = this; //se pueden utilizar objetos y variables de las inyecciones en la vista
        $scope.login = login;
        $scope.loginData={};


        initController();
        function initController() { // Se inicializa el servicio de limpiar credenciales en AuthenticationService       
            AuthenticationService.ClearCredentials();
  
        }//Estos parentesis del final indican que esto se inicia automaticamente

        /**
         * Login seleccionando un rol
         * Se guardan los valores importantes del usuario como nombre e id
         */
        function login() {
    
            $scope.loginData.Role="2";
            console.log($scope.loginData);
            AuthenticationService.Login( $scope.loginData)
                .then(function(response){

                if (response.data.UserId=== "0" ){
                    FlashService.Error("Amdmin no existe");//errores
                    $scope.dataLoading = false;
                }
                else{
                    $location.path('/');    
                    $rootScope.userId= response.data.UserId;
                    $rootScope.employeeName = response.data.Name;   //possibly needs a change
                    console.log($rootScope.userId);
                }
                },function(response){
                console.log( $rootScope.adminName);
                    FlashService.Error("Admin no existe");//errores
                    $scope.dataLoading = false;
            });                   
        } 
    }
}) ();