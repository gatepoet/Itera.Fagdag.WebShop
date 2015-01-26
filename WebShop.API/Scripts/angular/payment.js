var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('PaymentController', ['$scope', 'shoppingCartFactory', function ($scope, shoppingCartFactory) {
    $scope.method = '';
    $scope.selectMethod = function (method) {
        $scope.method = method;
    };
    $("#button").on("token", function(event, token) {
        console.log(token);
    });

    function init() {
        $scope.total = 0;
        requirejs(['paymill-bridge']);
        shoppingCartFactory.get().success(function(cart) {
            $scope.total = cart.total;
        });
    }

    init();
}]);