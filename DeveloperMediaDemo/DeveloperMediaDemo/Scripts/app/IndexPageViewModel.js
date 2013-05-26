define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping) {

    var IndexPageViewModel = function () {

        var self = this;

        self.header = ko.observable("Example");
        self.notes = ko.observableArray();

        self.loadData = function () {

            $.ajax('/api/note').done(function (xhr) {
                self.notes = mapping.fromJS(xhr, {}, self.notes);
                
                // later we will find a better position!
                $.dropShadows();
                $.cufon();
            });
        };
    };

    return IndexPageViewModel;
});