(function () {
    'use strict';

    var serviceId = 'complaintDetailDataService';
    angular.module('app').service(serviceId, ['$http', complaintDetailDataService]);

    function complaintDetailDataService($http) {
        var urlBase = '/api/complaintDetails';            

        this.getData = function () {
            return $http.get(urlBase + '/all');
        };

        this.getDataPageable = function (sortExpression, page, pageSize) { 
            return $http({
                 url: urlBase,
                 method: 'GET',
                 params: {
                     sortExpression : sortExpression || '', 
                     page : page || '', 
                     pageSize : pageSize || ''
                 }
            });
        };


    }
})();
