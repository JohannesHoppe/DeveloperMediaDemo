define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping, routes) {

    var EditPageViewMode = function(id) {

        var self = this;

        self.Id = ko.observable();
        self.Title = ko.observable();
        self.Categories = ko.observable();
        self.Message = ko.observable();
        self.Added = ko.observable();
        

        self.update = function(autoSave) {

            $.ajax({
                url: '/api/note',
                type: 'put',
                data: ko.toJSON(self),
                contentType: 'application/json'
                
            }).error(function () {
                window.alert("Error!");
            }).success(function () {
                window.alert("Success!");
            });
        };
        
        self.loadData = function () {

            $.ajax('/api/note/' + id).done(function (xhr) {
                self = mapping.fromJS(xhr, {}, self);
                $.cufon();
            });
        };
    };

    return EditPageViewMode;
});