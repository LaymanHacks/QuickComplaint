(function() {
    "use strict";

    var serviceId = "complaintDataService";
    angular.module("app").service(serviceId, ["$http", complaintDataService]);

    function complaintDataService($http) {
        var urlBase = "/api/complaints";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateComplaint = function(complaint) {
            return $http.put(urlBase, complaint);
        };

        this.deleteComplaint = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertComplaint = function(complaint) {
            return $http.post(urlBase, complaint);
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
            return $http.get(urlBase + "/all");
        };

        this.getDataByComplaintTypeId = function(complaintTypeId) {
            return $http.get("/api/complaintTypes/" + complaintTypeId + "/complaints/all");
        };

        this.getDataByComplaintTypeIdPageable = function(complaintTypeId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/complaintTypes/" + complaintTypeId + "/complaints",
                method: "GET",
                params: {
                    complaintTypeId: complaintTypeId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getDataByReportingPartyId = function(reportingPartyId) {
            return $http.get("/api/reportingParties/" + reportingPartyId + "/complaints/all");
        };

        this.getDataByReportingPartyIdPageable = function(reportingPartyId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/reportingParties/" + reportingPartyId + "/complaints",
                method: "GET",
                params: {
                    reportingPartyId: reportingPartyId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };


    }
})();