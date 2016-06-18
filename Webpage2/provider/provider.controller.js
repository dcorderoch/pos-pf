(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('ProviderController', ProviderController);
 
    ProviderController.$inject = ['$location', 'ProviderService', 'FlashService', '$rootScope','$scope'];
    function ProviderController(location, ProviderService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //CRUD
        $scope.allProviders=[]; //Read
        $scope.deleteProvider = deleteProvider; //Delete
        $scope.update = update;   //Update
        $scope.create= create;    //Create
        
        //Mostrar el form para crear un provider
         $scope.showCreate = false;
        //Objeto de nuevo provider
        $scope.newProvider={};
        
        //Editar
        $scope.updateProvider ={};                
//Mostrar el form para editar un provider
        $scope.showEdit = false;        

       /**
        *   Mostrar crear
        */
        $scope.toggle = function() {
        
            $scope.showCreate = !$scope.showCreate;
        };
        
       /**
        * Mostrar editar
        */
        $scope.toggle2 = function(providerID){

            $scope.showEdit = !$scope.showEdit;
            $scope.providerID = providerID;
        }
 
        /**
         * inicia todas los metodos
         */
        initController();

        function initController() {
            loadAllProviders();
            console.log($scope.allProviders);
        }
        /**
         * Carga todos los providers
         * asociados con un medico
         */
        function loadAllProviders() {
            ProviderService.Read()
                .then(function (Provider) {
                    $scope.allProviders = Provider.data;
            },function(){
                 FlashService.Error("Error al cargar providers");       
            });
        }
        /**
         * Elimna un provider y luego carga todos los providers
         * Para eliminar un provider se toma el id
         */
        function deleteProvider(id) {
            console.log(id);
            ProviderService.Delete(id)
            .then(function () {
                loadAllProviders();
                FlashService.Success('Eliminado de provider', true);   
            },function(){
                FlashService.Error("Error al eliminar el provider");       
            });
        }
        
        /**
         * Edita un provider y luego carga todos los providers
         * Para editar un provider se toma el id
         */
        function update(){
            
            $scope.updateProvider.SupplerID = $scope.providerID;
            $scope.toggle2(" ");    
            console.log($scope.updateProvider);
            ProviderService.Update($scope.updateProvider)
                .then(function() {
                    loadAllProviders();  
                    FlashService.Success('Actualización de provider exitoso', true);
                    $scope.updateProvider = {};
                },function(response){
                
                    FlashService.Error('Error en la actualización de provider');
                });
        }

        /**
         * Creae provider asociado a un doctor
         * 
         */
        function create(){
            
            $scope.toggle();
            ProviderService.Create($scope.newProvider)
                .then(function() {
                    loadAllProviders();
                    FlashService.Success('Creacion de provider exitosa');      
                    $scope.newProvider ={};   
                
                },function(response){
                    FlashService.Error('Error en la creacion de provider');      
                });
        }
    }
})();