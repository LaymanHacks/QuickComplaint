(function() {
    "use strict";

    var serviceId = "reportingPartyDataService";
    angular.module("app").service(serviceId, ["$http", reportingPartyDataService]);

    function reportingPartyDataService($http) {
        var urlBase = "/api/reportingParties";

        this.getData = function() {
            return $http.get(urlBase + "/all");
        };

        this.updateReportingParty = function(reportingParty) {
            return $http.put(urlBase, reportingParty);
        };

        this.deleteReportingParty = function(id) {
            return $http.Delete(urlBase, id);
        };

        this.insertReportingParty = function(reportingParty) {
            return $http.post(urlBase, reportingParty);
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
            return $http.get("/api/reportingParties/" + id);
        };

        this.getDataByphoneTypeId = function(phoneTypeId) {
            return $http.get("/api/phoneTypes/" + phoneTypeId + "/reportingParties/all");
        };

        this.getDataByphoneTypeIdPageable = function(phoneTypeId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/phoneTypes/" + phoneTypeId + "/reportingParties",
                method: "GET",
                params: {
                    phoneTypeId: phoneTypeId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.getDataByPhone2TypeId = function(phone2TypeId) {
            return $http.get("/api/phoneTypes/" + phone2TypeId + "/reportingParties/all");
        };

        this.getDataByPhone2TypeIdPageable = function(phone2TypeId, sortExpression, page, pageSize) {
            return $http({
                url: "/api/phoneTypes/" + phone2TypeId + "/reportingParties",
                method: "GET",
                params: {
                    phone2TypeId: phone2TypeId || "",
                    sortExpression: sortExpression || "",
                    page: page || "",
                    pageSize: pageSize || ""
                }
            });
        };

        this.search = function(searchValue) {
            return $http({
                url: "/api/reportingParties/search",
                method: "GET",
                params: {
                    searchValue: searchValue || ""
                }
            });

        };

    }
})();