(function () {

    var app = angular.module('musicApp', ['ngRoute', 'angularUUID2']);
    var viewBase = '/app/views/';

    app.config(['$routeProvider', function ($routeProvider) {

        $routeProvider
            .when('/artist', {
                controller: 'artistController',
                templateUrl: viewBase + 'artists.html'
            })
            .when('/album', {
                controller: 'albumController',
                templateUrl: viewBase + 'albums.html'
            })
            .when('/song', {
                controller: 'songController',
                templateUrl: viewBase + 'songs.html'
            })
            .otherwise({ redirectTo: '/' });

        //$routeProvider.when('/album', {
        //    controller: 'albumController',
        //    templateUrl: '/app/views/albums.html'
        //})
        //.otherwise({ redirectTo: '/' });

        //$routeProvider.when('/song', {
        //    controller: 'songController',
        //    templateUrl: '/app/views/songs.html'
        //})
        //.otherwise({ redirectTo: '/' });
    }]);

}());