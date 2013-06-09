requirejs.config({
    // enforceDefine gives us 404 load detection in IE
    // --> this requires an 'exports' for ALL shims so that they can be checked for successfull loading
    //     (if they do not call define on their own)
    enforceDefine: true,
    baseUrl: "/Scripts",
    paths: {
        'jquery': 'jquery-1.9.1',
        'knockout': 'knockout-2.2.1',
        'knockout.mapping': 'knockout.mapping-latest',
        'fonts/buxtonSketch': 'fonts/Buxton_Sketch_400.font'
    },
    shim: {
        'knockout': { deps: ['jquery', 'polyfills/json2'] },
        'polyfills/cufon': { exports: 'Cufon' },
        'polyfills/datejs': { exports: 'Date.CultureInfo' },
        'polyfills/json2': { exports: 'JSON.stringify' },
        'polyfills/iso8601': { exports: 'Date.parseISO' },
        'fonts/buxtonSketch': { deps: ['polyfills/cufon'], exports: 'Cufon' },
    }
});