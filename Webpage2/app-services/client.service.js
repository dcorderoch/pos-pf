(function () {
    'use strict';

    angular
        .module('app')          //servicio para el client
        .factory('ClientService', ClientService);

    ClientService.$inject = ['$http', '$rootScope'];
    function ClientService($http, $rootScope) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.Read= Read;
        service.Update = Update;
        service.Delete = Delete;

        return service; //Todos los servicios expuestos en esta variable son accesados al inyectar esta dependencia
        
      /**
       *  Crea un nuevo cliente, por administracion
       * 
       */
        function Create(data) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"Api/Customer/Create",
                data: data
            });
            return response;    
        }
        
      /**
       *  Obtiene todos los clientes existentes
       *
       */      
        function Read() {
            var response=$http({
                method:"get",
                url:$rootScope.url+"Api/Customer/GetAll"
            });
            return response;    
        }
        
      /**
       * Elimina un client 
       * 
       */
        function Delete(ClientID) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"Api/Customer/Delete",
                data: {IDNumber:ClientID}
            });
            return response;    
        }
        
      /**
       *  Actualiza un cliente dado
       * 
       */
        function Update(data) {  
            var request = $http({
            method: "post",
            url: $rootScope.url+"Api/Customer/Update",
            data: data
        });
            return request;
        }
        

        // private functions

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

})();
