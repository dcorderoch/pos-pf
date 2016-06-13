(function () {
    'use strict';

    angular
        .module('app')          //servicio para el client
        .factory('ReportService', ReportService);

    ReportService.$inject = ['$http', '$rootScope'];
    function ReportService($http, $rootScope) {
        var service = {};

        
        
        
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
