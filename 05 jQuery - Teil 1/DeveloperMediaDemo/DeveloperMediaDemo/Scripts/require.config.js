requirejs.config({
    // enforceDefine gives us 404 load detection in IE
    enforceDefine: true,
    baseUrl: "/Scripts",
    paths: {
        'jquery': 'jquery-2.0.3',
        'fonts/buxtonSketch': 'fonts/Buxton_Sketch_400.font'
    },
    shim: {
        'polyfills/cufon': { exports: 'Cufon' },
        'polyfills/datejs': { exports: 'Date.CultureInfo' },
        'polyfills/json2': { exports: 'JSON.stringify' },
        'polyfills/iso8601': { exports: 'Date.parseISO' },
        'fonts/buxtonSketch': { deps: ['polyfills/cufon'], exports: 'Cufon' }
    }
});