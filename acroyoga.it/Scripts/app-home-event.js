"use strict";

var app = angular.module("Event", []);

app.controller('EventController', function ($scope, $http, $sce) {

    $scope.currentEvent = {};
    $scope.ShowEvents = false;

    $http({
        url: "http://acroyoga.azurewebsites.net/odata/Events(" + index + ")",
        method: "GET"
        //,headers: {
        //    "X-ZUMO-AUTH": token
        //}
    }).then(function (result) {
        $scope.currentEvent = result.data;
        $scope.description = $sce.trustAsHtml($scope.currentEvent.Description);
        $scope.body = $sce.trustAsHtml($scope.currentEvent.Body);
        $scope.ShowEvents = true;
    }, function () { // failure
        $scope.ShowEvents = false;
        //deferred.reject("Errore durante la richiesta di elaborazione stagioni.");
    });

    $scope.getImageUrl = function (relativeUrl) {
        var url = "http://placehold.it/350x150";
        if (relativeUrl != null)
            url = "http://acroyoga.azurewebsites.net" + relativeUrl;
        return url;
    }
});
