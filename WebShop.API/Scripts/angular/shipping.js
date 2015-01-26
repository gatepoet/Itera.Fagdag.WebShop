var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('ShippingController', ['$scope', '$location', 'shoppingCartFactory', function ($scope, $location, shoppingCartFactory) {

    $scope.next = function() {
        var pickupPoint = $('input[name="pickuppoint"]:checked', '#pickup-point');
        var id = pickupPoint.val().split(';')[0];
        console.log(pickupPoint);
        $location.path('/cart/checkout/payment');
    }

    function init() {
        requirejs(['bring', 'google-maps']);
    }

    init();
}]);
var pp;
function initializeMap() {
    pp = $("#pickup-point").utleveringsenhet({
        googleMaps: true,
        mapHeight: 400,
        mapWidth: 400
    });
}