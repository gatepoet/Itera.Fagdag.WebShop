var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('ShoppingCartController', ['$scope', '$routeParams', 'productFactory', function ($scope, $routeParams, productFactory) {
    $scope.price = 3221;
}]);