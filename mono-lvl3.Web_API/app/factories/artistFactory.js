(function () {
    var injectParams = ['$http'];
    var artistFactory = function ($http) {

        var urlBase = '/api/artist';
        var factory = {};

        factory.getArtists = function () {
            return $http.get(urlBase);
        };

        factory.getArtist = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        factory.insertArtist = function (artist) {
            return $http.post(urlBase, artist);
        };

        factory.updateArtist = function (artist) {
            return $http.put(urlBase + '/' + artist.id, artist);
        };

        factory.deleteArtist = function (id) {
            return $http.delete(urlBase + '/' + id);
        };

        factory.getSongs = function () {
            return $http.get('api/song');
        }

        factory.getAlbums = function () {
            return $http.get('api/album')
        }
       
        return factory;
    };

    artistFactory.$inject = injectParams;

    angular.module('musicApp').factory('artistFactory', artistFactory);


}());
