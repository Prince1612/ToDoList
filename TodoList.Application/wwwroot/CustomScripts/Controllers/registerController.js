(function () {

    angular.module('app').controller('registerController', ['$log', '$location', 'accountsService', registerController]);

    function registerController($log, $location, accountsService) {
        var vm = this;

        vm.user = {};
        vm.user.role = 'admin';

        vm.register = function (user) {
            $log.info(user);

            accountsService.registerUser(user).then(onsuccess).catch(onerror);
        }

        function onsuccess(response) {
            $log.info(response);
            vm.status = response.statusText;

        }

        function onerror(response) {
            $log.error(response);
            vm.status = response.data;
        }

        vm.cancelChanges = function () {
            vm.user.username = undefined;
            vm.user.password = undefined;
            vm.user.email = undefined;
        }
    }

})();