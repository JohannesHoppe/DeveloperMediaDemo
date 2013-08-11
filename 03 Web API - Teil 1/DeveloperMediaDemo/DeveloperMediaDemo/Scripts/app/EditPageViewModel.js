define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping) {

    var EditPageViewModel = function(id) {

        var self = this;

        self.Id = ko.observable();
        self.Title = ko.observable();
        self.Message = ko.observable();
        self.Categories = ko.observableArray();
        self.CategoryChoices = ['important', 'hobby', 'private'];
        self.status = ko.observable('');
        
        self.loadData = function (callback) {

            $.ajax('/api/note/' + id).done(function (xhr) {
                self = mapping.fromJS(xhr, {}, self);
                callback.call(self);
            });
        };

        self.saveForm = function () {

            $.ajax({
                url: '/api/note',
                type: 'put',
                data: ko.toJSON(self),
                contentType: 'application/json'

            }).fail(function () {
                self.status('error');
            }).done(function () {
                self.status('success');
            });
        };

    };

    return EditPageViewModel;
});