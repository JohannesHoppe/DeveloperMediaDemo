(function (global) {
    var app = global.app = global.app || {};

    document.addEventListener("deviceready", function() {

        app.indexPageViewModel = new IndexPageViewModel();
        app.indexPageViewModel.loadData();

        app.detailsPageViewModel = new DetailsPageViewModel();
        
        // kendo.mobile.Application internally calls kendo.bind
        app.application = new kendo.mobile.Application($(document.body), { layout: "tabstrip-layout" });

    }, false);

})(window);