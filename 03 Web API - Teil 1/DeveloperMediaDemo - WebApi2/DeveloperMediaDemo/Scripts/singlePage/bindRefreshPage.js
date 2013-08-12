define(['jquery',
        'singlePage/app',
        'jquery.plugins'], function ($, app, cufon) {

    var bindRefreshPage = function () {

        app.events.bind('viewLoaded', function () {
            $.refreshPage();
        });
    };
            
    $(bindRefreshPage);
});