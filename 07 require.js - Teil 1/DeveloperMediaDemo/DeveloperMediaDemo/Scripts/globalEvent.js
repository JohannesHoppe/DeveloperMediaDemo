/**
 * Global events can be used to trigger events, and pass event-data, across frameworks.
 */
define(['jquery'], function ($) {

    var $eventobject = $({});

    return {
        bind: function() {

            var args = Array.prototype.slice.call(arguments);
            $eventobject.bind.apply($eventobject, args);
        },
        trigger: function() {

            var args = Array.prototype.slice.call(arguments);
            $eventobject.trigger.apply($eventobject, args);
        }
    };
});