(function () {

    angular.module('app').controller('loginController', ['$log', '$location', 'accountsService', loginController]);

    function loginController($log, $location, accountsService) {
        var vm = this;

        vm.username = 'Prince';
        vm.password = 'Test@123';

        accountsService.logoutUser().then(onsuccessLogout).catch(onerror);

        vm.cancelChanges = function () {
            vm.username = undefined;
            vm.password = undefined;
            $log.info('cleared the data from the form.');
        }

        vm.login = function(user, pass){
            $log.info('Username: ' + user + ' password: ' + pass);
            accountsService.loginUser({ username: user, password: pass}).then(onsuccess).catch(onerror);
        }

        function onsuccessLogout(response) {
            $log.info('logged out successfully. status: ' + response.statusText);
        }

        function onsuccess(response) {
            vm.status = response.data;
            $location.path('/');

        }

        function onerror(response) {
            vm.status = response.statusText;
        }
    }

})();