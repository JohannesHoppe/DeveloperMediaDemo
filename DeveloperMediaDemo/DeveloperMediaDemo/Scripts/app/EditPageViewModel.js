define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping, routes) {

    var EditPageViewMode = function(id) {

        var self = this;

        self.Id = ko.observable();
        self.Title = ko.observable();
        self.Message = ko.observable();
        self.Categories = ko.observableArray();

        self.CategoryChoices = ['important', 'hobby', 'private'];
        self.status = ko.observable('');
        
        self.loadData = function () {

            $.ajax('/api/note/' + id).done(function (xhr) {
                self = mapping.fromJS(xhr, {}, self);

                // later we will find a better position!
                $.refreshPage();
            });
        };

        self.saveForm = function () {

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