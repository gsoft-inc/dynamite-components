// Ensure GSoft.Dynamite
window.GSoft = window.GSoft || {};
window.GSoft.Dynamite = window.GSoft.Dynamite || {};

// Filtered Product Showcase
// It's a Javascript oriented webpart that query a REST service to receive Items and showcase them
// You can implement and add numerous Filter.
(function (FilteredProductShowcase, $, undefined) {

    // Private properties
    var searchRestApi = "/_api/search/query";

    // Public properties
    FilteredProductShowcase.ViewModel = null;

    FilteredProductShowcase.Initialize = function (searchQuery, selectProperties, filterDefinitions, itemKnockoutTemplate, itemJavaScriptViewModel) {
        var viewModel = this;
        $(document).ready(function (viewModel) {
            FilteredProductShowcase.ViewModel = new ShowcaseViewModel(searchQuery, selectProperties, filterDefinitions, itemKnockoutTemplate, itemJavaScriptViewModel);
            ko.applyBindings(FilteredProductShowcase.ViewModel, $(".showcase")[0]);
            FilteredProductShowcase.ViewModel.ExecuteSearchQuery();
        });
    };

    function ShowcaseViewModel(searchQuery, selectProperties, filterDefinitions, itemKnockoutTemplate, itemJavaScriptViewModel) {
        var self = this;

        self.SearchQuery = searchQuery;
        self.SelectProperties = selectProperties;
        self.SelectPropertiesArray = self.SelectProperties.split(",");
        self.FilterDefinitions = JSON.parse(filterDefinitions);
        self.ItemKnockoutTemplate = itemKnockoutTemplate;
        self.ItemJavaScriptViewModel = itemJavaScriptViewModel;

        self.Items = ko.observableArray();

        self.FilteredItems = ko.computed(function () {
            return ko.utils.arrayFilter(self.Items(), function (item) {
                return _.reduce(self.Filters(), function (memo, filter) {
                    if (typeof (memo) === 'boolean') {
                        return memo && filter.Filter(item);
                    }
                    return memo.Filter(item) && filter.Filter(item);
                });
            });
        });

        self.ShowItem = function (item) {
            console.log("show item");
            $(item).hide().fadeIn()
        }
        self.HideItem = function (item) {
            $(item).fadeOut(function () { $(item).remove(); })
        }


        // Filters
        self.Filters = ko.observableArray();
        self.FiltersTitle = ko.observable("Product Filters");
        self.FiltersResetLabel = ko.observable("Reset");

        // Create each instance of the filter via their filter definition
        _.each(self.FilterDefinitions, function (filterDefinition) {
            if (filterDefinition.JavaScriptViewModelFilterType && filterDefinition.Property) {
                // Try to eval the ViewModel type and create an instance.
                try {
                    filterViewModel = eval(filterDefinition.JavaScriptViewModelFilterType);
                } catch (e) {
                    console.log("[Product Showcase Filter] The type '" + filterDefinition.JavaScriptViewModelFilterType + "' couldn't be resolved. Error Msg: " + e.message);
                }

                if (typeof (filterViewModel) !== "function") {
                    console.log("[Product Showcase Filter] The type '" + filterDefinition.JavaScriptViewModelFilterType + "' couldn't be resolved. Not a function.");
                    return;
                }

                var filter = new filterViewModel(filterDefinition.Property, self.Items);
                self.Filters.push(filter);
            }
        });

        self.ExecuteSearchQuery = function () {
            // TODO (philavoie): Refactor to use URI.js
            var queryUrl = searchRestApi;
            queryUrl += "?querytext='";
            queryUrl += encodeURIComponent(self.SearchQuery);
            queryUrl += "'&trimduplicates=false&selectproperties='";
            queryUrl += self.SelectProperties;
            queryUrl += "'&QueryTemplatePropertiesUrl='spfile://webroot/queryparametertemplate.xml'";

            // Execute the AJAX call to the SharePoint Search REST API
            $.ajax({
                url: queryUrl,
                method: "GET",
                headers: { "Accept": "application/json; odata=verbose" },
                success: self.OnQuerySuccess,
                error: self.OnQuerySuccess
            });

        };

        self.OnQuerySuccess = function (data) {
            var results = data.d.query.PrimaryQueryResult.RelevantResults.Table.Rows.results;

            // For each result found
            _.each(results, function (result) {

                // Build the result item
                var itemViewModel = null;

                try {
                    itemViewModel = eval(self.ItemJavaScriptViewModel);
                } catch (e) {
                    console.log("[Product Showcase] The type '" + self.ItemJavaScriptViewModel + "' couldn't be resolved. Error Msg: " + e.message);
                }

                if (typeof (itemViewModel) !== "function") {
                    console.log("[Product Showcase] The type '" + self.ItemJavaScriptViewModel + "' couldn't be resolved. Not a function.");
                    return;
                }

                var item = new itemViewModel();

                // Find all the properties
                _.each(self.SelectPropertiesArray, function (propertyName) {

                    // Get the property value
                    var propertyValue = _.where(result.Cells.results, { Key: propertyName });
                    if (propertyValue != null && propertyValue.length > 0 && propertyValue[0].Value != undefined && typeof (item[propertyName]) === "function") {
                        item[propertyName](propertyValue[0].Value);
                    }
                    else {
                        console.log("[Search REST API] No value found for property with name '" + propertyName + "'.");
                    }
                });

                // Push to Item list
                self.Items.push(item);
            });
        }

        self.OnQueryError = function (msg) {
            console.log("[Search REST API] Error with the API Request.");
            console.log(msg);
        }

        // Reset Each Filters
        self.ResetFilters = function () {
            _.each(self.Filters(), function (filter) {
                filter.Reset();
            });
        }
    }

}(GSoft.Dynamite.FilteredProductShowcase = GSoft.Dynamite.FilteredProductShowcase || {}, jq110));