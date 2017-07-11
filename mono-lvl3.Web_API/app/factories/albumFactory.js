(function () {
    var injectParams = ['$http'];
    var albumFactory = function ($http) {

        var urlBase = '/api/album';
        var factory = {};

        factory.getAlbums = function () {
            return $http.get(urlBase);
        };

        factory.getAlbum = function (id) {
            var a = $http.get(urlBase + '/' + id);
            return a;
        };

        factory.insertAlbum = function (album) {
            return $http.post(urlBase, album);
        };

        factory.updateAlbum = function (album) {
            var a = $http.put(urlBase + '/' + album.id, album);
            return $http.put(urlBase + '/' + album.id, album);
        };

        factory.deleteAlbum = function (id) {
            return $http.delete(urlBase + '/' + id);
        };

        factory.getSongs = function () {
            return $http.get('/api/song');
        };

        factory.getArtists = function () {
            return $http.get('api/artist');
        };

        return factory;
    };

    albumFactory.$inject = injectParams;

    angular.module('musicApp').factory('albumFactory', albumFactory);


}());
