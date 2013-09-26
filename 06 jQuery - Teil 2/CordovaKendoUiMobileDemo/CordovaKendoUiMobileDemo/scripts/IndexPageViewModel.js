var IndexPageViewModel = function () {

    var viewModel = kendo.observable({
        notes: [],

        loadData: function() {

            $.ajax({
                url: 'http://johanneshoppe.github.io/DeveloperMediaSlides/examples/webinarp.json',
                dataType: 'jsonp',
                jsonpCallback: 'callback'
            }).done(function(result) {
                viewModel.set("notes", result);

                var lastNote = viewModel.notes[viewModel.notes.length - 1];
                app.detailsPageViewModel.setData(lastNote);
            });
        },

        showDetails: function(e) {

            app.detailsPageViewModel.setData(e.dataItem);
            app.application.navigate('#detailsPage', 'slide:left');
        }
    });

    return viewModel;
}