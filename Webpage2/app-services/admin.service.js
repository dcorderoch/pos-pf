(function () {
    'use strict';

    angular
        .module('app')          //servicio para el administrador
        .factory('AdminService', AdminService);

    AdminService.$inject = ['$http', '$rootScope'];
    function AdminService($http, $rootScope) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.Read= Read;
        service.Update = Update;
        service.Delete = Delete;

        return service; //Todos los servicios expuestos en esta variable son accesados al inyectar esta dependencia
        
      /**
       *  Crea un nuevo administrador, por administracion
       * 
       */
        function Create(data) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"Api/Staff/Create",
                data: data
            });
            return response;    
        }
        
      /**
       *  Obtiene todos los admins existentes
       *
       */      
        function Read() {
            var response=$http({
                method:"get",
                url:$rootScope.url+"Api/Staff/GetAll"
            });
            return response;    
        }
        
      /**
       * Elimina un client 
       * 
       */
        function Delete(AdminID) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"Api/Staff/Delete",
                data: {StaffID:AdminID}
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
            url: $rootScope.url+"Api/Staff/Update",
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
