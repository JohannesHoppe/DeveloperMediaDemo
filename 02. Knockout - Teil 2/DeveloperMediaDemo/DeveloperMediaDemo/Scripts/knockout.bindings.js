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
    
    /*
    ko.bindingHandlers.changeLocationOnClick = {
        init: function (element, valueAccessor) {

            var url = ko.utils.unwrapObservable(valueAccessor());
            $(element).click(function () {
                document.location.href = url;
            });
        }
    };*/
    
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
});