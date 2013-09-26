var DetailsPageViewModel = function () {

    var viewModel = kendo.observable({
        
        Title: '',
        Added: '',
        Message: '',

        setData: function(data) {

            viewModel.set('Title', data.Title);
            viewModel.set('Added', moment(data.Added).format('DD.MM.YYYY'));
            viewModel.set('Message', data.Message);

        }
    });

    return viewModel;
}