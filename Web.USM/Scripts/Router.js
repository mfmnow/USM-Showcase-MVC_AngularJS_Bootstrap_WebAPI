HomeApp.config(function ($routeProvider) {
    $routeProvider
      .when('/home', {
          templateUrl: '/Home/DashboardHome'
      })
      .when('/about', {
          templateUrl: 'simple.html'
      });
});
HomeApp.controller('cfgRouter', function ($scope) {
    /*
    Here you can handle controller for specific route as well.
    */
});