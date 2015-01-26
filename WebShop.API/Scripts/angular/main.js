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
    }).when('/cart/checkout/shipping', {
        controller: 'ShippingController',
        templateUrl: root + 'views/shipping.html'
    }).when('/cart/checkout/payment', {
        controller: 'PaymentController',
        templateUrl: root + 'views/payment.html'
    });
}]);

requirejs.config({
    paths: {
        'bring': 'http://fraktguide.bring.no/fraktguide/js/utleveringsenhet-1.0.1',
        'google-maps': 'http://maps.googleapis.com/maps/api/js?sensor=false&callback=initializeMap',
        'paymill-bridge': 'https://bridge.paymill.com/?',
    }
});
