(function () {
    'use strict';

    angular
        .module('app')          //servicio para el branch Office
        .factory('BranchOfficeService', BranchOfficeService);

    BranchOfficeService.$inject = ['$http', '$rootScope'];
    function BranchOfficeService($http, $rootScope) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.Read= Read;
        service.Update = Update;
        service.Delete = Delete;

        return service; //Todos los servicios expuestos en esta variable son accesados al inyectar esta dependencia
        
      /**
       *  Crea una nueva sucursal, por administracion
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
       *  Obtiene todas las sucursales existentes
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
       * Elimina un client 
       * 
       */
        function Delete(branchOfficeID) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"",
                data: {IdNumber:branchOfficeID}
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
