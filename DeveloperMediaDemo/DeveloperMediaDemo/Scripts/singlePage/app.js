define(['jquery',  
        'knockout'],
function ($, ko) {

    var currentView;
    var events = $({});

    var loadView = function(viewId, param) {

        unloadCurrentView();
        currentView = $("#" + viewId + "_view");

        var viewModelName = currentView.data("viewModel");
        if (viewModelName) {

            events.trigger('loadView');
            require(['app/' + viewModelName], function (ViewModelConstuctor) {

                var model = new ViewModelConstuctor(param);
                ko.applyBindings(model, currentView.get(0));
                currentView.show();
                
                model.loadData(function() {
                    events.trigger('viewLoaded');
                });
            });
        }
    };

    var unloadCurrentView = function() {

        if (currentView) {
            currentView.hide();

            ko.cleanNode(currentView.get(0));
            currentView.unbind();
            currentView = undefined;
        }
    };
    
    return {
        loadView: loadView,
        events: events
    };
});