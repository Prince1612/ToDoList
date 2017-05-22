(function () {
    'use strict';

    angular.module('app').controller('notesController', ['$location', 'notesService', notesController]);

    function notesController($location, notesService) {
        var vm = this;
        vm.message = 'This is working fine';

        notesService.getData().then(onsuccess).catch(onerror);

        function onsuccess(response) {
            vm.notes = response;
        }
        function onerror(error) {
            vm.message = error.data;
        }

        function ondeletesuccess(response) {
            notesService.getData().then(onsuccess).catch(onerror);
        }

        vm.addNotesClick = function () {
            $location.path('/addNotes');
        }

        vm.deleteInformation = function (param) {
            console.log('notes controller' + param.id);
            notesService.deleteNotes(param.id).then(ondeletesuccess).catch(onerror);
        }

        vm.editNote = function (param) {
            console.log('notes controller: ' + param);
            $location.path('/editNotes/' + JSON.stringify(param));
        }
    }

})();