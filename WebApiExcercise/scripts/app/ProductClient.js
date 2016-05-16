var MyModule = angular.module('MyApp', [])


MyModule.controller('ProductController', ['$scope', 'ProductService', function ($scope, ProductService) {

    $scope.pageTitle = "Product List";
    $scope.formTitle = "Product Form";

    getAll();
    function getAll() {
        ProductService.getAll()
            .success(function (prods) {
                $scope.products = prods;
                ProductService.getAllSuppliers()
                    .success(function (supps) {
                        $scope.suppliers = supps;
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
        ProductService.getSingle(Id)
            .success(function (supp) {
                $scope.Product = {};
                $scope.Product.Id = supp.Id;
                $scope.Product.Name = supp.Name;
                $scope.Product.Price = supp.Price;
                $scope.Product.SupplierId = supp.Supplier;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }


    $scope.delete = function deleteRecord(Id) {
        ProductService.delete(Id)
            .success(function () {
                alert("Deleted successfully!!");
                getAll();
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }

    $scope.submitForm = function submitForm(Product) {
        if (!Product.Id) {
            ProductService.add(Product)
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
            ProductService.update(Product)
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
        $scope.Product = {};
        $scope.Product.Id = '';
        $scope.Product.Name = '';
        $scope.Product.Price = '';
        $scope.Product.SupplierId = '';
    }
}]);


MyModule.factory('ProductService', ['$http', function ($http) {

    var ProductService = {};
    ProductService.getAll = function () {
        return $http.get('/api/Product');
    }

    ProductService.getAllSuppliers = function () {
        return $http.get('/api/Supplier');
    }

    ProductService.getSingle = function (Id) {
        return $http.get('/api/Product/' + Id);
    }

    ProductService.add = function (Product) {
        return $http.post('/api/Product', Product);
    }

    ProductService.update = function (Product) {
        return $http.put('/api/Product', Product);
    }

    ProductService.delete = function (Id) {
        return $http.delete('/api/Product/' + Id);
    }

    return ProductService;

}]);