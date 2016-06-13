(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('EmployeeController', EmployeeController);
 
    EmployeeController.$inject = ['$location', 'EmployeeService', 'FlashService', '$rootScope','$scope'];
    function EmployeeController(location, EmployeeService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //CRUD
        $scope.allEmployees=[]; //Read
        $scope.deleteEmployee = deleteEmployee; //Delete
        $scope.update = update;   //Update
        $scope.create= create;    //Create
        
        //Mostrar el form para crear un employee
         $scope.showCreate = false;
        //Objeto de nuevo employee
        $scope.newEmployee={};
        
        //Editar
        $scope.updateEmployee ={};                
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
            loadAllEmployees();
            console.log($scope.allEmployees);
        }
        /**
         * Carga todos los employees
         * asociados con un medico
         */
        function loadAllEmployees() {
            EmployeeService.Read()
                .then(function (Employee) {
                    $scope.allEmployees = Employee.data;
            },function(){
                 FlashService.Error("Error al cargar employees");       
            });
        }
        /**
         * Elimna un employee y luego carga todos los employees
         * Para eliminar un employee se toma el id
         */
        function deleteEmployee(id) {
            console.log(id);
            EmployeeService.Delete(id)
            .then(function () {
                loadAllEmployees();
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
            
            $scope.updateEmployee.IdNumber = $scope.EmployeeEditID;
            $scope.toggle2(" ");    
            console.log($scope.updateEmployee);
            EmployeeService.Update($scope.updateEmployee)
                .then(function() {
                    loadAllEmployees();  
                    FlashService.Success('Actualización de employee exitosos', true);
                    $scope.updateEmployee = {};
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
            EmployeeService.Create($scope.newEmployee)
                .then(function() {
                    loadAllEmployees();
                    FlashService.Success('Creacion de employee exitosa');      
                    $scope.newEmployee ={};   
                
                },function(response){
                    FlashService.Error('Error en la creacion de employee');      
                });
        }
    }
})();