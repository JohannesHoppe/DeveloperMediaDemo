(function (global) {
    
    $("#page-details").on('pagebeforeshow', function () {
                   
        var currentItem = JSON.parse(window.sessionStorage.getItem('currentItem'));
        
        if (currentItem) {

            $('#detailTitle').text(currentItem.Title);
            $('#detailAdded').text(moment(currentItem.Added).format('DD.MM.YYYY'));
            $('#detailMessage').text(currentItem.Message);
        }
    });

})(window);