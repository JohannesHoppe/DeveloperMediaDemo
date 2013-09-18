define(['knockout', 'jquery', 'app/IndexPageViewModel', 'knockout.bindings', 'jquery.plugins'], function (ko, $, IndexPageViewModel) {

    var init = function() {

        var model = new IndexPageViewModel();
        ko.applyBindings(model, $('#index_template').get(0));
        model.loadData();
        
        // later we will find a better position!
        $.refreshPage();
    };

    return {
        init: init
    };
});