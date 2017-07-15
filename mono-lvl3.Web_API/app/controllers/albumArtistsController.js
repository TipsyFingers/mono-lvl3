(function () {

    var injectParams = ['$scope', '$route', 'albumArtistsService'];
    var AlbumArtistsController = function ($scope, $route, albumArtistsService) {
        
        $scope.artists;
        $scope.selectedArtists = [];
        $scope.albumId = $route.current.params.id.valueOf();
        $scope.album = albumArtistsService.getAlbum();        

        getArtists();
        getAlbum($scope.albumId);


        function getArtists() {
            albumArtistsService.getArtists()
                .success(function (artists) {
                    $scope.artists = artists;                    
                })
                .error(function (error) {
                    $scope.status = 'Unable to load artists: ' + error.message;
                });
        };

        function getAlbum(id) {
            albumArtistsService.getAlbum(id)
                .success(function (album) {
                    $scope.album = album;
                })
            .error(function (error) {
                $scope.status = 'Unable to load album: ' + error.message;
            });
        };

        $scope.toggle = function (item, list) {
            var idx = list.indexOf(item);
            if (idx > -1) {
                list.splice(idx, 1);
            }
            else {
                list.push(item);
            }
        };

        $scope.exists = function (item, list) {
            return list.indexOf(item) > -1;
        };

        $scope.submitArtists = function () { 
            albumArtistsService.addArtists($scope.album.id, $scope.selectedArtists);
        };

        
    };

    AlbumArtistsController.$inject = injectParams;

    angular.module('musicApp').controller('albumArtistsController', AlbumArtistsController);

}());