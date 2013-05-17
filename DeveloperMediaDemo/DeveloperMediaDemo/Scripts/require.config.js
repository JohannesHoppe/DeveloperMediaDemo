requirejs.config({
    // enforceDefine gives us 404 load detection in IE
    // --> this requires an 'exports' for ALL shims so that they can be checked for successfull loading
    //     (if they do not call define on their own)
    enforceDefine: true,
    baseUrl: "Scripts",
    paths: {
        'jquery': 'jquery-1.9.1',
        'knockout': 'knockout-2.2.1',
        'knockout.mapping': 'knockout.mapping-latest',
        'cufon': 'cufon-yui',
        'buxtonSketch': 'fonts/Buxton_Sketch_400.font',
        'datejs': 'date'
    },
    shim: {
        'knockout': { deps: ['jquery', 'json2'] },
        'cufon': { exports: 'Cufon' },
        'buxtonSketch': { deps: ['cufon'], exports: 'Cufon' },
        'datejs': { exports: 'Date.CultureInfo' },
        'json2': { exports: 'JSON.stringify' }
    }
});