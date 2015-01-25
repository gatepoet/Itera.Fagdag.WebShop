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
shoebalooApp.factory('userFactory', [
    '$http', function ($http) {
        var factory = {};

        factory.login = function (email) {
            var xhr = $http.post('api/users/login/' + email);
            xhr.success(function(userId) {
                sessionStorage.setItem('userId', userId);
            });
            return xhr;
        };

        factory.logout = function () {
            sessionStorage.removeItem('userId');
        }

        factory.isLoggedIn = function() {
            return sessionStorage.getItem('userId') !== null;
        }

        return factory;
    }
]);
shoebalooApp.factory('shoppingCartFactory', [
    '$http', '$rootScope', function($http, $rootScope) {
        var factory = {};
        var _cartId = sessionStorage.getItem('cartId');
        var _version = 0;

        factory.get = function () {
            var url = 'api/shoppingCart/';
            if (_cartId != null) {
                url += _cartId;
            }
            var xhr = $http.get(url);
            xhr.success(function (cart) {
                _cartId = cart.id;
                _version = cart.version;
                sessionStorage.setItem('cartId', cart.id);
            });
            return xhr;
        }

        factory.addProduct = function (productId, count) {
            var url = 'api/shoppingCart/' + _cartId + '/' + _version + '/add/' + productId + '?count=' + count;
            var xhr = $http.post(url);
            xhr.success(function() {
                $rootScope.$broadcast("ShoppingCartUpdated");
            });
            return xhr;
        }
        factory.removeProduct = function (productId, count) {
            var url = 'api/shoppingCart/' + _cartId + '/' + _version + '/remove/' + productId + '?count=' + count;
            var xhr = $http.delete(url);
            xhr.success(function () {
                $rootScope.$broadcast("ShoppingCartUpdated");
            });
            return xhr;
        }

        factory.get();

        return factory;
    }
])