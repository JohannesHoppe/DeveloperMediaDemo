﻿//define(['jquery', 'knockout', 'knockout.mapping', 'knockout.validation'], function ($, ko, mapping) {
var mapping = ko.mapping;

    var EditPageViewModel = function(id) {

        var self = this;

        ko.validation.configure({
            decorateElement: true
        });

        self.Id = ko.observable();
        self.Title = ko.observable().extend({ required: true });
        self.Message = ko.observable().extend({ required: true });
        self.Categories = ko.observableArray();

        self.watchValid = ko.validatedObservable({
            Title: self.Title,
            Message: self.Message
        });

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

            if (!self.watchValid.isValid()) {
                self.status('error');
                return;
            }

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

//    return EditPageViewModel;
//});