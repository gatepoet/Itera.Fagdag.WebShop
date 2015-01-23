var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.factory('productFactory', [
    '$http', function ($http) {
        var factory = {};
        factory.get = function () {
            return $http.get('api/products');
        };

        return factory;
    }
]);