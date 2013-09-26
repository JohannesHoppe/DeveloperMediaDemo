var IndexPageViewModel = (function (ko) {

    var IndexPageViewModel = function () {

        var self = this;

        self.notes = ko.observableArray();
        self.selectedNote = ko.observable(false);

        self.loadData = function () {

            self.notes.removeAll();
            $.ajax({
                url: 'http://johanneshoppe.github.io/DeveloperMediaSlides/examples/webinarp.json',
                dataType: 'jsonp',
                jsonpCallback: 'callback'
            }).done(function(result) {
                self.notes = ko.mapping.fromJS(result, {}, self.notes);
            });
        };

        self.showDetails = function (current) {
            self.selectedNote(current);
        };

        self.showHome = function() {
            self.selectedNote(false);
        };
    };

    return IndexPageViewModel;
    
})(window.ko);