(function () {

    angular.module('app').controller('addNotesController', ['$location', 'notesService', addNotesController]);

    function addNotesController($location, notesService) {
        var vm = this;
        vm.newNote = {};

        vm.saveNote = function (note) {
            note.dateCreated = new Date();
            note.lastModified = new Date();
            notesService.addNotes(note).then(onsuccess).catch(onerror);
        }
        
        vm.cancelChanges = function () {
            $location.path('/');
        }

        function onsuccess(response) {
            $location.path('/');
        }

        function onerror(error) {
            console.log(error);
        }
    }

})();