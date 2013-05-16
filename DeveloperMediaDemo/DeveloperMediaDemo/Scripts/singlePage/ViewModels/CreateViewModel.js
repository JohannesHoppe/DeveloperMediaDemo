define(['jquery',
        'knockout.mapping',
        'singlePage/appState',
        'jquery.serializeObject'], function ($, mapping, appState) {

        var loadModel = function (param, callback) {

        var model = {};

        $.ajax('api/categories').done(function (xhr) {

            model.Categories = mapping.fromJS(xhr);
            callback.call(model);
        });

        model.handleAfterRender = function () {

            $("#createForm").submit(function() {

                var formData = $("#createForm").serializeObject();
                 $.ajax({
                    url: "api/notes",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(formData)
                }).success(function() {
                    appState.changeState('index');
                });
                
                return false;
            });
        };
    };

    return {
        loadModel: loadModel
    };
});
