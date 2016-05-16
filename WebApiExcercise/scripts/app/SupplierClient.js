var MyModule = angular.module('MyApp', [])


MyModule.controller('SupplierController', ['$scope','SupplierService', function ($scope, SupplierService) {

    $scope.pageTitle = "Supplier List";
    $scope.formTitle = "Supplier Form";

    getAll();
    function getAll() {
        SupplierService.getAll()
            .success(function (supps) {
                $scope.suppliers = supps;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }



    $scope.edit = function getSingle(Id) {
        SupplierService.getSingle(Id)
            .success(function (supp) { 
                $scope.Supplier = {};
                $scope.Supplier.Id = supp.Id;
                $scope.Supplier.Name = supp.Name; 
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }


    $scope.delete = function deleteRecord(Id) {
        SupplierService.delete(Id)
            .success(function () {
                alert("Deleted successfully!!");
                getAll();
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }

    $scope.submitForm = function submitForm(Supplier) {
        if (!Supplier.Id) {
            SupplierService.add(Supplier)
                .success(function () {
                    alert("Added successfully!!");
                    getAll();
                    resetForm();
                })
                .error(function (error) {
                    $scope.status = 'Unable to load data: ' + error.message;
                    console.log($scope.status);
                });
        } else {
            SupplierService.update(Supplier)
                .success(function () {
                    alert("Updated successfully!!");
                    getAll();
                    resetForm();
                })
                .error(function (error) {
                    $scope.status = 'Unable to load data: ' + error.message;
                    console.log($scope.status);
                });
        } 
    }

    function resetForm() {
        $scope.Supplier = {};
        $scope.Supplier.Id = '';
        $scope.Supplier.Name = ''; 
       }
}]);


MyModule.factory('SupplierService', ['$http', function ($http) {

    var SupplierService = {}; 
    SupplierService.getAll = function () {
        return $http.get('/api/Supplier');
    }

    SupplierService.getSingle = function (Id) {
        return $http.get('/api/Supplier/' + Id);
    }

    SupplierService.add = function (Supplier) {
        return $http.post('/api/Supplier', Supplier);
    }

    SupplierService.update = function (Supplier) {
        return $http.put('/api/Supplier', Supplier);
    }

    SupplierService.delete = function (Id) {
        return $http.delete('/api/Supplier/' + Id);
    }

    return SupplierService;

}]);


