angular.module('homeUnknown', ['ngRoute'])

.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        controller: 'TimelineCtrl',
        templateUrl: 'timelines.html'
    })
    .when('/#/events/:timelineId', {
        controller: 'EventsCtrl',
        template: 'events.html'
    //})
    //.otherwise({
    //    redirectTo: '/'
    });
})

.controller('TimelineCtrl', function ($scope, $http) {
    $http({ method: 'GET', url: '/api/timelines/0' }).
    success(function (data) {
        $scope.timelines = data;
    })
})

.controller('EventsCtrl', function ($scope, $http, $routeParams) {
    $http({ method: 'GET', url: '/api/events/' + $routeParams.timelineId }).
    success(function (data) {
        $scope.events = data;
    })
});