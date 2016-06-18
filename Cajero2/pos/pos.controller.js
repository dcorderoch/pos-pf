(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('PosController', PosController);
 
    PosController.$inject = ['$location', 'CashierService', 'FlashService', '$rootScope','$scope'];
    function PosController($location, CashierService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        // Hace que la funcion de realizar la compra sea accesible desde el DOM
        $scope.savePurchase = savePurchase;
    
        //La lista de productos, para llenar esta lista se obtiene detalles del producto desde la api
        //Ademas se agrega la cantidad, la cantidad se edita por el usuario
        //se envia al api  para realizar la compra (quitando ciertas propiedades)
        $scope.listOfProducts=[];
        $scope.clearOrder = clearOrder;
        $scope.addProduct = addProduct;
        //obtiene la fecha para mostrarla en la vista.
        $scope.today = new Date();
        $rootScope.bill = {};
        //Variable para conocer el comienzo de la transaccion
        var firstProduct = true;

        $scope.IdClient;
        var saleId;
       /**
        *   Funcion para agregar un producto por el ean, tambien se revisa si es el primer producto agregado
        *   para el timestamp.  Al obtener info del EAN se retorna del api los detalles del producto.
        */
        function addProduct(newP){
            
            if (firstProduct){
                startTransaction();
            }
            firstProduct=false;
            var newProduct = {EAN:newP};

            CashierService.SendEAN(newProduct)    
                .then(function(product){

                    FlashService.Success('Producto agregado');  
                    var productTemp = product.data;
                    $scope.listOfProducts.push(productTemp);

                }, function(){
                    FlashService.Error('Error agregando producto');
            });
        }
        
       /**
        * LLama al api para avisar que la transaccion ha comenzado.
        */
        function startTransaction(){
            var data={};
            data.CustomerId = $scope.IdClient;
            data.OfficeId ="2";
            data.CashierId ="1001";

            CashierService.StartTransaction(data)
                .then(function(response){
                    FlashService.Success('Transaccion ha comenzado');
                    saleId = response.data;

                }, function(Error){
                    FlashService.Error('No se ha podido realizar la transaccion');
                    console.log(Error.data);
            });
        }
        
       /**
        *   Guarda una transaccion, para esto envia: list of products (quitando atributos) 
        *   que contiene  Los eans y las cantidades respectivas.
        */
        function savePurchase(id){

            $rootScope.bill.saleId = saleId.SaleId;
            $rootScope.bill.Products=$scope.listOfProducts;

            var sendObject={};
            var products = prepareList();

            sendObject.saleId = saleId.SaleId;
            sendObject.Products = products;
            console.log(sendObject);
            console.log($rootScope.bill);
            CashierService.SavePurchase( sendObject )
                .then(function(){
                    FlashService.Success('Compra exitosa'); 
                   
                clearOrder();
                    $location.path('/purchase');  
            }, function(){
                clearOrder();
                    FlashService.Error('La compra no se ha realizado');  
                $location.path('/purchase');
            });
        }


        /**
         *  Prepara la lista que va a ser enviada al api
         * Solo necesita la informacion basica
         */       
        function prepareList(){

            var saveList =[];
            var i;
            for (i=0; i<$scope.listOfProducts.length; i++){

                var tempObject={};
                tempObject.EAN = $scope.listOfProducts[i].EAN;
                tempObject.Qty = $scope.listOfProducts[i].Quantity;
                saveList.push(tempObject);
            }
            // angular.forEach($scope.listOfProducts, function(item, index){    
            //      delete item.name;
            //      delete item.price;
            //  });
            return saveList;
        };
        
       /**
        *   Aumenta la cantidad de cierto producto
        */
        $scope.increase = function(product) {
            
            product.Quantity++;      
        };
        
       /**
        * Decrementa la cantidad de cierto producto
        */
        $scope.decrease = function(product) {
          
            if (product.Quantity==1){
                deleteThis(product);
            }
            else  {
              product.Quantity--;
            }
        };
        
       /**
        * Elimina cierto producto de la lista de productos y de la lista de productos.
        */
        function deleteThis(item){
            var list = $scope.listOfProducts;
            list.splice(list.indexOf(item), 1);
        }
        
       /**
        * Calcula el precio total.
        */
        $scope.sumCalc = function() {

         
           var sum = 0;   
          angular.forEach($scope.listOfProducts, function(item, index){
            
            sum += parseInt(item.Price, 10)* parseInt(item.Quantity, 10);
           });
          return sum;
            
        };
        
       /**
        * Vacia la lista de productos y eans.
        */
        function clearOrder(){
            $scope.listOfProducts = [];
       
        };
    }
})();