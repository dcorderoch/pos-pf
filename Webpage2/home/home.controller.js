(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('HomeController', HomeController);
 
    HomeController.$inject = ['$location', 'FlashService', '$rootScope','$scope'];
    function HomeController(location, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //Tomar nombre del paciente
        $scope.adminName ;
        initController();

    
        function initController() {
            loadAdminName();
        }
        
        /**
         *  Carga el nombre de un doctor.
         */
        function loadAdminName() {
            $scope.adminName = $rootScope.adminName;
        }
    }
})();
