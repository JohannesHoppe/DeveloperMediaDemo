define(['jquery',
        'knockout.mapping',
        'singlePage/appState'], function ($, mapping, appState) {

    var loadModel = function (param, callback) {

        $.ajax('api/notes').done(function (xhr) {

            var model = {
                notes: mapping.fromJS(xhr),
                deleteNote: function (data, event) {

                    $.ajax({
                        url: 'api/notes/' + data.Id(),
                        type: 'DELETE'
                    }).success(function () {
                        appState.reload();
                    });
                    
                }
            };
            callback.call(model);
        });
    };

    return { loadModel: loadModel };
});
