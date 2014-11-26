// Ensure GSoft.Dynamite
window.GSoft = window.GSoft || {};
window.GSoft.Dynamite = window.GSoft.Dynamite || {};

// Filtered Product Showcase
// It's a Javascript oriented webpart that query a REST service to receive Items and showcase them
// You can implement and add numerous Filter.
(function (Search, $, undefined) {
    // Private properties
    var searchRestApi = "/_api/search/query";

    Search.Execute = function (queryText, selectProperties, onQuerySuccess, onQueryError) {

        // TODO (philavoie): Refactor to use URI.js
        var queryUrl = searchRestApi;
        queryUrl += "?querytext='";
        queryUrl += encodeURIComponent(queryText);
        queryUrl += "'&trimduplicates=false&rowlimit=500&selectproperties='";
        queryUrl += selectProperties;
        queryUrl += "'&QueryTemplatePropertiesUrl='spfile://webroot/queryparametertemplate.xml'";

        // Execute the AJAX call to the SharePoint Search REST API
        $.ajax({
            url: queryUrl,
            method: "GET",
            headers: { "Accept": "application/json; odata=verbose" },
            success: onQuerySuccess,
            error: onQueryError
        });
    };

}(GSoft.Dynamite.Search = GSoft.Dynamite.Search || {}, jq110));

// Filtered Product Showcase
// It's a Javascript oriented webpart that query a REST service to receive Items and showcase them
// You can implement and add numerous Filter.
(function (FilteredProductShowcase, $, undefined) {

    // Private properties
    var searchRestApi = "/_api/search/query";

    // Public properties
    FilteredProductShowcase.ViewModel = null;

    FilteredProductShowcase.Initialize = function (searchQuery, selectProperties, filterDefinitions, itemKnockoutTemplate, itemJavaScriptViewModel, callbacks) {
        var viewModel = this;
        $(document).ready(function (viewModel) {
            FilteredProductShowcase.ViewModel = new ShowcaseViewModel(searchQuery, selectProperties, filterDefinitions, itemKnockoutTemplate, itemJavaScriptViewModel, callbacks);
            ko.applyBindings(FilteredProductShowcase.ViewModel, $(".showcase")[0]);
            FilteredProductShowcase.ViewModel.ExecuteSearchQuery();
        });
    };

    function ShowcaseViewModel(searchQuery, selectProperties, filterDefinitions, itemKnockoutTemplate, itemJavaScriptViewModel, callbacks) {
        var self = this;

        self.SearchQuery = searchQuery;
        self.SelectProperties = selectProperties;
        self.SelectPropertiesArray = self.SelectProperties.split(",");
        self.FilterDefinitions = JSON.parse(filterDefinitions);
        self.ItemKnockoutTemplate = itemKnockoutTemplate;
        self.ItemJavaScriptViewModel = itemJavaScriptViewModel;
        self.LazyLoadingTitle = ko.observable("Load more");
        self.LazyLoadingVisible = ko.observable(true);
        self.NoResultTitle = ko.observable("Loading...");
        self.FiltersTitle = ko.observable("Product Filters");
        self.FiltersResetLabel = ko.observable("Reset");
        self.Callbacks = {};

        if (callbacks) {
            self.Callbacks = JSON.parse(callbacks);
        }

        self.Items = ko.observableArray();

        self.FilteredItems = ko.computed(function () {
            var filteredItems = ko.utils.arrayFilter(self.Items(), function (item) {
                return _.reduce(self.Filters(), function (memo, filter) {
                    if (typeof (memo) === 'boolean') {
                        return memo && filter.Filter(item);
                    }
                    return memo.Filter(item) && filter.Filter(item);
                });
            });

            if (self.ReloadGrid) {
                self.ReloadGrid(filteredItems.length);
            }

            return filteredItems;
        });

        // Filters
        self.Filters = ko.observableArray();

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
            queryUrl += "'&trimduplicates=false&rowlimit=500&selectproperties='";
            queryUrl += self.SelectProperties;
            queryUrl += "'&QueryTemplatePropertiesUrl='spfile://webroot/queryparametertemplate.xml'";

            // Execute the AJAX call to the SharePoint Search REST API
            $.ajax({
                url: queryUrl,
                method: "GET",
                headers: { "Accept": "application/json; odata=verbose" },
                success: self.OnQuerySuccess,
                error: self.OnQueryError
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

            // SuccessCallback
            self.ReloadGrid(self.FilteredItems().length);

            if (self.Callbacks) {
                if (self.Callbacks.lazyLoadingTitle) { eval(self.Callbacks.lazyLoadingTitle)(self.LazyLoadingTitle); }
                if (self.Callbacks.lazyLoadingVisible) { eval(self.Callbacks.lazyLoadingVisible)(self.LazyLoadingVisible, self.FilteredItems().length); }
                if (self.Callbacks.noResultTitle) { eval(self.Callbacks.noResultTitle)(self.NoResultTitle); }
                if (self.Callbacks.filtersTitle) { eval(self.Callbacks.filtersTitle)(self.FiltersTitle); }
                if (self.Callbacks.filtersResetLabel) { eval(self.Callbacks.filtersResetLabel)(self.FiltersResetLabel); }
            }
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

        self.LazyLoadingClick = function () {
            // LazeLoading Callback
            if (self.Callbacks && self.Callbacks.lazyLoadingClickCallback) {
                eval(self.Callbacks.lazyLoadingClickCallback)(self.FilteredItems().length);
            }
        };

        self.ReloadGrid = function (nbItems) {
            if (self.Callbacks && self.Callbacks.onItemsLoadedCallback) {
                eval(self.Callbacks.onItemsLoadedCallback)(nbItems);
            }
        };
    }

}(GSoft.Dynamite.FilteredProductShowcase = GSoft.Dynamite.FilteredProductShowcase || {}, jq110));
