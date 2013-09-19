define(['knockout', 'jquery', 'app/EditPageViewModel', 'knockout.bindings', 'jquery.plugins'], function (ko, $, EditPageViewModel) {

    var init = function (id) {

        var model = new EditPageViewModel(id);
        ko.applyBindings(model, $('#edit_template').get(0));
        model.loadData();
    };

    return {
        init: init
    };
});