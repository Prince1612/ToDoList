(function () {

    angular.module('app').factory('notesService', ['$http','constantsService', notesService]);

    function notesService($http, constantsService) {
        return {
            getData: getData,
            addNotes: addNotes,
            deleteNotes: deleteNotes,
            getNoteById: getNoteById,
            updateNote: updateNote
        };

        function updateNote(note) {
            return $http({
                method: 'put',
                url: constantsService.NOTES_SERVICE_PATH,
                data: note
            }).then(onpostsuccess);
        }

        function getNoteById(id) {
            return $http({
                method: 'Get',
                url: constantsService.NOTES_SERVICE_PATH + id
            }).then(onsuccess);
        }
        
        function deleteNotes(id) {
            return $http({
                method: 'delete',
                url: constantsService.NOTES_SERVICE_PATH + id
            }).then(onpostsuccess);
        }

        function addNotes(notes) {
            return $http({
                method: 'Post',
                url: constantsService.NOTES_SERVICE_PATH,
                data: notes
            }).then(onpostsuccess);
        }

        function getData() {
            return $http({
                method: 'GET',
                url: constantsService.NOTES_SERVICE_PATH
            }).then(onsuccess);
        }
    }

    function onpostsuccess(response) {
        return response;
    }
    
    function onsuccess(response) {
        return response.data;
    }

})();