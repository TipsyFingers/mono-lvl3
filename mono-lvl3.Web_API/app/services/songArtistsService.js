(function () {

    var injectParams = ['$http', 'artistFactory', 'songFactory'];
    var songArtistsService = function ($http, artistFactory, songFactory) {

        this.getArtists = function () {
            return artistFactory.getArtists();
        };

        this.getSong = function (id) {
            return songFactory.getSong(id);
        }

        this.addArtists = function (songId, artistIds) {
            return songFactory.addArtists(songId, artistIds);
        };
    };

    songArtistsService.$inject = injectParams;
    angular.module('musicApp').service('songArtistsService', songArtistsService);

}());