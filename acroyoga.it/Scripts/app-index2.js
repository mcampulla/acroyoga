"use strict";

var app = angular.module("Index2", []);

app.controller('Index2Controller', function ($scope, $http) {

    $scope.currentEvent = {};
    $scope.ShowEvents = false;

    $http({
        url: "http://acroyoga.azurewebsites.net/odata/Events",
        method: "GET"
        //,headers: {
        //    "X-ZUMO-AUTH": token
        //}
    }).then(function (result) {
        $scope.events = angular.copy(result.data.value);
        $scope.currentEvent = $scope.events[0];
        $scope.ShowEvents = true;
    }, function () { // failure
        $scope.ShowEvents = false;
        //deferred.reject("Errore durante la richiesta di elaborazione stagioni.");
    });

    $scope.changeEvent = function (index) {
        $scope.currentEvent = $scope.events[index];
    };

});
