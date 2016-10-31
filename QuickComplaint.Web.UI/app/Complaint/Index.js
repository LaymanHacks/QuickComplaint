(function() {
    "use strict";

    var controllerId = "complaintIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "complaintDetailDataService", complaintIndexCtrl]);

    function complaintIndexCtrl(common,  complaintDetailDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "Complaint List",
            description: "Complaint List"
        };

        vm.pageableResults = [];
        vm.title = "ComplaintList";
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
                .then(function() { log("Activated Complaint List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return complaintDetailDataService.getDataPageable(sortExpression, page, pageSize)
                .then(function(results) {
                    return vm.pageableResults = results.data;
                });
        }

        
    }
})();