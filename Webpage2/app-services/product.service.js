(function () {
    'use strict';

    angular
        .module('app')          //servicio para el client
        .factory('ProductService', ProductService);

    ProductService.$inject = ['$http', '$rootScope'];
    function ProductService($http, $rootScope) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.Read= Read;
        service.Update = Update;
        service.Delete = Delete;

        return service; //Todos los servicios expuestos en esta variable son accesados al inyectar esta dependencia
        
      /**
       *  Crea un nuevo producto, por administracion
       * 
       */
        function Create(data) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"Api/Product/Create",
                data: data
            });
            return response;    
        }
        
      /**
       *  Obtiene todos los producto existentes
       *
       */      
        function Read() {
            var response=$http({
                method:"get",
                url:$rootScope.url+"Api/Product/GetAll"
            });
            return response;    
        }
        
      /**
       * Elimina un producto 
       * 
       */
        function Delete(productID) {
            var response=$http({
                method:"post",
                url: $rootScope.url+"Api/Product/Delete",
                data: {EAN:productID}
            });
            return response;    
        }
        
      /**
       *  Actualiza un producto dado
       * 
       */
        function Update(data) {  
            var request = $http({
            method: "post",
            url: $rootScope.url+"Api/Product/Update",
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
