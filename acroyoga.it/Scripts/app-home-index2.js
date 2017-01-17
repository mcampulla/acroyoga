"use strict";

var app = angular.module("Index2", []);

app.controller('Index2Controller', function ($scope, $http, $sce) {

    $scope.currentEvent = {};
    $scope.ShowEvents = false;

    $http({
        url: "http://acroyoga.azurewebsites.net/odata/Events?$filter=IsActive eq true",
        method: "GET"
        //,headers: {
        //    "X-ZUMO-AUTH": token
        //}
    }).then(function (result) {
        $scope.index = 0;
        $scope.events = angular.copy(result.data.value);
        $scope.currentEvent = $scope.events[$scope.index];
        $scope.description = $sce.trustAsHtml($scope.currentEvent.Description);
        $scope.body = $sce.trustAsHtml($scope.currentEvent.Body);

        setInterval(function () { slide($scope.index) }, 5000);

        $scope.ShowEvents = true;
    }, function () { // failure
        $scope.ShowEvents = false;
        //deferred.reject("Errore durante la richiesta di elaborazione stagioni.");
    });

    function slide(index) {
        var i = index + 1;
        if (i >= $scope.events.length)
            i = 0;
        $scope.index = i;
        $scope.changeEvent(i);
    }

    $scope.changeEvent = function (index) {
        console.log(index);
        $scope.currentEvent = $scope.events[index];
        $scope.description = $sce.trustAsHtml($scope.currentEvent.Description);
        $scope.body = $sce.trustAsHtml($scope.currentEvent.Body);
    };

    $scope.getImageUrl = function (relativeUrl) {
        var url = "http://placehold.it/350x150";
        if (relativeUrl != null)
            url = "http://acroyoga.azurewebsites.net" + relativeUrl;
        return url;
    }

    $scope.gotoEvent = function (id) {
        window.location = "/Home/Event/" + id;
    }
});
