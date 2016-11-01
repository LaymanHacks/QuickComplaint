﻿(function() {
    "use strict";

    var app = angular.module("app");

    // Collect the routes
    app.constant("routes", getRoutes());

    // Configure the routes and route resolvers
    app.config(["$routeProvider", "routes", routeConfigurator]);

    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function(r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: "/" });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: "/admin",
                config: {
                    title: "admin",
                    templateUrl: "app/admin/admin.html",
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }
        ];
    }
})();