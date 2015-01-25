var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('ItemController', ['$scope', '$routeParams', 'productFactory', 'shoppingCartFactory', function ($scope, $routeParams, productFactory, shoppingCartFactory) {
    $scope.count = 1;
    $scope.productId = $routeParams.productId || 0;
    $scope.addToCart = function() {
        shoppingCartFactory.addProduct($scope.productId, $scope.count);
    };
    function init() {
        productFactory.getProduct($scope.productId).success(function(data) {
            $scope.product = data;
        });
    }

    init();
}]);