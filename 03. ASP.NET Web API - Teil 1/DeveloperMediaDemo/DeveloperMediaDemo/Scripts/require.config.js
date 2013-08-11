requirejs.config({
    // enforceDefine gives us 404 load detection in IE
    enforceDefine: true,
    baseUrl: "/Scripts",
    paths: {
        'jquery': 'jquery-2.0.3',
        'knockout': 'knockout-2.3.0.debug',
        'knockout.mapping': 'knockout.mapping-latest',
        'knockout.validation' : 'knockout.validation.debug',
        'fonts/buxtonSketch': 'fonts/Buxton_Sketch_400.font',
        'sammy': 'sammy-0.7.4'
    },
    shim: {
        'knockout': { deps: ['jquery', 'polyfills/json2'] },
        'knockout.validation': { deps: ['knockout.legacy'], exports: 'ko.applyBindingsWithValidation', },
        'polyfills/cufon': { exports: 'Cufon' },
        'polyfills/datejs': { exports: 'Date.CultureInfo' },
        'polyfills/json2': { exports: 'JSON.stringify' },
        'polyfills/iso8601': { exports: 'Date.parseISO' },
        'fonts/buxtonSketch': { deps: ['polyfills/cufon'], exports: 'Cufon' },
        'sammy': { deps: ['jquery'] }
    }
});