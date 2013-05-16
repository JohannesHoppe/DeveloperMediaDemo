define(['jquery',
        'knockout.mapping',
        'singlePage/appState'], function () {

    var loadModel = function (param, callback) {

        var model = {};
        callback.call(model);
    };

    return { loadModel: loadModel };
});
