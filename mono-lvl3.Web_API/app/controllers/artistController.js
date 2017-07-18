(function () {

    var injectParams = ['$scope', '$route', 'artistFactory'];
    var ArtistController = function ($scope, $route, artistFactory) {


        $scope.artists;
        $scope.artistAlbums;
        $scope.artistSongs;
        $scope.newArtist;
        
        getArtists();
        $scope.status;
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

            artistFactory.insertArtist(artist)
                .success(function () {                    
                    $scope.status = 'Inserted Artist! Refreshing artist list.';
                    $scope.artists.push(artist);
                    $scope.newArtist = null;
                    $route.reload();
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

            $scope.artistAlbums = [];
            $scope.artistSongs = [];

            artistFactory.getAlbums()
                .success(function (albums) {                    
                    for (var i = 0; i < albums.length; i++) {
                        for (var j = 0; j < albums[i].artists.length; j++) {
                            if (albums[i].artists[j] == id) {
                                $scope.artistAlbums.push(albums[i]);
                            }
                        }
                    }
                    $scope.test = 1;
                })
            .error(function (error) {
                $scope.status = 'Unable to get albums: ' + error.message;
            });

            artistFactory.getSongs()
                .success(function (songs) {                    
                    for (var i = 0; i < songs.length; i++) {
                        for (var j = 0; j < songs[i].artists.length; j++) {
                            if (songs[i].artists[j] == id) {
                                $scope.artistSongs.push(songs[i]);
                            }
                        }
                    }
                    $scope.test = 1;
                })
            .error(function (error) {
                $scope.status = 'Unable to get songs: ' + error.message;
            });
        };
    };

    ArtistController.$inject = injectParams;
    
    angular.module('musicApp').controller('artistController', ArtistController);

}());