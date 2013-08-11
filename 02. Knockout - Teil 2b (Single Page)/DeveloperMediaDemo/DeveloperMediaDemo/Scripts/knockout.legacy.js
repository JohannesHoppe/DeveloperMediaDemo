/* adds ko to the global scope to ensure with legacy knockout code */

define(['knockout'], function (ko) {
    window.ko = ko;
});