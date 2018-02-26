var myapp = angular.module("MyApp", []);
myapp.controller("FormController", ["$scope", "$http",function ($scope,$http) {
    $http({
        method: "GET",
        dataType: "json",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        url: "http://localhost:2025/api/Customer"
    }).success(function (data) {
        $scope.status = data;
        console.log($scope.status)
    });
    $scope.rangefilter = function (val) {
        return (val.Address[0]=='f');
    };

}]);