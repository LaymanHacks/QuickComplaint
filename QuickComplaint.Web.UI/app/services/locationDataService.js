(function () {
    "use strict";

    var serviceId = "locationDataService";
    angular.module("app").service(serviceId, ["$http", locationDataService]);

    function locationDataService($http) {
      
        this.getLocation = function(val) {
            return $http({
                url: "//maps.googleapis.com/maps/api/geocode/json",
                method: "GET",
                params: {
                    address: val,
                    sensor: false
                }
            });
        };
       


    }
})();