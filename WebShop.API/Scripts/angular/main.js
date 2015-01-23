var shoebalooWebApp = angular.module('shoebalooWeb',
[
    'ngRoute'
]);

shoebalooWebApp.config(['$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {

    //$locationProvider.html5Mode({
    //    enabled: true,
    //    requireBase: false
    //});
    var root = 'Scripts/angular/';

    $routeProvider.when('/', {
        controller: 'RootController',
        templateUrl: root + 'views/root.html'
    }).when('/item', {
        controller: 'ItemController',
        templateUrl: root + 'views/item.html'
    }).when('/login', {
        controller: 'LoginController',
        templateUrl: root + 'views/login.html'
    }).when('/cart', {
        controller: 'CartController',
        templateUrl: root + 'views/cart.html'
    });
}]);