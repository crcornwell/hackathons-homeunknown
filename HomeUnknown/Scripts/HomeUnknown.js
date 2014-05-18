angular.module('homeUnknown', ['ngRoute'])

.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        controller: 'TimelineCtrl',
        templateUrl: 'timelines.html'
    })
    .when('/contents/:eventId', {
        controller: 'ContentsCtrl',
        templateUrl: 'contents.html'
    })
    .when('/events/:timelineId', {
        controller: 'EventsCtrl',
        templateUrl: 'events.html'
    });
})

.controller('TimelineCtrl', function ($scope, $http) {
    $http({ method: 'GET', url: '/api/timelines/0' }).
    success(function (data) {
        $scope.timelines = data;
    })
})

.controller('ContentsCtrl', function ($scope, $http, $routeParams) {
    $http({ method: 'GET', url: 'api/contents/' + $routeParams.eventId }).
    success(function (data) {
        $scope.contents = data;
    })
})

.controller('EventsCtrl', function ($scope, $http, $routeParams) {
    $http({ method: 'GET', url: '/api/events/' + $routeParams.timelineId }).
    success(function (data) {
        $scope.events = data;

    });
});