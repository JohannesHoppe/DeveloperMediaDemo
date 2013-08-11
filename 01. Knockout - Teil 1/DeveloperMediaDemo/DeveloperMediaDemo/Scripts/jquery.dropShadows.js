define(['jquery'], function($) {

    $.dropShadows = function () {

        // adds a simle CSS drop shadow effect
        $(".drop_shadow").wrapInner('<div class="drop_shadow5" />');
        $(".drop_shadow").wrapInner('<div class="drop_shadow4" />');
        $(".drop_shadow").wrapInner('<div class="drop_shadow3" />');
        $(".drop_shadow").wrapInner('<div class="drop_shadow2" />');
    };
});