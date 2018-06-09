(function () {
    angular.module('app').controller('app.views.bets.index', [
        '$scope', '$uibModal', 'abp.services.app.bet',
        function ($scope, $uibModal, betService) {
            var vm = this;

            vm.betMatches = [];

            function getBetMatches() {
                betService.getMatchesToBet({}).then(function (result) {
                    vm.betMatches = result.data.items;
                });
            }

            function canBet(item) {
                if (item.finished) {
                    abp.notify.error(App.localize("The match has been finished!"));
                    return false;
                }
                // Not allowed to bet  after 75th minute.
                if (abp.clock.now() > moment(item.date).add(90, 'm').toDate()) {
                    abp.notify.error(App.localize("It''s too late to bet!"));
                    return false;
                }

                if (item.homePredict == null || item.awayPredict == null) {
                    abp.notify.error(App.localize("Please enter valid score!"));
                    return false;
                }

                return true;
            }

            vm.bet = function (match) {
                if (!canBet(match)) {
                    return false;
                }

                betService.bet({
                    matchId: match.id,
                    homePredict: match.homePredict,
                    awayPredict: match.awayPredict
                }).then(function () {
                    abp.notify.success(App.localize("You've successfull place your bet!"));
                });
                    
            }

            vm.refresh = function () {
                getBetMatches();
            };

            getBetMatches();
        }
    ]);
})();