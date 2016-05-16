var MyModule = angular.module('MyApp', [])


MyModule.controller('PurchaseOrderController', ['$scope', 'PurchaseOrderService', function ($scope, PurchaseOrderService) {

    $scope.pageTitle = "Puchase Order List";
    $scope.formTitle = "Puchase Order Form";

    getAll();
    function getAll() {
        PurchaseOrderService.getAll()
            .success(function (prods) {
                $scope.purchaseOrders = prods;
                PurchaseOrderService.getAllProducts()
                    .success(function (supps) {
                        $scope.products = supps;
                    })
                    .error(function (error) {
                        $scope.status = 'Unable to load data: ' + error.message;
                        console.log($scope.status);
                    });
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }



    $scope.edit = function getSingle(Id) {
        PurchaseOrderService.getSingle(Id)
            .success(function (supp) {
                $scope.PurchaseOrder = {};
                $scope.PurchaseOrder.Id = supp.Id;
                $scope.PurchaseOrder.PurchaseDate = new Date(supp.PurchaseDate);
                $scope.PurchaseOrder.TotalAmount = supp.TotalAmount;
                $scope.PurchaseOrder.PurchaseOrderLine = supp.PurchaseOrderLine; 
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }


    $scope.delete = function deleteRecord(Id) {
        PurchaseOrderService.delete(Id)
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

    $scope.submitForm = function submitForm(PurchaseOrder) {
        if (!PurchaseOrder.Id) {
            PurchaseOrderService.add(PurchaseOrder)
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
            PurchaseOrderService.update(PurchaseOrder)
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
        $scope.PurchaseOrder.PurchaseOrderLine.push(itemToClone);
    }

    $scope.removeItem = function (item) { 
        index = $scope.PurchaseOrder.PurchaseOrderLine.indexOf(item)
        $scope.PurchaseOrder.PurchaseOrderLine.splice(index, 1);
    }



    $scope.PurchaseOrder = {};
    $scope.PurchaseOrder.PurchaseOrderLine = [
            {
                "ProductId": "",
                "Quantity": ""
            }]



    function resetForm() {
        $scope.PurchaseOrder = {};
        $scope.PurchaseOrder.Id = '';
        $scope.PurchaseOrder.Name = '';
        $scope.PurchaseOrder.TotalAmount = '';
        $scope.PurchaseOrder.PurchaseOrderLine = [
            {
                "ProductId": "",
                "Quantity": ""
            }]

    }
}]);


MyModule.factory('PurchaseOrderService', ['$http', function ($http) {

    var PurchaseOrderService = {};
    PurchaseOrderService.getAll = function () {
        return $http.get('/api/PurchaseOrder');
    }

    PurchaseOrderService.getAllProducts = function () {
        return $http.get('/api/Product');
    }

    PurchaseOrderService.getSingle = function (Id) {
        return $http.get('/api/PurchaseOrder/' + Id);
    }

    PurchaseOrderService.add = function (PurchaseOrder) {
        return $http.post('/api/PurchaseOrder', PurchaseOrder);
    }

    PurchaseOrderService.update = function (PurchaseOrder) {
        return $http.put('/api/PurchaseOrder', PurchaseOrder);
    }

    PurchaseOrderService.delete = function (Id) {
        return $http.delete('/api/PurchaseOrder/' + Id);
    }

    return PurchaseOrderService;

}]);