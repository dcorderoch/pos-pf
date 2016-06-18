(function () {
    'use strict';

    angular
        .module('app')          //servicio para el client
        .factory('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['$http', '$rootScope'];
    function EmployeeService($http, $rootScope) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.Read= Read;
        service.Update = Update;
        service.Delete = Delete;

        return service; //Todos los servicios expuestos en esta variable son accesados al inyectar esta dependencia
        
      /**
       *  Crea un nuevo empleado, por administracion
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
       *  Obtiene todos los empleado existentes
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
       * Elimina un empleado 
       * 
       */
        function Delete(EmployeeID) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"",
                data: {IdNumber:EmployeeID}
            });
            return response;    
        }
        
      /**
       *  Actualiza un empleado dado
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
