(function () {

    var injectParams = ['$http', 'artistFactory', 'albumFactory'];
    var albumArtistsService = function ($http, artistFactory, albumFactory) {

        this.getArtists = function () {
            return artistFactory.getArtists();
        };

        this.getAlbum = function (id) {
            return albumFactory.getAlbum(id);
        }

        this.addArtists = function (albumId, artistIds) {
            return albumFactory.addArtists(albumId, artistIds);
        };
    };

    albumArtistsService.$inject = injectParams;
    angular.module('musicApp').service('albumArtistsService', albumArtistsService);

}());