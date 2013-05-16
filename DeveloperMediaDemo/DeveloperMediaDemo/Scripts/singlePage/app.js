define(['jquery',
        'knockout'],
function ($, ko) {

    var $currentView;
    var $events = $({});

    var loadView = function(viewId, param) {

        unloadCurrentView();
        $currentView = $("#" + viewId + "_view");

        var viewModelName = $currentView.data("viewModel");
        if (viewModelName) {

            $events.trigger('loadView');
            require(['singlePage/ViewModels/' + viewModelName], function(viewModelFactory) {

                viewModelFactory.loadModel(param, function() {

                    ko.applyBindings(this, $currentView.get(0));
                    $events.trigger('viewLoaded');
                    $currentView.show();
                });
            });
        }
    };

    var unloadCurrentView = function() {

        if ($currentView) {
            $currentView.hide();

            ko.cleanNode($currentView.get(0));
            $currentView.unbind();
            $currentView = undefined;
        }
    };
    
    return {
        loadView: loadView,
        $events: $events
    };
});