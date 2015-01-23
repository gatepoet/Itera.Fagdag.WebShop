var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('CartController', ['$scope', 'productFactory', function ($scope, productFactory) {

    $scope.cartId = $routeParams.cartId || 0;
    function init() {
        productFactory.getCart().success(function (cartId) {
            $scope.products = data;
        });
    }

    init();
}]);