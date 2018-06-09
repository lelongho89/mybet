(function () {
    angular.module('app').directive('matches', [
        function () {
            return {
                restrict: 'E',
                replace: true,
                templateUrl: '/App/Main/views/directives/matches.cshtml',
                scope: {
                    matches: '='
                },
                link: function ($scope, element, attrs) {
                }
            };
        }
    ]);
})();