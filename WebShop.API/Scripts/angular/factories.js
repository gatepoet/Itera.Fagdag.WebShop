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