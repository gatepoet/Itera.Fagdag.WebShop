var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('CartController', ['$scope', 'productFactory', function ($scope, productFactory) {
    function init() {
        productFactory.getCart().success(function (data) {
            $scope.products = data;
        });
    }

    init();
}]);