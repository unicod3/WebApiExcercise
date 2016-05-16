var MyModule = angular.module('MyApp', [])


MyModule.controller('UserController', ['$scope', 'UserService', function ($scope, UserService) {

    $scope.pageTitle = "User List";
    $scope.formTitle = "User Form";

    getAll();
    function getAll() {
        UserService.getAll()
            .success(function (supps) {
                $scope.users = supps;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }



    $scope.edit = function getSingle(Id) {
        UserService.getSingle(Id)
            .success(function (supp) {
                $scope.User = {};
                $scope.User.Id = supp.Id;
                $scope.User.Name = supp.Name;
                $scope.User.Email = supp.Email;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }


    $scope.delete = function deleteRecord(Id) {
        UserService.delete(Id)
            .success(function () {
                alert("Deleted successfully!!");
                getAll();
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }

    $scope.submitForm = function submitForm(User) {
        if (!User.Id) {
            UserService.add(User)
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
            UserService.update(User)
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
        $scope.User = {};
        $scope.User.Id = '';
        $scope.User.Name = '';
        $scope.User.Email = '';
    }
}]);


MyModule.factory('UserService', ['$http', function ($http) {

    var UserService = {};
    UserService.getAll = function () {
        return $http.get('/api/User');
    }

    UserService.getSingle = function (Id) {
        return $http.get('/api/User/' + Id);
    }

    UserService.add = function (User) {
        return $http.post('/api/User', User);
    }

    UserService.update = function (User) {
        return $http.put('/api/User', User);
    }

    UserService.delete = function (Id) {
        return $http.delete('/api/User/' + Id);
    }

    return UserService;

}]);