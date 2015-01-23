var shoebalooWebApp = angular.module('shoebalooWeb',
[
    'ngRoute'
]);

shoebalooWebApp.config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/', {
        controller: 'RootController',
        templateUrl: 'Scripts/angular/views/root.html'
    }).when('/item', {
        controller: 'ItemController',
        templateUrl: 'views/item'
    });
}]);