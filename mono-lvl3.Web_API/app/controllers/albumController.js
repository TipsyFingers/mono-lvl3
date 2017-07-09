(function () {

    var injectParams = ['$scope', '$route', 'uuid2', 'albumFactory'];
    var AlbumController = function ($scope, $route, uuid2, albumFactory) {

        $scope.status;
        $scope.albums;
        $scope.songs = [];
        $scope.newAlbum;

        getAlbums();

        function getAlbums() {
            albumFactory.getAlbums()
                .success(function (albums) {
                    $scope.albums = albums;
                })
                .error(function (error) {
                    $scope.status = 'Unable to load albums: ' + error.message;
                });
        }

        $scope.updateAlbum = function (id) {
            var album;
            for (var i = 0; i < $scope.albums.length; i++) {
                var currAlbum = $scope.albums[i];
                if (currAlbum.id == id) {
                    album = currAlbum;
                    break;
                }
            }

            albumFactory.updateAlbum(album)
              .success(function () {
                  $scope.status = 'Updated Album! Refreshing album list.';
              })
              .error(function (error) {
                  $scope.status = 'Unable to update album: ' + error.message;
              });
        };

        $scope.insertAlbum = function () {

            var album = $scope.newAlbum;
            album.id = uuid2.newguid();

            albumFactory.insertAlbum(album)
                .success(function () {
                    $scope.status = 'Inserted Album! Refreshing album list.';
                    $scope.albums.push(album);
                    $scope.newAlbum = null;
                }).
                error(function (error) {
                    $scope.status = 'Unable to insert album: ' + error.message;
                });
        };

        $scope.deleteAlbum = function (id) {
            albumFactory.deleteAlbum(id)
            .success(function () {
                for (var i = 0; i < $scope.albums.length; i++) {
                    var album = $scope.albums[i];
                    if (album.id === id) {
                        $scope.albums.splice(i, 1);
                        break;
                    }
                }
                $scope.status = 'Deleted Album! Refreshing album list.';
            })
            .error(function (error) {
                $scope.status = 'Unable to delete album: ' + error.message;
            });
        };

        $scope.getAlbumSongs = function (id) {
            albumFactory.getSongs()
                .then(function (songs) {
                    $scope.songs = [];

                    for (var i = 0; i < songs.data.length; i++) {
                        var song = songs.data[i];

                        if (song.albumId == id) {                            
                            $scope.songs.push(song);
                        }
                    }
                });
        };
    };

    AlbumController.$inject = injectParams;

    angular.module('musicApp').controller('albumController', AlbumController);

}());