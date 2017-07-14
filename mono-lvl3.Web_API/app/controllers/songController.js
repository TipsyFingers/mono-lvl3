(function () {

    var injectParams = ['$scope', '$route', 'songFactory', 'albumFactory'];
    var SongController = function ($scope, $route, songFactory, albumFactory) {

        $scope.status;
        $scope.songs;
        $scope.albums;
        $scope.newSong;

        getSongs();
        getAlbums();

        function getSongs() {
            songFactory.getSongs()
                .success(function (songs) {
                    $scope.songs = songs;
                })
                .error(function (error) {
                    $scope.status = 'Unable to load songs: ' + error.message;
                });
        }

        function getAlbums() {
            albumFactory.getAlbum()
                .success(function (albums) {
                    $scope.albums = albums;
                })
                .error(function (error) {
                    $scope.status = 'Unable to load albums: ' + error.message;
                });
        }

        $scope.updateSong = function (id) {
            var song;
            for (var i = 0; i < $scope.songs.length; i++) {
                var currSong = $scope.songs[i];
                if (currSong.id == id) {
                    song = currSong;
                    break;
                }
            }

            songFactory.updateSong(song)
              .success(function () {
                  $scope.status = 'Updated Song! Refreshing song list.';
              })
              .error(function (error) {
                  $scope.status = 'Unable to update song: ' + error.message;
              });
        };

        $scope.insertSong = function () {
            var song = $scope.newSong;

            songFactory.insertSong(song)
                .success(function () {
                    $scope.status = 'Inserted Song! Refreshing song list.';
                    $scope.songs.push(song);
                    $scope.newSong = null;
                    $route.reload();
                }).
                error(function (error) {
                    $scope.status = 'Unable to insert song: ' + error.message;
                });
        };

        $scope.deleteSong = function (id) {
            songFactory.deleteSong(id)
            .success(function () {
                for (var i = 0; i < $scope.songs.length; i++) {
                    var song = $scope.songs[i];
                    if (song.id === id) {
                        $scope.songs.splice(i, 1);
                        break;
                    }
                }
                $scope.status = 'Deleted Song! Refreshing song list.';
            })
            .error(function (error) {
                $scope.status = 'Unable to delete song: ' + error.message;
            });
        };

        
    };

    SongController.$inject = injectParams;

    angular.module('musicApp').controller('songController', SongController);

}());