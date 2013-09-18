define(['jquery', 'knockout', 'polyfills/iso8601', 'polyfills/datejs'],
function ($, ko) {

    var colorMapping = [
        { category: 'important', color: "red" },
        { category: 'hobby', color: "green" },
        { category: 'private', color: "gray" }];
    
    ko.bindingHandlers.choseCategoryColor = {
        update: function (element, valueAccessor) {

            var chosenColor, categories = ko.utils.unwrapObservable(valueAccessor());

            // remove all already existing CSS classes
            $.each(colorMapping, function (index, mapping) {
                $(element).removeClass(mapping.color + "Color");
            });

            // find new class
            $.each(colorMapping, function (index, mapping) {
                if ($.inArray(mapping.category, categories) !== -1) {
                    chosenColor = mapping.color;
                    return false;
                }
            });

            if (chosenColor) {
                $(element).addClass(chosenColor + "Color");
            }
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
    
    /* seems to be a Knockout + jQuery + Adblock Plus bug ... I don't even know where to report that issue?!
       so i had to add event.stopPropagation();
       */
    ko.bindingHandlers.submit = {
        'init': function (element, valueAccessor, allBindingsAccessor, viewModel) {
            if (typeof valueAccessor() != "function")
                throw new Error("The value for a submit binding must be a function");
            ko.utils.registerEventHandler(element, "submit", function (event) {
                var handlerReturnValue;
                var value = valueAccessor();
                try { handlerReturnValue = value.call(viewModel, element); }
                finally {
                    if (handlerReturnValue !== true) {
                        if (event.preventDefault) {
                            event.preventDefault();

                            // NEW - required if adblock plus is active!!
                            event.stopPropagation();
                        }
                        else
                            event.returnValue = false;
                    }
                }
            });
        }
    };
});