(function () {
    'use strict';

    angular
        .module('app')          //servicio para el cajero
        .factory('CashierService', CashierService);

    CashierService.$inject = ['$http', '$rootScope'];
    function CashierService($http, $rootScope) {
        
        var service = {};

        service.StartTransaction = StartTransaction;    //de esta forma se pueden utilizar en los controladores
        service.SendEAN= SendEAN;
        service.SavePurchase = SavePurchase;

        return service; //Todos los servicios expuestos en esta variable son accesados al inyectar esta dependencia
        
      /**
       * Envia mensaje de comienzo de transaccion para el timestamp
       * 
       */
        function StartTransaction() {
            var response=$http({
                method:"post",          //talvez al final no sea un post
                url: $rootScope.url+"X"
            });
            return response;    
        }
        
      /**
       *  Obtiene informacion de un producto
       *
       */      
        function SendEAN(EAN) {
            var response=$http({
                method:"post",
                url:$rootScope.url+"X",
                data: EAN
            });
            return response;    
        }
        
      /**
       * Realiza una compra
       * 
       */
        function SavePurchase(Data){  
            var response=$http({
                method:"post",
                url: $rootScope.url+"",
                data: Data
            });
            return response;    
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
