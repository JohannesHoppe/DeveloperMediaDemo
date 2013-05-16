define(['jquery',
        'singlePage/app',
        'cufon',
        'buxtonSketch'], function ($, app, cufon) {

    var bindRefreshView = function () {

        app.$events.bind('viewLoaded', function () {

            // adds a drop shadow effect
            $(".drop_shadow").wrapInner('<div class="drop_shadow5" />');
            $(".drop_shadow").wrapInner('<div class="drop_shadow4" />');
            $(".drop_shadow").wrapInner('<div class="drop_shadow3" />');
            $(".drop_shadow").wrapInner('<div class="drop_shadow2" />');

            cufon.replace('h1, h2', { fontFamily: 'Buxton Sketch' });
        });
    };
            
    $(bindRefreshView);
});