define(['jquery', 'knockout', 'knockout.mapping'], function ($, ko, mapping) {

    var AdminCatalogueViewModel = function () {

        var self = this;


        self.header = ko.observable("Example");
        self.notes = ko.observableArray(
            [{  Title: "Ein PostIt", Message: "Hello World" },
             {  Title: "Zweites Beispiel", Message: "Alles mit Bindings" }]);



        self.loadData = function () {

            $.ajax('/URL').done(function (xhr) {
                self.notes = mapping.fromJS(xhr, {}, self.notes);
            });
        };
    };

    return AdminCatalogueViewModel;
});