(function () {
    'use strict';

    angular
        .module('app')          //servicio para el client
        .factory('ProviderService', ProviderService);

    ProviderService.$inject = ['$http', '$rootScope'];
    function ProviderService($http, $rootScope) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.Read= Read;
        service.Update = Update;
        service.Delete = Delete;

        return service; //Todos los servicios expuestos en esta variable son accesados al inyectar esta dependencia
        
      /**
       *  Crea un nuevo proveedor, por administracion
       * 
       */
        function Create(data) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"X",
                data: data
            });
            return response;    
        }
        
      /**
       *  Obtiene todos los proveedores existentes
       *
       */      
        function Read() {
            var response=$http({
                method:"post",
                url:$rootScope.url+"X"
            });
            return response;    
        }
        
      /**
       * Elimina un proveedor 
       * 
       */
        function Delete(providerID) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"",
                data: {IdNumber:providerID}
            });
            return response;    
        }
        
      /**
       *  Actualiza un proveedor dado
       * 
       */
        function Update(data) {  
            var request = $http({
            method: "post",
            url: $rootScope.url+"X",
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
