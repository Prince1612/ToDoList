(function () {

    angular.module('app').directive('displayNoteDirective', [displayNoteDirective]);

    function displayNoteDirective() {
        return {
            templateUrl: 'CustomScripts/Directives/DisplayNoteDirective/displayNoteDirective.html',
            restrict: 'E',
            scope: {
                noteCollection: '=',
                deleteClick: '&',
                updateNote: '&'
            },
            controller: ['$scope', controllerMethod]
        };
    }

    function controllerMethod($scope) {

        $scope.editNote = function (note) {
            console.log('directive: ' + note);
            $scope.updateNote({ note: note });
        }

        $scope.deleteNote = function (id) {
            console.log('directive: ' + id);
            $scope.deleteClick({ id: id });
        }
    }

})();