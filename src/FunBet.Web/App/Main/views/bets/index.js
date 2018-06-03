(function () {
    angular.module('app').controller('app.views.bets.index', [
        '$scope', '$uibModal', 'abp.services.app.bet', 'abp.services.app.match',
        function ($scope, $uibModal, betService, matchService) {
            var vm = this;

            vm.matches = [];

            function getMatches() {
                matchService.getAll({}).then(function (result) {
                    vm.matches = result.data.items;
                });
            }

            function canBet(item) {
                return (item.homeResult || '') !== '' && (item.awayResult || '') !== '';
            }

            vm.bet = function (match) {
                betService.bet({
                    matchId: match.id,
                    homePredict: match.homeResult,
                    awayPredict: match.awayResult
                }).then(function () {
                    abp.notify.success(abp.localization("You've successfull place your bet!"));
                });
                    
            }

            vm.refresh = function () {
                getMatches();
            };

            getMatches();
        }
    ]);
})();