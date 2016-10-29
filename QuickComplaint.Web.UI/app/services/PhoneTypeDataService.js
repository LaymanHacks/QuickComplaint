(function() {
    "use strict";

    var serviceId = "phoneTypeDataService";
    angular.module("app").service(serviceId, ["$http", phoneTypeDataService]);

    function phoneTypeDataService($http) {
        var urlBase = "/api/phoneTypes";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updatePhoneType = function(phoneType) {
            return $http.put(urlBase, phoneType);
        };

        this.deletePhoneType = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertPhoneType = function(phoneType) {
            return $http.post(urlBase, phoneType);
        };

        this.getDataPageable = function(sortExpression, page, pageSize) {
            return $http({
                url: urlBase,
                method: "GET",
                params: {
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getDataById = function(id) {
            return $http.get("/api/phoneTypes/" + id);
        };


    }
})();