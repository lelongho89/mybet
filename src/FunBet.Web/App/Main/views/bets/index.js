(function () {
    angular.module('app').controller('app.views.bets.index', [
        '$scope', '$uibModal', 'abp.services.app.bet',
        function ($scope, $uibModal, betService) {
            var vm = this;

            vm.matches = [];

            function getMatches() {
                betService.getAllMatches({}).then(function (result) {
                    vm.matches = result.data.items;
                });
            }

            

            vm.bet = function (match) {
                betService.bet({ matchId: match.id })
                    .then(function () {
                    });
            }

            vm.refresh = function () {
                getMatches();
            };

            getMatches();
        }
    ]);
})();