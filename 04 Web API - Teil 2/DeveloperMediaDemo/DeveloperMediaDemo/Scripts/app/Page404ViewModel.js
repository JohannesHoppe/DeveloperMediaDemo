﻿define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping) {

    var Page404ViewModel = function() {

        var self = this;
        self.loadData = function (callback) {
            callback.call(self);
        };
    };

    return Page404ViewModel;
});