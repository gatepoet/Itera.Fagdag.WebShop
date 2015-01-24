var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('LoginController', ['$scope', 'userFactory', function ($scope, userFactory) {
    $scope.isLoggedIn = userFactory.isLoggedIn();
    $scope.login = function() {
        var email = prompt("Enter email");
        userFactory.login(email).success(function() {
            $scope.isLoggedIn = true;
        });
    };
}]);