var shoebalooApp = angular.module('shoebalooWeb');

shoebalooApp.controller('ShippingController', ['$scope', '$location', 'shoppingCartFactory', function ($scope, $location, shoppingCartFactory) {

    $scope.next = function() {
        var pickupPoint = $('input[name="pickuppoint"]:checked', '#pickup-point');
        if (pickupPoint.length == 0) {
            alert('Du må velge utleveringspunkt.');
            return;
        }
        var id = pickupPoint.val().split(';')[0];
        console.log(id);
        
        $location.path('/cart/checkout/payment');
    }

    function init() {
        if (require.defined('bring') && require.defined('google-maps')) {
            initializeMap();
        } else {
            requirejs(['bring'], function() { requirejs(['google-maps']); });
        }
    }

    init();
}]);
function initializeMap() {
    $("#pickup-point").utleveringsenhet({
        googleMaps: true,
        mapHeight: 303,
        mapWidth: 303
    });
}