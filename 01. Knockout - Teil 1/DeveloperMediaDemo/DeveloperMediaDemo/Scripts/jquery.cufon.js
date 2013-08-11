define(['jquery', 'cufon', 'buxtonSketch'], function ($, cufon) {

    $.cufon = function () {
        cufon.replace('h1, h2', { fontFamily: 'Buxton Sketch' });
    };
});