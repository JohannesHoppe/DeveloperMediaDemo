var mapping = ko.mapping;

var IndexPageViewModel = function () {

    var self = this;

    self.header = ko.observable("Example");
    self.notes = ko.observableArray();

    self.loadData = function () {

        $.ajax('/api/note').done(function (xhr) {
            self.notes = mapping.fromJS(xhr, {}, self.notes);
            $.refreshPage();
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