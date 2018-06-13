(function () {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.match', 'abp.services.app.standing', 
        function ($scope, matchService, standingService) {
            var vm = this;
            vm.matches = [];
            vm.position = {};
            function getNextMatches(){
                matchService.getNextMatches({}).then(function (result) {
                    vm.matches = result.data.items;
                });
            }

            function getPosition(){
                standingService.getPosition({}).then(function(result){
                    vm.position = result.data.position;
                });
            }

            vm.standings = [];

            function getStandings() {
                standingService.getAll({}).then(function (result) {
                    vm.standings = result.data.items;
                });
            }

            vm.refresh = function () {
                getStandings();
            };

            getStandings();
            getNextMatches();
            getPosition();
        }
    ]);
})();