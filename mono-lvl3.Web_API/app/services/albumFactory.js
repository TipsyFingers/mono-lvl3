(function () {
    var injectParams = ['$http'];
    var albumFactory = function ($http) {

        var urlBase = '/api/album';
        var factory = {};

        factory.getAlbums = function () {
            return $http.get(urlBase);
        };

        factory.getAlbum = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        factory.insertAlbum = function (album) {
            return $http.post(urlBase, album);
        };

        factory.updateAlbum = function (album) {
            return $http.put(urlBase + '/' + album.id, album);
        };

        factory.deleteAlbum = function (id) {
            return $http.delete(urlBase + '/' + id);
        };

        factory.getSongs = function () {
            return $http.get('/api/song');
        };

        return factory;
    };

    albumFactory.$inject = injectParams;

    angular.module('musicApp').factory('albumFactory', albumFactory);


}());
