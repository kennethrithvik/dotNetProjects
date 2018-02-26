var myapp = angular.module("MyApp", []);
myapp.controller("FormController", ["$scope", function ($scope) {
    $scope.formobj = { name: "" ,add:"",mob:"",dob:""};
    $scope.submit = function () {
        console.log("Name= " + $scope.formobj.name);
    };
    
}]);