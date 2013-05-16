define(['jquery',
        'knockout.mapping'], function ($, mapping) {

    var loadModel = function (param, callback) {

        $.ajax('api/notes/' + param).done(function (xhr) {

            var model = mapping.fromJS(xhr);
            callback.call(model);
        });
    };

    return { loadModel: loadModel };
});