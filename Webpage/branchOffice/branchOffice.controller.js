(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('BranchOfficeController', BranchOfficeController);
 
    BranchOfficeController.$inject = ['$location', 'BranchOfficeService', 'FlashService', '$rootScope','$scope'];
    function BranchOfficeController(location, BranchOfficeService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //CRUD
        $scope.allBranchOffices=[]; //Read
        $scope.deleteBranchOffice = deleteBranchOffice; //Delete
        $scope.update = update;   //Update
        $scope.create= create;    //Create
        
        //Mostrar el form para crear un sucursal
         $scope.showCreate = false;
        //Objeto de nuevo sucursal
        $scope.newBranchOffice={};
        
        //Editar
        $scope.updateBranchOffice ={};                
//Mostrar el form para editar un sucursal
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
        $scope.toggle2 = function(branchOfficeID){
            
            $scope.showEdit = !$scope.showEdit;
            $scope.branchOfficeID = branchOfficeID;
            console.log(branchOfficeID);
        }
 
        /**
         * inicia todas los metodos
         */
        initController();

        function initController() {
            loadAllBranchOffices();
            console.log($scope.allBranchOffices);
        }
        /**
         * Carga todos los sucursals
         * asociados con un medico
         */
        function loadAllBranchOffices() {
            BranchOfficeService.Read()
                .then(function (BranchOffice) {
                    $scope.allBranchOffices = BranchOffice.data;
            },function(){
                 FlashService.Error("Error al cargar sucursals");       
            });
        }
        /**
         * Elimna un sucursal y luego carga todos los sucursals
         * Para eliminar un sucursal se toma el id
         */
        function deleteBranchOffice(id) {
            console.log(id);
            BranchOfficeService.Delete(id)
            .then(function () {
                loadAllBranchOffices();
                FlashService.Success('Eliminado de Branch Office exitoso', true);   
            },function(){
                FlashService.Error("Error al eliminar BranchO ffice");       
            });
        }
        
        /**
         * Edita un sucursal y luego carga todos los sucursals
         * Para editar un sucursal se toma el id
         */
        function update(){
            
            $scope.updateBranchOffice.IdNumber = $scope.BranchOfficeEditID;
            $scope.toggle2(" ");    
            console.log($scope.updateBranchOffice);
            BranchOfficeService.Update($scope.updateBranchOffice)
                .then(function() {
                    loadAllBranchOffices();  
                    FlashService.Success('Actualización de Branch Office exitosos', true);
                    $scope.updateBranchOffice = {};
                },function(response){
                
                    FlashService.Error('Error en la actualización de Branch Office');
                });
        }

        /**
         * Creae sucursal asociado a un doctor
         * 
         */
        function create(){
            
            $scope.toggle();
            BranchOfficeService.Create($scope.newBranchOffice)
                .then(function() {
                    loadAllBranchOffices();
                    FlashService.Success('Creacion de Branch Office exitosa');      
                    $scope.newBranchOffice ={};   
                
                },function(response){
                    FlashService.Error('Error en la creacion de Branch Office');      
                });
        }
    }
})();