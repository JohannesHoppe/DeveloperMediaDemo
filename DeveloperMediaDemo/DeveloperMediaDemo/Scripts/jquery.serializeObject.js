/* 
    Convert form data to JS object with jQuery
    dirty, dirty black jquery hacking here
*/
define(['jquery'], function($) {

    $.fn.serializeObject = function () {
        var o = {};
        var a = this.mySerializeArray({ checkboxesAsBools: true });
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });

        // remove all UNCHECKED array items
        $.each(o, function(index, value) {

            if (Object.prototype.toString.call(value) === '[object Array]') {

                var newArray = [];
                $.each(value, function(index2, value2) {

                    if (value2 !== "UNCHECKED") {
                        newArray.push(value2);
                    }
                });
                
                // replace with the cleaned array
                o[index] = newArray;
            }
        });

        return o;
    };

    // all checkboxes will be used
    $.fn.mySerializeArray = function (options) {
        var o = $.extend({
            checkboxesAsBools: false
        }, options || {});

        var rselectTextarea = /select|textarea/i;
        var rinput = /text|hidden|password|search/i;

        return this.map(function () {
            return this.elements ? $.makeArray(this.elements) : this;
        })
        .filter(function () {
            return this.name && !this.disabled &&
                (this.checked
                || this.type === 'checkbox'
                || rselectTextarea.test(this.nodeName)
                || rinput.test(this.type));
        })
            .map(function (i, elem) {
                var val = $(this).val();
                return val == null ?
                null :
                $.isArray(val) ?
                $.map(val, function (val, i) {
                    return { name: elem.name, value: val };
                }) :
            {
                name: elem.name,
                value: (this.type === 'checkbox') ?
                    (this.checked ? val : "UNCHECKED") :
                    val
            };
            }).get();
    };


});