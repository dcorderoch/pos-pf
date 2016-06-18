(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('PurchaseController', PurchaseController);
 
    PurchaseController.$inject = ['$location', 'CashierService', 'FlashService', '$rootScope','$scope'];
    function PurchaseController($location, CashierService, FlashService, $rootScope,$scope) {
        var vm = this;
 

        $scope.listOfProducts=[];
        $scope.sale;
        $scope.today = new Date(); 
        $scope.returnBack= returnBack;
        initController();
        
        function initController(){
            
            $scope.listOfProducts = $rootScope.bill.Products;
            $scope.sale = $rootScope.bill.saleId;
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
        
        function returnBack(){
            
            $rootScope.bill = {};
            $location.path('/');
        }

    }
})();