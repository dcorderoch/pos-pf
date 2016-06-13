(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('ProductController', ProductController);
 
    ProductController.$inject = ['$location', 'ProductService', 'FlashService', '$rootScope','$scope'];
    function ProductController(location, ProductService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //CRUD
        $scope.allProducts=[]; //Read
        $scope.deleteProduct = deleteProduct; //Delete
        $scope.update = update;   //Update
        $scope.create= create;    //Create
        
        //Mostrar el form para crear un producto
         $scope.showCreate = false;
        //Objeto de nuevo producto
        $scope.newProduct={};
        
        //Editar
        $scope.updateProduct ={};                
//Mostrar el form para editar un producto
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
        $scope.toggle2 = function(productID){
            
            $scope.showEdit = !$scope.showEdit;
            $scope.productEditID = productID;
            console.log(productID);
        }
 
        /**
         * inicia todas los metodos
         */
        initController();

        function initController() {
            loadAllProducts();
            console.log($scope.allProducts);
        }
        /**
         * Carga todos los productos
         * asociados con un medico
         */
        function loadAllProducts() {
            ProductService.Read()
                .then(function (products) {
                    $scope.allProducts = products.data;
            },function(){
                 FlashService.Error("Error al cargar productos");       
            });
        }
        /**
         * Elimna un producto y luego carga todos los productos
         * Para eliminar un producto se toma el id
         */
        function deleteProduct(id) {
            console.log(id);
            ProductService.Delete(id)
            .then(function () {
                loadAllProducts();
                FlashService.Success('Eliminado de producto exitoso', true);   
            },function(){
                FlashService.Error("Error al eliminar productos");       
            });
        }
        
        /**
         * Edita un producto y luego carga todos los productos
         * Para editar un producto se toma el id
         */
        function update(){
            
            $scope.updateProduct.IdNumber = $scope.productEditID;
            $scope.toggle2(" ");    
            console.log($scope.updateProduct);
            ProductService.Update($scope.updateProduct)
                .then(function() {
                    loadAllProducts();  
                    FlashService.Success('Actualización de producto exitosos', true);
                    $scope.updateProduct = {};
                },function(response){
                
                    FlashService.Error('Error en la actualización de producto');
                });
        }

        /**
         * Creae producto asociado a un doctor
         * 
         */
        function create(){
            
            $scope.toggle();
            ProductService.Create($scope.newProduct)
                .then(function() {
                    loadAllProducts();
                    FlashService.Success('Creacion de producto exitosa');      
                    $scope.newProduct ={};   
                
                },function(response){
                    FlashService.Error('Error en la creacion de producto');      
                });
        }
    }
})();