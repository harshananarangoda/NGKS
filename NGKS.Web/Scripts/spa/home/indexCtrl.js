(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function indexCtrl($scope, apiService, notificationService) {

        $scope.pageClass = 'page-home';
        $scope.loadingPosts = true;
        $scope.loadingCategories = true;
        $scope.readOnly = true;

        $scope.latestPosts = [];
        $scope.loadData = loadData;

        function loadData() {
            apiService.get('/api/posts/latest', null,
                        postsLoadCompleted,
                        postsLoadFailed);

            apiService.get("/api/category/", null,
                categoriesLoadCompleted,
                categoriesLoadFailed);
        };

        function postsLoadCompleted(result) {
            $scope.latestPosts = result.data;
            $scope.loadingPosts = false;
        };

        function categoriesLoadFailed(response) {
            notificationService.displayError(response.data);
        };

        function postsLoadFailed(response) {
            notificationService.displayError(response.data);
        };

        function categoriesLoadCompleted(result) {
            var categories = result.data;
            Morris.Bar({
                element: "categories-bar",
                data: categories,
                xkey: "Name",
                ykeys: ["NumberOfPosts"],
                labels: ["Number Of Posts"],
                barRatio: 0.4,
                xLabelAngle: 55,
                hideHover: "auto",
                resize: 'true'
            });

            $scope.loadingCategories = false;
        };

        loadData();
    };

})(angular.module('NGKSApp'));