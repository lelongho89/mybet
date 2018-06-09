(function () {
    angular.module('app').controller('app.views.matches.index', [
        '$scope', '$uibModal', 'abp.services.app.match',
        function ($scope, $uibModal, matchService) {
            var vm = this;

            vm.data = {};


            function getMatches() {
                matchService.getAll({}).then(function (result) {
                    vm.data = result.data;
                });
            }
            
            vm.currentViewType = 'List';

            vm.view = function(type){
                vm.currentViewType = type;    
            }

            vm.refresh = function () {
                getMatches();
            };

            getMatches();
        }
    ]);
})();