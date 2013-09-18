define(['jquery'], function($) {

    var addLoadingIndicator = function($el, options) {

        var settings = $.extend({
            'image': 'Content/Images/ajax-loader.gif',
            'width': '100',
            'height': '100',
            'position': 'inline'
        }, options);

        var $div = $('<div id="loadingIndicator">&nbsp; Loading...</div>');
        $div.css({
            'background': "url('" + settings.image + "') no-repeat center top",
            'display': 'none',
            'width': settings.width + 'px',
            'height': settings.height + 'px',
            'padding-top': '38px',
            'text-align': 'center',
            'color': 'gray'
        });

        if (settings.position == 'fixed' ||
            settings.position == 'absolute') {
            $div.css({
                'left': '50%',
                'top': '50%',
                'margin-top': (0 - settings.height / 2) + 'px',
                'margin-left': (0 - settings.width / 2) + 'px'
            });
        }

        var publicMethods = {
            show: function() { $div.css('display', 'block'); },
            hide: function() { $div.css('display', 'none'); }                     
        };

        $el.prepend($div);
        $el.data('loadingIndicator', publicMethods);
    };

    $.fn.loadingIndicator = function(options) {

        return this.each(function() {
            addLoadingIndicator($(this), options);
        });
    };

    $(function () {
        $(window.document.body).append('<img src="Content/Images/ajax-loader.gif" style="display:none;" alt="preloaded image" />');
    });
});