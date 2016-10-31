(function() {
    "use strict";

    var controllerId = "complaintCreateCtrl";
    angular.module("app")
        .controller(controllerId, ["$window", "common", "complaintDataService", "complaintTypeDataService", "phoneTypeDataService", "reportingPartyDataService", "locationDataService", complaintCreateCtrl]);

    function complaintCreateCtrl($window, common, complaintDataService, complaintTypeDataService, phoneTypeDataService, reportingPartyDataService, locationDataService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
       
        vm.title = "New Complaint";
        vm.complaintTypes = [];
        vm.phoneTypes = [];
        vm.reportingParties = [];
       
        vm.complaint = {
            complaintTypeId: 1,
            description: "",
            id: -1,
            locationDetails: "",
            reportingPartyId: -1,
            reportingParty: {
                id: -1,
                email: "",
                name: "",
                phone: "",
                phoneTypeId: 1
            }
        };
        
        vm.createComplaint = createComplaint;
        vm.cancelComplaint = cancelComplaint;
        vm.getLocation = getLocation;
        vm.getReportingParties = getReportingParties;
        vm.reportingPartySelected = reportingPartySelected;
       
        activate();


        function activate() {
            var promises = [getComplaintTypes(), getPhoneTypes()];
            common.activateController(promises, controllerId)
                .then(function() { log("Activated Create Complaint View"); });
        }
        
        function createComplaint() {
           return complaintDataService.insertComplaint(vm.complaint)
                .then(function (results) {
                   $window.location.href = "/complaint";
               });
        }

        function cancelComplaint() {
            $window.location.href = "/complaint";
        }

        function getComplaintTypes() {
            return complaintTypeDataService.getData()
                .then(function(results) {
                    return vm.complaintTypes = results.data;});
        }

        function getPhoneTypes() {
            return phoneTypeDataService.getData()
                .then(function (results) {
                    return vm.phoneTypes = results.data;
                });
        }

        function reportingPartySelected($item, $model, $label) {
            setReportingParty($item);
        
        };
        

        function setReportingParty(selectedParty) {
            vm.complaint.reportingParty.id = selectedParty.id;
            vm.complaint.reportingParty.name = selectedParty.name;
            vm.complaint.reportingParty.email = selectedParty.email;
            vm.complaint.reportingParty.phone = selectedParty.phone;
            vm.complaint.reportingParty.phoneTypeId = selectedParty.phoneTypeId;
            vm.complaint.reportingPartyId = selectedParty.id;
            
        };

        function getReportingParties(val) {
            return reportingPartyDataService.search(val)
               .then(function (results) {
                   return vm.reportingParties = results.data;
               });
        }

        function getLocation(val) {
            return locationDataService.getLocation(val).then(function(response){
                return response.data.results.map(function(item){
                    return item.formatted_address;
                });
            });
        };

    }
})();