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

    (function (FilteredProductShowcase, $, undefined) {

        // Private properties
        var searchRestApi = "/_api/search/query";

        // Public properties
        FilteredProductShowcase.ViewModel = null;

        FilteredProductShowcase.Initialize = function () {
            var vm = this;
            $(document).ready(function (vm) {
                FilteredProductShowcase.ViewModel = new ShowcaseViewModel("<%=this.SearchQuery%>", "<%=this.SelectProperties%>", '<%=this.FilterDefinitions%>', "<%=this.ItemKnockoutTemplate%>");
                ko.applyBindings(FilteredProductShowcase.ViewModel, $(".showcase")[0]);
                FilteredProductShowcase.ViewModel.ExecuteSearchQuery();
            });
        };

        function ShowcaseViewModel(searchQuery, selectProperties, filterDefinitions, itemKnockoutTemplate) {
            var self = this;

            self.SearchQuery = searchQuery;
            self.SelectProperties = selectProperties;
            self.SelectPropertiesArray = self.SelectProperties.split(",");
            self.FilterDefinitions = JSON.parse(filterDefinitions);
            self.ItemKnockoutTemplate = itemKnockoutTemplate;

            self.Items = ko.observableArray();
            self.FilteredItems = ko.observableArray();
            self.Filters = null;

            self.ExecuteSearchQuery = function () {
                // TODO (philavoie): Refactor to use URI.js
                var queryUrl = window.location.origin + searchRestApi;
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
                    var item = {};

                    // Find all the properties
                    _.each(self.SelectPropertiesArray, function (propertyName) {

                        // Get the property value
                        var propertyValue = _.where(result.Cells.results, { Key: propertyName });
                        if (propertyValue != null && propertyValue.length > 0 && propertyValue[0].Value != undefined) {
                            Object.defineProperty(item, propertyName, { value: propertyValue[0].Value });
                        }
                        else {
                            console.log("[Search REST API] No value found for property with name '" + propertyName + "'.");
                        }
                    });

                    // Push to Item list
                    self.Items.push(item);
                    self.FilteredItems.push(item);
                });
            }

            self.OnQueryError = function (msg) {
                console.log("[Search REST API] Error with the API Request.");
                console.log(msg);
            }

            self.ResetFilters = function () {

            }
        }

    }(Dynamite.FilteredProductShowcase = Dynamite.FilteredProductShowcase || {}, jq110));

    // Launch the search
    console.log("Init");
    Dynamite.FilteredProductShowcase.Initialize();
</script>

<div class="showcase">
    <div class="filters" data-bind="foreach: FilterDefinitions">
        <%--<div class="filter" data-bind="template: { name: $data.JavaScriptViewModelFilterType, data: $data }">
        </div>--%>
    </div>
    <ul data-bind="foreach: FilteredItems">
        <li data-bind="template: { name: function () { return $root.ItemKnockoutTemplate; }, data: $data }"></li>
    </ul>
</div>
