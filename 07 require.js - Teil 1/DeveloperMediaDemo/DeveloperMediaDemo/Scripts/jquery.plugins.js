define(['jquery', 'globalEvent', 'jquery.cufon', 'jquery.dropShadows'], function ($, globalEvent) {

    $.refreshPage = function () {
        $.dropShadows();
        $.cufon();
    };

    globalEvent.bind('dataLoaded', function () {
        $.refreshPage();
    });
});