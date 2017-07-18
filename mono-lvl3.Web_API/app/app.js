/// <reference path="C:\Users\Kruno\Documents\Visual Studio 2015\Projects\mono-lvl3\mono-lvl3.Web_API\Scripts/angular.min.js" />


(function () {

    var app = angular.module('musicApp', ['ngRoute']);
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
            .when('/addArtistsAlbum/:id', {
                controller: 'albumArtistsController',
                templateUrl: viewBase + 'addArtistsAlbum.html'
            })
            .when('/addArtistsSong/:id', {
                controller: 'songArtistsController',
                templateUrl: viewBase + 'addArtistsSong.html'
            })
            .otherwise({ redirectTo: '/' });

    }]);

}());