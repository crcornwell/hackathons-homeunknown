angular.module('homeUnknown', ['ngRoute', 'ui.router'])

//.config(function ($routeProvider) {
//    $routeProvider
//    .when('/', {
//        controller: 'TimelineCtrl',
//        templateUrl: 'timelines.html'
//    })
//    .when('/contents/:eventId/:timelineId', {
//        controller: 'ContentsCtrl',
//        templateUrl: 'contents.html'
//    })
//    .when('/events/:timelineId', {
//        controller: 'EventsCtrl',
//        templateUrl: 'events.html'
//    });
//})

.config(function ($stateProvider) {
    $stateProvider
    .state('timelines', {
        url: '/',
        controller: 'TimelineCtrl',
        templateUrl: 'timelines.html'
    })
    .state('events', {
        url: '/timelines/:timelineId/events',
        controller: 'EventsCtrl',
        templateUrl: 'events.html'
    })
    .state('events.contents', {
        url: '/:eventId/contents',
        controller: 'ContentsCtrl',
        templateUrl: 'contents.html'
    });
})

.controller('TimelineCtrl', function ($scope, $http) {
    $http({ method: 'GET', url: '/api/timelines/0' }).
    success(function (data) {
        $scope.timelines = data;
    })
})

.controller('ContentsCtrl', function ($scope, $http, $stateParams) {
    $http({ method: 'GET', url: 'api/contents/' + $stateParams.eventId }).
    success(function (data) {
        $scope.contents = data;
        $scope.eventID = $stateParams.eventId;
    });
    $scope.addContent = function() {
        $http({ method: 'POST', url: '/api/content/', data: $('#add-content-form').serialize() });
    }
})

.controller('EventsCtrl', function ($scope, $http, $state, $stateParams) {
    $http({ method: 'GET', url: '/api/events/' + $stateParams.timelineId }).
    success(function (data) {
        $scope.events = data;
    });
});