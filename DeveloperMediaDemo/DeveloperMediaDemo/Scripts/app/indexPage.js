define(['knockout', 'jquery', 'IndexPageViewModel', 'jquery.cufon', 'jquery.dropShadows'], function (ko, $, IndexPageViewModel) {

    var init = function() {

        var model = new IndexPageViewModel();
        ko.applyBindings(model, $('#index_template').get(0));
        model.loadData();
        
        $.dropShadows();
        $.cufon();
    };

    return {
        init: init
    };
});