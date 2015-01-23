var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('ItemController', ['$scope', '$routeParams', 'productFactory', function ($scope, $routeParams, productFactory) {
    $scope.productId = $routeParams.productId || 0;

    function init() {
        productFactory.getProduct($scope.productId).success(function(data) {
            $scope.product = data;
        });
    }

    init();
}]);