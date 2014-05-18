angular.module('homeUnknown', ['ngRoute', 'ui.router'])

.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        controller: 'TimelineCtrl',
        templateUrl: 'timelines.html'
    })
    .when('/contents/:eventId/:timelineId', {
        controller: 'ContentsCtrl',
        templateUrl: 'contents.html'
    })
    .when('/events/:timelineId', {
        controller: 'EventsCtrl',
        templateUrl: 'events.html'
    });
})

.config(function ($stateProvider) {
    $stateProvider
    .state('contents', {
        templateUrl: 'contents.html',
        controller: 'ContentsCtrl'
    })
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
        $scope.eventID = $routeParams.eventId;
    });
    $http({ method: 'GET', url: 'api/events/' + $routeParams.timelineId }).
    success(function (data) {
        $scope.events = data;
    });
    $scope.addContent = function() {
        $http({ method: 'POST', url: '/api/content/', data: $('#add-content-form').serialize() });
    }
})

.controller('EventsCtrl', function ($scope, $http, $routeParams) {
    $http({ method: 'GET', url: '/api/events/' + $routeParams.timelineId }).
    success(function (data) {
        $scope.events = data;
        $('#timelinejs').show();
        timeline = new VMM.Timeline();
        timeline.init();
        $('.vco-slider').hide();
    });
});