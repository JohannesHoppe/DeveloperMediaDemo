define(['jquery'], function($) {

    $.dropShadows = function () {

        $(".drop_shadow:not(.processed)").each(function () {
            $(this).wrapInner('<div class="drop_shadow5" />')
                .wrapInner('<div class="drop_shadow4" />')
                .wrapInner('<div class="drop_shadow3" />')
                .wrapInner('<div class="drop_shadow2" />')
                .addClass('processed');
        });
    };
});