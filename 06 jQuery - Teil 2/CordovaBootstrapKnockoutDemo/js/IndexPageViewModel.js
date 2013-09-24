var IndexPageViewModel = (function (ko) {

    var IndexPageViewModel = function () {

        var self = this;

        self.notes = ko.observableArray();

        self.loadData = function () {

            $.ajax({
                url: 'http://johanneshoppe.github.io/DeveloperMediaSlides/examples/webinarp.json',
                dataType: 'jsonp',
                jsonpCallback: 'callback'
            }).done(function(xhr) {
                self.notes = ko.mapping.fromJS(xhr, {}, self.notes);
            });
        };

        self.goToDetails = function () {
            document.location.href = "/Home/Edit/" + this.Id();
        };
    };

    return IndexPageViewModel;
    
})(window.ko);