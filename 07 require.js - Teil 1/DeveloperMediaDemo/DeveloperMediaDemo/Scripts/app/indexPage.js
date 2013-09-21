define(['knockout', 'jquery', 'app/IndexPageViewModel', 'globalEvent', 'knockout.bindings', 'jquery.plugins'], function (ko, $, IndexPageViewModel) {

    var init = function() {

        var model = new IndexPageViewModel();
        ko.applyBindings(model, $('#index_template').get(0));
        model.loadData();
    };

    return {
        init: init
    };
});