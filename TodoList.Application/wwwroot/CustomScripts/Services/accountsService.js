(function () {

    angular.module('app').factory('accountsService', ['$log', '$http','constantsService', accountsService]);

    function accountsService($log, $http, constantsService) {
        return {
            registerUser: registerUser,
            loginUser: loginUser,
            logoutUser: logoutUser
        };

        function logoutUser() {
            return $http({
                method: 'get',
                url: constantsService.ACCOUNTS_SERVICE_PATH + 'logout',
            }).then(onsuccess);
        }

        function loginUser(user) {
            return $http({
                method: 'post',
                url: constantsService.ACCOUNTS_SERVICE_PATH + 'login',
                data: user
            }).then(onsuccess);
        }

        function registerUser(user) {
            $log.debug('registering user...');

            return $http({
                method: 'post',
                url: constantsService.ACCOUNTS_SERVICE_PATH,
                data: user
            }).then(onsuccess);
        }
        function onsuccess(response) {
            return response;
        }
    }

})();