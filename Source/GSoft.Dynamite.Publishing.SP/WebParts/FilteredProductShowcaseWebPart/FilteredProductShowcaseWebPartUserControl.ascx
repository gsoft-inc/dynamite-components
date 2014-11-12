<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilteredProductShowcaseWebPartUserControl.ascx.cs" Inherits="GSoft.Dynamite.Publishing.SP.WebParts.FilteredProductShowcaseWebPart.FilteredProductShowcaseWebPartUserControl" %>

<script type="text/javascript">

    window.Dynamite = window.Dynamite || {};

    // Ensure Utilities method
    (function (Utilities, $, undefined) {
        Utilities.ExtractTaxonomyInfo = function (taxonomyValue) {
            if (taxonomyValue) {
                var match = taxonomyValue.match(/L0\|#0([a-f0-9]{8}(?:-[a-f0-9]{4}){3}-[a-f0-9]{12})\|([\d \w \s áàâäãåçéèêëíìîïñóòôöõúùûüýÿæœÁÀÂÄÃÅÇÉÈÊËÍÌÎÏÑÓÒÔÖÕÚÙÛÜÝŸÆŒ']*);/i);
                return {
                    id: match[1],
                    label: match[2]
                };
            }

            return { id: undefined, label: undefined };
        };
    }(Dynamite.Utilities = Dynamite.Utilities || {}, jq110));

    (function (FilteredProductShowcase, $, undefined) {

        // Private properties
        var searchRestApi = "/_api/search/query";

        // Public properties
        FilteredProductShowcase.ViewModel = null;

        FilteredProductShowcase.Initialize = function () {
            var vm = this;
            $(document).ready(function (vm) {
                FilteredProductShowcase.ViewModel = new ShowcaseViewModel("<%=this.SearchQuery%>", "<%=this.SelectProperties%>", '<%=this.FilterDefinitions%>', "<%=this.ItemKnockoutTemplate%>", "<%=this.ItemJavaScriptViewModel%>");
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

            self.ShowItem = function (item) { if (item.nodeType === 1) $(item).hide().slideDown() }
            self.HideItem = function (item) { if (item.nodeType === 1) $(item).slideUp(function () { $(item).remove(); }) }


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
                queryUrl += "'";

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
                    //self.FilteredItems.push(item);
                });
            }

            self.OnQueryError = function (msg) {
                console.log("[Search REST API] Error with the API Request.");
                console.log(msg);
            }

            self.ResetFilters = function () {
                _.each(self.Filters(), function (filter) {
                    filter.Reset();
                });
            }
        }

    }(Dynamite.FilteredProductShowcase = Dynamite.FilteredProductShowcase || {}, jq110));

        // Launch the search
        console.log("Init");
        Dynamite.FilteredProductShowcase.Initialize();
</script>

<div class="showcase">
    <div class="section filters-header"></div>
    <div class="section filters-container">
        <div class="full-width">
            <h2 data-bind="text: FiltersTitle"></h2>
            <div class="filters clearfix" data-bind="foreach: Filters">
                <div class="filter" data-bind="template: { name: function () { return $data.TemplateName; }, data: $data }">
                </div>
            </div>
            <div class="filter-reset-container full-width clearfix">
                <div class="filter-reset" data-bind="click: ResetFilters">
                    <span class="filter-reset-button"></span>
                    <span class="filter-reset-label" data-bind="text: FiltersResetLabel"></span>
                </div>
            </div>
        </div>
    </div>
    <div class="section filters-footer"></div>
    <div class="section items-header"></div>
    <div class="section items-container">
        <div class="full-width clearfix">
            <ul data-bind="foreach: FilteredItems, beforeRemove: HideItem, afterAdd: ShowItem">
                <li data-bind="template: { name: function () { return $root.ItemKnockoutTemplate; }, data: $data }"></li>
            </ul>
        </div>
    </div>
    <div class="section items-footer"></div>
</div>
