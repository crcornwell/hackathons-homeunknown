function timelineController($scope, $http) {
    $http({ method: 'GET', url: '/api/timelines/0' }).
    success(function (data) {
        $scope.timelines = JSON.parse(data);
    });
}