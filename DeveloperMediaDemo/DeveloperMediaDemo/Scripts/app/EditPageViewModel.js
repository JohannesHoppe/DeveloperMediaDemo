define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping) {

    var EditPageViewMode = function(id) {

        var self = this;

        self.Id = ko.observable();
        self.Title = ko.observable();
        self.Message = ko.observable();
        self.Categories = ko.observableArray();
        
        self.loadData = function () {

            $.ajax('/api/note/' + id).done(function (xhr) {
                self = mapping.fromJS(xhr, {}, self);

                // later we will find a better position!
                $.refreshPage();
            });
        };
    };

    return EditPageViewMode;
});