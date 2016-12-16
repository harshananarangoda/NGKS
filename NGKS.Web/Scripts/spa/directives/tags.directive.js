(function (app) {
    'use strict';
    
    app.directive('tags', tags);

    function tags() {
        return {
            restrict: 'E',
            templateUrl: "/Scripts/spa/directives/tags.html",
            link: function ($scope, $element, $attrs) {
                $scope.getTags = function () {
                    var tags = $attrs.tags.split(',');
                    var tagsDom = "";

                    angular.forEach(tags, function (value, index) {
                        tagsDom += "<span class='label label-success right-margin-3'>" + value + "</span>";
                    });

                    $element.html(tagsDom);
                };
            }
        }
    };

})(angular.module('common.ui'));