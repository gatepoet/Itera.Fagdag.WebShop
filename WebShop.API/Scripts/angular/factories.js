var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.factory('productFactory', [
    '$http', function ($http) {
        var factory = {};
        factory.get = function () {
            return $http.get('api/products');
        };

        factory.getProduct = function(id) {
            return $http.get('api/products?id=' + id);
        }

        factory.getCart = function(id) {
            return $http.get('api/shoppingCart/' + id);
        }
        return factory;
    }
]);