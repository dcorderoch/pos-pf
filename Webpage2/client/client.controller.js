(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('ClientController', ClientController);
 
    ClientController.$inject = ['$location', 'ClientService', 'FlashService', '$rootScope','$scope'];
    function ClientController(location, ClientService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //CRUD
        $scope.allClients=[]; //Read
        $scope.deleteClient = deleteClient; //Delete
        $scope.update = update;   //Update
        $scope.create= create;    //Create
        
        //Mostrar el form para crear un employee
         $scope.showCreate = false;
        //Objeto de nuevo employee
        $scope.newClient={};
        
        //Editar
        $scope.updateClient ={};                
//Mostrar el form para editar un employee
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
        $scope.toggle2 = function(employeeID){
            
            $scope.showEdit = !$scope.showEdit;
            $scope.employeeID = employeeID;
            console.log(employeeID);
        }
 
        /**
         * inicia todas los metodos
         */
        initController();

        function initController() {
            loadAllClients();
            console.log($scope.allClients);
        }
        /**
         * Carga todos los employees
         * asociados con un medico
         */
        function loadAllClients() {
            ClientService.Read()
                .then(function (Client) {
                    $scope.allClients = Client.data;
            },function(){
                 FlashService.Error("Error al cargar employees");       
            });
        }
        /**
         * Elimna un employee y luego carga todos los employees
         * Para eliminar un employee se toma el id
         */
        function deleteClient(id) {
            console.log(id);
            ClientService.Delete(id)
            .then(function () {
                loadAllClients();
                FlashService.Success('Eliminado de employee', true);   
            },function(){
                FlashService.Error("Error al eliminar el employee");       
            });
        }
        
        /**
         * Edita un employee y luego carga todos los employees
         * Para editar un employee se toma el id
         */
        function update(){
            
            $scope.updateClient.IDNumber = $scope.employeeID;
            $scope.toggle2(" ");    
            console.log($scope.updateClient);
            ClientService.Update($scope.updateClient)
                .then(function() {
                    loadAllClients();  
                    FlashService.Success('Actualización de employee exitosos', true);
                    $scope.updateClient = {};
                },function(response){
                
                    FlashService.Error('Error en la actualización de employee');
                });
        }

        /**
         * Creae employee 
         * 
         */
        function create(){
            
            $scope.toggle();
            ClientService.Create($scope.newClient)
                .then(function() {
                    loadAllClients();
                    FlashService.Success('Creacion de employee exitosa');      
                    $scope.newClient ={};   
                
                },function(response){
                    FlashService.Error('Error en la creacion de employee');      
                });
        }
    }
})();