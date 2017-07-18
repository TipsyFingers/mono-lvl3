(function () {

    var injectParams = ['$scope', '$route', '$location', 'songArtistsService'];
    var SongArtistsController = function ($scope, $route, $location, songArtistsService) {

        $scope.artists;
        $scope.selectedArtists = [];
        $scope.songId = $route.current.params.id.valueOf();
        $scope.song = songArtistsService.getSong();

        getArtists();
        getSong($scope.songId);


        function getArtists() {
            songArtistsService.getArtists()
                .success(function (artists) {
                    $scope.artists = artists;
                })
                .error(function (error) {
                    $scope.status = 'Unable to load artists: ' + error.message;
                });
        };

        function getSong(id) {
            songArtistsService.getSong(id)
                .success(function (song) {
                    $scope.song = song;
                    $scope.selectedArtists = song.artists;
                })
            .error(function (error) {
                $scope.status = 'Unable to load song: ' + error.message;
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
            songArtistsService.addArtists($scope.song.id, $scope.selectedArtists);
            $location.url('/song');
        };


    };

    SongArtistsController.$inject = injectParams;

    angular.module('musicApp').controller('songArtistsController', SongArtistsController);

}());