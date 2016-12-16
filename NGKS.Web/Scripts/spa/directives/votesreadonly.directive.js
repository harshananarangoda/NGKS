(function (app) {
    'use strict';

    app.directive('votesReadonly', votesReadonly);

    function votesReadonly() {
        return {
            restrict: 'E',
            templateUrl: "/Scripts/spa/directives/votesReadonly.html",
            link: function ($scope, $element, $attrs) {
                $scope.getVotes = function () {
                    var upVotes = $attrs.upvotes;
                    var downVotes = $attrs.downvotes;

                    $element.html("<span class='right-margin-3'><i class='fa fa-thumbs-up' aria-hidden='true'></i>" + upVotes + "</span><i class='fa fa-thumbs-down' aria-hidden='true'></i>" + downVotes);
                };
            }
        }
    };

})(angular.module('common.ui'));