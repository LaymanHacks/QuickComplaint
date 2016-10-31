(function() {
    "use strict";

    var controllerId = "reportingPartyIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "reportingPartyDataService", reportingPartyIndexCtrl]);

    function reportingPartyIndexCtrl(common, reportingPartyDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "ReportingParty List",
            description: "ReportingParty List"
        };

        vm.pageableResults = [];
        vm.title = "ReportingPartyList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;

        activate();

        vm.pageChanged = function() {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated ReportingParty List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return reportingPartyDataService.getDataPageable(sortExpression, page, pageSize)
                .then(function(results) {
                    return vm.pageableResults = results.data;
                });
        }

    }
})();