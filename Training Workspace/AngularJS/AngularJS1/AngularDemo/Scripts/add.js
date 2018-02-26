var myapp = angular.module("MyApp", []);
myapp.controller("FormController", ["$scope", "$http", function ($scope, $http) {
    $http({
        method: "GET",
        dataType: "json",
        headers: {
            "Caontent-Type": "application/x-www-form-urlencoded"
        },
        url: "http://localhost:2025/api/Customer"
    }).success(function (data) {
        $scope.status = data;
        console.log($scope.status)
    });
    $scope.rangefilter = function (val) {
        return (val.Address[0] == 'f');
    };

}]);





//$(document).ready(function () {
//    $("#btnSub").click(function () {

//        var cdata = {
//            CabId: $("#txtCN").val(),
//            Model: $("#txtMod").val(),
//            Capacity: $("#txtCap").val()
//        };
//        //console.log("clicked");
//        $.ajax({
//            type: "GET",
//            url: "http://localhost:2203/api/Cab",
//            datatype: "json",
//            data: { cab: JSON.stringify(cdata) },

//            success: function (data) {
//                var data = JSON.parse(data);
//                console.log(data);

//            },

//            error: function (er) {
//                console.log(er);
//            }

//        });
//    });
//});
