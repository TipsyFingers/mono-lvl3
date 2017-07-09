(function () {

    var injectParams = ['$scope', '$route', 'uuid2', 'songFactory'];
    var SongController = function ($scope, $route, uuid2, songFactory) {

        $scope.status;
        $scope.songs;
        $scope.newSong;

        getSongs();

        function getSongs() {
            songFactory.getSongs()
                .success(function (songs) {
                    $scope.songs = songs;
                })
                .error(function (error) {
                    $scope.status = 'Unable to load songs: ' + error.message;
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
            song.id = uuid2.newguid();

            songFactory.insertSong(song)
                .success(function () {
                    $scope.status = 'Inserted Song! Refreshing song list.';
                    $scope.songs.push(song);
                    $scope.newSong = null;
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