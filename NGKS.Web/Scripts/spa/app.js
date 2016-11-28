(function () {
    'use strict';

    angular.module('NGKSApp', ['common.ui', 'common.core'])
        .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
            .when("/", {
                    templateUrl: "scripts/spa/home/index.html",
                    controller: "indexCtrl"
            })
            .when("/login", {
                templateUrl: "scripts/spa/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html",
                controller: "registerCtrl"
            })
            .when("/posts", {
                templateUrl: "scripts/spa/posts/posts.html",
                controller: "postsCtrl"
            })
            .when("/posts/add", {
                templateUrl: "scripts/spa/posts/addpost.html",
                controller: "addPostCtrl"
            })
            .when("/posts/edit:id", {
                templateUrl: "scripts/spa/posts/editpost.html",
                controller: "editPostCtrl"
            })
            .when("/posts/read:id", {
                templateUrl: "scripts/spa/posts/readpost.html",
                controller: "readPostCtrl"
            })
            .otherwise({ redirectTo: "/" });
    };
})();