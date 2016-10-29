(function() {
    "use strict";

    var serviceId = "complaintTypeDataService";
    angular.module("app").service(serviceId, ["$http", complaintTypeDataService]);

    function complaintTypeDataService($http) {
        var urlBase = "/api/complaintTypes";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateComplaintType = function(complaintType) {
            return $http.put(urlBase, complaintType);
        };

        this.deleteComplaintType = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertComplaintType = function(complaintType) {
            return $http.post(urlBase, complaintType);
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
            return $http.get("/api/complaintTypes/" + id);
        };


    }
})();