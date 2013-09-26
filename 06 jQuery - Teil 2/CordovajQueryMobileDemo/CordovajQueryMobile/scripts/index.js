(function ($) {

    $("#page-home").on('pagebeforeshow', function () {
        
        $.ajax({
            url: 'http://johanneshoppe.github.io/DeveloperMediaSlides/examples/webinarp.json',
            dataType: 'jsonp',
            jsonpCallback: 'callback'
        }).done(function (result) {
            $('#home-listview')
                .empty()
                .append(createListItems(result))
                .listview('refresh');
        });
    });

    var createListItems = function(data) {

        var items = [];
        $.each(data, function(index, item) {

            var listItemWithLink = $('<li />').append(
                $('<a />')
                    .attr('href', '#page-details')
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

})(window.jQuery);