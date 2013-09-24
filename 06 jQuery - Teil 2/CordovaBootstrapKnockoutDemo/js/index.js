var app = function (ko, IndexPageViewModel) {

    var init, onDeviceReady, bindModel;

    init = function () {
        document.addEventListener('deviceready', onDeviceReady, false);
    };

    onDeviceReady = function() {
        bindModel();
        navigator.splashscreen.hide();
    };

    bindModel = function() {

        var model = new IndexPageViewModel();
        ko.applyBindings(model, $('#index_template').get(0));
        model.loadData();
    };

    return {
        init: init
    };

}(window.ko, window.IndexPageViewModel);
