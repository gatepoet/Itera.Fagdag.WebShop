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

//        factory.get = function ()

        return factory;
    }
]);
shoebalooApp.factory('shoppingCartFactory', [
    '$http', '$rootScope', function($http, $rootScope) {
        var factory = {};
        var _cartId = sessionStorage.getItem('cartId');
        var _version = 0;
        var _cart = null;
        factory.get = function () {
            if (_cart) {
                return {
                    success: function(func) { func(_cart); },
                    error: function(func) { },
                };
            }
            var url = 'api/shoppingCart/';
            if (_cartId) {
                url += _cartId;
            }
            var xhr = $http.get(url);
            xhr.success(function (cart) {
                cart.total = cart.items.reduce(function (total, currentItem) {
                    return total + (currentItem.count * currentItem.product.price);
                }, 0);
                _cart = cart;
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
                _cart = null;
                $rootScope.$broadcast("ShoppingCartUpdated");
            });
            return xhr;
        }
        factory.removeProduct = function (productId, count) {
            var url = 'api/shoppingCart/' + _cartId + '/' + _version + '/remove/' + productId + '?count=' + count;
            var xhr = $http.delete(url);
            xhr.success(function () {
                _cart = null;
                $rootScope.$broadcast("ShoppingCartUpdated");
            });
            return xhr;
        }

        factory.checkOut = function()
        {
            var url = 'api/shoppingCart/' + _cartId + '/' + _version + '/checkout';
            var xhr = $http.post(url);
            xhr.success(function () {
                _cart = null;
                $rootScope.$broadcast("ShoppingCartUpdated");
            });
            return xhr;
        }

        factory.get();

        return factory;
    }
])