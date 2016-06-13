(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('AdminController', AdminController);
 
    AdminController.$inject = ['$location', 'AdminService', 'FlashService', '$rootScope','$scope'];
    function AdminController(location, AdminService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //CRUD
        $scope.allAdmins=[]; //Read
        $scope.deleteAdmin = deleteAdmin; //Delete
        $scope.update = update;   //Update
        $scope.create= create;    //Create
        
        //Mostrar el form para crear un admin
         $scope.showCreate = false;
        //Objeto de nuevo admin
        $scope.newAdmin={};
        
        //Editar
        $scope.updateAdmin ={};                
//Mostrar el form para editar un admin
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
        $scope.toggle2 = function(adminID){
            
            $scope.showEdit = !$scope.showEdit;
            $scope.adminID = adminID;
            console.log(adminID);
        }
 
        /**
         * inicia todas los metodos
         */
        initController();

        function initController() {
            loadAllAdmins();
            console.log($scope.allAdmins);
        }
        /**
         * Carga todos los admins
         * asociados con un medico
         */
        function loadAllAdmins() {
            AdminService.Read()
                .then(function (Admin) {
                    $scope.allAdmins = Admin.data;
            },function(){
                 FlashService.Error("Error al cargar admins");       
            });
        }
        /**
         * Elimna un admin y luego carga todos los admins
         * Para eliminar un admin se toma el id
         */
        function deleteAdmin(id) {
            console.log(id);
            AdminService.Delete(id)
            .then(function () {
                loadAllAdmins();
                FlashService.Success('Eliminado de admin', true);   
            },function(){
                FlashService.Error("Error al eliminar el admin");       
            });
        }
        
        /**
         * Edita un admin y luego carga todos los admins
         * Para editar un admin se toma el id
         */
        function update(){
            
            $scope.updateAdmin.IdNumber = $scope.AdminEditID;
            $scope.toggle2(" ");    
            console.log($scope.updateAdmin);
            AdminService.Update($scope.updateAdmin)
                .then(function() {
                    loadAllAdmins();  
                    FlashService.Success('Actualización de admin exitosos', true);
                    $scope.updateAdmin = {};
                },function(response){
                
                    FlashService.Error('Error en la actualización de admin');
                });
        }

        /**
         * Crea un admin 
         * 
         */
        function create(){
            
            $scope.toggle();
            AdminService.Create($scope.newAdmin)
                .then(function() {
                    loadAllAdmins();
                    FlashService.Success('Creacion de admin exitosa');      
                    $scope.newAdmin ={};   
                
                },function(response){
                    FlashService.Error('Error en la creacion de admin');      
                });
        }
    }
})();