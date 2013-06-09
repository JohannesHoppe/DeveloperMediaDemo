define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping, routes) {

    var EditPageViewMode = function(id) {

        var self = this;

        self.Id = ko.observable();
        self.Title = ko.observable();
        self.Message = ko.observable();
        self.Categories = ko.observable();
        
        
        self.loadData = function () {

            $.ajax('/api/note/' + id).done(function (xhr) {
                self = mapping.fromJS(xhr, {}, self);

                $.refreshPage();
            });
        };

        self.saveForm = function (formElement) {

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

    };

    return EditPageViewMode;
});