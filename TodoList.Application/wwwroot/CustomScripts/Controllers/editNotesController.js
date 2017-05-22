(function () {

    angular.module('app').controller('editNotesController', ['$routeParams', '$location', 'notesService', editNotesController]);

    function editNotesController($routeParams, $location, notesService) {

        var vm = this;
        vm.note = angular.fromJson($routeParams.note);

        vm.saveNote = function (note) {
            note.lastModified = new Date();
            notesService.updateNote(note).then(onsuccess).catch(onerror);
        }

        vm.cancelChanges = function () {
            $location.path('/');
        }
        
        function onsuccess(data) {
            $location.path('/');
        }
    }

    function onerror(error) {
        vm.error = error;
    }

})();