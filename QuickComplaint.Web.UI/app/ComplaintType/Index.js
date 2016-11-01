(function() {
    "use strict";

    var controllerId = "complaintTypeIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "complaintTypeDataService", complaintTypeIndexCtrl]);

    function complaintTypeIndexCtrl(common, complaintTypeDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "ComplaintType List",
            description: "ComplaintType List"
        };

        vm.pageableResults = [];
        vm.title = "ComplaintTypeList";
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
                .then(function() { log("Activated ComplaintType List View"); });
        }

        function getDataPageable(sortExpression, page, pageSize) {
            return complaintTypeDataService.getDataPageable(sortExpression, page, pageSize)
                .then(function(results) {
                    return vm.pageableResults = results.data;
                });
        }


    }
})();