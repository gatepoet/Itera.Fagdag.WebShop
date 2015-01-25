var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('ShoppingCartController', ['$scope', '$routeParams', 'shoppingCartFactory', function ($scope, $routeParams, shoppingCartFactory) {
    $scope.total = 0;

    var init = function() {
        shoppingCartFactory.get().success(function(cart) {
            $scope.total = cart.items.reduce(function (total, currentItem) {
                return total + (currentItem.count * currentItem.product.price);
            }, 0);
        });
    };
    init();
    $scope.$on('ShoppingCartUpdated', function() {
        init();
    });
}]);