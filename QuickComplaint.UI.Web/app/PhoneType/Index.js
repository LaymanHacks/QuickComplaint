(function () {
    "use strict";

    var controllerId = "phoneTypeIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "phoneTypeDataService", phoneTypeIndexCtrl]);

    function phoneTypeIndexCtrl(common, phoneTypeDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: "PhoneType List",
            description: "PhoneType List"
        };
       
        vm.pageableResults = [];
        vm.title = "PhoneTypeList";
        vm.sortExpression = "";
        vm.currentPage = 1;
        vm.pageSize = 10;
        vm.deletePhoneType = deletePhoneType;

        activate();

        vm.pageChanged = function () {
            return getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize);
        };

        function activate() {
            var promises = [getDataPageable(vm.sortExpression, vm.currentPage, vm.pageSize)];
            common.activateController(promises, controllerId)
                .then(function () { log("Activated PhoneType List View"); });
        }
        
        function getDataPageable(sortExpression, page, pageSize) {
            return phoneTypeDataService.getDataPageable(sortExpression, page, pageSize).then(function (results) {
                return  vm.pageableResults = results.data;
              });
        }

        function deletePhoneType(phoneTypeId) {
            return phoneTypeDataService.deletePhoneType(phoneTypeId);
        };
    }
})();

