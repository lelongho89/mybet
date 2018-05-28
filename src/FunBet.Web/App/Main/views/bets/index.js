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

            function normalizeMatches(items) {
                return items.forEach(function (obj, index) {
                    obj.homeScore = '';
                    obj.awayScore = '';
                });
            }

            function canBet(item) {
                return (item.homeScore || '') !== '' && (item.awayScore || '') !== '';
            }

            vm.bet = function (match) {
                betService.bet({
                    matchId: match.id,
                    predictScore: match.homeScore + '-' + match.awayScore
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