var app = angular.module('app', []);
app.controller('AppController', function ($scope, $http, OwnersService) {
    
   
    $scope.owners = null;
    

    OwnersService.GetAllRecords().then(function (d) {
        $scope.owners = d.data; // Success
    }, function () {
        alert('Error Occured !!!'); // Failed
    });



    $scope.add = function () {
                    if ($scope.Owner.Name != "") {
              
                        $http({
                            method: 'POST',
                            url: 'api/Owner/PostOwner/',
                            data: $scope.Owner
                        }).then(function successCallback(response) {
                            OwnersService.GetAllRecords().then(function (d) {
                                $scope.owners = d.data; // Success
                            }, function () {
                                alert('Error Occured !!!'); // Failed
                            });
                           alert("Owner Added Successfully !!!");
                        }, function errorCallback(response) {
                    
                            alert("Error : " + response.data.ExceptionMessage);
                        });
                    }
                    else {
                        alert('Please Enter All the Values !!');
                    }
            };


    $scope.delete = function (index) {
        

            $http({
                method: 'DELETE',
                url: 'api/Owner/' + $scope.owners[index].Id,
            }).then(function successCallback(response) {
                OwnersService.GetAllRecords().then(function (d) {
                    $scope.owners = d.data; // Success
                }, function () {
                    alert('Error Occured !!!'); // Failed
                });
                alert("Owner Deleted Successfully !!!");
            }, function errorCallback(response) {

                alert("Error: " + response.data.ExceptionMessage);
            });
           };
 

});


app.factory('OwnersService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('/api/Owner/');
    }
    return fac;
});





