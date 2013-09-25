﻿(function ($) {

    $("#page-home").on('pagebeforeshow', function () {
        
        $.ajax({
            url: 'http://johanneshoppe.github.io/DeveloperMediaSlides/examples/webinarp.json',
            dataType: 'jsonp',
            jsonpCallback: 'callback'
        }).done(function (xhr) {
            $('#home-listview')
                .empty()
                .append(createListItems(xhr))
                .listview('refresh');
        });
    });

    var createListItems = function(data) {

        var items = [];
        $.each(data, function(index, item) {

            var listItemWithLink = $('<li />').append(
                $('<a />')
                    .attr('href', '#page-ui-interaction')
                    .data('transition', 'slide')
                    .text(item.Title)
                    .click(function() {
                        window.sessionStorage.setItem('currentItem', JSON.stringify(item));
                    })
            );

            items.push(listItemWithLink);
        });
        return items;
    };


    //$(document).on("deviceready", init);

})(window.jQuery);