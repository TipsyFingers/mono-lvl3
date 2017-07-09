(function () {

    var injectParams = ['$scope', '$route', 'uuid2', 'artistFactory'];
    var ArtistController = function ($scope, $route, uuid2, artistFactory) {

        $scope.status;
        $scope.artists;
        $scope.albums;
        $scope.songs;
        $scope.newArtist;

        getArtists();

        function getArtists() {
            artistFactory.getArtists()
                .success(function (artists) {
                    $scope.artists = artists;
                })
                .error(function (error) {
                    $scope.status = 'Unable to load artists: ' + error.message;
                });
        }

        $scope.updateArtist = function (id) {
            var artist;
            for (var i = 0; i < $scope.artists.length; i++) {
                var currArtist = $scope.artists[i];
                if (currArtist.id == id) {
                    artist = currArtist;
                    break;
                }
            }

            artistFactory.updateArtist(artist)
              .success(function () {
                  $scope.status = 'Updated Artist! Refreshing artist list.';
              })
              .error(function (error) {
                  $scope.status = 'Unable to update artist: ' + error.message;
              });
        };

        $scope.insertArtist = function () {
            
            var artist = $scope.newArtist;
            artist.id = uuid2.newguid();

            artistFactory.insertArtist(artist)
                .success(function () {                    
                    $scope.status = 'Inserted Artist! Refreshing artist list.';
                    $scope.artists.push(artist);
                    $scope.newArtist = null;                    
                }).
                error(function (error) {
                    $scope.status = 'Unable to insert artist: ' + error.message;
                });
        };

        $scope.deleteArtist = function (id) {
            artistFactory.deleteArtist(id)
            .success(function () {                
                for (var i = 0; i < $scope.artists.length; i++) {
                    var artist = $scope.artists[i];
                    if (artist.id === id) {
                        $scope.artists.splice(i, 1);
                        break;
                    }
                }
                $scope.status = 'Deleted Artist! Refreshing artist list.';
                $scope.albums = null;
                $scope.songs = null;
            })
            .error(function (error) {
                $scope.status = 'Unable to delete artist: ' + error.message;
            });
        };

        $scope.getDiscography = function (id) {
            artistFactory.getAlbums()
                .then(function (albums) {
                    for (var i = 0; i < albums.length; i++) {
                        if (albums[i].id == id) {
                            $scope.albums.push(albums[i]);
                        }
                    }
                });
        };
    };

    ArtistController.$inject = injectParams;

    angular.module('musicApp').controller('artistController', ArtistController);

}());