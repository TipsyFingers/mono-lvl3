(function () {
    var injectParams = ['$http'];
    var songFactory = function ($http) {

        var urlBase = '/api/song';
        var factory = {};

        factory.getSongs = function () {
            return $http.get(urlBase);
        };

        factory.getSong = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        factory.insertSong = function (song) {
            return $http.post(urlBase, song);
        };

        factory.updateSong = function (song) {
            return $http.put(urlBase + '/' + song.id, song);
        };

        factory.deleteSong = function (id) {
            return $http.delete(urlBase + '/' + id);
        };

        

        return factory;
    };

    songFactory.$inject = injectParams;

    angular.module('musicApp').factory('songFactory', songFactory);


}());
