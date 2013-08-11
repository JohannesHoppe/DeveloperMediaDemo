define(['jquery', 'knockout', 'knockout.mapping', 'singlePage/appState'], function ($, ko, mapping, appState) {

    var IndexPageViewModel = function () {

        var self = this;

        self.header = ko.observable("Example");
        self.notes = ko.observableArray();

        self.loadData = function (callback) {

            $.ajax('/api/note').done(function (xhr) {
                self.notes = mapping.fromJS(xhr, {}, self.notes);
                callback.call(self);
            });
        };
        
        self.createNote = function () {
            $.post('api/note/').done(function (newId) {
                appState.changeState("edit", newId);
            });
        };
       
        self.deleteNote = function (data) {
            $.ajax({
                url: 'api/note/' + data.Id(),
                type: 'DELETE'
            }).success(self.loadData);
        };
    };

    return IndexPageViewModel;
});