var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('CartController', ['$scope', '$routeParams', 'shoppingCartFactory', function ($scope, $routeParams, shoppingCartFactory) {

    $scope.cartId = $routeParams.cartId || 0;
    $scope.total = 0;
    $scope.items = [];
    $scope.$watch('items', function () {
        $scope.total = $scope.items.reduce(function (total, currentItem) {
            return total + (currentItem.count * currentItem.product.price);
        }, 0);
    }, true);
    $scope.add = function(item) {
        shoppingCartFactory.addProduct(item.product.id, 1).success(function() {
            init();
        });
    };
    $scope.remove = function(item) {
        shoppingCartFactory.removeProduct(item.product.id, 1).success(function () {
            init();
        });
    };
    $scope.removeItem = function(item) {
        shoppingCartFactory.removeProduct(item.product.id, item.count).success(function () {
            init();
        });
    };
    function init() {
        shoppingCartFactory.get().success(function (cart) {
            $scope.items = cart.items;
        });
    }

    init();
}]);