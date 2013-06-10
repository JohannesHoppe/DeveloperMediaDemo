define(['singlePage/app',
        'jquery',
        'sammy',
        'singlePage/bindLoadingIndicator',
        'singlePage/bindRefreshPage'], function (app, $, sammy) {

    var sammyApp;

    var init = function() {

        // Client-side routes    
        sammyApp = sammy(function () {

            this.get('#/', function () {
                app.loadView('index');
            });

            this.get('#:viewId', function () {
                app.loadView(this.params.viewId);
            });

            this.get('#:viewId/:param', function () {
                app.loadView(this.params.viewId, this.params.param);
            });

            this.notFound = function() {
                app.loadView('page404');
            };

        }).run('#/');
    };

    var changeState = function (newViewId, newParam) {

        var newLocation = !newParam ? "#" + newViewId :
                                      "#" + newViewId + "/" + newParam;
        sammyApp.setLocation(newLocation);
    };
            
    var reload = function() {
        sammyApp.refresh();
    };

    return {
        init: init,
        changeState: changeState,
        reload: reload
    };
});