var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('RootController', ['$scope', 'productFactory', function ($scope, productFactory) {
    function init() {

        $scope.filter = 'herre';

        productFactory.get().success(function(data) {
            $scope.products = data;
        });
    }

    init();
}]);