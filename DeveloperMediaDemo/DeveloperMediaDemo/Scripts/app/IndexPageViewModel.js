define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping) {

    var IndexPageViewModel = function () {

        var self = this;

        self.header = ko.observable("Example");
        self.notes = ko.observableArray(
            [{  Title: "Ein PostIt", Message: "Hello World" },
             { Title: "Zweites Beispiel", Message: "Alles mit Bindings" },
             { Title: "Drittes Beispiel", Message: "Geladen über WebApi" }]);

        self.loadData = function () {

            $.ajax('/URL').done(function (xhr) {
                self.notes = mapping.fromJS(xhr, {}, self.notes);
            });
        };
    };

    return IndexPageViewModel;
});