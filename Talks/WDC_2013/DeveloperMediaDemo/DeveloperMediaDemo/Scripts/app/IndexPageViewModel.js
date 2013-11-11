define(['jquery', 'knockout', 'knockout.mapping', 'globalEvent'], function ($, ko, mapping, globalEvent) {

    var IndexPageViewModel = function () {

        var self = this;

        self.header = ko.observable("Example");
        self.notes = ko.observableArray();

        self.loadData = function () {

            globalEvent.trigger('loadData');

            $.ajax('/api/note')
            .done(function (xhr) {
                self.notes = mapping.fromJS(xhr, {}, self.notes);
            }).done(function() {
                globalEvent.trigger('dataLoaded');
            });
        };
        
        self.createNote = function () {

            $.post('api/note/').done(function (newId) {
                self.goToDetails.call({ Id: function () { return newId; }});
            });
        };

        self.goToDetails = function () {
            document.location.href = "/Home/Edit/" + this.Id();
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