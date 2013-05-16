define(['jquery',
        'knockout',
        'singlePage/appState',
        'datejs'],
function ($, ko, appState) {

    ko.bindingHandlers.changeStateOnClick = {
        init: function (element, valueAccessor) {

            var value = ko.utils.unwrapObservable(valueAccessor());
            $(element).click(function () {
                appState.changeState(value.viewId, value.param);
            });
        }
    };

    // uses Date.js
    // expects a string in ISO 8601 format
    ko.bindingHandlers.dateText = {
        update: function (element, valueAccessor, allBindingsAccessor) {

            var allBindings = allBindingsAccessor();
            var value = ko.utils.unwrapObservable(valueAccessor());

            var pattern = allBindings.datePattern || 'MM/dd/yyyy';
            var dt = new Date(Date.parseISO(value));
            var formatedByDatejs = dt.toString(pattern);

            $(element).text(formatedByDatejs);
        }
    };

    var colorPreference = ["red", "green", "gray"];
    ko.bindingHandlers.choseCategoryColor = {
        update: function (element, valueAccessor) {

            var categories = ko.utils.unwrapObservable(valueAccessor());

            var allAvaliableColors = [];
            $.each(categories, function (index, colorName) {
                allAvaliableColors.push(colorName.Color());
            });

            var chosenColor;
            $.each(colorPreference, function (index, colorName) {
                if ($.inArray(colorName, allAvaliableColors) !== -1) {
                    chosenColor = colorName;
                    return false;
                }
            });

            if (chosenColor) {
                $(element).addClass(chosenColor + "Color");
            }
        }
    };
});

    

/**
* Date.parse with enhancement for ISO 8601 <https://github.com/csnover/js-iso8601>
* © 2011 Colin Snover <http://zetafleet.com>
* Released under MIT license.
*/
(function (Date, undefined) {
    
    var origParse = Date.parse, numericKeys = [1, 4, 5, 6, 7, 10, 11];
    
    Date.parseISO = function (date) {
        var timestamp, struct, minutesOffset = 0;

        // ES5 §15.9.4.2 states that the string should attempt to be parsed as a Date Time String Format string
        // before falling back to any implementation-specific date parsing, so that’s what we do, even if native
        // implementations could be faster
        //              1 YYYY                2 MM       3 DD           4 HH    5 mm       6 ss        7 msec        8 Z 9 ±    10 tzHH    11 tzmm
        if ((struct = /^(\d{4}|[+\-]\d{6})(?:-(\d{2})(?:-(\d{2}))?)?(?:T(\d{2}):(\d{2})(?::(\d{2})(?:\.(\d{3}))?)?(?:(Z)|([+\-])(\d{2})(?::(\d{2}))?)?)?$/.exec(date))) {
            // avoid NaN timestamps caused by “undefined” values being passed to Date.UTC
            for (var i = 0, k; (k = numericKeys[i]); i += 1) {
                struct[k] = +struct[k] || 0;
            }

            // allow undefined days and months
            struct[2] = (+struct[2] || 1) - 1;
            struct[3] = +struct[3] || 1;

            if (struct[8] !== 'Z' && struct[9] !== undefined) {
                minutesOffset = struct[10] * 60 + struct[11];

                if (struct[9] === '+') {
                    minutesOffset = 0 - minutesOffset;
                }
            }

            timestamp = Date.UTC(struct[1], struct[2], struct[3], struct[4], struct[5] + minutesOffset, struct[6], struct[7]);
        }
        else {
            timestamp = origParse ? origParse(date) : NaN;
        }

        return timestamp;
    };
} (Date));