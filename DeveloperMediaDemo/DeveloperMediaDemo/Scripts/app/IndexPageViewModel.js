define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping) {

    var IndexPageViewModel = function () {

        var self = this;

        self.header = ko.observable("Example");
        self.notes = ko.observableArray();

        self.loadData = function () {

            $.ajax('/api/note').done(function (xhr) {
                self.notes = mapping.fromJS(xhr, {}, self.notes);
                
                // later we will find a better position!
                $.refreshPage();
            });
        };
        
        self.goToCreate = function () {
            document.location.href = "/Home/Create";
        };

        self.goToDetails = function() {
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