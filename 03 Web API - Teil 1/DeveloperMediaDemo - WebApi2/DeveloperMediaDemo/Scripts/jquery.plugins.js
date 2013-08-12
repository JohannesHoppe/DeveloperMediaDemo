define(['jquery', 'jquery.cufon', 'jquery.dropShadows'], function ($) {

    $.refreshPage = function () {
        $.dropShadows();
        $.cufon();
    };
});