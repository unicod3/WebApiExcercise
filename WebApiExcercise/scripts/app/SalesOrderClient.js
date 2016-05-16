var MyModule = angular.module('MyApp', [])


MyModule.controller('SalesOrderController', ['$scope', 'SalesOrderService', function ($scope, SalesOrderService) {

    $scope.pageTitle = "Sales Order List";
    $scope.formTitle = "Sales Order Form";
    $scope.SalesOrder = {};
    $scope.SalesOrder.SalesOrderLine = [
            {
                "ProductId": "",
                "Quantity": ""
            }];

    getAll();
    function getAll() {
        SalesOrderService.getAll()
            .success(function (sales) {
                $scope.salesOrders = sales;
                getAllProducts();
                getAllUsers();
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }

    function getAllProducts() {
        SalesOrderService.getAllProducts()
            .success(function (prods) {
                $scope.products = prods;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }

    function getAllUsers() {
        SalesOrderService.getAllUsers()
            .success(function (users) {
                $scope.users = users;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }


    $scope.edit = function getSingle(Id) {
        SalesOrderService.getSingle(Id)
            .success(function (supp) {
                $scope.SalesOrder = {};
                $scope.SalesOrder.Id = supp.Id;
                $scope.SalesOrder.SalesDate = new Date(supp.SalesDate);
                $scope.SalesOrder.TotalAmount = supp.TotalAmount;
                $scope.SalesOrder.SalesOrderLine = supp.SalesOrderLine;
                $scope.SalesOrder.UserId = supp.User;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }


    $scope.delete = function deleteRecord(Id) {
        SalesOrderService.delete(Id)
            .success(function () {
                alert("Deleted successfully!!");
                getAll();
                resetForm();
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }

    $scope.submitForm = function submitForm(SalesOrder) {
        if (!SalesOrder.Id) {
            SalesOrderService.add(SalesOrder)
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
            
            SalesOrderService.update(SalesOrder)
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


    $scope.cloneItem = function () {
        var itemToClone = { "ProductId": "", "Quantity": "" };
        $scope.SalesOrder.SalesOrderLine.push(itemToClone);
    }

    $scope.removeItem = function (item) {
        index = $scope.SalesOrder.SalesOrderLine.indexOf(item)
        $scope.SalesOrder.SalesOrderLine.splice(index, 1);
    }



   

    function resetForm() {
        $scope.SalesOrder = {};
        $scope.SalesOrder.Id = '';
        $scope.SalesOrder.Name = '';
        $scope.SalesOrder.TotalAmount = '';
        $scope.SalesOrder.SalesOrderLine = [
            {
                "ProductId": "",
                "Quantity": ""
            }]

    }
}]);


MyModule.factory('SalesOrderService', ['$http', function ($http) {

    var SalesOrderService = {};
    SalesOrderService.getAll = function () {
        return $http.get('/api/SalesOrder');
    }

    SalesOrderService.getSingle = function (Id) {
        return $http.get('/api/SalesOrder/' + Id);
    }

    SalesOrderService.add = function (SalesOrder) {
        return $http.post('/api/SalesOrder', SalesOrder);
    }

    SalesOrderService.update = function (SalesOrder) {
        return $http.put('/api/SalesOrder', SalesOrder);
    }

    SalesOrderService.delete = function (Id) {
        return $http.delete('/api/SalesOrder/' + Id);
    }


    SalesOrderService.getAllProducts = function () {
        return $http.get('/api/Product');
    }

    SalesOrderService.getAllUsers = function () {
        return $http.get('/api/User');
    }

    return SalesOrderService;

}]);