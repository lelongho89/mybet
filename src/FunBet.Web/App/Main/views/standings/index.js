(function () {
    angular.module('app').controller('app.views.standings.index', [
        '$scope', '$uibModal', 'abp.services.app.standing',
        function ($scope, $uibModal, standingService) {
            var vm = this;

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
        }
    ]);
})();